using Microsoft.EntityFrameworkCore;
using Models.HandleData;
using Models.Models;
using System.Diagnostics;
using WinFormsApp1.Constants;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace WinFormsApp1
{
    public partial class frmQuanLyCanBo : BaseForm
    {
        private TaiKhoan currentUser;
        private List<CanBo> allCanBo = new List<CanBo>();

        public frmQuanLyCanBo(TaiKhoan user)
        {
            currentUser = user;
            InitializeComponent();
            LoadData();
            SetupDataGridView();
            SetupUserPermissions();
        }

        private void SetupUserPermissions()
        {
            // Kiểm tra quyền của người dùng
            bool isAdmin = currentUser.VaiTro == VaiTroTaiKhoan.Admin;

            // Chỉ Admin mới được thêm/sửa/xóa - ẨN hoàn toàn cho User
            btnThem.Visible = isAdmin;
            btnSua.Visible = isAdmin;
            btnXoa.Visible = isAdmin;

            // User và Admin đều được xem và xuất file
            btnTaiFile.Visible = true;
            btnXuatWord.Visible = true;
            btnXuatExcel.Visible = true;
            btnXuatPDF.Visible = true;
            btnLamMoi.Visible = true;

            // Không cần tooltip nữa vì đã ẩn buttons
        }

        private void SetupDataGridView()
        {
            dgvCanBo.AutoGenerateColumns = false;
            dgvCanBo.AllowUserToAddRows = false;
            dgvCanBo.AllowUserToDeleteRows = false;
            dgvCanBo.ReadOnly = true;
            dgvCanBo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCanBo.MultiSelect = false;

            // Thiết lập các cột
            dgvCanBo.Columns.Clear();

            dgvCanBo.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MaCanBo",
                HeaderText = "Mã CB",
                DataPropertyName = "MaCanBo",
                Width = 60
            });

            dgvCanBo.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HoTen",
                HeaderText = "Họ và tên",
                DataPropertyName = "HoTen",
                Width = 150
            });

            dgvCanBo.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ChucVu",
                HeaderText = "Chức vụ",
                DataPropertyName = "ChucVu",
                Width = 120
            });

            dgvCanBo.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HocVi",
                HeaderText = "Học vị",
                DataPropertyName = "HocVi",
                Width = 80
            });

            dgvCanBo.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HocHam",
                HeaderText = "Học hàm",
                DataPropertyName = "HocHam",
                Width = 100
            });

            dgvCanBo.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ChuyenNganh",
                HeaderText = "Chuyên ngành",
                DataPropertyName = "ChuyenNganh",
                Width = 120
            });

            dgvCanBo.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DienThoai",
                HeaderText = "Điện thoại",
                DataPropertyName = "DienThoai",
                Width = 100
            });

            dgvCanBo.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 150
            });

            dgvCanBo.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PhongBan",
                HeaderText = "Phòng ban",
                DataPropertyName = "PhongBan",
                Width = 120
            });
        }

        private async void LoadData()
        {
            try
            {
                allCanBo = await ExecuteDbOperationAsync(async context =>
                {
                    return await context.CanBo.ToListAsync();
                }, AppConstants.Messages.ErrorLoadingData);

                ApplyFilter();
            }
            catch (Exception ex)
            {
                ShowErrorMessage(AppConstants.Messages.ErrorLoadingData, ex);
            }
        }

        private void ApplyFilter()
        {
            var filteredData = allCanBo.AsQueryable();

            // Lọc theo tên
            if (!string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                string searchText = txtTimKiem.Text.ToLower();
                filteredData = filteredData.Where(cb =>
                    (cb.HoTen != null && cb.HoTen.ToLower().Contains(searchText)) ||
                    (cb.ChucVu != null && cb.ChucVu.ToLower().Contains(searchText)) ||
                    (cb.ChuyenNganh != null && cb.ChuyenNganh.ToLower().Contains(searchText)) ||
                    (cb.PhongBan != null && cb.PhongBan.ToLower().Contains(searchText))
                );
            }

            // Lọc theo học vị
            if (cmbHocVi.SelectedIndex > 0)
            {
                string selectedHocVi = cmbHocVi.SelectedItem.ToString();
                filteredData = filteredData.Where(cb => cb.HocVi == selectedHocVi);
            }

            // Lọc theo phòng ban
            if (cmbPhongBan.SelectedIndex > 0)
            {
                string selectedPhongBan = cmbPhongBan.SelectedItem.ToString();
                filteredData = filteredData.Where(cb => cb.PhongBan == selectedPhongBan);
            }

            dgvCanBo.DataSource = filteredData.ToList();
            lblTongSo.Text = $"Tổng số: {filteredData.Count()} cán bộ";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền Admin
            if (currentUser.VaiTro != VaiTroTaiKhoan.Admin)
            {
                ShowErrorMessage(AppConstants.Messages.ErrorUnauthorized, new Exception());
                return;
            }

            var frmThem = new frmThemCanBo();
            if (frmThem.ShowDialog() == DialogResult.OK)
            {
                LoadData(); // Reload data after adding
                ShowSuccessMessage(AppConstants.Messages.AddSuccess);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền Admin
            if (currentUser.VaiTro != VaiTroTaiKhoan.Admin)
            {
                ShowErrorMessage(AppConstants.Messages.ErrorUnauthorized, new Exception());
                return;
            }

            if (dgvCanBo.SelectedRows.Count == 0)
            {
                ShowWarningMessage(AppConstants.Messages.WarningSelectItem);
                return;
            }

            var selectedCanBo = (CanBo)dgvCanBo.SelectedRows[0].DataBoundItem;
            if (selectedCanBo != null)
            {
                var frmSua = new frmThemCanBo(selectedCanBo.MaCanBo);
                if (frmSua.ShowDialog() == DialogResult.OK)
                {
                    LoadData(); // Reload data after editing
                    ShowSuccessMessage(AppConstants.Messages.UpdateSuccess);
                }
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền Admin
            if (currentUser.VaiTro != VaiTroTaiKhoan.Admin)
            {
                MessageBox.Show("Bạn không có quyền xóa cán bộ!\nChỉ Admin mới có thể thực hiện chức năng này.",
                    "Không có quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvCanBo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn cán bộ cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCanBo = (CanBo)dgvCanBo.SelectedRows[0].DataBoundItem;
            if (selectedCanBo == null) return;

            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa cán bộ '{selectedCanBo.HoTen}'?\n\nLưu ý: Việc xóa cán bộ sẽ ảnh hưởng đến các đề tài mà cán bộ này tham gia.",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var context = new DAContext())
                    {
                        // Kiểm tra xem cán bộ có tham gia đề tài nào không
                        var hasProjects = await context.VaiTroThamGia.AnyAsync(vt => vt.MaCanBo == selectedCanBo.MaCanBo);
                        if (hasProjects)
                        {
                            MessageBox.Show("Không thể xóa cán bộ này vì đang tham gia các đề tài nghiên cứu!",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Xóa tài khoản liên quan (nếu có)
                        var taiKhoan = await context.TaiKhoan.FirstOrDefaultAsync(tk => tk.MaCanBo == selectedCanBo.MaCanBo);
                        if (taiKhoan != null)
                        {
                            context.TaiKhoan.Remove(taiKhoan);
                        }

                        // Xóa cán bộ
                        var canBo = await context.CanBo.FindAsync(selectedCanBo.MaCanBo);
                        if (canBo != null)
                        {
                            context.CanBo.Remove(canBo);
                            await context.SaveChangesAsync();
                            MessageBox.Show("Xóa cán bộ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa cán bộ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void cmbHocVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void cmbPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnXuatWord_Click(object sender, EventArgs e)
        {
            HandleExport(true); // true = Word export
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            HandleExport(false); // false = Excel export
        }

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCanBo.Rows.Count == 0)
                {
                    ShowWarningMessage(AppConstants.Messages.InfoNoDataFound);
                    return;
                }

                // PDF chỉ xuất bản ghi đang chọn
                if (dgvCanBo.SelectedRows.Count == 0)
                {
                    ShowWarningMessage(AppConstants.Messages.WarningSelectItem);
                    return;
                }

                var selectedCanBo = (CanBo)dgvCanBo.SelectedRows[0].DataBoundItem;
                if (selectedCanBo == null) return;

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = AppConstants.Files.PdfFilter,
                    Title = "Lưu file PDF",
                    FileName = $"ChiTietCanBo_{selectedCanBo.MaCanBo}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportSelectedRecordToPDF(saveFileDialog.FileName, selectedCanBo.MaCanBo);
                    ShowSuccessMessage($"Xuất PDF thành công!\nFile đã được lưu tại: {saveFileDialog.FileName}");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi khi xuất PDF", ex);
            }
        }

        private void HandleExport(bool isWordExport)
        {
            try
            {
                if (dgvCanBo.Rows.Count == 0)
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
                            if (dgvCanBo.SelectedRows.Count == 0)
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

        private async void btnTaiFile_Click(object sender, EventArgs e)
        {
            if (dgvCanBo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn cán bộ để tải file lý lịch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedCanBo = (CanBo)dgvCanBo.SelectedRows[0].DataBoundItem;
            if (selectedCanBo == null) return;

            try
            {
                using (var context = new DAContext())
                {
                    var canBo = await context.CanBo.FindAsync(selectedCanBo.MaCanBo);
                    if (canBo?.File_LyLich == null)
                    {
                        MessageBox.Show("Cán bộ này chưa có file lý lịch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    using (var saveDialog = new SaveFileDialog())
                    {
                        saveDialog.Filter = "All files (*.*)|*.*|PDF files (*.pdf)|*.pdf|Word files (*.docx)|*.docx|Excel files (*.xlsx)|*.xlsx|Image files (*.jpg;*.png)|*.jpg;*.png";
                        saveDialog.Title = "Lưu file lý lịch - Vui lòng chọn định dạng phù hợp";
                        saveDialog.FileName = $"LyLich_{canBo.HoTen?.Replace(" ", "_").Replace("/", "_").Replace("\\", "_")}";
                        saveDialog.FilterIndex = 1; // Mặc định chọn "All files"

                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            await File.WriteAllBytesAsync(saveDialog.FileName, canBo.File_LyLich);
                            MessageBox.Show("Tải file thành công!\nLưu ý: Hãy đảm bảo extension file phù hợp với nội dung để mở được file.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Mở file sau khi tải
                            try
                            {
                                Process.Start(new ProcessStartInfo(saveDialog.FileName) { UseShellExecute = true });
                            }
                            catch
                            {
                                // Nếu không mở được file, chỉ thông báo đã tải thành công
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadFilterData()
        {
            try
            {
                using (var context = new DAContext())
                {
                    // Load học vị
                    var hocViList = await context.CanBo
                        .Where(cb => !string.IsNullOrEmpty(cb.HocVi))
                        .Select(cb => cb.HocVi)
                        .Distinct()
                        .ToListAsync();

                    cmbHocVi.Items.Clear();
                    cmbHocVi.Items.Add("-- Tất cả --");
                    foreach (var hocVi in hocViList)
                    {
                        if (hocVi != null)
                            cmbHocVi.Items.Add(hocVi);
                    }
                    cmbHocVi.SelectedIndex = 0;

                    // Load phòng ban
                    var phongBanList = await context.CanBo
                        .Where(cb => !string.IsNullOrEmpty(cb.PhongBan))
                        .Select(cb => cb.PhongBan)
                        .Distinct()
                        .ToListAsync();

                    cmbPhongBan.Items.Clear();
                    cmbPhongBan.Items.Add("-- Tất cả --");
                    foreach (var phongBan in phongBanList)
                    {
                        if (phongBan != null)
                            cmbPhongBan.Items.Add(phongBan);
                    }
                    cmbPhongBan.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu lọc: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmQuanLyCanBo_Load(object sender, EventArgs e)
        {
            LoadFilterData();
        }

        private void ExportSelectedRecord(bool isWordExport)
        {
            var selectedCanBo = (CanBo)dgvCanBo.SelectedRows[0].DataBoundItem;
            if (selectedCanBo == null) return;

            string fileExtension = isWordExport ? ".docx" : ".xlsx";
            string filter = isWordExport ? "Word files (*.docx)|*.docx" : AppConstants.Files.ExcelFilter;
            string title = isWordExport ? "Lưu file Word" : "Lưu file Excel";

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = filter,
                Title = title,
                FileName = $"ChiTietCanBo_{selectedCanBo.MaCanBo}_{DateTime.Now:yyyyMMdd_HHmmss}{fileExtension}"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (isWordExport)
                {
                    ExportSelectedRecordToWord(saveFileDialog.FileName, selectedCanBo.MaCanBo);
                }
                else
                {
                    ExportSelectedRecordToExcel(saveFileDialog.FileName, selectedCanBo.MaCanBo);
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
                FileName = $"DanhSachCanBo_{DateTime.Now:yyyyMMdd_HHmmss}{fileExtension}"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (isWordExport)
                {
                    ExportAllRecordsToWord(saveFileDialog.FileName);
                }
                else
                {
                    ExportAllRecordsToExcel(saveFileDialog.FileName);
                }
                ShowSuccessMessage($"Xuất {(isWordExport ? "Word" : "Excel")} thành công!\nFile đã được lưu tại: {saveFileDialog.FileName}");
            }
        }
    }
}
