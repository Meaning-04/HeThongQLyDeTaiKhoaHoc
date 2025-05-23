using Models;
using Models.Models;
using Microsoft.EntityFrameworkCore;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Đăng nhập hệ thống";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Thiết lập mật khẩu ẩn
            matkhau.PasswordChar = '*';

            // Gán sự kiện cho nút đăng nhập
            button1.Click += Button1_Click;

            // Cho phép nhấn Enter để đăng nhập
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1_Click(sender, e);
            }
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            string username = taikhoan.Text.Trim();
            string password = matkhau.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị loading
            button1.Enabled = false;
            button1.Text = "Đang đăng nhập...";

            try
            {
                using (var context = new DAContext())
                {
                    // Tìm tài khoản trong database
                    var user = await context.TaiKhoan
                        .Include(t => t.CanBo)
                        .FirstOrDefaultAsync(t => t.TenDangNhap == username && t.MatKhau == password);

                    if (user != null)
                    {
                        // Đăng nhập thành công
                        MessageBox.Show($"Đăng nhập thành công! Xin chào {user.CanBo?.HoTen ?? user.TenDangNhap}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở form chính và ẩn form đăng nhập
                        MainFormNew mainForm = new MainFormNew(user);
                        mainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Đăng nhập thất bại
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        matkhau.Clear();
                        taikhoan.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối cơ sở dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Khôi phục trạng thái nút
                button1.Enabled = true;
                button1.Text = "Đăng nhập";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
