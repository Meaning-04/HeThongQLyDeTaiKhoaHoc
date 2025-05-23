using Microsoft.EntityFrameworkCore;
using Models.Models;
using WinFormsApp1.Constants;
using WinFormsApp1.Helpers;

namespace WinFormsApp1
{
    public partial class frmThemSanPhamIII : BaseValidationForm
    {
        private int deTaiId;
        private int? sanPhamId; // null = thêm mới, có giá trị = sửa
        private byte[]? fileData;

        public frmThemSanPhamIII(int deTaiId, int? sanPhamId = null)
        {
            this.deTaiId = deTaiId;
            this.sanPhamId = sanPhamId;
            InitializeComponent();

            // Set form title after InitializeComponent
            this.Text = sanPhamId.HasValue ? "Sửa sản phẩm dạng III" : "Thêm sản phẩm dạng III";

            LoadLoaiBaiBao();

            if (sanPhamId.HasValue)
            {
                LoadSanPhamData();
            }
        }

        protected override void SetupValidation()
        {
            // Add validation rules using ValidationHelper
            AddValidationRule(txtTieuDe, value => ValidationHelper.ValidateRequired(value, "tiêu đề"), "tiêu đề");
            AddValidationRule(cmbLoaiBaiBao, "loại bài báo");
        }

        private void LoadLoaiBaiBao()
        {
            cmbLoaiBaiBao.Items.Clear();
            cmbLoaiBaiBao.Items.AddRange(new string[] {
                "BangSangChe",
                "GiaiPhapHuuIch",
                "BaiBao"
            });
        }

        // Validation is now handled by BaseValidationForm





        private async void LoadSanPhamData()
        {
            if (!sanPhamId.HasValue) return;

            await ExecuteDbOperationAsync(async context =>
            {
                var sanPham = await context.ChiTietSanPham_DangIII.FirstOrDefaultAsync(sp => sp.MaSanPham_III == sanPhamId.Value);
                if (sanPham != null)
                {
                    txtTieuDe.Text = sanPham.TenSanPham_III;
                    txtTacGia.Text = sanPham.NoiCongBo ?? string.Empty;

                    // Set loại sản phẩm
                    string loaiSanPham = sanPham.LoaiSanPham_III.ToString();
                    int index = cmbLoaiBaiBao.Items.IndexOf(loaiSanPham);
                    if (index >= 0)
                        cmbLoaiBaiBao.SelectedIndex = index;

                    // Check file
                    if (sanPham.file_SanPham_III != null && sanPham.file_SanPham_III.Length > 0)
                    {
                        fileData = sanPham.file_SanPham_III;
                        lblFile.Text = $"Có file đính kèm ({fileData.Length / 1024} KB)";
                        lblFile.ForeColor = Color.Green;
                    }
                    else
                    {
                        lblFile.Text = "Chưa có file đính kèm";
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
                saveFileDialog.FileName = $"SanPhamIII_{sanPhamId}";

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
                ChiTietSanPham_DangIII sanPham;

                if (sanPhamId.HasValue)
                {
                    // Sửa sản phẩm
                    sanPham = await context.ChiTietSanPham_DangIII.FirstOrDefaultAsync(sp => sp.MaSanPham_III == sanPhamId.Value);
                    if (sanPham == null)
                    {
                        ShowErrorMessage("Không tìm thấy sản phẩm!", new Exception());
                        return false;
                    }
                }
                else
                {
                    // Thêm mới sản phẩm
                    sanPham = new ChiTietSanPham_DangIII { MaDeTai = deTaiId };
                    context.ChiTietSanPham_DangIII.Add(sanPham);
                }

                // Set các thuộc tính theo model mới
                sanPham.TenSanPham_III = txtTieuDe.Text.Trim();
                sanPham.NoiCongBo = txtTacGia.Text.Trim();

                // Parse enum từ combobox
                if (cmbLoaiBaiBao.SelectedItem != null)
                {
                    string selectedValue = cmbLoaiBaiBao.SelectedItem.ToString()!;
                    if (Enum.TryParse<LoaiSanPham_III>(selectedValue, out var loaiSanPham))
                    {
                        sanPham.LoaiSanPham_III = loaiSanPham;
                    }
                }

                // Save file if selected
                if (fileData != null && fileData.Length > 0)
                {
                    sanPham.file_SanPham_III = fileData;
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
