using Microsoft.EntityFrameworkCore;
using Models.Models;
using WinFormsApp1.Constants;
using WinFormsApp1.Helpers;

namespace WinFormsApp1
{
    public partial class frmThemSanPhamII : BaseValidationForm
    {
        private int deTaiId;
        private int? sanPhamId; // null = thêm mới, có giá trị = sửa
        private byte[]? fileData;

        public frmThemSanPhamII(int deTaiId, int? sanPhamId = null)
        {
            this.deTaiId = deTaiId;
            this.sanPhamId = sanPhamId;
            InitializeComponent();

            // Set form title after InitializeComponent
            this.Text = sanPhamId.HasValue ? "Sửa sản phẩm dạng II" : "Thêm sản phẩm dạng II";

            LoadLoaiBaoCao();

            if (sanPhamId.HasValue)
            {
                LoadSanPhamData();
            }
        }

        protected override void SetupValidation()
        {
            // Add validation rules using ValidationHelper
            AddValidationRule(txtTenBaoCao, value => ValidationHelper.ValidateRequired(value, "tên báo cáo"), "tên báo cáo");
            AddValidationRule(cmbLoaiBaoCao, "loại báo cáo");
        }

        // Validation is now handled by BaseValidationForm

        private void LoadLoaiBaoCao()
        {
            cmbLoaiBaoCao.Items.Clear();
            cmbLoaiBaoCao.Items.AddRange(new string[] {
                "BaoCao",
                "QuyTrinh",
                "BanVe",
                "BanDo",
                "Khac"
            });
        }

        private async void LoadSanPhamData()
        {
            if (!sanPhamId.HasValue) return;

            await ExecuteDbOperationAsync(async context =>
            {
                var sanPham = await context.ChiTietSanPham_DangII.FirstOrDefaultAsync(sp => sp.MaSanPham_II == sanPhamId.Value);
                if (sanPham != null)
                {
                    txtTenBaoCao.Text = sanPham.TenSanPham_II;

                    // Set loại sản phẩm
                    string loaiSanPham = sanPham.LoaiSanPham_II.ToString();
                    int index = cmbLoaiBaoCao.Items.IndexOf(loaiSanPham);
                    if (index >= 0)
                        cmbLoaiBaoCao.SelectedIndex = index;

                    // Check file
                    if (sanPham.file_SanPham_II != null && sanPham.file_SanPham_II.Length > 0)
                    {
                        fileData = sanPham.file_SanPham_II;
                        lblFile.Text = $"Có file đính kèm ({fileData.Length / 1024} KB)";
                        lblFile.ForeColor = Color.Green;
                    }
                    else
                    {
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

        private void BtnTaiFile_Click(object sender, EventArgs e)
        {
            if (fileData == null || fileData.Length == 0)
            {
                ShowWarningMessage(AppConstants.Messages.NoFileToDownload);
                return;
            }

            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = AppConstants.Files.AllFileFilter;
                saveFileDialog.FileName = $"SanPhamII_{sanPhamId}";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllBytes(saveFileDialog.FileName, fileData);
                        ShowSuccessMessage(AppConstants.Messages.DownloadSuccess);
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage("Lỗi khi tải file", ex);
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
                ChiTietSanPham_DangII sanPham;

                if (sanPhamId.HasValue)
                {
                    // Sửa sản phẩm
                    sanPham = await context.ChiTietSanPham_DangII.FirstOrDefaultAsync(sp => sp.MaSanPham_II == sanPhamId.Value);
                    if (sanPham == null)
                    {
                        ShowErrorMessage("Không tìm thấy sản phẩm!", new Exception());
                        return false;
                    }
                }
                else
                {
                    // Thêm mới sản phẩm
                    sanPham = new ChiTietSanPham_DangII { MaDeTai = deTaiId };
                    context.ChiTietSanPham_DangII.Add(sanPham);
                }

                // Set các thuộc tính theo model mới
                sanPham.TenSanPham_II = txtTenBaoCao.Text.Trim();

                // Parse enum từ combobox
                if (cmbLoaiBaoCao.SelectedItem != null)
                {
                    string selectedValue = cmbLoaiBaoCao.SelectedItem.ToString()!;
                    if (Enum.TryParse<LoaiSanPham_II>(selectedValue, out var loaiSanPham))
                    {
                        sanPham.LoaiSanPham_II = loaiSanPham;
                    }
                }

                // Save file if selected
                if (fileData != null && fileData.Length > 0)
                {
                    sanPham.file_SanPham_II = fileData;
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
