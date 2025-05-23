using Microsoft.EntityFrameworkCore;
using Models.Models;
using System.Data;

namespace WinFormsApp1
{
    public partial class frmTaiKhoan : BaseForm
    {
        private bool isEditing = false;
        private int currentTaiKhoanId = 0;

        public frmTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
            LoadTaiKhoanData();
            SetButtonStates(false);
            ClearInputs();

            // Thiết lập tooltip cho các button
            SetupTooltips();
        }

        private void SetupTooltips()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnThem, "Thêm tài khoản mới");
            toolTip.SetToolTip(btnSua, "Sửa thông tin tài khoản đã chọn");
            toolTip.SetToolTip(btnXoa, "Xóa tài khoản đã chọn");
            toolTip.SetToolTip(btnResetMatKhau, "Đặt lại mật khẩu về '123'");
            toolTip.SetToolTip(btnLuu, "Lưu thông tin tài khoản");
            toolTip.SetToolTip(btnHuy, "Hủy thao tác hiện tại");
        }

        private async void LoadComboBoxData()
        {
            try
            {
                // Load vai trò
                cmbVaiTro.Items.Clear();
                cmbVaiTro.Items.Add("Admin");
                cmbVaiTro.Items.Add("User");

                // Load danh sách cán bộ using DbService
                var canBoList = await ExecuteDbOperationAsync(async context =>
                {
                    return await context.CanBo
                        .Select(cb => new { cb.MaCanBo, DisplayText = $"{cb.MaCanBo} - {cb.HoTen}" })
                        .ToListAsync();
                }, "Lỗi khi tải danh sách cán bộ");

                cmbCanBo.DataSource = canBoList;
                cmbCanBo.DisplayMember = "DisplayText";
                cmbCanBo.ValueMember = "MaCanBo";
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi khi tải dữ liệu ComboBox", ex);
            }
        }

        private async void LoadTaiKhoanData()
        {
            try
            {
                var taiKhoanList = await ExecuteDbOperationAsync(async context =>
                {
                    return await context.TaiKhoan
                        .Include(tk => tk.CanBo)
                        .Select(tk => new
                        {
                            STT = tk.MaTaiKhoan,
                            TenCanBo = tk.CanBo.HoTen,
                            TenDangNhap = tk.TenDangNhap,
                            MatKhau = "******", // Ẩn mật khẩu
                            VaiTro = tk.VaiTro.ToString(),
                            MaTaiKhoan = tk.MaTaiKhoan,
                            MaCanBo = tk.MaCanBo,
                            MatKhauThuc = tk.MatKhau
                        })
                        .ToListAsync();
                }, "Lỗi khi tải dữ liệu tài khoản");

                dgvTaiKhoan.DataSource = taiKhoanList;

                // Cấu hình DataGridView
                if (dgvTaiKhoan.Columns.Count > 0)
                {
                    dgvTaiKhoan.Columns["STT"].HeaderText = "STT";
                    dgvTaiKhoan.Columns["STT"].Width = 40;
                    dgvTaiKhoan.Columns["TenCanBo"].HeaderText = "Tên Cán Bộ";
                    dgvTaiKhoan.Columns["TenDangNhap"].HeaderText = "Tên Đăng Nhập";
                    dgvTaiKhoan.Columns["MatKhau"].HeaderText = "Mật Khẩu";
                    dgvTaiKhoan.Columns["MatKhau"].Width = 100;
                    dgvTaiKhoan.Columns["VaiTro"].HeaderText = "Vai Trò";
                    dgvTaiKhoan.Columns["VaiTro"].Width = 80;

                    // Ẩn các cột không cần thiết
                    dgvTaiKhoan.Columns["MaTaiKhoan"].Visible = false;
                    dgvTaiKhoan.Columns["MaCanBo"].Visible = false;
                    dgvTaiKhoan.Columns["MatKhauThuc"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi khi tải dữ liệu tài khoản", ex);
            }
        }

        private void dgvTaiKhoan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow != null && !isEditing)
            {
                var row = dgvTaiKhoan.CurrentRow;
                txtMaTaiKhoan.Text = row.Cells["MaTaiKhoan"].Value?.ToString();
                txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value?.ToString();
                txtMatKhau.Text = row.Cells["MatKhauThuc"].Value?.ToString();
                cmbVaiTro.Text = row.Cells["VaiTro"].Value?.ToString();
                cmbCanBo.SelectedValue = row.Cells["MaCanBo"].Value;

                currentTaiKhoanId = Convert.ToInt32(row.Cells["MaTaiKhoan"].Value);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isEditing = true;
            currentTaiKhoanId = 0;
            ClearInputs();
            SetButtonStates(true);
            txtTenDangNhap.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            isEditing = true;
            SetButtonStates(true);
            txtTenDangNhap.Focus();
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null)
            {
                ShowWarningMessage("Vui lòng chọn tài khoản cần xóa!");
                return;
            }

            if (!AskConfirmation("Bạn có chắc chắn muốn xóa tài khoản này?"))
                return;

            try
            {
                await ExecuteDbOperationAsync(async context =>
                {
                    var taiKhoan = await context.TaiKhoan.FindAsync(currentTaiKhoanId);
                    if (taiKhoan != null)
                    {
                        context.TaiKhoan.Remove(taiKhoan);
                        await context.SaveChangesAsync();
                    }
                }, "Lỗi khi xóa tài khoản");

                LoadTaiKhoanData();
                ClearInputs();
                ShowSuccessMessage("Xóa tài khoản thành công!");
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi khi xóa tài khoản", ex);
            }
        }

        private async void btnResetMatKhau_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null)
            {
                ShowWarningMessage("Vui lòng chọn tài khoản cần reset mật khẩu!");
                return;
            }

            if (!AskConfirmation("Bạn có chắc chắn muốn reset mật khẩu về '123'?"))
                return;

            try
            {
                await ExecuteDbOperationAsync(async context =>
                {
                    var taiKhoan = await context.TaiKhoan.FindAsync(currentTaiKhoanId);
                    if (taiKhoan != null)
                    {
                        taiKhoan.MatKhau = "123";
                        await context.SaveChangesAsync();
                    }
                }, "Lỗi khi reset mật khẩu");

                LoadTaiKhoanData();
                ShowSuccessMessage("Reset mật khẩu thành công! Mật khẩu mới là: 123");
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi khi reset mật khẩu", ex);
            }
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                if (currentTaiKhoanId == 0) // Thêm mới
                {
                    string tenDangNhap = txtTenDangNhap.Text.Trim();
                    int maCanBo = (int)cmbCanBo.SelectedValue;

                    // Kiểm tra tên đăng nhập và cán bộ đã tồn tại
                    var validationResult = await ExecuteDbOperationAsync(async context =>
                    {
                        bool tenDangNhapExists = await context.TaiKhoan.AnyAsync(tk => tk.TenDangNhap == tenDangNhap);
                        bool canBoExists = await context.TaiKhoan.AnyAsync(tk => tk.MaCanBo == maCanBo);
                        return new { TenDangNhapExists = tenDangNhapExists, CanBoExists = canBoExists };
                    }, "Lỗi khi kiểm tra dữ liệu");

                    if (validationResult.TenDangNhapExists)
                    {
                        ShowErrorMessage("Tên đăng nhập đã tồn tại!", new Exception());
                        return;
                    }

                    if (validationResult.CanBoExists)
                    {
                        ShowErrorMessage("Cán bộ này đã có tài khoản!", new Exception());
                        return;
                    }

                    // Thêm tài khoản mới
                    await ExecuteDbOperationAsync(async context =>
                    {
                        var newTaiKhoan = new TaiKhoan
                        {
                            TenDangNhap = tenDangNhap,
                            MatKhau = txtMatKhau.Text.Trim(),
                            VaiTro = (VaiTroTaiKhoan)Enum.Parse(typeof(VaiTroTaiKhoan), cmbVaiTro.Text),
                            MaCanBo = maCanBo
                        };

                        context.TaiKhoan.Add(newTaiKhoan);
                        await context.SaveChangesAsync();
                    }, "Lỗi khi thêm tài khoản");

                    ShowSuccessMessage("Thêm tài khoản thành công!");
                }
                else // Cập nhật
                {
                    string tenDangNhap = txtTenDangNhap.Text.Trim();
                    int maCanBo = (int)cmbCanBo.SelectedValue;

                    // Kiểm tra tên đăng nhập và cán bộ đã tồn tại (trừ tài khoản hiện tại)
                    var validationResult = await ExecuteDbOperationAsync(async context =>
                    {
                        bool tenDangNhapExists = await context.TaiKhoan.AnyAsync(tk => tk.TenDangNhap == tenDangNhap && tk.MaTaiKhoan != currentTaiKhoanId);
                        bool canBoExists = await context.TaiKhoan.AnyAsync(tk => tk.MaCanBo == maCanBo && tk.MaTaiKhoan != currentTaiKhoanId);
                        return new { TenDangNhapExists = tenDangNhapExists, CanBoExists = canBoExists };
                    }, "Lỗi khi kiểm tra dữ liệu");

                    if (validationResult.TenDangNhapExists)
                    {
                        ShowErrorMessage("Tên đăng nhập đã tồn tại!", new Exception());
                        return;
                    }

                    if (validationResult.CanBoExists)
                    {
                        ShowErrorMessage("Cán bộ này đã có tài khoản khác!", new Exception());
                        return;
                    }

                    // Cập nhật tài khoản
                    await ExecuteDbOperationAsync(async context =>
                    {
                        var taiKhoan = await context.TaiKhoan.FindAsync(currentTaiKhoanId);
                        if (taiKhoan != null)
                        {
                            taiKhoan.TenDangNhap = tenDangNhap;
                            taiKhoan.MatKhau = txtMatKhau.Text.Trim();
                            taiKhoan.VaiTro = (VaiTroTaiKhoan)Enum.Parse(typeof(VaiTroTaiKhoan), cmbVaiTro.Text);
                            taiKhoan.MaCanBo = maCanBo;

                            await context.SaveChangesAsync();
                        }
                    }, "Lỗi khi cập nhật tài khoản");

                    ShowSuccessMessage("Cập nhật tài khoản thành công!");
                }

                LoadTaiKhoanData();
                isEditing = false;
                SetButtonStates(false);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi khi lưu tài khoản", ex);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            isEditing = false;
            SetButtonStates(false);
            if (dgvTaiKhoan.CurrentRow != null)
            {
                dgvTaiKhoan_SelectionChanged(sender, e);
            }
            else
            {
                ClearInputs();
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenDangNhap.Focus();
                return false;
            }

            // Kiểm tra độ dài tên đăng nhập
            if (txtTenDangNhap.Text.Trim().Length < 3)
            {
                MessageBox.Show("Tên đăng nhập phải có ít nhất 3 ký tự!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenDangNhap.Focus();
                return false;
            }

            // Kiểm tra ký tự đặc biệt trong tên đăng nhập
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtTenDangNhap.Text.Trim(), @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("Tên đăng nhập chỉ được chứa chữ cái, số và dấu gạch dưới!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenDangNhap.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Focus();
                return false;
            }

            // Kiểm tra độ dài mật khẩu
            if (txtMatKhau.Text.Trim().Length < 3)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 3 ký tự!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Focus();
                return false;
            }

            if (cmbVaiTro.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn vai trò!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbVaiTro.Focus();
                return false;
            }

            if (cmbCanBo.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn cán bộ!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCanBo.Focus();
                return false;
            }

            return true;
        }

        private void SetButtonStates(bool editing)
        {
            btnThem.Enabled = !editing;
            btnSua.Enabled = !editing && dgvTaiKhoan.CurrentRow != null;
            btnXoa.Enabled = !editing && dgvTaiKhoan.CurrentRow != null;
            btnResetMatKhau.Enabled = !editing && dgvTaiKhoan.CurrentRow != null;
            btnLuu.Enabled = editing;
            btnHuy.Enabled = editing;

            txtTenDangNhap.ReadOnly = !editing;
            txtMatKhau.ReadOnly = !editing;
            cmbVaiTro.Enabled = editing;
            cmbCanBo.Enabled = editing;
        }

        private void ClearInputs()
        {
            txtMaTaiKhoan.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cmbVaiTro.SelectedIndex = -1;
            cmbCanBo.SelectedIndex = -1;
            currentTaiKhoanId = 0;
        }

        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnResetMatKhau.Enabled = true;
            btnXoa.Enabled = true;
            btnResetMatKhau.Enabled = true;
        }

        private void dgvTaiKhoan_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnSua.Enabled = true;
            btnResetMatKhau.Enabled = true;
            btnXoa.Enabled = true;
            btnResetMatKhau.Enabled = true;
        }
    }
}
