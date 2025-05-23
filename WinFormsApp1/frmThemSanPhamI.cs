using Microsoft.EntityFrameworkCore;
using Models.Models;
using WinFormsApp1.Constants;
using WinFormsApp1.Helpers;

namespace WinFormsApp1
{
    public partial class frmThemSanPhamI : BaseValidationForm
    {
        private int deTaiId;
        private int? sanPhamId; // null = thêm mới, có giá trị = sửa
        private byte[]? fileData;

        public frmThemSanPhamI(int deTaiId, int? sanPhamId = null)
        {
            this.deTaiId = deTaiId;
            this.sanPhamId = sanPhamId;
            InitializeComponent();

            // Set form title after InitializeComponent
            this.Text = sanPhamId.HasValue ? "Sửa sản phẩm dạng I" : "Thêm sản phẩm dạng I";

            LoadDonViHanhChinh();

            if (sanPhamId.HasValue)
            {
                LoadSanPhamData();
            }
        }

        protected override void SetupValidation()
        {
            // Add validation rules using ValidationHelper
            AddValidationRule(txtTenSanPham, value => ValidationHelper.ValidateRequired(value, "tên sản phẩm"), "tên sản phẩm");
        }

        // Override ValidateCustomRules to handle ComboBox validation manually
        protected override bool ValidateCustomRules()
        {
            // Validate ComboBox manually
            if (cmbDonViHanhChinh.SelectedIndex == -1)
            {
                ShowErrorMessage("Vui lòng chọn đơn vị hành chính!", new Exception());
                cmbDonViHanhChinh.Focus();
                return false;
            }

            if (cmbDonViHanhChinh.SelectedItem is ComboBoxItem selectedItem)
            {
                if (selectedItem.Value < 0)
                {
                    ShowErrorMessage("Vui lòng chọn đơn vị hành chính!", new Exception());
                    cmbDonViHanhChinh.Focus();
                    return false;
                }
            }
            else
            {
                ShowErrorMessage("Dữ liệu đơn vị hành chính không hợp lệ!", new Exception());
                cmbDonViHanhChinh.Focus();
                return false;
            }

            return true;
        }

        // Validation is now handled by BaseValidationForm





        private async void LoadDonViHanhChinh()
        {
            await ExecuteDbOperationAsync(async context =>
            {
                var donViList = await context.DonViHanhChinh.ToListAsync();
                cmbDonViHanhChinh.Items.Clear();
                cmbDonViHanhChinh.Items.Add(new ComboBoxItem { Text = "-- Chọn đơn vị --", Value = -1 });

                foreach (var donVi in donViList)
                {
                    cmbDonViHanhChinh.Items.Add(new ComboBoxItem { Text = donVi.TinhThanh, Value = donVi.MaDonViHC });
                }

                cmbDonViHanhChinh.SelectedIndex = 0;
                return true;
            });
        }

        private async void LoadSanPhamData()
        {
            if (!sanPhamId.HasValue) return;

            await ExecuteDbOperationAsync(async context =>
            {
                var sanPham = await context.ChiTietSanPham_DangI.FirstOrDefaultAsync(sp => sp.MaSanPham_I == sanPhamId.Value);
                if (sanPham != null)
                {
                    txtTenSanPham.Text = sanPham.TenSanPham_I;

                    // Set đơn vị hành chính
                    for (int i = 0; i < cmbDonViHanhChinh.Items.Count; i++)
                    {
                        var item = (ComboBoxItem)cmbDonViHanhChinh.Items[i]!;
                        if (item.Value == sanPham.MaDonViHC)
                        {
                            cmbDonViHanhChinh.SelectedIndex = i;
                            break;
                        }
                    }

                    // Load file data if exists
                    if (sanPham.file_SanPham_I != null)
                    {
                        fileData = sanPham.file_SanPham_I;
                        lblFile.Text = $"File đã có ({fileData.Length / 1024} KB)";
                        lblFile.ForeColor = Color.Green;
                    }
                }
                return true;
            });
        }

        private void BtnChonFile_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = AppConstants.Files.AllFileFilter;
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        fileData = File.ReadAllBytes(openFileDialog.FileName);
                        lblFile.Text = $"Đã chọn: {Path.GetFileName(openFileDialog.FileName)} ({fileData.Length / 1024} KB)";
                        lblFile.ForeColor = Color.Green;
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage("Lỗi khi đọc file", ex);
                    }
                }
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
                ChiTietSanPham_DangI sanPham;

                if (sanPhamId.HasValue)
                {
                    // Sửa sản phẩm
                    sanPham = await context.ChiTietSanPham_DangI.FirstOrDefaultAsync(sp => sp.MaSanPham_I == sanPhamId.Value);
                    if (sanPham == null)
                    {
                        ShowErrorMessage("Không tìm thấy sản phẩm!", new Exception());
                        return false;
                    }
                }
                else
                {
                    // Thêm mới sản phẩm
                    sanPham = new ChiTietSanPham_DangI { MaDeTai = deTaiId };
                    context.ChiTietSanPham_DangI.Add(sanPham);
                }

                // Set các thuộc tính theo model mới
                sanPham.TenSanPham_I = txtTenSanPham.Text.Trim();

                // Set đơn vị hành chính (đã được validate bởi BaseValidationForm)
                if (cmbDonViHanhChinh.SelectedItem is ComboBoxItem selectedItem)
                {
                    sanPham.MaDonViHC = selectedItem.Value;
                }

                // Set file data
                if (fileData != null)
                {
                    sanPham.file_SanPham_I = fileData;
                }

                await context.SaveChangesAsync();

                DialogResult = DialogResult.OK;
                Close();
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
