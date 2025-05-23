using Microsoft.EntityFrameworkCore;
using Models.Models;
using System.Data;
using WinFormsApp1.Constants;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace WinFormsApp1
{
    public partial class frmDeTai : BaseForm
    {
        private TaiKhoan currentUser;
        private List<DeTai> allDeTai = new List<DeTai>();

        public frmDeTai(TaiKhoan user)
        {
            currentUser = user;
            InitializeComponent();
            SetupDefaultValues();
            SetupDataGridView();
            SetupUserPermissions();
            LoadFilterData();
            LoadData();
        }

        private void SetupDefaultValues()
        {
            // Thiết lập giá trị mặc định cho DateTimePicker để hiển thị tất cả dữ liệu
            dtpTuNgay.Value = DateTime.Now.AddYears(-5);
            dtpDenNgay.Value = DateTime.Now.AddYears(5);
        }

        private void SetupUserPermissions()
        {
            // Kiểm tra quyền của người dùng
            bool isAdmin = currentUser.VaiTro == VaiTroTaiKhoan.Admin;

            // Chỉ Admin mới được thêm/sửa/xóa - ẨN hoàn toàn cho User
            btnThem.Visible = isAdmin;
            btnSua.Visible = isAdmin;
            btnXoa.Visible = isAdmin;

            // User và Admin đều được xem chi tiết và xuất file
            btnXemChiTiet.Visible = true;
            btnXuatWord.Visible = true;
            btnXuatExcel.Visible = true;
            btnLamMoi.Visible = true;
        }

        private void SetupDataGridView()
        {
            dgvDeTai.Columns.Clear();
            dgvDeTai.AutoGenerateColumns = false;
            dgvDeTai.AllowUserToAddRows = false;
            dgvDeTai.AllowUserToDeleteRows = false;
            dgvDeTai.ReadOnly = true;
            dgvDeTai.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDeTai.MultiSelect = false;

            // Cột STT - không có DataPropertyName, sẽ thêm thủ công
            dgvDeTai.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "STT",
                HeaderText = "STT",
                Width = 35,
                ReadOnly = true
            });

            dgvDeTai.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaDeTai",
                HeaderText = "Mã đề tài",
                DataPropertyName = "MaDeTai",
                Width = 100
            });

            dgvDeTai.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TenDeTai",
                HeaderText = "Tên đề tài",
                DataPropertyName = "TenDeTai",
                Width = 300
            });

            dgvDeTai.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LinhVuc",
                HeaderText = "Lĩnh vực",
                DataPropertyName = "LinhVuc",
                Width = 150
            });

            dgvDeTai.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CapQuanLy",
                HeaderText = "Cấp quản lý",
                DataPropertyName = "CapQuanLy",
                Width = 120
            });

            dgvDeTai.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ThoiGianBatDau",
                HeaderText = "Thời gian bắt đầu",
                DataPropertyName = "ThoiGianBatDau",
                Width = 120
            });

            dgvDeTai.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ChuNhiem",
                HeaderText = "Chủ nhiệm",
                DataPropertyName = "ChuNhiem",
                Width = 150,
                ReadOnly = true
            });
        }

        private async void LoadData()
        {
            try
            {
                allDeTai = await ExecuteDbOperationAsync(async context =>
                {
                    return await context.DeTai.ToListAsync();
                }, AppConstants.Messages.ErrorLoadingData);

                // Debug: Hiển thị số lượng bản ghi đã load
                lblTongSo.Text = $"Đã load: {allDeTai.Count} đề tài từ database";

                ApplyFilter();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(AppConstants.Messages.ErrorLoadingData, ex);
            }
        }



        private async void LoadFilterData()
        {
            try
            {
                var linhVucList = await ExecuteDbOperationAsync(async context =>
                {
                    return await context.DeTai.Select(dt => dt.LinhVuc).Distinct().ToListAsync();
                }, "Lỗi khi tải dữ liệu lĩnh vực");

                // Load dữ liệu cho ComboBox Lĩnh vực
                cmbLinhVuc.Items.Clear();
                cmbLinhVuc.Items.Add("-- Tất cả --");
                foreach (var lv in linhVucList.Where(x => !string.IsNullOrEmpty(x)))
                {
                    cmbLinhVuc.Items.Add(lv ?? string.Empty);
                }
                cmbLinhVuc.SelectedIndex = 0;

                // Load dữ liệu cho ComboBox Cấp quản lý
                cmbCapQuanLy.Items.Clear();
                cmbCapQuanLy.Items.Add("-- Tất cả --");
                cmbCapQuanLy.Items.Add("Nhà nước");
                cmbCapQuanLy.Items.Add("Bộ");
                cmbCapQuanLy.Items.Add("Ngành");
                cmbCapQuanLy.Items.Add("Cơ sở");
                cmbCapQuanLy.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi khi tải dữ liệu bộ lọc", ex);
            }
        }

        private async void ApplyFilter()
        {
            var filteredData = allDeTai.AsEnumerable();

            // Lọc theo tìm kiếm
            if (!string.IsNullOrEmpty(txtTimKiem.Text))
            {
                string searchText = txtTimKiem.Text.ToLower();
                filteredData = filteredData.Where(dt =>
                    (dt.TenDeTai?.ToLower().Contains(searchText) ?? false) ||
                    $"DT{dt.MaDeTai:D6}".ToLower().Contains(searchText));
            }

            // Lọc theo lĩnh vực
            if (cmbLinhVuc.SelectedIndex > 0 && cmbLinhVuc.SelectedItem != null)
            {
                string selectedLinhVuc = cmbLinhVuc.SelectedItem.ToString() ?? string.Empty;
                filteredData = filteredData.Where(dt => dt.LinhVuc == selectedLinhVuc);
            }

            // Lọc theo cấp quản lý
            if (cmbCapQuanLy.SelectedIndex > 0 && cmbCapQuanLy.SelectedItem != null)
            {
                string selectedCapQuanLy = cmbCapQuanLy.SelectedItem.ToString() ?? string.Empty;
                string capQuanLyEnum = selectedCapQuanLy switch
                {
                    "Nhà nước" => "NhaNuoc",
                    "Bộ" => "Bo",
                    "Ngành" => "Nganh",
                    "Cơ sở" => "CoSo",
                    _ => string.Empty
                };
                filteredData = filteredData.Where(dt => dt.CapQuanLy.ToString() == capQuanLyEnum);
            }

            // Lọc theo thời gian - chỉ lọc khi có giá trị thời gian bắt đầu
            filteredData = filteredData.Where(dt =>
                !dt.ThoiGianBatDau.HasValue ||
                (dt.ThoiGianBatDau.Value.Date >= dtpTuNgay.Value.Date &&
                 dt.ThoiGianBatDau.Value.Date <= dtpDenNgay.Value.Date));

            var filteredList = filteredData.ToList();

            // Clear existing rows
            dgvDeTai.Rows.Clear();

            try
            {
                // Lấy tất cả mã đề tài cần query
                var deTaiIds = filteredList.Select(dt => dt.MaDeTai).ToList();

                // Query một lần để lấy tất cả thông tin chủ nhiệm using DbService
                var chuNhiemDict = await ExecuteDbOperationAsync(async context =>
                {
                    return await context.VaiTroThamGia
                        .Where(vt => deTaiIds.Contains(vt.MaDeTai) && vt.VaiTro == VaiTroThamGiaEnum.ChuNhiem)
                        .Join(context.CanBo, vt => vt.MaCanBo, cb => cb.MaCanBo, (vt, cb) => new { vt.MaDeTai, cb.HoTen })
                        .ToDictionaryAsync(x => x.MaDeTai, x => x.HoTen);
                }, "Lỗi khi tải thông tin chủ nhiệm");

                // Debug: Kiểm tra số lượng chủ nhiệm tìm được
                System.Diagnostics.Debug.WriteLine($"Tìm được {chuNhiemDict.Count} chủ nhiệm cho {deTaiIds.Count} đề tài");

                // Thêm từng dòng vào DataGridView
                int stt = 1;
                foreach (var deTai in filteredList)
                {
                    var chuNhiem = chuNhiemDict.TryGetValue(deTai.MaDeTai, out string? tenChuNhiem) ? tenChuNhiem : "Chưa có";
                    var maDeTaiFormatted = $"DT{deTai.MaDeTai:D6}";

                    // Debug: Log thông tin đang thêm vào DataGridView
                    System.Diagnostics.Debug.WriteLine($"Adding row {stt}: MaDeTai={maDeTaiFormatted} (Original: {deTai.MaDeTai}), TenDeTai={deTai.TenDeTai}");

                    dgvDeTai.Rows.Add(
                        stt++,
                        maDeTaiFormatted,
                        deTai.TenDeTai,
                        deTai.LinhVuc,
                        GetCapQuanLyDisplayText(deTai.CapQuanLy),
                        deTai.ThoiGianBatDau?.ToString(AppConstants.Formats.DateFormat) ?? string.Empty,
                        chuNhiem
                    );
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi khi tải thông tin chủ nhiệm", ex);
                // Fallback: hiển thị không có thông tin chủ nhiệm
                int stt = 1;
                foreach (var deTai in filteredList)
                {
                    var maDeTaiFormatted = $"DT{deTai.MaDeTai:D6}";

                    // Debug: Log thông tin đang thêm vào DataGridView (fallback)
                    System.Diagnostics.Debug.WriteLine($"Adding row (fallback) {stt}: MaDeTai={maDeTaiFormatted} (Original: {deTai.MaDeTai}), TenDeTai={deTai.TenDeTai}");

                    dgvDeTai.Rows.Add(
                        stt++,
                        maDeTaiFormatted,
                        deTai.TenDeTai,
                        deTai.LinhVuc,
                        GetCapQuanLyDisplayText(deTai.CapQuanLy),
                        deTai.ThoiGianBatDau?.ToString(AppConstants.Formats.DateFormat) ?? string.Empty,
                        "Chưa có"
                    );
                }
            }

            lblTongSo.Text = $"Tổng số: {filteredList.Count} đề tài";
        }

        private string GetCapQuanLyDisplayText(CapQuanLy capQuanLy)
        {
            return capQuanLy switch
            {
                CapQuanLy.NhaNuoc => "Nhà nước",
                CapQuanLy.Bo => "Bộ",
                CapQuanLy.Nganh => "Ngành",
                CapQuanLy.CoSo => "Cơ sở",
                _ => string.Empty
            };
        }

        #region Event Handlers - Filter
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void cmbLinhVuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void cmbCapQuanLy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dgvDeTai.DataSource = null;
            dgvDeTai.ClearSelection();

            txtTimKiem.Text = string.Empty;
            cmbLinhVuc.SelectedIndex = 0;
            cmbCapQuanLy.SelectedIndex = 0;
            dtpTuNgay.Value = DateTime.Now.AddYears(-5);  // Mở rộng phạm vi để hiển thị tất cả
            dtpDenNgay.Value = DateTime.Now.AddYears(5);
            LoadData();
        }
        #endregion

        #region Event Handlers - CRUD
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            var frmThem = new frmThemDeTai();
            if (frmThem.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                ShowSuccessMessage(AppConstants.Messages.AddSuccess);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            if (dgvDeTai.SelectedRows.Count == 0)
            {
                ShowWarningMessage(AppConstants.Messages.WarningSelectItem);
                return;
            }

            // Lấy mã đề tài từ cột MaDeTai
            var maDeTaiStr = dgvDeTai.SelectedRows[0].Cells["MaDeTai"].Value?.ToString();
            if (!string.IsNullOrEmpty(maDeTaiStr))
            {
                // Chuyển đổi từ "DT000001" thành 1
                var maDeTaiNumber = maDeTaiStr.Replace("DT", string.Empty);
                if (int.TryParse(maDeTaiNumber, out int maDeTai))
                {
                    var frmSua = new frmThemDeTai(maDeTai);
                    if (frmSua.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                        //ShowSuccessMessage(AppConstants.Messages.UpdateSuccess);
                    }
                }
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            if (dgvDeTai.SelectedRows.Count == 0)
            {
                ShowWarningMessage(AppConstants.Messages.WarningSelectItem);
                return;
            }

            // Lấy mã đề tài và tên đề tài từ DataGridView
            var maDeTaiStr = dgvDeTai.SelectedRows[0].Cells["MaDeTai"].Value?.ToString();
            var tenDeTai = dgvDeTai.SelectedRows[0].Cells["TenDeTai"].Value?.ToString();

            if (!string.IsNullOrEmpty(maDeTaiStr))
            {
                // Chuyển đổi từ "DT000001" thành 1
                var maDeTaiNumber = maDeTaiStr.Replace("DT", string.Empty);
                if (int.TryParse(maDeTaiNumber, out int maDeTai))
                {
                    if (!AskConfirmation($"Bạn có chắc chắn muốn xóa đề tài '{tenDeTai}'?\nHành động này không thể hoàn tác!", "Xác nhận xóa"))
                        return;

                    try
                    {
                        await ExecuteDbOperationAsync(async context =>
                        {
                            var deTai = await context.DeTai.FindAsync(maDeTai);
                            if (deTai != null)
                            {
                                context.DeTai.Remove(deTai);
                                await context.SaveChangesAsync();
                            }
                        }, AppConstants.Messages.ErrorDeletingData);

                        LoadData();
                        //ShowSuccessMessage(AppConstants.Messages.DeleteSuccess);
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage(AppConstants.Messages.ErrorDeletingData, ex);
                    }
                }
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvDeTai.SelectedRows.Count == 0)
            {
                ShowWarningMessage(AppConstants.Messages.WarningSelectItem);
                return;
            }

            // Lấy mã đề tài từ cột MaDeTai
            var maDeTaiStr = dgvDeTai.SelectedRows[0].Cells["MaDeTai"].Value?.ToString();
            var tenDeTai = dgvDeTai.SelectedRows[0].Cells["TenDeTai"].Value?.ToString();

            // Debug: Hiển thị thông tin đang được chọn
            System.Diagnostics.Debug.WriteLine($"Selected row: MaDeTai = {maDeTaiStr}, TenDeTai = {tenDeTai}");

            if (!string.IsNullOrEmpty(maDeTaiStr))
            {
                // Chuyển đổi từ "DT000001" thành 1
                var maDeTaiNumber = maDeTaiStr.Replace("DT", string.Empty);
                if (int.TryParse(maDeTaiNumber, out int maDeTai))
                {
                    System.Diagnostics.Debug.WriteLine($"Opening detail for MaDeTai: {maDeTai}");
                    LoadDeTaiChiTietForm(maDeTai);
                }
                else
                {
                    ShowErrorMessage("Không thể chuyển đổi mã đề tài!", new Exception($"Invalid MaDeTai format: {maDeTaiStr}"));
                }
            }
            else
            {
                ShowErrorMessage("Không tìm thấy mã đề tài!", new Exception("MaDeTai is null or empty"));
            }
        }

        private void LoadDeTaiChiTietForm(int maDeTai)
        {
            // Tìm panel cha (panelMain trong MainForm)
            var parentPanel = FindParentPanel();
            if (parentPanel != null)
            {
                // Xóa nội dung hiện tại trong panel
                parentPanel.Controls.Clear();

                // Tạo form chi tiết với callback để quay lại
                var frmChiTiet = new frmDeTaiChiTiet(currentUser, maDeTai, () => LoadBackToDeTaiForm(parentPanel))
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };

                // Thêm form vào panel
                parentPanel.Controls.Add(frmChiTiet);
                frmChiTiet.Show();
            }
            else
            {
                // Fallback: mở dialog như cũ
                var frmChiTiet = new frmDeTaiChiTiet(currentUser, maDeTai);
                frmChiTiet.ShowDialog();
            }
        }

        private Panel? FindParentPanel()
        {
            // Tìm panel cha (panelMain) từ MainForm
            System.Windows.Forms.Control? parent = this.Parent;
            while (parent != null)
            {
                if (parent is Panel panel && panel.Name == "panelMain")
                {
                    return panel;
                }
                parent = parent.Parent;
            }
            return null;
        }

        private void LoadBackToDeTaiForm(Panel parentPanel)
        {
            // Xóa nội dung hiện tại trong panel
            parentPanel.Controls.Clear();

            // Tạo lại form DeTai
            var deTaiForm = new frmDeTai(currentUser)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            // Thêm form vào panel
            parentPanel.Controls.Add(deTaiForm);
            deTaiForm.Show();
        }

        private void dgvDeTai_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Đảm bảo row được chọn trước khi gọi xem chi tiết
                dgvDeTai.ClearSelection();
                dgvDeTai.Rows[e.RowIndex].Selected = true;
                btnXemChiTiet_Click(sender, e);
            }
        }

        private void dgvDeTai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Đảm bảo row được chọn khi click vào cell
                dgvDeTai.ClearSelection();
                dgvDeTai.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnXuatWord_Click(object sender, EventArgs e)
        {
            HandleExport(true); // true = Word export
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            HandleExport(false); // false = Excel export
        }

        private void HandleExport(bool isWordExport)
        {
            try
            {
                if (dgvDeTai.Rows.Count == 0)
                {
                    ShowWarningMessage(AppConstants.Messages.InfoNoDataFound);
                    return;
                }

                // Hiển thị dialog chọn option
                using (var optionForm = new frmChonOptionXuat(isWordExport))
                {
                    if (optionForm.ShowDialog() == DialogResult.OK)
                    {
                        if (optionForm.SelectedOption == frmChonOptionXuat.ExportOption.SelectedRecord)
                        {
                            // Xuất bản ghi đang chọn
                            if (dgvDeTai.SelectedRows.Count == 0)
                            {
                                ShowWarningMessage(AppConstants.Messages.WarningSelectItem);
                                return;
                            }
                            ExportSelectedRecord(isWordExport);
                        }
                        else
                        {
                            // Xuất danh sách tất cả
                            ExportAllRecords(isWordExport);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Lỗi khi xuất {(isWordExport ? "Word" : "Excel")}", ex);
            }
        }

        private void ExportSelectedRecord(bool isWordExport)
        {
            var maDeTaiStr = dgvDeTai.SelectedRows[0].Cells["MaDeTai"].Value?.ToString();
            if (string.IsNullOrEmpty(maDeTaiStr)) return;

            var maDeTaiNumber = maDeTaiStr.Replace("DT", string.Empty);
            if (!int.TryParse(maDeTaiNumber, out int maDeTai)) return;

            string fileExtension = isWordExport ? ".docx" : ".xlsx";
            string filter = isWordExport ? "Word files (*.docx)|*.docx" : AppConstants.Files.ExcelFilter;
            string title = isWordExport ? "Lưu file Word" : "Lưu file Excel";

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = filter,
                Title = title,
                FileName = $"ChiTietDeTai_{maDeTaiStr}_{DateTime.Now:yyyyMMdd_HHmmss}{fileExtension}"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (isWordExport)
                {
                    ExportSelectedRecordToWord(saveFileDialog.FileName, maDeTai);
                }
                else
                {
                    ExportSelectedRecordToExcel(saveFileDialog.FileName, maDeTai);
                }
                ShowSuccessMessage($"Xuất {(isWordExport ? "Word" : "Excel")} thành công!\nFile đã được lưu tại: {saveFileDialog.FileName}");
            }
        }

        private void ExportAllRecords(bool isWordExport)
        {
            string fileExtension = isWordExport ? ".docx" : ".xlsx";
            string filter = isWordExport ? "Word files (*.docx)|*.docx" : AppConstants.Files.ExcelFilter;
            string title = isWordExport ? "Lưu file Word" : "Lưu file Excel";

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = filter,
                Title = title,
                FileName = $"DanhSachDeTai_{DateTime.Now:yyyyMMdd_HHmmss}{fileExtension}"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (isWordExport)
                {
                    ExportAllRecordsToWord(saveFileDialog.FileName);
                }
                else
                {
                    ExportToExcel(saveFileDialog.FileName);
                }
                ShowSuccessMessage($"Xuất {(isWordExport ? "Word" : "Excel")} thành công!\nFile đã được lưu tại: {saveFileDialog.FileName}");
            }
        }

        private void ExportToExcel(string filePath)
        {
            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Danh sách đề tài");

                // Tiêu đề
                worksheet.Cell(1, 1).Value = "DANH SÁCH ĐỀ TÀI NGHIÊN CỨU";
                worksheet.Range(1, 1, 1, 7).Merge().Style.Font.Bold = true;
                worksheet.Range(1, 1, 1, 7).Style.Font.FontSize = 16;
                worksheet.Range(1, 1, 1, 7).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;

                // Thông tin xuất
                worksheet.Cell(2, 1).Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                worksheet.Cell(3, 1).Value = $"Người xuất: {currentUser.TenDangNhap}";

                // Header
                int headerRow = 5;
                worksheet.Cell(headerRow, 1).Value = "STT";
                worksheet.Cell(headerRow, 2).Value = "Mã đề tài";
                worksheet.Cell(headerRow, 3).Value = "Tên đề tài";
                worksheet.Cell(headerRow, 4).Value = "Lĩnh vực";
                worksheet.Cell(headerRow, 5).Value = "Cấp quản lý";
                worksheet.Cell(headerRow, 6).Value = "Thời gian bắt đầu";
                worksheet.Cell(headerRow, 7).Value = "Chủ nhiệm";

                // Style header
                var headerRange = worksheet.Range(headerRow, 1, headerRow, 7);
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.LightBlue;
                headerRange.Style.Border.OutsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thick;
                headerRange.Style.Border.InsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;

                // Data
                int currentRow = headerRow + 1;
                for (int i = 0; i < dgvDeTai.Rows.Count; i++)
                {
                    var row = dgvDeTai.Rows[i];
                    worksheet.Cell(currentRow, 1).Value = i + 1;
                    worksheet.Cell(currentRow, 2).Value = row.Cells["MaDeTai"].Value?.ToString() ?? string.Empty;
                    worksheet.Cell(currentRow, 3).Value = row.Cells["TenDeTai"].Value?.ToString() ?? string.Empty;
                    worksheet.Cell(currentRow, 4).Value = row.Cells["LinhVuc"].Value?.ToString() ?? string.Empty;
                    worksheet.Cell(currentRow, 5).Value = row.Cells["CapQuanLy"].Value?.ToString() ?? string.Empty;
                    worksheet.Cell(currentRow, 6).Value = row.Cells["ThoiGianBatDau"].Value?.ToString() ?? string.Empty;
                    worksheet.Cell(currentRow, 7).Value = row.Cells["ChuNhiem"].Value?.ToString() ?? string.Empty;
                    currentRow++;
                }

                // Style data
                var dataRange = worksheet.Range(headerRow + 1, 1, currentRow - 1, 7);
                dataRange.Style.Border.OutsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;
                dataRange.Style.Border.InsideBorder = ClosedXML.Excel.XLBorderStyleValues.Thin;

                // Auto fit columns
                worksheet.Columns().AdjustToContents();

                // Tổng số
                worksheet.Cell(currentRow + 1, 1).Value = $"Tổng số: {dgvDeTai.Rows.Count} đề tài";
                worksheet.Range(currentRow + 1, 1, currentRow + 1, 7).Merge().Style.Font.Bold = true;

                workbook.SaveAs(filePath);
            }
        }

        private async void ExportSelectedRecordToWord(string filePath, int maDeTai)
        {
            // Lấy thông tin chi tiết đề tài
            var deTaiInfo = await GetDetailedDeTaiInfo(maDeTai);
            if (deTaiInfo == null)
            {
                ShowErrorMessage("Không tìm thấy thông tin đề tài!", new Exception("DeTai not found"));
                return;
            }

            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                // Tiêu đề chính
                AddHeading(body, "BÁO CÁO CHI TIẾT ĐỀ TÀI NGHIÊN CỨU", 1);
                AddParagraph(body, $"Mã đề tài: DT{maDeTai:D6}", true);
                AddParagraph(body, $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                AddParagraph(body, $"Người xuất: {currentUser.TenDangNhap}");
                AddParagraph(body, ""); // Dòng trống

                // Thông tin cơ bản đề tài
                AddHeading(body, "I. THÔNG TIN CƠ BẢN", 2);
                AddParagraph(body, $"Tên đề tài: {deTaiInfo.TenDeTai}");
                AddParagraph(body, $"Lĩnh vực: {deTaiInfo.LinhVuc}");
                AddParagraph(body, $"Cấp quản lý: {GetCapQuanLyDisplayText(deTaiInfo.CapQuanLy)}");
                AddParagraph(body, $"Thời gian bắt đầu: {deTaiInfo.ThoiGianBatDau?.ToString(AppConstants.Formats.DateFormat) ?? "Chưa xác định"}");
                AddParagraph(body, $"Thời gian kết thúc: {deTaiInfo.ThoiGianKetThuc?.ToString(AppConstants.Formats.DateFormat) ?? "Chưa xác định"}");
                if (!string.IsNullOrEmpty(deTaiInfo.MoTaTomTat))
                {
                    AddParagraph(body, $"Mô tả tóm tắt: {deTaiInfo.MoTaTomTat}");
                }
                AddParagraph(body, ""); // Dòng trống

                // Thông tin nhân sự
                AddHeading(body, "II. THÔNG TIN NHÂN SỰ", 2);
                await AddPersonnelInfo(body, maDeTai);
                AddParagraph(body, ""); // Dòng trống

                // Thông tin đơn vị phối hợp
                AddHeading(body, "III. ĐƠN VỊ PHỐI HỢP", 2);
                await AddDonViPhoiHopInfo(body, maDeTai);
                AddParagraph(body, ""); // Dòng trống

                // Thông tin kinh phí
                AddHeading(body, "IV. THÔNG TIN KINH PHÍ", 2);
                await AddKinhPhiInfo(body, maDeTai);
                AddParagraph(body, ""); // Dòng trống

                // Thông tin sản phẩm
                AddHeading(body, "V. THÔNG TIN SẢN PHẨM", 2);
                await AddSanPhamInfo(body, maDeTai);

                mainPart.Document.Save();
            }
        }

        private void ExportAllRecordsToWord(string filePath)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                // Tiêu đề chính
                AddHeading(body, "DANH SÁCH ĐỀ TÀI NGHIÊN CỨU", 1);
                AddParagraph(body, $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                AddParagraph(body, $"Người xuất: {currentUser.TenDangNhap}");
                AddParagraph(body, $"Tổng số: {dgvDeTai.Rows.Count} đề tài");
                AddParagraph(body, ""); // Dòng trống

                // Tạo bảng
                Table table = new Table();

                // Tạo table properties
                TableProperties tableProperties = new TableProperties(
                    new TableBorders(
                        new TopBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                        new BottomBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                        new LeftBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                        new RightBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 12 },
                        new InsideHorizontalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 },
                        new InsideVerticalBorder() { Val = new EnumValue<BorderValues>(BorderValues.Single), Size = 6 }
                    )
                );
                table.AppendChild(tableProperties);

                // Header row
                TableRow headerRow = new TableRow();
                headerRow.Append(CreateTableCell("STT", true));
                headerRow.Append(CreateTableCell("Mã đề tài", true));
                headerRow.Append(CreateTableCell("Tên đề tài", true));
                headerRow.Append(CreateTableCell("Lĩnh vực", true));
                headerRow.Append(CreateTableCell("Cấp quản lý", true));
                headerRow.Append(CreateTableCell("Thời gian bắt đầu", true));
                headerRow.Append(CreateTableCell("Chủ nhiệm", true));
                table.Append(headerRow);

                // Data rows
                for (int i = 0; i < dgvDeTai.Rows.Count; i++)
                {
                    var row = dgvDeTai.Rows[i];
                    TableRow dataRow = new TableRow();
                    dataRow.Append(CreateTableCell((i + 1).ToString()));
                    dataRow.Append(CreateTableCell(row.Cells["MaDeTai"].Value?.ToString() ?? ""));
                    dataRow.Append(CreateTableCell(row.Cells["TenDeTai"].Value?.ToString() ?? ""));
                    dataRow.Append(CreateTableCell(row.Cells["LinhVuc"].Value?.ToString() ?? ""));
                    dataRow.Append(CreateTableCell(row.Cells["CapQuanLy"].Value?.ToString() ?? ""));
                    dataRow.Append(CreateTableCell(row.Cells["ThoiGianBatDau"].Value?.ToString() ?? ""));
                    dataRow.Append(CreateTableCell(row.Cells["ChuNhiem"].Value?.ToString() ?? ""));
                    table.Append(dataRow);
                }

                body.Append(table);
                mainPart.Document.Save();
            }
        }
        #endregion

        #region Helper Methods
        private bool CheckAdminPermission()
        {
            if (currentUser.VaiTro != VaiTroTaiKhoan.Admin)
            {
                MessageBox.Show("Bạn không có quyền thực hiện chức năng này!\nChỉ Admin mới có thể thực hiện.",
                    "Không có quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Word document helper methods
        private void AddHeading(Body body, string text, int level)
        {
            Paragraph paragraph = new Paragraph();
            Run run = new Run();

            RunProperties runProperties = new RunProperties();
            runProperties.Bold = new Bold();

            if (level == 1)
            {
                runProperties.FontSize = new FontSize() { Val = "16" };
            }
            else if (level == 2)
            {
                runProperties.FontSize = new FontSize() { Val = "14" };
            }
            else if (level == 3)
            {
                runProperties.FontSize = new FontSize() { Val = "12" };
            }

            run.RunProperties = runProperties;
            run.AppendChild(new Text(text));
            paragraph.AppendChild(run);

            ParagraphProperties paragraphProperties = new ParagraphProperties();
            if (level <= 2)
            {
                paragraphProperties.Justification = new Justification() { Val = JustificationValues.Center };
            }
            else
            {
                paragraphProperties.Justification = new Justification() { Val = JustificationValues.Left };
            }
            paragraph.ParagraphProperties = paragraphProperties;

            body.AppendChild(paragraph);
        }

        private void AddParagraph(Body body, string text, bool bold = false)
        {
            Paragraph paragraph = new Paragraph();
            Run run = new Run();

            if (bold)
            {
                RunProperties runProperties = new RunProperties();
                runProperties.Bold = new Bold();
                run.RunProperties = runProperties;
            }

            run.AppendChild(new Text(text));
            paragraph.AppendChild(run);
            body.AppendChild(paragraph);
        }

        private TableCell CreateTableCell(string text, bool isHeader = false)
        {
            TableCell cell = new TableCell();

            TableCellProperties cellProperties = new TableCellProperties();
            if (isHeader)
            {
                cellProperties.Shading = new Shading()
                {
                    Val = ShadingPatternValues.Clear,
                    Color = "auto",
                    Fill = "D9D9D9"
                };
            }
            cell.Append(cellProperties);

            Paragraph paragraph = new Paragraph();
            Run run = new Run();

            if (isHeader)
            {
                RunProperties runProperties = new RunProperties();
                runProperties.Bold = new Bold();
                run.RunProperties = runProperties;
            }

            run.AppendChild(new Text(text));
            paragraph.AppendChild(run);
            cell.AppendChild(paragraph);

            return cell;
        }

        private async Task<DeTai?> GetDetailedDeTaiInfo(int maDeTai)
        {
            return await ExecuteDbOperationAsync(async context =>
            {
                return await context.DeTai.FirstOrDefaultAsync(dt => dt.MaDeTai == maDeTai);
            }, "Lỗi khi lấy thông tin đề tài");
        }

        private async Task AddPersonnelInfo(Body body, int maDeTai)
        {
            var personnelInfo = await ExecuteDbOperationAsync(async context =>
            {
                return await context.VaiTroThamGia
                    .Include(vt => vt.CanBo)
                    .Where(vt => vt.MaDeTai == maDeTai)
                    .ToListAsync();
            }, "Lỗi khi lấy thông tin nhân sự");

            if (personnelInfo != null && personnelInfo.Any())
            {
                var chuNhiem = personnelInfo.Where(p => p.VaiTro == VaiTroThamGiaEnum.ChuNhiem).ToList();
                var thanhVien = personnelInfo.Where(p => p.VaiTro == VaiTroThamGiaEnum.ThamGia).ToList();

                if (chuNhiem.Any())
                {
                    AddParagraph(body, "Chủ nhiệm đề tài:", true);
                    foreach (var cn in chuNhiem)
                    {
                        AddParagraph(body, $"- {cn.CanBo.HoTen} ({cn.CanBo.ChucVu ?? "N/A"})");
                    }
                }

                if (thanhVien.Any())
                {
                    AddParagraph(body, "Thành viên tham gia:", true);
                    foreach (var tv in thanhVien)
                    {
                        AddParagraph(body, $"- {tv.CanBo.HoTen} ({tv.CanBo.ChucVu ?? "N/A"})");
                    }
                }
            }
            else
            {
                AddParagraph(body, "Chưa có thông tin nhân sự.");
            }
        }

        private async Task AddDonViPhoiHopInfo(Body body, int maDeTai)
        {
            var donViInfo = await ExecuteDbOperationAsync(async context =>
            {
                return await context.DeTai_DonVi
                    .Include(dd => dd.DonViPhoiHop)
                    .Where(dd => dd.MaDeTai == maDeTai)
                    .ToListAsync();
            }, "Lỗi khi lấy thông tin đơn vị");

            if (donViInfo != null && donViInfo.Any())
            {
                foreach (var dv in donViInfo)
                {
                    AddParagraph(body, $"- {dv.DonViPhoiHop.TenDonVi}");
                    if (!string.IsNullOrEmpty(dv.DonViPhoiHop.DiaChi))
                        AddParagraph(body, $"  Địa chỉ: {dv.DonViPhoiHop.DiaChi}");
                    if (!string.IsNullOrEmpty(dv.DonViPhoiHop.SoDienThoai))
                        AddParagraph(body, $"  Điện thoại: {dv.DonViPhoiHop.SoDienThoai}");
                    if (!string.IsNullOrEmpty(dv.DonViPhoiHop.Email))
                        AddParagraph(body, $"  Email: {dv.DonViPhoiHop.Email}");
                    if (!string.IsNullOrEmpty(dv.GhiChu))
                        AddParagraph(body, $"  Ghi chú: {dv.GhiChu}");
                }
            }
            else
            {
                AddParagraph(body, "Chưa có thông tin đơn vị phối hợp.");
            }
        }

        private async Task AddKinhPhiInfo(Body body, int maDeTai)
        {
            var kinhPhiInfo = await ExecuteDbOperationAsync(async context =>
            {
                return await context.KinhPhi
                    .Where(kp => kp.MaDeTai == maDeTai)
                    .FirstOrDefaultAsync();
            }, "Lỗi khi lấy thông tin kinh phí");

            if (kinhPhiInfo != null)
            {
                AddParagraph(body, $"Ngân sách: {kinhPhiInfo.NganSach?.ToString("N0") ?? "0"} VNĐ");
                AddParagraph(body, $"Kinh phí khác: {kinhPhiInfo.Khac?.ToString("N0") ?? "0"} VNĐ");
                var tongKinhPhi = (kinhPhiInfo.NganSach ?? 0) + (kinhPhiInfo.Khac ?? 0);
                AddParagraph(body, $"Tổng kinh phí: {tongKinhPhi:N0} VNĐ", true);
            }
            else
            {
                AddParagraph(body, "Chưa có thông tin kinh phí.");
            }
        }

        private async Task AddSanPhamInfo(Body body, int maDeTai)
        {
            // Sản phẩm Dạng I
            var sanPhamI = await ExecuteDbOperationAsync(async context =>
            {
                return await context.ChiTietSanPham_DangI
                    .Include(sp => sp.DonViHanhChinh)
                    .Include(sp => sp.DacTinhKyThuat)
                    .Where(sp => sp.MaDeTai == maDeTai)
                    .ToListAsync();
            }, "Lỗi khi lấy sản phẩm dạng I");

            if (sanPhamI != null && sanPhamI.Any())
            {
                AddHeading(body, "5.1. Sản phẩm dạng I (Vật chất)", 3);
                foreach (var sp in sanPhamI)
                {
                    AddParagraph(body, $"- {sp.TenSanPham_I}");
                    AddParagraph(body, $"  Đơn vị hành chính: {sp.DonViHanhChinh?.TinhThanh ?? "N/A"}");

                    if (sp.DacTinhKyThuat.Any())
                    {
                        AddParagraph(body, "  Đặc tính kỹ thuật:");
                        foreach (var dt in sp.DacTinhKyThuat)
                        {
                            AddParagraph(body, $"    + {dt.ThongSo}: {dt.GiaTri} {dt.DonViDo}");
                            if (!string.IsNullOrEmpty(dt.ChiChu))
                                AddParagraph(body, $"      ({dt.ChiChu})");
                        }
                    }
                }
                AddParagraph(body, "");
            }

            // Sản phẩm Dạng II
            var sanPhamII = await ExecuteDbOperationAsync(async context =>
            {
                return await context.ChiTietSanPham_DangII
                    .Where(sp => sp.MaDeTai == maDeTai)
                    .ToListAsync();
            }, "Lỗi khi lấy sản phẩm dạng II");

            if (sanPhamII != null && sanPhamII.Any())
            {
                AddHeading(body, "5.2. Sản phẩm dạng II (Phi vật chất)", 3);
                foreach (var sp in sanPhamII)
                {
                    AddParagraph(body, $"- {sp.TenSanPham_II}");
                    AddParagraph(body, $"  Loại: {GetLoaiSanPhamIIDisplayText(sp.LoaiSanPham_II)}");
                }
                AddParagraph(body, "");
            }

            // Sản phẩm Dạng III
            var sanPhamIII = await ExecuteDbOperationAsync(async context =>
            {
                return await context.ChiTietSanPham_DangIII
                    .Where(sp => sp.MaDeTai == maDeTai)
                    .ToListAsync();
            }, "Lỗi khi lấy sản phẩm dạng III");

            if (sanPhamIII != null && sanPhamIII.Any())
            {
                AddHeading(body, "5.3. Sản phẩm dạng III (Sở hữu trí tuệ)", 3);
                foreach (var sp in sanPhamIII)
                {
                    AddParagraph(body, $"- {sp.TenSanPham_III}");
                    AddParagraph(body, $"  Loại: {GetLoaiSanPhamIIIDisplayText(sp.LoaiSanPham_III)}");
                    if (!string.IsNullOrEmpty(sp.NoiCongBo))
                        AddParagraph(body, $"  Nơi công bố: {sp.NoiCongBo}");
                }
            }

            if ((sanPhamI == null || !sanPhamI.Any()) &&
                (sanPhamII == null || !sanPhamII.Any()) &&
                (sanPhamIII == null || !sanPhamIII.Any()))
            {
                AddParagraph(body, "Chưa có thông tin sản phẩm.");
            }
        }

        private string GetLoaiSanPhamIIDisplayText(LoaiSanPham_II loai)
        {
            return loai switch
            {
                LoaiSanPham_II.BaoCao => "Báo cáo",
                LoaiSanPham_II.QuyTrinh => "Quy trình",
                LoaiSanPham_II.BanVe => "Bản vẽ",
                LoaiSanPham_II.BanDo => "Bản đồ",
                LoaiSanPham_II.Khac => "Khác",
                _ => "Không xác định"
            };
        }

        private string GetLoaiSanPhamIIIDisplayText(LoaiSanPham_III loai)
        {
            return loai switch
            {
                LoaiSanPham_III.BangSangChe => "Bằng sáng chế",
                LoaiSanPham_III.GiaiPhapHuuIch => "Giải pháp hữu ích",
                LoaiSanPham_III.BaiBao => "Bài báo",
                _ => "Không xác định"
            };
        }

        private async void ExportSelectedRecordToExcel(string filePath, int maDeTai)
        {
            // Lấy thông tin chi tiết đề tài
            var deTaiInfo = await GetDetailedDeTaiInfo(maDeTai);
            if (deTaiInfo == null)
            {
                ShowErrorMessage("Không tìm thấy thông tin đề tài!", new Exception("DeTai not found"));
                return;
            }

            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Chi tiết đề tài");

                // Tiêu đề
                worksheet.Cell(1, 1).Value = "BÁO CÁO CHI TIẾT ĐỀ TÀI NGHIÊN CỨU";
                worksheet.Range(1, 1, 1, 4).Merge().Style.Font.Bold = true;
                worksheet.Range(1, 1, 1, 4).Style.Font.FontSize = 16;
                worksheet.Range(1, 1, 1, 4).Style.Alignment.Horizontal = ClosedXML.Excel.XLAlignmentHorizontalValues.Center;

                // Thông tin xuất
                worksheet.Cell(2, 1).Value = $"Mã đề tài: DT{maDeTai:D6}";
                worksheet.Cell(3, 1).Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                worksheet.Cell(4, 1).Value = $"Người xuất: {currentUser.TenDangNhap}";

                int currentRow = 6;

                // I. THÔNG TIN CƠ BẢN
                worksheet.Cell(currentRow, 1).Value = "I. THÔNG TIN CƠ BẢN";
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 1).Style.Font.FontSize = 14;
                currentRow++;

                worksheet.Cell(currentRow, 1).Value = "Tên đề tài:";
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 2).Value = deTaiInfo.TenDeTai;
                currentRow++;

                worksheet.Cell(currentRow, 1).Value = "Lĩnh vực:";
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 2).Value = deTaiInfo.LinhVuc;
                currentRow++;

                worksheet.Cell(currentRow, 1).Value = "Cấp quản lý:";
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 2).Value = GetCapQuanLyDisplayText(deTaiInfo.CapQuanLy);
                currentRow++;

                worksheet.Cell(currentRow, 1).Value = "Thời gian bắt đầu:";
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 2).Value = deTaiInfo.ThoiGianBatDau?.ToString(AppConstants.Formats.DateFormat) ?? "Chưa xác định";
                currentRow++;

                worksheet.Cell(currentRow, 1).Value = "Thời gian kết thúc:";
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 2).Value = deTaiInfo.ThoiGianKetThuc?.ToString(AppConstants.Formats.DateFormat) ?? "Chưa xác định";
                currentRow++;

                if (!string.IsNullOrEmpty(deTaiInfo.MoTaTomTat))
                {
                    worksheet.Cell(currentRow, 1).Value = "Mô tả tóm tắt:";
                    worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                    worksheet.Cell(currentRow, 2).Value = deTaiInfo.MoTaTomTat;
                    currentRow++;
                }
                currentRow++;

                // II. THÔNG TIN NHÂN SỰ
                worksheet.Cell(currentRow, 1).Value = "II. THÔNG TIN NHÂN SỰ";
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 1).Style.Font.FontSize = 14;
                currentRow++;

                currentRow = await AddPersonnelInfoToExcel(worksheet, currentRow, maDeTai);
                currentRow++;

                // III. ĐƠN VỊ PHỐI HỢP
                worksheet.Cell(currentRow, 1).Value = "III. ĐƠN VỊ PHỐI HỢP";
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 1).Style.Font.FontSize = 14;
                currentRow++;

                currentRow = await AddDonViPhoiHopInfoToExcel(worksheet, currentRow, maDeTai);
                currentRow++;

                // IV. THÔNG TIN KINH PHÍ
                worksheet.Cell(currentRow, 1).Value = "IV. THÔNG TIN KINH PHÍ";
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 1).Style.Font.FontSize = 14;
                currentRow++;

                currentRow = await AddKinhPhiInfoToExcel(worksheet, currentRow, maDeTai);
                currentRow++;

                // V. THÔNG TIN SẢN PHẨM
                worksheet.Cell(currentRow, 1).Value = "V. THÔNG TIN SẢN PHẨM";
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 1).Style.Font.FontSize = 14;
                currentRow++;

                await AddSanPhamInfoToExcel(worksheet, currentRow, maDeTai);

                // Auto fit columns
                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(filePath);
            }
        }
        #endregion

        private async Task<int> AddPersonnelInfoToExcel(ClosedXML.Excel.IXLWorksheet worksheet, int startRow, int maDeTai)
        {
            var personnelInfo = await ExecuteDbOperationAsync(async context =>
            {
                return await context.VaiTroThamGia
                    .Include(vt => vt.CanBo)
                    .Where(vt => vt.MaDeTai == maDeTai)
                    .ToListAsync();
            }, "Lỗi khi lấy thông tin nhân sự");

            int currentRow = startRow;

            if (personnelInfo != null && personnelInfo.Any())
            {
                var chuNhiem = personnelInfo.Where(p => p.VaiTro == VaiTroThamGiaEnum.ChuNhiem).ToList();
                var thanhVien = personnelInfo.Where(p => p.VaiTro == VaiTroThamGiaEnum.ThamGia).ToList();

                if (chuNhiem.Any())
                {
                    worksheet.Cell(currentRow, 1).Value = "Chủ nhiệm đề tài:";
                    worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                    currentRow++;
                    foreach (var cn in chuNhiem)
                    {
                        worksheet.Cell(currentRow, 1).Value = $"- {cn.CanBo.HoTen}";
                        worksheet.Cell(currentRow, 2).Value = cn.CanBo.ChucVu ?? "N/A";
                        currentRow++;
                    }
                }

                if (thanhVien.Any())
                {
                    worksheet.Cell(currentRow, 1).Value = "Thành viên tham gia:";
                    worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                    currentRow++;
                    foreach (var tv in thanhVien)
                    {
                        worksheet.Cell(currentRow, 1).Value = $"- {tv.CanBo.HoTen}";
                        worksheet.Cell(currentRow, 2).Value = tv.CanBo.ChucVu ?? "N/A";
                        currentRow++;
                    }
                }
            }
            else
            {
                worksheet.Cell(currentRow, 1).Value = "Chưa có thông tin nhân sự.";
                currentRow++;
            }

            return currentRow;
        }

        private async Task<int> AddDonViPhoiHopInfoToExcel(ClosedXML.Excel.IXLWorksheet worksheet, int startRow, int maDeTai)
        {
            var donViInfo = await ExecuteDbOperationAsync(async context =>
            {
                return await context.DeTai_DonVi
                    .Include(dd => dd.DonViPhoiHop)
                    .Where(dd => dd.MaDeTai == maDeTai)
                    .ToListAsync();
            }, "Lỗi khi lấy thông tin đơn vị");

            int currentRow = startRow;

            if (donViInfo != null && donViInfo.Any())
            {
                foreach (var dv in donViInfo)
                {
                    worksheet.Cell(currentRow, 1).Value = $"- {dv.DonViPhoiHop.TenDonVi}";
                    worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                    currentRow++;

                    if (!string.IsNullOrEmpty(dv.DonViPhoiHop.DiaChi))
                    {
                        worksheet.Cell(currentRow, 1).Value = "  Địa chỉ:";
                        worksheet.Cell(currentRow, 2).Value = dv.DonViPhoiHop.DiaChi;
                        currentRow++;
                    }
                    if (!string.IsNullOrEmpty(dv.DonViPhoiHop.SoDienThoai))
                    {
                        worksheet.Cell(currentRow, 1).Value = "  Điện thoại:";
                        worksheet.Cell(currentRow, 2).Value = dv.DonViPhoiHop.SoDienThoai;
                        currentRow++;
                    }
                    if (!string.IsNullOrEmpty(dv.DonViPhoiHop.Email))
                    {
                        worksheet.Cell(currentRow, 1).Value = "  Email:";
                        worksheet.Cell(currentRow, 2).Value = dv.DonViPhoiHop.Email;
                        currentRow++;
                    }
                    if (!string.IsNullOrEmpty(dv.GhiChu))
                    {
                        worksheet.Cell(currentRow, 1).Value = "  Ghi chú:";
                        worksheet.Cell(currentRow, 2).Value = dv.GhiChu;
                        currentRow++;
                    }
                }
            }
            else
            {
                worksheet.Cell(currentRow, 1).Value = "Chưa có thông tin đơn vị phối hợp.";
                currentRow++;
            }

            return currentRow;
        }

        private async Task<int> AddKinhPhiInfoToExcel(ClosedXML.Excel.IXLWorksheet worksheet, int startRow, int maDeTai)
        {
            var kinhPhiInfo = await ExecuteDbOperationAsync(async context =>
            {
                return await context.KinhPhi
                    .Where(kp => kp.MaDeTai == maDeTai)
                    .FirstOrDefaultAsync();
            }, "Lỗi khi lấy thông tin kinh phí");

            int currentRow = startRow;

            if (kinhPhiInfo != null)
            {
                worksheet.Cell(currentRow, 1).Value = "Ngân sách:";
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 2).Value = $"{kinhPhiInfo.NganSach?.ToString("N0") ?? "0"} VNĐ";
                currentRow++;

                worksheet.Cell(currentRow, 1).Value = "Kinh phí khác:";
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 2).Value = $"{kinhPhiInfo.Khac?.ToString("N0") ?? "0"} VNĐ";
                currentRow++;

                var tongKinhPhi = (kinhPhiInfo.NganSach ?? 0) + (kinhPhiInfo.Khac ?? 0);
                worksheet.Cell(currentRow, 1).Value = "Tổng kinh phí:";
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 2).Value = $"{tongKinhPhi:N0} VNĐ";
                worksheet.Cell(currentRow, 2).Style.Font.Bold = true;
                currentRow++;
            }
            else
            {
                worksheet.Cell(currentRow, 1).Value = "Chưa có thông tin kinh phí.";
                currentRow++;
            }

            return currentRow;
        }

        private async Task AddSanPhamInfoToExcel(ClosedXML.Excel.IXLWorksheet worksheet, int startRow, int maDeTai)
        {
            int currentRow = startRow;

            // Sản phẩm Dạng I
            var sanPhamI = await ExecuteDbOperationAsync(async context =>
            {
                return await context.ChiTietSanPham_DangI
                    .Include(sp => sp.DonViHanhChinh)
                    .Include(sp => sp.DacTinhKyThuat)
                    .Where(sp => sp.MaDeTai == maDeTai)
                    .ToListAsync();
            }, "Lỗi khi lấy sản phẩm dạng I");

            if (sanPhamI != null && sanPhamI.Any())
            {
                worksheet.Cell(currentRow, 1).Value = "5.1. Sản phẩm dạng I (Vật chất)";
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 1).Style.Font.FontSize = 12;
                currentRow++;

                foreach (var sp in sanPhamI)
                {
                    worksheet.Cell(currentRow, 1).Value = $"- {sp.TenSanPham_I}";
                    worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                    currentRow++;

                    worksheet.Cell(currentRow, 1).Value = "  Đơn vị hành chính:";
                    worksheet.Cell(currentRow, 2).Value = sp.DonViHanhChinh?.TinhThanh ?? "N/A";
                    currentRow++;

                    if (sp.DacTinhKyThuat.Any())
                    {
                        worksheet.Cell(currentRow, 1).Value = "  Đặc tính kỹ thuật:";
                        worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                        currentRow++;
                        foreach (var dt in sp.DacTinhKyThuat)
                        {
                            worksheet.Cell(currentRow, 1).Value = $"    + {dt.ThongSo}:";
                            worksheet.Cell(currentRow, 2).Value = $"{dt.GiaTri} {dt.DonViDo}";
                            currentRow++;
                            if (!string.IsNullOrEmpty(dt.ChiChu))
                            {
                                worksheet.Cell(currentRow, 1).Value = "      Ghi chú:";
                                worksheet.Cell(currentRow, 2).Value = dt.ChiChu;
                                currentRow++;
                            }
                        }
                    }
                    currentRow++; // Dòng trống giữa các sản phẩm
                }
            }

            // Sản phẩm Dạng II
            var sanPhamII = await ExecuteDbOperationAsync(async context =>
            {
                return await context.ChiTietSanPham_DangII
                    .Where(sp => sp.MaDeTai == maDeTai)
                    .ToListAsync();
            }, "Lỗi khi lấy sản phẩm dạng II");

            if (sanPhamII != null && sanPhamII.Any())
            {
                worksheet.Cell(currentRow, 1).Value = "5.2. Sản phẩm dạng II (Phi vật chất)";
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 1).Style.Font.FontSize = 12;
                currentRow++;

                foreach (var sp in sanPhamII)
                {
                    worksheet.Cell(currentRow, 1).Value = $"- {sp.TenSanPham_II}";
                    worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                    currentRow++;

                    worksheet.Cell(currentRow, 1).Value = "  Loại:";
                    worksheet.Cell(currentRow, 2).Value = GetLoaiSanPhamIIDisplayText(sp.LoaiSanPham_II);
                    currentRow++;
                }
                currentRow++; // Dòng trống
            }

            // Sản phẩm Dạng III
            var sanPhamIII = await ExecuteDbOperationAsync(async context =>
            {
                return await context.ChiTietSanPham_DangIII
                    .Where(sp => sp.MaDeTai == maDeTai)
                    .ToListAsync();
            }, "Lỗi khi lấy sản phẩm dạng III");

            if (sanPhamIII != null && sanPhamIII.Any())
            {
                worksheet.Cell(currentRow, 1).Value = "5.3. Sản phẩm dạng III (Sở hữu trí tuệ)";
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 1).Style.Font.FontSize = 12;
                currentRow++;

                foreach (var sp in sanPhamIII)
                {
                    worksheet.Cell(currentRow, 1).Value = $"- {sp.TenSanPham_III}";
                    worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                    currentRow++;

                    worksheet.Cell(currentRow, 1).Value = "  Loại:";
                    worksheet.Cell(currentRow, 2).Value = GetLoaiSanPhamIIIDisplayText(sp.LoaiSanPham_III);
                    currentRow++;

                    if (!string.IsNullOrEmpty(sp.NoiCongBo))
                    {
                        worksheet.Cell(currentRow, 1).Value = "  Nơi công bố:";
                        worksheet.Cell(currentRow, 2).Value = sp.NoiCongBo;
                        currentRow++;
                    }
                }
            }

            // Nếu không có sản phẩm nào
            if ((sanPhamI == null || !sanPhamI.Any()) &&
                (sanPhamII == null || !sanPhamII.Any()) &&
                (sanPhamIII == null || !sanPhamIII.Any()))
            {
                worksheet.Cell(currentRow, 1).Value = "Chưa có thông tin sản phẩm.";
                currentRow++;
            }
        }

        private void dgvDeTai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
