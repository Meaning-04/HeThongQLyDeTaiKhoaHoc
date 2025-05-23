using System.Data;
using System.Windows.Forms.DataVisualization.Charting;
using WinFormsApp1.Constants;
using WinFormsApp1.Services;

namespace WinFormsApp1
{
    public partial class frmThongKe : BaseForm
    {
        private readonly StatisticsService _statisticsService;
        private bool isInitializing = true;

        public frmThongKe()
        {
            InitializeComponent();
            _statisticsService = new StatisticsService(DbService);
            InitializeCharts();
            InitializeForm();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await LoadRealData();
        }

        private void InitializeCharts()
        {
            // Khởi tạo cơ bản cho các chart để tránh null reference
            // Chart sẽ được cấu hình chi tiết trong SetupChart method

            try
            {
                // Đảm bảo các chart đã được khởi tạo trong designer
                if (chartCapQuanLy != null)
                {
                    chartCapQuanLy.ChartAreas.Clear();
                    chartCapQuanLy.Series.Clear();
                    chartCapQuanLy.Legends.Clear();
                    chartCapQuanLy.Titles.Clear();

                    // Add basic chart area to prevent null reference
                    var chartArea = new ChartArea("DefaultArea");
                    chartCapQuanLy.ChartAreas.Add(chartArea);
                }

                if (chartDonViHanhChinh != null)
                {
                    chartDonViHanhChinh.ChartAreas.Clear();
                    chartDonViHanhChinh.Series.Clear();
                    chartDonViHanhChinh.Legends.Clear();
                    chartDonViHanhChinh.Titles.Clear();

                    // Add basic chart area to prevent null reference
                    var chartArea = new ChartArea("DefaultArea");
                    chartDonViHanhChinh.ChartAreas.Add(chartArea);
                }

                if (chartKinhPhi != null)
                {
                    chartKinhPhi.ChartAreas.Clear();
                    chartKinhPhi.Series.Clear();
                    chartKinhPhi.Legends.Clear();
                    chartKinhPhi.Titles.Clear();

                    // Add basic chart area to prevent null reference
                    var chartArea = new ChartArea("DefaultArea");
                    chartKinhPhi.ChartAreas.Add(chartArea);
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi khởi tạo biểu đồ", ex);
            }
        }

        private void InitializeForm()
        {
            // Thiết lập DateTimePicker - Mở rộng phạm vi để bao gồm tất cả dữ liệu
            dtpTuNgay.Value = new DateTime(2020, 1, 1);
            dtpDenNgay.Value = DateTime.Now.AddYears(1);



            // Load dữ liệu thật cho CheckedListBox từ database
            LoadFilterData();
        }

        private void RegisterEventHandlers()
        {
            // Đăng ký event handlers sau khi load xong dữ liệu
            dtpTuNgay.ValueChanged += FilterChanged;
            dtpDenNgay.ValueChanged += FilterChanged;
            clbCapQuanLy.ItemCheck += FilterChanged;
            clbLinhVuc.ItemCheck += FilterChanged;
        }

        private async void LoadFilterData()
        {
            try
            {
                var filterData = await _statisticsService.GetFilterDataAsync();

                clbCapQuanLy.Items.Clear();
                foreach (var cap in filterData.CapQuanLyList)
                {
                    clbCapQuanLy.Items.Add(GetCapQuanLyDisplayName(cap.ToString()), true);
                }

                clbLinhVuc.Items.Clear();
                foreach (var linhVuc in filterData.LinhVucList)
                {
                    if (!string.IsNullOrEmpty(linhVuc))
                    {
                        clbLinhVuc.Items.Add(linhVuc, true);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(AppConstants.Messages.ErrorLoadingData, ex);
            }
        }

        private async Task LoadRealData()
        {
            try
            {
                // Hiển thị loading message
                this.Text = "Đang tải dữ liệu thống kê...";

                // Clear hoàn toàn charts trước khi load mới
                ClearChart(chartCapQuanLy);
                ClearChart(chartDonViHanhChinh);
                ClearChart(chartKinhPhi);

                await LoadCapQuanLyData();
                await LoadDonViHanhChinhData();
                await LoadKinhPhiData();

                // Hoàn thành loading
                this.Text = "Thống kê";

                // Đăng ký event handlers sau lần load đầu tiên
                if (isInitializing)
                {
                    RegisterEventHandlers();
                    isInitializing = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu thống kê: {ex.Message}\n\nStack trace: {ex.StackTrace}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Text = "Thống kê - Lỗi";
            }
        }

        private async Task LoadCapQuanLyData()
        {
            var selectedCapQuanLy = GetSelectedCapQuanLy();
            var selectedLinhVuc = GetSelectedLinhVuc();

            var statistics = await _statisticsService.GetCapQuanLyStatisticsAsync(
                dtpTuNgay.Value, dtpDenNgay.Value, selectedCapQuanLy, selectedLinhVuc);

            // Load DataGridView
            dgvCapQuanLy.DataSource = statistics.Select(x => new
            {
                CapQuanLy = x.CapQuanLy,
                SoLuongDeTai = x.SoLuongDeTai,
                KinhPhi = x.KinhPhi.ToString(AppConstants.Formats.CurrencyFormat) + " VNĐ",
                TrangThai = x.TrangThai
            }).ToList();

            dgvCapQuanLy.Columns[0].HeaderText = "Cấp quản lý";
            dgvCapQuanLy.Columns[1].HeaderText = "Số lượng đề tài";
            dgvCapQuanLy.Columns[2].HeaderText = "Kinh phí";
            dgvCapQuanLy.Columns[3].HeaderText = "Trạng thái";

            // Setup Chart
            SetupChart(chartCapQuanLy, "Thống kê đề tài theo Cấp quản lý");

            // Check if there's data to display
            if (statistics.Count == 0)
            {
                // Add a message series to indicate no data
                var noDataSeries = new Series("Không có dữ liệu")
                {
                    ChartType = SeriesChartType.Column,
                    Color = Color.LightGray
                };
                noDataSeries.Points.AddXY("Không có dữ liệu", 0);
                chartCapQuanLy.Series.Add(noDataSeries);
                return;
            }

            // Add Column Chart
            var series1 = new Series("Số lượng đề tài")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.SteelBlue
            };

            foreach (var item in statistics)
            {
                series1.Points.AddXY(item.CapQuanLy, item.SoLuongDeTai);
            }
            chartCapQuanLy.Series.Add(series1);

            // Add Line Chart for Kinh phí
            var series2 = new Series("Kinh phí (tỷ VNĐ)")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Red,
                BorderWidth = 3,
                YAxisType = AxisType.Secondary
            };

            foreach (var item in statistics)
            {
                series2.Points.AddXY(item.CapQuanLy, (double)(item.KinhPhi / 1000000000m));
            }
            chartCapQuanLy.Series.Add(series2);

            // Setup secondary Y axis
            chartCapQuanLy.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            chartCapQuanLy.ChartAreas[0].AxisY2.Title = "Kinh phí (tỷ VNĐ)";

            // Thêm legend để chú thích các series
            if (chartCapQuanLy.Legends.Count == 0)
            {
                var legend = new Legend("Legend1")
                {
                    Docking = Docking.Top,
                    Alignment = StringAlignment.Center,
                    Font = new Font("Segoe UI", 9F),
                    BackColor = Color.Transparent
                };
                chartCapQuanLy.Legends.Add(legend);
            }
        }

        private async Task LoadDonViHanhChinhData()
        {
            var selectedCapQuanLy = GetSelectedCapQuanLy();
            var selectedLinhVuc = GetSelectedLinhVuc();

            var statistics = await _statisticsService.GetDonViHanhChinhStatisticsAsync(
                dtpTuNgay.Value, dtpDenNgay.Value, selectedCapQuanLy, selectedLinhVuc);

            var data = statistics.Select(s => new
            {
                DonVi = s.DonVi,
                SoLuongSanPham = s.SoLuongSanPham,
                SoLuongDeTai = s.SoLuongDeTai,
                KinhPhi = s.KinhPhi
            }).ToList();

            // Tính tổng số sản phẩm để tính tỷ lệ
            int totalSanPham = data.Sum(d => d.SoLuongSanPham);

            // Load DataGridView
            dgvDonViHanhChinh.DataSource = data.Select(x => new
            {
                TinhThanh = x.DonVi,
                SoLuongSanPham = x.SoLuongSanPham,
                SoLuongDeTai = x.SoLuongDeTai,
                KinhPhi = x.KinhPhi.ToString(AppConstants.Formats.CurrencyFormat) + " VNĐ",
                TyLe = totalSanPham > 0 ?
                    ((double)x.SoLuongSanPham / totalSanPham).ToString(AppConstants.Formats.PercentageFormat) :
                    "0.00%"
            }).ToList();

            dgvDonViHanhChinh.Columns[0].HeaderText = "Tỉnh/Thành";
            dgvDonViHanhChinh.Columns[1].HeaderText = "Số sản phẩm";
            dgvDonViHanhChinh.Columns[2].HeaderText = "Số đề tài";
            dgvDonViHanhChinh.Columns[3].HeaderText = "Kinh phí";
            dgvDonViHanhChinh.Columns[4].HeaderText = "Tỷ lệ";

            // Setup Chart
            SetupChart(chartDonViHanhChinh, "Thống kê sản phẩm theo Tỉnh/Thành");

            // Check if there's data to display
            if (data.Count == 0)
            {
                // Add a message series to indicate no data
                var noDataSeries = new Series("Không có dữ liệu")
                {
                    ChartType = SeriesChartType.Pie,
                    Color = Color.LightGray
                };
                noDataSeries.Points.AddXY("Không có dữ liệu", 1);
                chartDonViHanhChinh.Series.Add(noDataSeries);
                return;
            }

            // Add Pie Chart
            var series = new Series("Phân bố sản phẩm")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true
            };

            var colors = new Color[] { Color.SteelBlue, Color.Orange, Color.Green, Color.Red, Color.Purple, Color.Brown, Color.Cyan, Color.Magenta, Color.Yellow, Color.Gray };
            int colorIndex = 0;
            int totalSanPhamForChart = data.Sum(d => d.SoLuongSanPham);

            foreach (var item in data)
            {
                var point = series.Points.Add(item.SoLuongSanPham);
                point.AxisLabel = item.DonVi;
                point.LegendText = item.DonVi;
                point.Color = colors[colorIndex % colors.Length];

                // Tính phần trăm và set label hiển thị đúng
                double percentage = (double)item.SoLuongSanPham / totalSanPhamForChart * 100;
                point.Label = $"{item.SoLuongSanPham} ({percentage:F1}%)";

                colorIndex++;
            }

            chartDonViHanhChinh.Series.Add(series);

            // Đảm bảo không có legend cũ trước khi thêm mới
            if (chartDonViHanhChinh.Legends.Count == 0)
            {
                chartDonViHanhChinh.Legends.Add(new Legend("Legend1"));
            }
        }

        private async Task LoadKinhPhiData()
        {
            var selectedCapQuanLy = GetSelectedCapQuanLy();
            var selectedLinhVuc = GetSelectedLinhVuc();

            var statistics = await _statisticsService.GetKinhPhiStatisticsAsync(
                dtpTuNgay.Value, dtpDenNgay.Value, selectedCapQuanLy, selectedLinhVuc);

            var data = statistics.Select(s => new
            {
                Nam = s.Nam,
                SoDeTai = s.SoDeTai,
                TongKinhPhi = s.TongKinhPhi,
                KinhPhiTrungBinh = s.KinhPhiTrungBinh
            }).ToList();

            // Load DataGridView
            dgvKinhPhi.DataSource = data.Select(x => new
            {
                Nam = x.Nam,
                SoDeTai = x.SoDeTai,
                TongKinhPhi = x.TongKinhPhi.ToString(AppConstants.Formats.CurrencyFormat) + " VNĐ",
                KinhPhiTrungBinh = x.KinhPhiTrungBinh.ToString(AppConstants.Formats.CurrencyFormat) + " VNĐ"
            }).ToList();

            dgvKinhPhi.Columns[0].HeaderText = "Năm";
            dgvKinhPhi.Columns[1].HeaderText = "Số đề tài";
            dgvKinhPhi.Columns[2].HeaderText = "Tổng kinh phí";
            dgvKinhPhi.Columns[3].HeaderText = "Kinh phí TB/đề tài";

            // Setup Chart
            SetupChart(chartKinhPhi, "Thống kê Kinh phí theo năm");

            // Check if there's data to display
            if (data.Count == 0)
            {
                // Add a message series to indicate no data
                var noDataSeries = new Series("Không có dữ liệu")
                {
                    ChartType = SeriesChartType.Area,
                    Color = Color.LightGray
                };
                noDataSeries.Points.AddXY("Không có dữ liệu", 0);
                chartKinhPhi.Series.Add(noDataSeries);
                return;
            }

            // Add Area Chart for Tổng kinh phí
            var series1 = new Series("Tổng kinh phí (tỷ VNĐ)")
            {
                ChartType = SeriesChartType.Area,
                Color = Color.FromArgb(100, Color.SteelBlue),
                BorderColor = Color.SteelBlue,
                BorderWidth = 2
            };

            foreach (var item in data)
            {
                series1.Points.AddXY(item.Nam, (double)(item.TongKinhPhi / 1000000000m));
            }
            chartKinhPhi.Series.Add(series1);

            // Add Line Chart for Số đề tài
            var series2 = new Series("Số đề tài")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Red,
                BorderWidth = 3,
                YAxisType = AxisType.Secondary,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8
            };

            foreach (var item in data)
            {
                series2.Points.AddXY(item.Nam, item.SoDeTai);
            }
            chartKinhPhi.Series.Add(series2);

            // Setup secondary Y axis
            chartKinhPhi.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            chartKinhPhi.ChartAreas[0].AxisY2.Title = "Số đề tài";

            // Thêm legend để chú thích các series
            if (chartKinhPhi.Legends.Count == 0)
            {
                var legend = new Legend("Legend1")
                {
                    Docking = Docking.Top,
                    Alignment = StringAlignment.Center,
                    Font = new Font("Segoe UI", 9F),
                    BackColor = Color.Transparent
                };
                chartKinhPhi.Legends.Add(legend);
            }
        }

        private void SetupChart(Chart chart, string title)
        {
            // Clear tất cả elements của chart để tránh overlap
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Legends.Clear();
            chart.Titles.Clear();

            var chartArea = new ChartArea("MainArea");
            chartArea.AxisX.Title = string.Empty;
            chartArea.AxisY.Title = string.Empty;
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;

            // Reset secondary Y axis
            chartArea.AxisY2.Enabled = AxisEnabled.False;

            chart.ChartAreas.Add(chartArea);

            var title1 = new Title(title)
            {
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.DarkBlue
            };
            chart.Titles.Add(title1);
        }

        private async void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Hiển thị SaveFileDialog để chọn nơi lưu file
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Lưu báo cáo thống kê";
                    saveFileDialog.FileName = $"BaoCaoThongKe_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Hiển thị loading
                        this.Cursor = Cursors.WaitCursor;
                        this.Text = "Đang xuất Excel...";

                        await Task.Run(() => ExportToExcel(saveFileDialog.FileName));

                        // Hoàn thành
                        this.Cursor = Cursors.Default;
                        this.Text = "Thống kê";

                        MessageBox.Show($"Xuất Excel thành công!\nFile đã được lưu tại: {saveFileDialog.FileName}",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Hỏi có muốn mở file không
                        if (MessageBox.Show("Bạn có muốn mở file Excel vừa tạo không?", "Xác nhận",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = saveFileDialog.FileName,
                                UseShellExecute = true
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                this.Text = "Thống kê";
                MessageBox.Show($"Lỗi khi xuất Excel: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToExcel(string filePath)
        {
            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                // Tạo worksheet cho từng tab thống kê
                ExportCapQuanLySheet(workbook);
                ExportDonViHanhChinhSheet(workbook);
                ExportKinhPhiSheet(workbook);

                workbook.SaveAs(filePath);
            }
        }

        private void ExportCapQuanLySheet(ClosedXML.Excel.XLWorkbook workbook)
        {
            var worksheet = workbook.Worksheets.Add("Thống kê cấp quản lý");

            // Tiêu đề
            worksheet.Cell(1, 1).Value = "BÁO CÁO THỐNG KÊ THEO CẤP QUẢN LÝ";
            worksheet.Range(1, 1, 1, 4).Merge().Style.Font.Bold = true;
            worksheet.Range(1, 1, 1, 4).Style.Font.FontSize = 16;
            worksheet.Range(1, 1, 1, 4).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;

            // Thông tin xuất
            worksheet.Cell(2, 1).Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
            worksheet.Cell(3, 1).Value = $"Thời gian thống kê: {dtpTuNgay.Value:dd/MM/yyyy} - {dtpDenNgay.Value:dd/MM/yyyy}";

            // Header
            int headerRow = 5;
            worksheet.Cell(headerRow, 1).Value = "Cấp quản lý";
            worksheet.Cell(headerRow, 2).Value = "Số lượng đề tài";
            worksheet.Cell(headerRow, 3).Value = "Kinh phí";
            worksheet.Cell(headerRow, 4).Value = "Trạng thái";

            // Style header
            var headerRange = worksheet.Range(headerRow, 1, headerRow, 4);
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.LightBlue;
            headerRange.Style.Border.OutsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thick;

            // Data
            int currentRow = headerRow + 1;
            foreach (DataGridViewRow row in dgvCapQuanLy.Rows)
            {
                worksheet.Cell(currentRow, 1).Value = row.Cells[0].Value?.ToString() ?? string.Empty;
                worksheet.Cell(currentRow, 2).Value = row.Cells[1].Value?.ToString() ?? string.Empty;
                worksheet.Cell(currentRow, 3).Value = row.Cells[2].Value?.ToString() ?? string.Empty;
                worksheet.Cell(currentRow, 4).Value = row.Cells[3].Value?.ToString() ?? string.Empty;
                currentRow++;
            }

            // Auto fit columns
            worksheet.Columns().AdjustToContents();
        }

        private void ExportDonViHanhChinhSheet(ClosedXML.Excel.XLWorkbook workbook)
        {
            var worksheet = workbook.Worksheets.Add("Thống kê đơn vị hành chính");

            // Tiêu đề
            worksheet.Cell(1, 1).Value = "BÁO CÁO THỐNG KÊ THEO ĐƠN VỊ HÀNH CHÍNH";
            worksheet.Range(1, 1, 1, 5).Merge().Style.Font.Bold = true;
            worksheet.Range(1, 1, 1, 5).Style.Font.FontSize = 16;
            worksheet.Range(1, 1, 1, 5).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;

            // Thông tin xuất
            worksheet.Cell(2, 1).Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
            worksheet.Cell(3, 1).Value = $"Thời gian thống kê: {dtpTuNgay.Value:dd/MM/yyyy} - {dtpDenNgay.Value:dd/MM/yyyy}";

            // Header và data từ dgvDonViHanhChinh
            int headerRow = 5;
            worksheet.Cell(headerRow, 1).Value = "Tỉnh/Thành";
            worksheet.Cell(headerRow, 2).Value = "Số sản phẩm";
            worksheet.Cell(headerRow, 3).Value = "Số đề tài";
            worksheet.Cell(headerRow, 4).Value = "Kinh phí";
            worksheet.Cell(headerRow, 5).Value = "Tỷ lệ";

            var headerRange = worksheet.Range(headerRow, 1, headerRow, 5);
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.LightBlue;
            headerRange.Style.Border.OutsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thick;

            int currentRow = headerRow + 1;
            foreach (DataGridViewRow row in dgvDonViHanhChinh.Rows)
            {
                worksheet.Cell(currentRow, 1).Value = row.Cells[0].Value?.ToString() ?? string.Empty; // TinhThanh
                worksheet.Cell(currentRow, 2).Value = row.Cells[1].Value?.ToString() ?? string.Empty; // SoLuongSanPham
                worksheet.Cell(currentRow, 3).Value = row.Cells[2].Value?.ToString() ?? string.Empty; // SoLuongDeTai
                worksheet.Cell(currentRow, 4).Value = row.Cells[3].Value?.ToString() ?? string.Empty; // KinhPhi
                worksheet.Cell(currentRow, 5).Value = row.Cells[4].Value?.ToString() ?? string.Empty; // TyLe (đây là cột đúng cho tỷ lệ %)
                currentRow++;
            }

            worksheet.Columns().AdjustToContents();
        }

        private void ExportKinhPhiSheet(ClosedXML.Excel.XLWorkbook workbook)
        {
            var worksheet = workbook.Worksheets.Add("Thống kê kinh phí");

            // Tiêu đề
            worksheet.Cell(1, 1).Value = "BÁO CÁO THỐNG KÊ KINH PHÍ THEO NĂM";
            worksheet.Range(1, 1, 1, 4).Merge().Style.Font.Bold = true;
            worksheet.Range(1, 1, 1, 4).Style.Font.FontSize = 16;
            worksheet.Range(1, 1, 1, 4).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;

            // Header và data từ dgvKinhPhi
            int headerRow = 5;
            worksheet.Cell(headerRow, 1).Value = "Năm";
            worksheet.Cell(headerRow, 2).Value = "Số đề tài";
            worksheet.Cell(headerRow, 3).Value = "Tổng kinh phí";
            worksheet.Cell(headerRow, 4).Value = "Kinh phí TB/đề tài";

            var headerRange = worksheet.Range(headerRow, 1, headerRow, 4);
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.LightBlue;

            int currentRow = headerRow + 1;
            foreach (DataGridViewRow row in dgvKinhPhi.Rows)
            {
                worksheet.Cell(currentRow, 1).Value = row.Cells[0].Value?.ToString() ?? string.Empty;
                worksheet.Cell(currentRow, 2).Value = row.Cells[1].Value?.ToString() ?? string.Empty;
                worksheet.Cell(currentRow, 3).Value = row.Cells[2].Value?.ToString() ?? string.Empty;
                worksheet.Cell(currentRow, 4).Value = row.Cells[3].Value?.ToString() ?? string.Empty;
                currentRow++;
            }

            worksheet.Columns().AdjustToContents();
        }

        private async void FilterChanged(object sender, EventArgs e)
        {
            if (isInitializing) return; // Tránh gọi khi đang khởi tạo

            // Reload dữ liệu khi filter thay đổi
            try
            {
                // Clear hoàn toàn tất cả charts để tránh overlap
                ClearChart(chartCapQuanLy);
                ClearChart(chartDonViHanhChinh);
                ClearChart(chartKinhPhi);

                await LoadCapQuanLyData();
                await LoadDonViHanhChinhData();
                await LoadKinhPhiData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearChart(Chart chart)
        {
            // Kiểm tra null để tránh lỗi
            if (chart == null) return;

            try
            {
                // Clear hoàn toàn tất cả elements của chart
                chart.Series.Clear();
                chart.ChartAreas.Clear();
                chart.Legends.Clear();
                chart.Titles.Clear();
                chart.Annotations.Clear();

                // Add a basic chart area to prevent null reference errors
                var chartArea = new ChartArea("DefaultArea");
                chart.ChartAreas.Add(chartArea);

                // Force refresh để đảm bảo chart được clear hoàn toàn
                chart.Invalidate();
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi khi xóa biểu đồ", ex);
            }
        }

        #region Helper Methods

        private List<string> GetSelectedCapQuanLy()
        {
            var selected = new List<string>();
            for (int i = 0; i < clbCapQuanLy.Items.Count; i++)
            {
                if (clbCapQuanLy.GetItemChecked(i))
                {
                    var displayName = clbCapQuanLy.Items[i].ToString();
                    // Chuyển đổi từ display name về enum value
                    var enumValue = displayName switch
                    {
                        "Nhà nước" => "NhaNuoc",
                        "Bộ" => "Bo",
                        "Ngành" => "Nganh",
                        "Cơ sở" => "CoSo",
                        _ => displayName
                    };
                    if (!string.IsNullOrEmpty(enumValue))
                        selected.Add(enumValue);
                }
            }
            return selected;
        }

        private List<string> GetSelectedLinhVuc()
        {
            var selected = new List<string>();
            for (int i = 0; i < clbLinhVuc.Items.Count; i++)
            {
                if (clbLinhVuc.GetItemChecked(i))
                {
                    selected.Add(clbLinhVuc.Items[i].ToString() ?? string.Empty);
                }
            }
            return selected;
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

        private string GetTrangThaiString(List<Models.Models.DeTai> deTaiList)
        {
            var hoanthanh = deTaiList.Count(d => d.ThoiGianKetThuc < DateTime.Now);
            var dangthuchien = deTaiList.Count - hoanthanh;
            return $"Hoàn thành: {hoanthanh}, Đang thực hiện: {dangthuchien}";
        }

        #endregion
    }
}