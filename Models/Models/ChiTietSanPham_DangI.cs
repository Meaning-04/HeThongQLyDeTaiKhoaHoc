namespace Models.Models
{
    public class ChiTietSanPham_DangI
    {
        public int MaSanPham { get; set; }
        public int MaDeTai { get; set; }
        public string? TenSanPham { get; set; }
        public string? MoTa { get; set; }
        public string? DonViTinh { get; set; }
        public int? SoLuong { get; set; }
        public decimal? GiaTri { get; set; }
        public DateTime? NgayHoanThanh { get; set; }
        public string? TrangThai { get; set; }
        public int? MaDonViHC { get; set; }

        // Navigation properties
        public virtual DeTai DeTai { get; set; } = null!;
        public virtual DonViHanhChinh? DonViHanhChinh { get; set; }
        public virtual ICollection<DacTinhKyThuat> DacTinhKyThuat { get; set; } = new List<DacTinhKyThuat>();
    }
}
