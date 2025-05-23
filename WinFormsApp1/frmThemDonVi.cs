using Microsoft.EntityFrameworkCore;
using Models.Models;
using WinFormsApp1.Helpers;

namespace WinFormsApp1
{
    public partial class frmThemDonVi : BaseValidationForm
    {
        private int deTaiId;
        private int? donViId; // null = thêm mới, có giá trị = sửa

        public frmThemDonVi(int deTaiId, int? donViId = null)
        {
            this.deTaiId = deTaiId;
            this.donViId = donViId;
            InitializeComponent();

            // Set form title after InitializeComponent
            this.Text = donViId.HasValue ? "Sửa đơn vị phối hợp" : "Thêm đơn vị phối hợp";

            if (donViId.HasValue)
            {
                LoadDonViData();
            }
        }

        protected override void SetupValidation()
        {
            // Add validation rules using ValidationHelper
            AddValidationRule(txtTenDonVi, value => ValidationHelper.ValidateRequired(value, "tên đơn vị"), "tên đơn vị");
            AddValidationRule(txtDienThoai, value => ValidationHelper.ValidatePhoneNumber(value), "số điện thoại");
            AddValidationRule(txtEmail, value => ValidationHelper.ValidateEmail(value), "email");
        }

        // Validation is now handled by BaseValidationForm

        private async void LoadDonViData()
        {
            if (!donViId.HasValue) return;

            await ExecuteDbOperationAsync(async context =>
            {
                var donVi = await context.DonViPhoiHop.FirstOrDefaultAsync(dv => dv.MaDonVi == donViId.Value);
                if (donVi != null)
                {
                    txtTenDonVi.Text = donVi.TenDonVi;
                    txtDiaChi.Text = donVi.DiaChi;
                    txtDienThoai.Text = donVi.SoDienThoai;
                    txtEmail.Text = donVi.Email;
                }
                return true;
            });
        }

        private async void BtnLuu_Click(object sender, EventArgs e)
        {
            await SaveAsync();
        }

        protected override async Task<bool> PerformSaveOperation()
        {
            return await ExecuteDbOperationAsync(async context =>
            {
                // Kiểm tra đề tài có tồn tại không
                var deTaiExists = await context.DeTai.AnyAsync(dt => dt.MaDeTai == deTaiId);
                if (!deTaiExists)
                {
                    ShowErrorMessage("Đề tài không tồn tại!", new Exception());
                    return false;
                }

                DonViPhoiHop donVi;

                if (donViId.HasValue)
                {
                    // Sửa đơn vị
                    donVi = await context.DonViPhoiHop.FirstOrDefaultAsync(dv => dv.MaDonVi == donViId.Value);
                    if (donVi == null)
                    {
                        ShowErrorMessage("Không tìm thấy đơn vị cần sửa!", new Exception());
                        return false;
                    }

                    // Kiểm tra đơn vị có đang được liên kết với đề tài này không
                    var isLinkedToDeTai = await context.DeTai_DonVi
                        .AnyAsync(dd => dd.MaDeTai == deTaiId && dd.MaDonVi == donViId.Value);

                    if (!isLinkedToDeTai)
                    {
                        ShowErrorMessage("Đơn vị này không thuộc đề tài hiện tại!", new Exception());
                        return false;
                    }
                }
                else
                {
                    // Thêm mới đơn vị - kiểm tra trùng tên trong cùng đề tài
                    var tenDonVi = txtTenDonVi.Text.Trim();
                    if (!string.IsNullOrEmpty(tenDonVi))
                    {
                        var existingDonViInDeTai = await (from dv in context.DonViPhoiHop
                                                          join dd in context.DeTai_DonVi on dv.MaDonVi equals dd.MaDonVi
                                                          where dd.MaDeTai == deTaiId && dv.TenDonVi == tenDonVi
                                                          select dv).FirstOrDefaultAsync();

                        if (existingDonViInDeTai != null)
                        {
                            ShowErrorMessage("Đơn vị với tên này đã tồn tại trong đề tài!", new Exception());
                            return false;
                        }
                    }

                    donVi = new DonViPhoiHop();
                    context.DonViPhoiHop.Add(donVi);
                }

                // Cập nhật thông tin đơn vị
                donVi.TenDonVi = txtTenDonVi.Text.Trim();
                donVi.DiaChi = txtDiaChi.Text.Trim();
                donVi.SoDienThoai = txtDienThoai.Text.Trim();
                donVi.Email = txtEmail.Text.Trim();

                // Lưu đơn vị trước
                await context.SaveChangesAsync();

                // Nếu là thêm mới, cần liên kết với đề tài
                if (!donViId.HasValue)
                {
                    // Kiểm tra xem liên kết đã tồn tại chưa (double check)
                    var existingLink = await context.DeTai_DonVi
                        .FirstOrDefaultAsync(dd => dd.MaDeTai == deTaiId && dd.MaDonVi == donVi.MaDonVi);

                    if (existingLink == null)
                    {
                        var deTaiDonVi = new DeTai_DonVi
                        {
                            MaDeTai = deTaiId,
                            MaDonVi = donVi.MaDonVi,
                            GhiChu = null
                        };
                        context.DeTai_DonVi.Add(deTaiDonVi);
                        await context.SaveChangesAsync();
                    }
                }

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
