using Microsoft.EntityFrameworkCore;
using Models.Models;
using WinFormsApp1.Constants;
using WinFormsApp1.Helpers;

namespace WinFormsApp1
{
    public partial class frmThemDeTai : BaseValidationForm
    {
        private int? deTaiId; // null = thêm mới, có giá trị = sửa

        public int? NewDeTaiId { get; private set; }

        public frmThemDeTai(int? deTaiId = null)
        {
            this.deTaiId = deTaiId;
            InitializeComponent();

            // Set form title after InitializeComponent
            this.Text = deTaiId.HasValue ? "Sửa thông tin đề tài" : "Thêm đề tài mới";

            if (deTaiId.HasValue)
            {
                LoadDeTaiData();
            }
        }

        protected override void SetupValidation()
        {
            // Add validation rules using ValidationHelper
            AddValidationRule(txtTenDeTai, value => ValidationHelper.ValidateRequired(value, "tên đề tài"), "tên đề tài");
            AddValidationRule(txtLinhVuc, value => ValidationHelper.ValidateRequired(value, "lĩnh vực"), "lĩnh vực");
            AddValidationRule(cmbCapQuanLy, "cấp quản lý");

            // Custom validation for date range
            AddValidationRule(dtpThoiGianKetThuc, control =>
            {
                var startDate = dtpThoiGianBatDau.Value;
                var endDate = ((DateTimePicker)control).Value;
                return ValidationHelper.ValidateDateRange(startDate, endDate);
            }, "thời gian");
        }

        // Validation is now handled by BaseValidationForm



        private async void LoadDeTaiData()
        {
            if (!deTaiId.HasValue) return;

            try
            {
                var deTai = await ExecuteDbOperationAsync(async context =>
                {
                    return await context.DeTai.FirstOrDefaultAsync(dt => dt.MaDeTai == deTaiId.Value);
                }, AppConstants.Messages.ErrorLoadingData);

                if (deTai != null)
                {
                    txtTenDeTai.Text = deTai.TenDeTai;
                    txtMoTa.Text = deTai.MoTaTomTat;
                    txtLinhVuc.Text = deTai.LinhVuc;

                    if (deTai.ThoiGianBatDau.HasValue)
                        dtpThoiGianBatDau.Value = deTai.ThoiGianBatDau.Value;
                    if (deTai.ThoiGianKetThuc.HasValue)
                        dtpThoiGianKetThuc.Value = deTai.ThoiGianKetThuc.Value;

                    // Set cấp quản lý
                    var capQuanLyMapping = new Dictionary<string, int>
                    {
                        { "NhaNuoc", 0 }, { "Bo", 1 }, { "Nganh", 2 }, { "CoSo", 3 }
                    };

                    if (capQuanLyMapping.ContainsKey(deTai.CapQuanLy.ToString()))
                    {
                        cmbCapQuanLy.SelectedIndex = capQuanLyMapping[deTai.CapQuanLy.ToString()];
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(AppConstants.Messages.ErrorLoadingData, ex);
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
                DeTai deTai;

                if (deTaiId.HasValue)
                {
                    // Sửa đề tài
                    deTai = await context.DeTai.FirstOrDefaultAsync(dt => dt.MaDeTai == deTaiId.Value);
                    if (deTai == null)
                    {
                        ShowErrorMessage("Không tìm thấy đề tài!", new Exception());
                        return false;
                    }
                }
                else
                {
                    // Thêm mới đề tài
                    deTai = new DeTai();
                    context.DeTai.Add(deTai);
                }

                deTai.TenDeTai = txtTenDeTai.Text.Trim();
                deTai.MoTaTomTat = txtMoTa.Text.Trim();
                deTai.LinhVuc = txtLinhVuc.Text.Trim();
                deTai.ThoiGianBatDau = dtpThoiGianBatDau.Value;
                deTai.ThoiGianKetThuc = dtpThoiGianKetThuc.Value;

                // Map ComboBox selection to enum
                var capQuanLyValues = new[] { CapQuanLy.NhaNuoc, CapQuanLy.Bo, CapQuanLy.Nganh, CapQuanLy.CoSo };
                deTai.CapQuanLy = capQuanLyValues[cmbCapQuanLy.SelectedIndex];

                await context.SaveChangesAsync();

                if (!deTaiId.HasValue)
                {
                    NewDeTaiId = deTai.MaDeTai;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
                return true;
            }, deTaiId.HasValue ? AppConstants.Messages.ErrorUpdatingData : AppConstants.Messages.ErrorAddingData);
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
