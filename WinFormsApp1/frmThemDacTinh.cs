using Microsoft.EntityFrameworkCore;
using Models.Models;
using WinFormsApp1.Helpers;

namespace WinFormsApp1
{
    public partial class frmThemDacTinh : BaseValidationForm
    {
        private int sanPhamId;
        private int? dacTinhId; // null = thêm mới, có giá trị = sửa

        public frmThemDacTinh(int sanPhamId, int? dacTinhId = null)
        {
            this.sanPhamId = sanPhamId;
            this.dacTinhId = dacTinhId;
            InitializeComponent();

            // Set form title after InitializeComponent
            this.Text = dacTinhId.HasValue ? "Sửa đặc tính kỹ thuật" : "Thêm đặc tính kỹ thuật";

            if (dacTinhId.HasValue)
            {
                LoadDacTinhData();
            }
        }

        protected override void SetupValidation()
        {
            // Add validation rules using ValidationHelper
            AddValidationRule(txtTenDacTinh, value => ValidationHelper.ValidateRequired(value, "thông số"), "thông số");
        }

        // Validation is now handled by BaseValidationForm

        private async void LoadDacTinhData()
        {
            if (!dacTinhId.HasValue) return;

            await ExecuteDbOperationAsync(async context =>
            {
                var dacTinh = await context.DacTinhKyThuat.FirstOrDefaultAsync(dt => dt.MaDacTinhKyThuat == dacTinhId.Value);
                if (dacTinh != null)
                {
                    txtTenDacTinh.Text = dacTinh.ThongSo ?? string.Empty;
                    txtGiaTri.Text = dacTinh.GiaTri?.ToString() ?? string.Empty;
                    txtDonVi.Text = dacTinh.DonViDo ?? string.Empty;
                    txtMoTa.Text = dacTinh.ChiChu ?? string.Empty;
                }
                return true;
            });
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
                DacTinhKyThuat dacTinh;

                if (dacTinhId.HasValue)
                {
                    // Sửa đặc tính
                    dacTinh = await context.DacTinhKyThuat.FirstOrDefaultAsync(dt => dt.MaDacTinhKyThuat == dacTinhId.Value);
                    if (dacTinh == null)
                    {
                        ShowErrorMessage("Không tìm thấy đặc tính!", new Exception());
                        return false;
                    }
                }
                else
                {
                    // Thêm mới đặc tính
                    dacTinh = new DacTinhKyThuat { MaSanPham_I = sanPhamId };
                    context.DacTinhKyThuat.Add(dacTinh);
                }

                // Set các thuộc tính theo model mới
                dacTinh.ThongSo = string.IsNullOrWhiteSpace(txtTenDacTinh.Text) ? null : txtTenDacTinh.Text.Trim();
                dacTinh.DonViDo = string.IsNullOrWhiteSpace(txtDonVi.Text) ? null : txtDonVi.Text.Trim();
                dacTinh.ChiChu = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim();

                // Parse giá trị số
                if (decimal.TryParse(txtGiaTri.Text.Trim(), out decimal giaTri))
                {
                    dacTinh.GiaTri = giaTri;
                }
                else
                {
                    dacTinh.GiaTri = null;
                }

                await context.SaveChangesAsync();

                this.DialogResult = DialogResult.OK;
                this.Close();
                return true;
            });
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
