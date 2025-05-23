namespace WinFormsApp1
{
    partial class frmTaiKhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaiKhoan));
            panelTop = new Panel();
            lblTitle = new Label();
            panelButtons = new Panel();
            btnHuy = new Button();
            btnLuu = new Button();
            btnResetMatKhau = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            panelMain = new Panel();
            dgvTaiKhoan = new DataGridView();
            panelBottom = new Panel();
            grpThongTin = new GroupBox();
            cmbCanBo = new ComboBox();
            lblCanBo = new Label();
            cmbVaiTro = new ComboBox();
            lblVaiTro = new Label();
            txtMatKhau = new TextBox();
            lblMatKhau = new Label();
            txtTenDangNhap = new TextBox();
            lblTenDangNhap = new Label();
            txtMaTaiKhoan = new TextBox();
            lblMaTaiKhoan = new Label();
            panelTop.SuspendLayout();
            panelButtons.SuspendLayout();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).BeginInit();
            panelBottom.SuspendLayout();
            grpThongTin.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(3, 2, 3, 2);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(9, 8, 9, 8);
            panelTop.Size = new Size(1050, 45);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Left;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(9, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(244, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🔧 Quản Trị Hệ Thống";
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnHuy);
            panelButtons.Controls.Add(btnLuu);
            panelButtons.Controls.Add(btnResetMatKhau);
            panelButtons.Controls.Add(btnXoa);
            panelButtons.Controls.Add(btnSua);
            panelButtons.Controls.Add(btnThem);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Location = new Point(9, 292);
            panelButtons.Margin = new Padding(3, 2, 3, 2);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(9, 4, 9, 4);
            panelButtons.Size = new Size(1032, 46);
            panelButtons.TabIndex = 1;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.FromArgb(108, 117, 125);
            btnHuy.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(539, 8);
            btnHuy.Margin = new Padding(3, 2, 3, 2);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(100, 30);
            btnHuy.TabIndex = 5;
            btnHuy.Text = "❌ Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(0, 123, 255);
            btnLuu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(433, 8);
            btnLuu.Margin = new Padding(3, 2, 3, 2);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(100, 30);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "💾 Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnResetMatKhau
            // 
            btnResetMatKhau.BackColor = Color.FromArgb(108, 117, 125);
            btnResetMatKhau.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnResetMatKhau.ForeColor = Color.White;
            btnResetMatKhau.Location = new Point(327, 8);
            btnResetMatKhau.Margin = new Padding(3, 2, 3, 2);
            btnResetMatKhau.Name = "btnResetMatKhau";
            btnResetMatKhau.Size = new Size(100, 30);
            btnResetMatKhau.TabIndex = 3;
            btnResetMatKhau.Text = "🔄 Reset MK";
            btnResetMatKhau.UseVisualStyleBackColor = false;
            btnResetMatKhau.Click += btnResetMatKhau_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(220, 53, 69);
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(221, 8);
            btnXoa.Margin = new Padding(3, 2, 3, 2);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 30);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(255, 193, 7);
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSua.ForeColor = Color.Black;
            btnSua.Location = new Point(115, 8);
            btnSua.Margin = new Padding(3, 2, 3, 2);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 30);
            btnSua.TabIndex = 1;
            btnSua.Text = "✏️ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(40, 167, 69);
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(9, 8);
            btnThem.Margin = new Padding(3, 2, 3, 2);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 30);
            btnThem.TabIndex = 0;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(dgvTaiKhoan);
            panelMain.Controls.Add(panelButtons);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 45);
            panelMain.Margin = new Padding(3, 2, 3, 2);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(9, 0, 9, 0);
            panelMain.Size = new Size(1050, 338);
            panelMain.TabIndex = 2;
            // 
            // dgvTaiKhoan
            // 
            dgvTaiKhoan.AllowUserToAddRows = false;
            dgvTaiKhoan.AllowUserToDeleteRows = false;
            dgvTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTaiKhoan.BackgroundColor = Color.White;
            dgvTaiKhoan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTaiKhoan.Dock = DockStyle.Fill;
            dgvTaiKhoan.Location = new Point(9, 0);
            dgvTaiKhoan.Margin = new Padding(3, 2, 3, 2);
            dgvTaiKhoan.MultiSelect = false;
            dgvTaiKhoan.Name = "dgvTaiKhoan";
            dgvTaiKhoan.ReadOnly = true;
            dgvTaiKhoan.RowHeadersWidth = 51;
            dgvTaiKhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTaiKhoan.Size = new Size(1032, 292);
            dgvTaiKhoan.TabIndex = 0;
            dgvTaiKhoan.CellContentClick += dgvTaiKhoan_CellContentClick;
            dgvTaiKhoan.CellMouseClick += dgvTaiKhoan_CellMouseClick;
            dgvTaiKhoan.SelectionChanged += dgvTaiKhoan_SelectionChanged;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(grpThongTin);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 383);
            panelBottom.Margin = new Padding(3, 2, 3, 2);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(9, 8, 9, 8);
            panelBottom.Size = new Size(1050, 142);
            panelBottom.TabIndex = 3;
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(cmbCanBo);
            grpThongTin.Controls.Add(lblCanBo);
            grpThongTin.Controls.Add(cmbVaiTro);
            grpThongTin.Controls.Add(lblVaiTro);
            grpThongTin.Controls.Add(txtMatKhau);
            grpThongTin.Controls.Add(lblMatKhau);
            grpThongTin.Controls.Add(txtTenDangNhap);
            grpThongTin.Controls.Add(lblTenDangNhap);
            grpThongTin.Controls.Add(txtMaTaiKhoan);
            grpThongTin.Controls.Add(lblMaTaiKhoan);
            grpThongTin.Dock = DockStyle.Fill;
            grpThongTin.Font = new Font("Montserrat", 9.749999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpThongTin.Location = new Point(9, 8);
            grpThongTin.Margin = new Padding(3, 2, 3, 2);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Padding = new Padding(3, 2, 3, 2);
            grpThongTin.Size = new Size(1032, 126);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "📝 Thông tin chi tiết";
            // 
            // cmbCanBo
            // 
            cmbCanBo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCanBo.Font = new Font("Segoe UI", 9F);
            cmbCanBo.FormattingEnabled = true;
            cmbCanBo.Location = new Point(438, 60);
            cmbCanBo.Margin = new Padding(3, 2, 3, 2);
            cmbCanBo.Name = "cmbCanBo";
            cmbCanBo.Size = new Size(263, 23);
            cmbCanBo.TabIndex = 9;
            // 
            // lblCanBo
            // 
            lblCanBo.AutoSize = true;
            lblCanBo.Font = new Font("Segoe UI", 9F);
            lblCanBo.Location = new Point(350, 62);
            lblCanBo.Name = "lblCanBo";
            lblCanBo.Size = new Size(48, 15);
            lblCanBo.TabIndex = 8;
            lblCanBo.Text = "Cán bộ:";
            // 
            // cmbVaiTro
            // 
            cmbVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVaiTro.Font = new Font("Segoe UI", 9F);
            cmbVaiTro.FormattingEnabled = true;
            cmbVaiTro.Location = new Point(438, 30);
            cmbVaiTro.Margin = new Padding(3, 2, 3, 2);
            cmbVaiTro.Name = "cmbVaiTro";
            cmbVaiTro.Size = new Size(176, 23);
            cmbVaiTro.TabIndex = 7;
            // 
            // lblVaiTro
            // 
            lblVaiTro.AutoSize = true;
            lblVaiTro.Font = new Font("Segoe UI", 9F);
            lblVaiTro.Location = new Point(350, 32);
            lblVaiTro.Name = "lblVaiTro";
            lblVaiTro.Size = new Size(43, 15);
            lblVaiTro.TabIndex = 6;
            lblVaiTro.Text = "Vai trò:";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Segoe UI", 9F);
            txtMatKhau.Location = new Point(131, 90);
            txtMatKhau.Margin = new Padding(3, 2, 3, 2);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(176, 23);
            txtMatKhau.TabIndex = 5;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Font = new Font("Segoe UI", 9F);
            lblMatKhau.Location = new Point(18, 92);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(60, 15);
            lblMatKhau.TabIndex = 4;
            lblMatKhau.Text = "Mật khẩu:";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Font = new Font("Segoe UI", 9F);
            txtTenDangNhap.Location = new Point(131, 60);
            txtTenDangNhap.Margin = new Padding(3, 2, 3, 2);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(176, 23);
            txtTenDangNhap.TabIndex = 3;
            // 
            // lblTenDangNhap
            // 
            lblTenDangNhap.AutoSize = true;
            lblTenDangNhap.Font = new Font("Segoe UI", 9F);
            lblTenDangNhap.Location = new Point(18, 62);
            lblTenDangNhap.Name = "lblTenDangNhap";
            lblTenDangNhap.Size = new Size(89, 15);
            lblTenDangNhap.TabIndex = 2;
            lblTenDangNhap.Text = "Tên đăng nhập:";
            // 
            // txtMaTaiKhoan
            // 
            txtMaTaiKhoan.Font = new Font("Segoe UI", 9F);
            txtMaTaiKhoan.Location = new Point(131, 30);
            txtMaTaiKhoan.Margin = new Padding(3, 2, 3, 2);
            txtMaTaiKhoan.Name = "txtMaTaiKhoan";
            txtMaTaiKhoan.ReadOnly = true;
            txtMaTaiKhoan.Size = new Size(176, 23);
            txtMaTaiKhoan.TabIndex = 1;
            // 
            // lblMaTaiKhoan
            // 
            lblMaTaiKhoan.AutoSize = true;
            lblMaTaiKhoan.Font = new Font("Segoe UI", 9F);
            lblMaTaiKhoan.Location = new Point(18, 32);
            lblMaTaiKhoan.Name = "lblMaTaiKhoan";
            lblMaTaiKhoan.Size = new Size(79, 15);
            lblMaTaiKhoan.TabIndex = 0;
            lblMaTaiKhoan.Text = "Mã tài khoản:";
            // 
            // frmTaiKhoan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 525);
            Controls.Add(panelMain);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmTaiKhoan";
            Text = "Quản Trị Hệ Thống - Quản Lý Tài Khoản";
            Load += frmTaiKhoan_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTaiKhoan).EndInit();
            panelBottom.ResumeLayout(false);
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnResetMatKhau;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.ComboBox cmbCanBo;
        private System.Windows.Forms.Label lblCanBo;
        private System.Windows.Forms.ComboBox cmbVaiTro;
        private System.Windows.Forms.Label lblVaiTro;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblMatKhau;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label lblTenDangNhap;
        private System.Windows.Forms.TextBox txtMaTaiKhoan;
        private System.Windows.Forms.Label lblMaTaiKhoan;
    }
}
