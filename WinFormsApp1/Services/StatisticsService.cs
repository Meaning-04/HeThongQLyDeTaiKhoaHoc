using DbHelper;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System.Collections.Concurrent;

namespace WinFormsApp1.Services
{
    /// <summary>
    /// Service for handling statistics operations with caching and performance optimization
    /// Addresses the performance issues in frmThongKe by reducing database calls and implementing caching
    /// </summary>
    public class StatisticsService
    {
        private readonly IDbContextService _dbService;
        private readonly ConcurrentDictionary<string, CachedData> _cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);

        public StatisticsService(IDbContextService dbService)
        {
            _dbService = dbService;
            _cache = new ConcurrentDictionary<string, CachedData>();
        }

        /// <summary>
        /// Get statistics data by management level with caching
        /// </summary>
        public async Task<List<CapQuanLyStatistics>> GetCapQuanLyStatisticsAsync(
            DateTime fromDate, DateTime toDate,
            List<string> selectedCapQuanLy,
            List<string> selectedLinhVuc)
        {
            string cacheKey = $"CapQuanLy_{fromDate:yyyyMMdd}_{toDate:yyyyMMdd}_{string.Join(",", selectedCapQuanLy)}_{string.Join(",", selectedLinhVuc)}";

            if (TryGetFromCache<List<CapQuanLyStatistics>>(cacheKey, out var cachedResult))
            {
                return cachedResult;
            }

            var result = await _dbService.ExecuteAsync(async context =>
            {
                // Load all data once with includes
                var allDeTaiData = await context.DeTai
                    .Include(d => d.KinhPhi)
                    .Where(d => d.ThoiGianBatDau >= fromDate && d.ThoiGianBatDau <= toDate)
                    .ToListAsync();

                // Apply filters on client side
                var filteredData = allDeTaiData.AsEnumerable();

                // If no CapQuanLy is selected, return empty results
                if (selectedCapQuanLy.Count == 0)
                {
                    return new List<CapQuanLyStatistics>();
                }
                else
                {
                    var enumValues = selectedCapQuanLy.Select(s => Enum.Parse<CapQuanLy>(s)).ToList();
                    filteredData = filteredData.Where(d => enumValues.Contains(d.CapQuanLy));
                }

                // If no LinhVuc is selected, return empty results
                if (selectedLinhVuc.Count == 0)
                {
                    return new List<CapQuanLyStatistics>();
                }
                else
                {
                    filteredData = filteredData.Where(d => !string.IsNullOrEmpty(d.LinhVuc) && selectedLinhVuc.Contains(d.LinhVuc));
                }

                // Group and calculate statistics
                var statistics = filteredData
                    .GroupBy(d => d.CapQuanLy)
                    .Select(g => new CapQuanLyStatistics
                    {
                        CapQuanLy = GetCapQuanLyDisplayName(g.Key.ToString()),
                        SoLuongDeTai = g.Count(),
                        KinhPhi = g.SelectMany(d => d.KinhPhi).Sum(k => (k.NganSach ?? 0) + (k.Khac ?? 0)),
                        TrangThai = GetTrangThaiString(g.ToList())
                    })
                    .OrderBy(x => GetCapQuanLyOrder(x.CapQuanLy))
                    .ToList();

                return statistics;
            });

            AddToCache(cacheKey, result);
            return result;
        }

        /// <summary>
        /// Get administrative unit statistics with caching
        /// </summary>
        public async Task<List<DonViHanhChinhStatistics>> GetDonViHanhChinhStatisticsAsync(
            DateTime fromDate, DateTime toDate,
            List<string> selectedCapQuanLy,
            List<string> selectedLinhVuc)
        {
            string cacheKey = $"DonViHC_{fromDate:yyyyMMdd}_{toDate:yyyyMMdd}_{string.Join(",", selectedCapQuanLy)}_{string.Join(",", selectedLinhVuc)}";

            if (TryGetFromCache<List<DonViHanhChinhStatistics>>(cacheKey, out var cachedResult))
            {
                return cachedResult;
            }

            var result = await _dbService.ExecuteAsync(async context =>
            {
                var query = context.ChiTietSanPham_DangI
                    .Include(sp => sp.DeTai)
                        .ThenInclude(d => d.KinhPhi)
                    .Include(sp => sp.DonViHanhChinh)
                    .Where(sp => sp.DeTai.ThoiGianBatDau >= fromDate && sp.DeTai.ThoiGianBatDau <= toDate);

                // Apply filters - if no items selected, return empty results
                if (selectedCapQuanLy.Count == 0)
                {
                    return new List<DonViHanhChinhStatistics>();
                }
                else
                {
                    var enumValues = selectedCapQuanLy.Select(s => Enum.Parse<CapQuanLy>(s)).ToList();
                    query = query.Where(sp => enumValues.Contains(sp.DeTai.CapQuanLy));
                }

                if (selectedLinhVuc.Count == 0)
                {
                    return new List<DonViHanhChinhStatistics>();
                }
                else
                {
                    query = query.Where(sp => !string.IsNullOrEmpty(sp.DeTai.LinhVuc) && selectedLinhVuc.Contains(sp.DeTai.LinhVuc));
                }

                var sanPhamData = await query.ToListAsync();

                // Group by province/city
                var statistics = sanPhamData
                    .GroupBy(sp => sp.DonViHanhChinh.TinhThanh)
                    .Select(g => new DonViHanhChinhStatistics
                    {
                        DonVi = g.Key,
                        SoLuongSanPham = g.Count(),
                        SoLuongDeTai = g.Select(sp => sp.MaDeTai).Distinct().Count(),
                        KinhPhi = g.GroupBy(sp => sp.MaDeTai)
                                   .Sum(deTaiGroup => deTaiGroup.First().DeTai.KinhPhi.Sum(k => (k.NganSach ?? 0) + (k.Khac ?? 0)))
                    })
                    .OrderByDescending(x => x.SoLuongSanPham)
                    .Take(10)
                    .ToList();

                return statistics;
            });

            AddToCache(cacheKey, result);
            return result;
        }

        /// <summary>
        /// Get budget statistics by year with caching
        /// </summary>
        public async Task<List<KinhPhiStatistics>> GetKinhPhiStatisticsAsync(
            DateTime fromDate, DateTime toDate,
            List<string> selectedCapQuanLy,
            List<string> selectedLinhVuc)
        {
            string cacheKey = $"KinhPhi_{fromDate:yyyyMMdd}_{toDate:yyyyMMdd}_{string.Join(",", selectedCapQuanLy)}_{string.Join(",", selectedLinhVuc)}";

            if (TryGetFromCache<List<KinhPhiStatistics>>(cacheKey, out var cachedResult))
            {
                return cachedResult;
            }

            var result = await _dbService.ExecuteAsync(async context =>
            {
                var query = context.DeTai
                    .Include(d => d.KinhPhi)
                    .Where(d => d.ThoiGianBatDau >= fromDate && d.ThoiGianBatDau <= toDate);

                // Apply filters - if no items selected, return empty results
                if (selectedCapQuanLy.Count == 0)
                {
                    return new List<KinhPhiStatistics>();
                }
                else
                {
                    var enumValues = selectedCapQuanLy.Select(s => Enum.Parse<CapQuanLy>(s)).ToList();
                    query = query.Where(d => enumValues.Contains(d.CapQuanLy));
                }

                if (selectedLinhVuc.Count == 0)
                {
                    return new List<KinhPhiStatistics>();
                }
                else
                {
                    query = query.Where(d => !string.IsNullOrEmpty(d.LinhVuc) && selectedLinhVuc.Contains(d.LinhVuc));
                }

                var deTaiData = await query.ToListAsync();

                // Group by year
                var statistics = deTaiData
                    .Where(d => d.ThoiGianBatDau.HasValue)
                    .GroupBy(d => d.ThoiGianBatDau!.Value.Year)
                    .Select(g => new KinhPhiStatistics
                    {
                        Nam = g.Key,
                        SoDeTai = g.Count(),
                        TongKinhPhi = g.SelectMany(d => d.KinhPhi).Sum(k => (k.NganSach ?? 0) + (k.Khac ?? 0)),
                        KinhPhiTrungBinh = g.Any() ? g.SelectMany(d => d.KinhPhi).Sum(k => (k.NganSach ?? 0) + (k.Khac ?? 0)) / g.Count() : 0
                    })
                    .OrderBy(x => x.Nam)
                    .ToList();

                return statistics;
            });

            AddToCache(cacheKey, result);
            return result;
        }

        /// <summary>
        /// Get filter data with caching
        /// </summary>
        public async Task<FilterData> GetFilterDataAsync()
        {
            const string cacheKey = "FilterData";

            if (TryGetFromCache<FilterData>(cacheKey, out var cachedResult))
            {
                return cachedResult;
            }

            var result = await _dbService.ExecuteAsync(async context =>
            {
                var capQuanLyList = await context.DeTai
                    .Select(d => d.CapQuanLy)
                    .Distinct()
                    .ToListAsync();

                var linhVucList = await context.DeTai
                    .Where(d => !string.IsNullOrEmpty(d.LinhVuc))
                    .Select(d => d.LinhVuc!)
                    .Distinct()
                    .OrderBy(l => l)
                    .ToListAsync();

                return new FilterData
                {
                    CapQuanLyList = capQuanLyList,
                    LinhVucList = linhVucList
                };
            });

            AddToCache(cacheKey, result);
            return result;
        }

        /// <summary>
        /// Clear all cached data
        /// </summary>
        public void ClearCache()
        {
            _cache.Clear();
        }

        /// <summary>
        /// Clear expired cache entries
        /// </summary>
        public void ClearExpiredCache()
        {
            var expiredKeys = _cache
                .Where(kvp => kvp.Value.ExpirationTime < DateTime.Now)
                .Select(kvp => kvp.Key)
                .ToList();

            foreach (var key in expiredKeys)
            {
                _cache.TryRemove(key, out _);
            }
        }

        #region Private Helper Methods

        private bool TryGetFromCache<T>(string key, out T result)
        {
            result = default(T)!;

            if (_cache.TryGetValue(key, out var cachedData))
            {
                if (cachedData.ExpirationTime > DateTime.Now)
                {
                    result = (T)cachedData.Data;
                    return true;
                }
                else
                {
                    _cache.TryRemove(key, out _);
                }
            }

            return false;
        }

        private void AddToCache<T>(string key, T data)
        {
            var cachedData = new CachedData
            {
                Data = data!,
                ExpirationTime = DateTime.Now.Add(_cacheExpiration)
            };

            _cache.AddOrUpdate(key, cachedData, (k, v) => cachedData);
        }

        private string GetCapQuanLyDisplayName(string capQuanLy)
        {
            return capQuanLy switch
            {
                "NhaNuoc" => "Nhà nước",
                "Bo" => "Bộ",
                "Nganh" => "Ngành",
                "CoSo" => "Cơ sở",
                _ => capQuanLy
            };
        }

        private int GetCapQuanLyOrder(string capQuanLy)
        {
            return capQuanLy switch
            {
                "Nhà nước" => 1,
                "Bộ" => 2,
                "Ngành" => 3,
                "Cơ sở" => 4,
                _ => 5
            };
        }

        private string GetTrangThaiString(List<DeTai> deTaiList)
        {
            var hoanthanh = deTaiList.Count(d => d.ThoiGianKetThuc < DateTime.Now);
            var dangthuchien = deTaiList.Count - hoanthanh;
            return $"Hoàn thành: {hoanthanh}, Đang thực hiện: {dangthuchien}";
        }

        #endregion
    }

    #region Data Transfer Objects

    public class CapQuanLyStatistics
    {
        public required string CapQuanLy { get; set; }
        public int SoLuongDeTai { get; set; }
        public decimal KinhPhi { get; set; }
        public required string TrangThai { get; set; }
    }

    public class DonViHanhChinhStatistics
    {
        public required string DonVi { get; set; }
        public int SoLuongSanPham { get; set; }
        public int SoLuongDeTai { get; set; }
        public decimal KinhPhi { get; set; }
    }

    public class KinhPhiStatistics
    {
        public int Nam { get; set; }
        public int SoDeTai { get; set; }
        public decimal TongKinhPhi { get; set; }
        public decimal KinhPhiTrungBinh { get; set; }
    }

    public class FilterData
    {
        public required List<CapQuanLy> CapQuanLyList { get; set; }
        public required List<string> LinhVucList { get; set; }
    }

    public class CachedData
    {
        public required object Data { get; set; }
        public DateTime ExpirationTime { get; set; }
    }

    #endregion
}
