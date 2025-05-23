using Models.HandleData;
using Models.Models;
using WinFormsApp1.Constants;
using WinFormsApp1.Helpers;

namespace WinFormsApp1
{
    public partial class frmThemCanBo : BaseValidationForm
    {
        private int? canBoId; // null = thêm mới, có giá trị = sửa
        private byte[]? fileData;

        public frmThemCanBo(int? canBoId = null)
        {
            this.canBoId = canBoId;
            InitializeComponent();

            // Set form title after InitializeComponent
            this.Text = canBoId.HasValue ? "Sửa thông tin cán bộ" : "Thêm cán bộ mới";

            LoadComboBoxData();

            if (canBoId.HasValue)
            {
                LoadCanBoData();
            }
        }

        protected override void SetupValidation()
        {
            // Add validation rules using the new ValidationHelper
            AddValidationRule(txtHoTen, value => ValidationHelper.ValidateRequired(value, "họ tên"), "họ tên");
            AddValidationRule(txtEmail, value => ValidationHelper.ValidateEmail(value), "email");
            AddValidationRule(txtDienThoai, value => ValidationHelper.ValidatePhoneNumber(value), "điện thoại");
        }



        private void LoadComboBoxData()
        {
            // Load giới tính
            cmbGioiTinh.Items.Clear();
            cmbGioiTinh.Items.Add("Nam");
            cmbGioiTinh.Items.Add("Nữ");
            cmbGioiTinh.SelectedIndex = 0;

            // Set default date
            dtpNgaySinh.Value = DateTime.Now.AddYears(-30);
        }

        private async void LoadCanBoData()
        {
            try
            {
                using (var context = new DAContext())
                {
                    var canBo = await context.CanBo.FindAsync(canBoId.Value);
                    if (canBo != null)
                    {
                        txtHoTen.Text = canBo.HoTen ?? string.Empty;
                        txtChucVu.Text = canBo.ChucVu ?? string.Empty;
                        txtQuanHam.Text = canBo.QuanHam ?? string.Empty;

                        if (canBo.NgaySinh.HasValue)
                            dtpNgaySinh.Value = canBo.NgaySinh.Value;

                        cmbGioiTinh.SelectedItem = canBo.GioiTinh == GioiTinh.Nam ? "Nam" : "Nữ";

                        txtHocVi.Text = canBo.HocVi ?? string.Empty;
                        if (canBo.Nam_HocVi.HasValue)
                            numNamHocVi.Value = canBo.Nam_HocVi.Value;
                        else
                            numNamHocVi.Value = 0;

                        txtHocHam.Text = canBo.HocHam ?? string.Empty;
                        if (canBo.Nam_HocHam.HasValue)
                            numNamHocHam.Value = canBo.Nam_HocHam.Value;
                        else
                            numNamHocHam.Value = 0;

                        txtChucDanhCMKTNV.Text = canBo.ChucDanhCMKTNV ?? string.Empty;
                        if (canBo.Nam_PhongChucDanh.HasValue)
                            numNamPhongChucDanh.Value = canBo.Nam_PhongChucDanh.Value;
                        else
                            numNamPhongChucDanh.Value = 0;

                        txtChuyenNganh.Text = canBo.ChuyenNganh ?? string.Empty;
                        txtDienThoai.Text = canBo.DienThoai ?? string.Empty;
                        txtEmail.Text = canBo.Email ?? string.Empty;
                        txtDiaChi.Text = canBo.DiaChi ?? string.Empty;
                        txtPhongBan.Text = canBo.PhongBan ?? string.Empty;

                        if (canBo.File_LyLich != null)
                        {
                            fileData = canBo.File_LyLich;
                            lblFileStatus.Text = "✅ Đã có file lý lịch";
                            lblFileStatus.ForeColor = Color.Green;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu cán bộ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Validation is now handled by BaseValidationForm

        private async void BtnLuu_Click(object sender, EventArgs e)
        {
            await SaveAsync();
        }

        protected override async Task<bool> PerformSaveOperation()
        {
            return await ExecuteDbOperationAsync(async context =>
            {
                CanBo canBo;

                if (canBoId.HasValue)
                {
                    // Sửa cán bộ
                    canBo = await context.CanBo.FindAsync(canBoId.Value);
                    if (canBo == null)
                    {
                        ShowErrorMessage("Không tìm thấy cán bộ!", new Exception());
                        return false;
                    }
                }
                else
                {
                    // Thêm cán bộ mới
                    canBo = new CanBo();
                    context.CanBo.Add(canBo);
                }

                // Cập nhật thông tin
                canBo.HoTen = txtHoTen.Text.Trim();
                canBo.ChucVu = string.IsNullOrWhiteSpace(txtChucVu.Text) ? null : txtChucVu.Text.Trim();
                canBo.QuanHam = string.IsNullOrWhiteSpace(txtQuanHam.Text) ? null : txtQuanHam.Text.Trim();
                canBo.NgaySinh = dtpNgaySinh.Value.Date;
                canBo.GioiTinh = cmbGioiTinh.SelectedItem.ToString() == "Nam" ? GioiTinh.Nam : GioiTinh.Nu;
                canBo.HocVi = string.IsNullOrWhiteSpace(txtHocVi.Text) ? null : txtHocVi.Text.Trim();
                canBo.Nam_HocVi = numNamHocVi.Value == 0 ? null : (int)numNamHocVi.Value;
                canBo.HocHam = string.IsNullOrWhiteSpace(txtHocHam.Text) ? null : txtHocHam.Text.Trim();
                canBo.Nam_HocHam = numNamHocHam.Value == 0 ? null : (int)numNamHocHam.Value;
                canBo.ChucDanhCMKTNV = string.IsNullOrWhiteSpace(txtChucDanhCMKTNV.Text) ? null : txtChucDanhCMKTNV.Text.Trim();
                canBo.Nam_PhongChucDanh = numNamPhongChucDanh.Value == 0 ? null : (int)numNamPhongChucDanh.Value;
                canBo.ChuyenNganh = string.IsNullOrWhiteSpace(txtChuyenNganh.Text) ? null : txtChuyenNganh.Text.Trim();
                canBo.DienThoai = string.IsNullOrWhiteSpace(txtDienThoai.Text) ? null : txtDienThoai.Text.Trim();
                canBo.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
                canBo.DiaChi = string.IsNullOrWhiteSpace(txtDiaChi.Text) ? null : txtDiaChi.Text.Trim();
                canBo.PhongBan = string.IsNullOrWhiteSpace(txtPhongBan.Text) ? null : txtPhongBan.Text.Trim();

                if (fileData != null)
                {
                    canBo.File_LyLich = fileData;
                }

                await context.SaveChangesAsync();

                this.DialogResult = DialogResult.OK;
                this.Close();
                return true;
            }, canBoId.HasValue ? AppConstants.Messages.ErrorUpdatingData : AppConstants.Messages.ErrorAddingData);
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnChonFile_Click(object sender, EventArgs e)
        {
            using (var openDialog = new OpenFileDialog())
            {
                openDialog.Filter = AppConstants.Files.WordFilter + "|" + AppConstants.Files.PdfFilter + "|" + AppConstants.Files.AllFilesFilter;
                openDialog.Title = "Chọn file lý lịch";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        fileData = File.ReadAllBytes(openDialog.FileName);
                        lblFileStatus.Text = $"✅ Đã chọn: {Path.GetFileName(openDialog.FileName)}";
                        lblFileStatus.ForeColor = Color.Green;
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage(AppConstants.Messages.ErrorFileAccess, ex);
                    }
                }
            }
        }

        private void btnXoaFile_Click(object sender, EventArgs e)
        {
            fileData = null;
            lblFileStatus.Text = "❌ Chưa có file";
            lblFileStatus.ForeColor = Color.Red;
        }
    }
}
