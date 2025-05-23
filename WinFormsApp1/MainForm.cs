using Models.Models;

namespace WinFormsApp1
{
    public partial class MainFormNew : Form
    {
        private TaiKhoan currentUser;

        public MainFormNew(TaiKhoan user)
        {
            InitializeComponent();
            currentUser = user;
            SetupUserInterface();
            LoadDefaultContent();
        }

        private void SetupUserInterface()
        {
            // Hiển thị thông tin người dùng trong StatusBar
            lblUserName.Text = $"Người dùng: {currentUser.CanBo?.HoTen ?? currentUser.TenDangNhap}";

            // Thiết lập quyền truy cập dựa trên vai trò
            if (currentUser.VaiTro == VaiTroTaiKhoan.Admin)
            {
                lblUserRole.Text = "Vai trò: Quản trị viên";
                quanTriMenuItem.Enabled = true;
            }
            else
            {
                lblUserRole.Text = "Vai trò: Người dùng";
                quanTriMenuItem.Enabled = false;
            }

            // Cập nhật thời gian
            UpdateDateTime();
        }

        private void LoadDefaultContent()
        {
            // Mặc định load form Thống kê
            LoadThongKeForm();
        }

        private void UpdateDateTime()
        {
            lblDateTime.Text = $"Ngày giờ: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateDateTime();
        }

        // Event handlers cho MenuStrip
        private void thongKeMenuItem_Click(object sender, EventArgs e)
        {
            LoadThongKeForm();
        }

        private void canBoMenuItem_Click(object sender, EventArgs e)
        {
            LoadCanBoForm();
        }

        private void LoadCanBoForm()
        {
            // Xóa nội dung hiện tại trong panelMain
            panelMain.Controls.Clear();

            // Tạo và load form Quản lý cán bộ
            frmQuanLyCanBo canBoForm = new frmQuanLyCanBo(currentUser)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelMain.Controls.Add(canBoForm);
            canBoForm.Show();
        }

        private void deTaiMenuItem_Click(object sender, EventArgs e)
        {
            LoadDeTaiForm();
        }

        private void LoadDeTaiForm()
        {
            // Xóa nội dung hiện tại trong panelMain
            panelMain.Controls.Clear();

            // Tạo và load form Quản lý đề tài (danh sách) với thông tin user
            frmDeTai deTaiForm = new frmDeTai(currentUser)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelMain.Controls.Add(deTaiForm);
            deTaiForm.Show();
        }

        private void quanTriMenuItem_Click(object sender, EventArgs e)
        {
            if (currentUser.VaiTro != VaiTroTaiKhoan.Admin)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            LoadTaiKhoanForm();
        }

        private void thoatMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close(); // Đóng MainForm, sẽ trigger FormClosed event để hiển thị lại Form1
            }
        }

        private void LoadThongKeForm()
        {
            // Xóa nội dung hiện tại trong panelMain
            panelMain.Controls.Clear();

            // Tạo và load form Thống kê
            frmThongKe thongKeForm = new frmThongKe
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelMain.Controls.Add(thongKeForm);
            thongKeForm.Show();
        }

        private void LoadTaiKhoanForm()
        {
            // Xóa nội dung hiện tại trong panelMain
            panelMain.Controls.Clear();

            // Tạo và load form Quản trị hệ thống
            frmTaiKhoan taiKhoanForm = new frmTaiKhoan
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            panelMain.Controls.Add(taiKhoanForm);
            taiKhoanForm.Show();
        }

        private void LoadFormIntoPanel(string formName)
        {
            // Xóa nội dung hiện tại trong panelMain
            panelMain.Controls.Clear();

            // Tạo label tạm thời để hiển thị tên form
            Label lblTemp = new Label
            {
                Text = $"Form _ {formName}",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                AutoSize = true,
                Anchor = AnchorStyles.None
            };

            // Tính toán vị trí center
            lblTemp.Location = new Point(
                (panelMain.Width - lblTemp.PreferredWidth) / 2,
                (panelMain.Height - lblTemp.PreferredHeight) / 2
            );

            panelMain.Controls.Add(lblTemp);
        }

        private void MainFormNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Chỉ hỏi xác nhận nếu người dùng đóng form bằng nút X, không phải từ menu Thoát
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void lblSystemTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
