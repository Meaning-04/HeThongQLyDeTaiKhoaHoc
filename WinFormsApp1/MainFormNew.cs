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
            // Mặc định load form Thống kê (sẽ implement sau)
            lblWelcome.Text = $"Chào mừng {currentUser.CanBo?.HoTen ?? currentUser.TenDangNhap} đến với hệ thống!";
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
            // TODO: Load form Thống kê vào panelMain
            LoadFormIntoPanel("Thống kê chung");
        }

        private void canBoMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Load form Quản lý cán bộ vào panelMain
            LoadFormIntoPanel("Quản lý cán bộ");
        }

        private void deTaiMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Load form Quản lý đề tài vào panelMain
            LoadFormIntoPanel("Quản lý đề tài (bao gồm sản phẩm)");
        }

        private void quanTriMenuItem_Click(object sender, EventArgs e)
        {
            if (currentUser.VaiTro != VaiTroTaiKhoan.Admin)
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // TODO: Load form Quản trị hệ thống vào panelMain
            LoadFormIntoPanel("Quản trị hệ thống");
        }

        private void thoatMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi hệ thống?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void LoadFormIntoPanel(string formName)
        {
            // Xóa nội dung hiện tại trong panelMain
            panelMain.Controls.Clear();

            // Tạo label tạm thời để hiển thị tên form
            Label lblTemp = new Label
            {
                Text = $"Đây sẽ là form: {formName}",
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
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi hệ thống?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
