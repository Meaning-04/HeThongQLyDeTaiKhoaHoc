using Microsoft.EntityFrameworkCore;
using Models.HandleData;
using Models.Models;

namespace WinFormsApp1
{
    public partial class frmThemThanhVien : Form
    {
        private int deTaiId;

        public int SelectedCanBoId { get; private set; }
        public VaiTroThamGiaEnum SelectedVaiTro { get; private set; }

        public frmThemThanhVien(int deTaiId)
        {
            this.deTaiId = deTaiId;
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"LoadData: deTaiId = {deTaiId}");

                using (var context = new DAContext())
                {
                    // Load danh sách cán bộ chưa tham gia đề tài này
                    var existingCanBoIds = await context.VaiTroThamGia
                        .Where(vt => vt.MaDeTai == deTaiId)
                        .Select(vt => vt.MaCanBo)
                        .ToListAsync();

                    System.Diagnostics.Debug.WriteLine($"Existing CanBo IDs: {string.Join(", ", existingCanBoIds)}");

                    var availableCanBo = await context.CanBo
                        .Where(cb => !existingCanBoIds.Contains(cb.MaCanBo))
                        .OrderBy(cb => cb.HoTen)
                        .ToListAsync();

                    System.Diagnostics.Debug.WriteLine($"Available CanBo count: {availableCanBo.Count}");

                    // Setup vai trò combo box trước
                    cmbVaiTro.Items.Clear();
                    cmbVaiTro.Items.Add("Chủ nhiệm");
                    cmbVaiTro.Items.Add("Tham gia");
                    cmbVaiTro.SelectedIndex = 1; // Mặc định là "Tham gia"

                    System.Diagnostics.Debug.WriteLine($"VaiTro selected: {cmbVaiTro.SelectedItem}");

                    // Setup cán bộ combo box
                    cmbCanBo.Items.Clear();

                    if (availableCanBo.Count == 0)
                    {
                        MessageBox.Show("Không có cán bộ nào khả dụng để thêm vào đề tài này!\n\nTất cả cán bộ đã tham gia đề tài hoặc không có cán bộ nào trong hệ thống.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                        return;
                    }

                    foreach (var canBo in availableCanBo)
                    {
                        var item = new ComboBoxItem { Text = canBo.HoTen ?? "N/A", Value = canBo.MaCanBo };
                        cmbCanBo.Items.Add(item);
                        System.Diagnostics.Debug.WriteLine($"Added CanBo: {item.Text} (ID: {item.Value})");
                    }

                    if (cmbCanBo.Items.Count > 0)
                    {
                        cmbCanBo.SelectedIndex = 0;
                        var selectedItem = (ComboBoxItem)cmbCanBo.SelectedItem;
                        System.Diagnostics.Debug.WriteLine($"Selected first CanBo: {selectedItem.Text} (ID: {selectedItem.Value})");
                    }

                    // Force refresh ComboBox
                    cmbCanBo.Refresh();
                    cmbVaiTro.Refresh();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in LoadData: {ex}");
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}\n\nChi tiết: {ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                var selectedItem = (ComboBoxItem)cmbCanBo.SelectedItem;
                SelectedCanBoId = selectedItem.Value;
                SelectedVaiTro = cmbVaiTro.SelectedIndex == 0 ? VaiTroThamGiaEnum.ChuNhiem : VaiTroThamGiaEnum.ThamGia;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (cmbCanBo.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn cán bộ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCanBo.Focus();
                return false;
            }

            if (cmbVaiTro.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn vai trò!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbVaiTro.Focus();
                return false;
            }

            return true;
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; } = string.Empty;
        public int Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
