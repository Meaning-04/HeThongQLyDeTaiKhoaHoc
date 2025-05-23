using Microsoft.EntityFrameworkCore;
using Models.HandleData;
using System.Drawing.Drawing2D;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetupForm();
            LoadRememberedCredentials();
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

            // Thiết lập hiệu ứng cho form
            SetupUIEffects();

            // Force set màu trắng cho panel login và disable visual styles
            Application.EnableVisualStyles();
            panelLogin.BackColor = Color.White;
            panelUsername.BackColor = Color.White;
            panelPassword.BackColor = Color.White;

            // Debug: In ra màu hiện tại
            System.Diagnostics.Debug.WriteLine($"panelLogin BackColor: {panelLogin.BackColor}");
            System.Diagnostics.Debug.WriteLine($"panelMain BackColor: {panelMain.BackColor}");
        }

        private void SetupUIEffects()
        {
            // Thiết lập rounded corners cho panel login
            SetupRoundedCorners();

            // Thiết lập custom paint cho panel login
            panelLogin.Paint += PanelLogin_Paint;

            // Thiết lập border cho textbox
            SetupTextBoxBorders();

            // Thiết lập hover effect cho button
            SetupButtonHoverEffect();

            // Thiết lập placeholder text
            SetupPlaceholderText();

            // Force refresh
            panelLogin.Invalidate();
        }

        private void SetupRoundedCorners()
        {
            // Tạo rounded corners cho panel login
            panelLogin.Region = CreateRoundedRegion(panelLogin.Size, 15);

            // Tạo rounded corners cho button
            button1.Region = CreateRoundedRegion(button1.Size, 8);
        }

        private Region CreateRoundedRegion(Size size, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(size.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(size.Width - radius, size.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, size.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            return new Region(path);
        }

        private void PanelLogin_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Panel panel)
            {
                // Vẽ background trắng trước
                using (SolidBrush whiteBrush = new SolidBrush(Color.White))
                {
                    e.Graphics.FillRectangle(whiteBrush, 0, 0, panel.Width, panel.Height);
                }

                // Vẽ shadow cho panel login (optional)
                // Rectangle shadowRect = new Rectangle(5, 5, panel.Width, panel.Height);
                // using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
                // {
                //     e.Graphics.FillRectangle(shadowBrush, shadowRect);
                // }
            }
        }

        private void SetupTextBoxBorders()
        {
            // Thiết lập border cho username panel
            panelUsername.Paint += (sender, e) =>
            {
                if (sender is Panel panel)
                {
                    using (Pen pen = new Pen(Color.FromArgb(189, 195, 199), 2))
                    {
                        e.Graphics.DrawRectangle(pen, 0, 25, panel.Width - 1, 30);
                    }
                }
            };

            // Thiết lập border cho password panel
            panelPassword.Paint += (sender, e) =>
            {
                if (sender is Panel panel)
                {
                    using (Pen pen = new Pen(Color.FromArgb(189, 195, 199), 2))
                    {
                        e.Graphics.DrawRectangle(pen, 0, 25, panel.Width - 1, 30);
                    }
                }
            };

            // Focus events cho textboxes
            taikhoan.Enter += (sender, e) => panelUsername.Invalidate();
            taikhoan.Leave += (sender, e) => panelUsername.Invalidate();
            matkhau.Enter += (sender, e) => panelPassword.Invalidate();
            matkhau.Leave += (sender, e) => panelPassword.Invalidate();
        }

        private void SetupButtonHoverEffect()
        {
            Color originalColor = Color.FromArgb(41, 128, 185);
            Color hoverColor = Color.FromArgb(52, 152, 219);

            button1.MouseEnter += (sender, e) =>
            {
                button1.BackColor = hoverColor;
                button1.Cursor = Cursors.Hand;
            };

            button1.MouseLeave += (sender, e) =>
            {
                button1.BackColor = originalColor;
                button1.Cursor = Cursors.Default;
            };
        }

        private void SetupPlaceholderText()
        {
            // Placeholder cho username
            if (string.IsNullOrEmpty(taikhoan.Text))
            {
                taikhoan.ForeColor = Color.Gray;
                taikhoan.Text = "Nhập tên đăng nhập...";
            }

            taikhoan.Enter += (sender, e) =>
            {
                if (taikhoan.Text == "Nhập tên đăng nhập...")
                {
                    taikhoan.Text = "";
                    taikhoan.ForeColor = Color.Black;
                }
            };

            taikhoan.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(taikhoan.Text))
                {
                    taikhoan.Text = "Nhập tên đăng nhập...";
                    taikhoan.ForeColor = Color.Gray;
                }
            };

            // Placeholder cho password
            matkhau.Enter += (sender, e) =>
            {
                if (matkhau.Text == "")
                {
                    matkhau.ForeColor = Color.Black;
                }
            };
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1_Click(sender ?? this, e);
            }
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            string username = taikhoan.Text.Trim();
            string password = matkhau.Text.Trim();

            // Kiểm tra placeholder text
            if (username == "Nhập tên đăng nhập..." || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
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
                        // Lưu thông tin đăng nhập nếu được chọn Remember Me
                        SaveCredentialsIfRemembered(username);

                        // Đăng nhập thành công
                        MessageBox.Show($"Đăng nhập thành công! Xin chào {user.CanBo?.HoTen ?? user.TenDangNhap}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở form chính và ẩn form đăng nhập
                        MainFormNew mainForm = new MainFormNew(user);

                        // Đăng ký sự kiện khi MainForm đóng để hiển thị lại Form1
                        mainForm.FormClosed += (s, args) =>
                        {
                            this.Show();
                            this.WindowState = FormWindowState.Normal;
                            this.BringToFront();
                            // Reset form đăng nhập
                            matkhau.Clear();
                            if (!chkRememberMe.Checked)
                            {
                                taikhoan.Clear();
                            }
                            taikhoan.Focus();
                        };

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

        private void LoadRememberedCredentials()
        {
            try
            {
                // Kiểm tra xem có thông tin đăng nhập được lưu không
                if (Properties.Settings.Default.RememberMe)
                {
                    string savedUsername = Properties.Settings.Default.SavedUsername ?? string.Empty;
                    if (!string.IsNullOrEmpty(savedUsername))
                    {
                        taikhoan.Text = savedUsername;
                        taikhoan.ForeColor = Color.Black;
                        chkRememberMe.Checked = true;
                        matkhau.Focus();
                    }
                    else
                    {
                        chkRememberMe.Checked = true;
                        taikhoan.Focus();
                    }
                }
                else
                {
                    taikhoan.Focus();
                }
            }
            catch (Exception ex)
            {
                // Nếu có lỗi khi đọc settings, bỏ qua và tiếp tục
                System.Diagnostics.Debug.WriteLine($"Lỗi khi tải thông tin đăng nhập: {ex.Message}");
                taikhoan.Focus();
            }
        }

        private void SaveCredentialsIfRemembered(string username)
        {
            try
            {
                if (chkRememberMe.Checked)
                {
                    Properties.Settings.Default.RememberMe = true;
                    Properties.Settings.Default.SavedUsername = username;
                }
                else
                {
                    Properties.Settings.Default.RememberMe = false;
                    Properties.Settings.Default.SavedUsername = string.Empty;
                }
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                // Nếu có lỗi khi lưu settings, bỏ qua
                System.Diagnostics.Debug.WriteLine($"Lỗi khi lưu thông tin đăng nhập: {ex.Message}");
            }
        }

        private void LinkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Test",
                           "Quên mật khẩu",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
        }
    }
}
