namespace WinFormsApp1
{
    partial class frmDeTai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeTai));
            panelTop = new Panel();
            groupBoxFilter = new GroupBox();
            cmbCapQuanLy = new ComboBox();
            lblCapQuanLy = new Label();
            cmbLinhVuc = new ComboBox();
            lblLinhVuc = new Label();
            dtpDenNgay = new DateTimePicker();
            lblDenNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            lblTuNgay = new Label();
            txtTimKiem = new TextBox();
            lblTimKiem = new Label();
            btnLamMoi = new Button();
            btnXuatWord = new Button();
            btnXuatExcel = new Button();
            panelButtons = new Panel();
            btnXemChiTiet = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            panelMain = new Panel();
            dgvDeTai = new DataGridView();
            panelBottom = new Panel();
            lblTongSo = new Label();
            panelTop.SuspendLayout();
            groupBoxFilter.SuspendLayout();
            panelButtons.SuspendLayout();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDeTai).BeginInit();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(groupBoxFilter);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(10);
            panelTop.Size = new Size(1495, 114);
            panelTop.TabIndex = 0;
            // 
            // groupBoxFilter
            // 
            groupBoxFilter.Controls.Add(cmbCapQuanLy);
            groupBoxFilter.Controls.Add(lblCapQuanLy);
            groupBoxFilter.Controls.Add(cmbLinhVuc);
            groupBoxFilter.Controls.Add(lblLinhVuc);
            groupBoxFilter.Controls.Add(dtpDenNgay);
            groupBoxFilter.Controls.Add(lblDenNgay);
            groupBoxFilter.Controls.Add(dtpTuNgay);
            groupBoxFilter.Controls.Add(lblTuNgay);
            groupBoxFilter.Controls.Add(txtTimKiem);
            groupBoxFilter.Controls.Add(lblTimKiem);
            groupBoxFilter.Dock = DockStyle.Fill;
            groupBoxFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxFilter.Location = new Point(10, 10);
            groupBoxFilter.Name = "groupBoxFilter";
            groupBoxFilter.Size = new Size(1475, 94);
            groupBoxFilter.TabIndex = 0;
            groupBoxFilter.TabStop = false;
            groupBoxFilter.Text = "Điều kiện lọc";
            // 
            // cmbCapQuanLy
            // 
            cmbCapQuanLy.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCapQuanLy.Font = new Font("Segoe UI", 9F);
            cmbCapQuanLy.FormattingEnabled = true;
            cmbCapQuanLy.Location = new Point(800, 50);
            cmbCapQuanLy.Name = "cmbCapQuanLy";
            cmbCapQuanLy.Size = new Size(180, 23);
            cmbCapQuanLy.TabIndex = 9;
            cmbCapQuanLy.SelectedIndexChanged += cmbCapQuanLy_SelectedIndexChanged;
            // 
            // lblCapQuanLy
            // 
            lblCapQuanLy.AutoSize = true;
            lblCapQuanLy.Font = new Font("Segoe UI", 9F);
            lblCapQuanLy.Location = new Point(800, 30);
            lblCapQuanLy.Name = "lblCapQuanLy";
            lblCapQuanLy.Size = new Size(73, 15);
            lblCapQuanLy.TabIndex = 8;
            lblCapQuanLy.Text = "Cấp quản lý:";
            // 
            // cmbLinhVuc
            // 
            cmbLinhVuc.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLinhVuc.Font = new Font("Segoe UI", 9F);
            cmbLinhVuc.FormattingEnabled = true;
            cmbLinhVuc.Location = new Point(600, 50);
            cmbLinhVuc.Name = "cmbLinhVuc";
            cmbLinhVuc.Size = new Size(180, 23);
            cmbLinhVuc.TabIndex = 7;
            cmbLinhVuc.SelectedIndexChanged += cmbLinhVuc_SelectedIndexChanged;
            // 
            // lblLinhVuc
            // 
            lblLinhVuc.AutoSize = true;
            lblLinhVuc.Font = new Font("Segoe UI", 9F);
            lblLinhVuc.Location = new Point(600, 30);
            lblLinhVuc.Name = "lblLinhVuc";
            lblLinhVuc.Size = new Size(55, 15);
            lblLinhVuc.TabIndex = 6;
            lblLinhVuc.Text = "Lĩnh vực:";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Font = new Font("Segoe UI", 9F);
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(1198, 50);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(180, 23);
            dtpDenNgay.TabIndex = 5;
            dtpDenNgay.ValueChanged += dtpDenNgay_ValueChanged;
            // 
            // lblDenNgay
            // 
            lblDenNgay.AutoSize = true;
            lblDenNgay.Font = new Font("Segoe UI", 9F);
            lblDenNgay.Location = new Point(1198, 30);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(60, 15);
            lblDenNgay.TabIndex = 4;
            lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Font = new Font("Segoe UI", 9F);
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(997, 50);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(180, 23);
            dtpTuNgay.TabIndex = 3;
            dtpTuNgay.ValueChanged += dtpTuNgay_ValueChanged;
            // 
            // lblTuNgay
            // 
            lblTuNgay.AutoSize = true;
            lblTuNgay.Font = new Font("Segoe UI", 9F);
            lblTuNgay.Location = new Point(997, 30);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(53, 15);
            lblTuNgay.TabIndex = 2;
            lblTuNgay.Text = "Từ ngày:";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 9F);
            txtTimKiem.Location = new Point(20, 50);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập tên đề tài hoặc mã đề tài...";
            txtTimKiem.Size = new Size(560, 23);
            txtTimKiem.TabIndex = 1;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI", 9F);
            lblTimKiem.Location = new Point(20, 30);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(60, 15);
            lblTimKiem.TabIndex = 0;
            lblTimKiem.Text = "Tìm kiếm:";
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnLamMoi.BackColor = Color.FromArgb(108, 117, 125);
            btnLamMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(1110, 11);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(120, 39);
            btnLamMoi.TabIndex = 10;
            btnLamMoi.Text = "🔄 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXuatWord
            // 
            btnXuatWord.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnXuatWord.BackColor = Color.FromArgb(0, 123, 255);
            btnXuatWord.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXuatWord.ForeColor = Color.White;
            btnXuatWord.Location = new Point(1236, 10);
            btnXuatWord.Name = "btnXuatWord";
            btnXuatWord.Size = new Size(120, 40);
            btnXuatWord.TabIndex = 11;
            btnXuatWord.Text = "📄 Xuất Word";
            btnXuatWord.UseVisualStyleBackColor = false;
            btnXuatWord.Click += btnXuatWord_Click;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnXuatExcel.BackColor = Color.FromArgb(40, 167, 69);
            btnXuatExcel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXuatExcel.ForeColor = Color.White;
            btnXuatExcel.Location = new Point(1362, 10);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(120, 40);
            btnXuatExcel.TabIndex = 12;
            btnXuatExcel.Text = "📊 Xuất Excel";
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnLamMoi);
            panelButtons.Controls.Add(btnXuatWord);
            panelButtons.Controls.Add(btnXemChiTiet);
            panelButtons.Controls.Add(btnXuatExcel);
            panelButtons.Controls.Add(btnXoa);
            panelButtons.Controls.Add(btnSua);
            panelButtons.Controls.Add(btnThem);
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Location = new Point(0, 114);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(10, 5, 10, 5);
            panelButtons.Size = new Size(1495, 60);
            panelButtons.TabIndex = 1;
            // 
            // btnXemChiTiet
            // 
            btnXemChiTiet.BackColor = Color.FromArgb(40, 167, 69);
            btnXemChiTiet.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXemChiTiet.ForeColor = Color.White;
            btnXemChiTiet.Location = new Point(388, 10);
            btnXemChiTiet.Name = "btnXemChiTiet";
            btnXemChiTiet.Size = new Size(120, 40);
            btnXemChiTiet.TabIndex = 3;
            btnXemChiTiet.Text = "👁️ Xem chi tiết";
            btnXemChiTiet.UseVisualStyleBackColor = false;
            btnXemChiTiet.Click += btnXemChiTiet_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(220, 53, 69);
            btnXoa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(262, 10);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(120, 40);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(255, 193, 7);
            btnSua.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSua.ForeColor = Color.Black;
            btnSua.Location = new Point(136, 10);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(120, 40);
            btnSua.TabIndex = 1;
            btnSua.Text = "✏️ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(40, 167, 69);
            btnThem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(10, 10);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(120, 40);
            btnThem.TabIndex = 0;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(dgvDeTai);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 174);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(10, 0, 10, 0);
            panelMain.Size = new Size(1495, 476);
            panelMain.TabIndex = 2;
            // 
            // dgvDeTai
            // 
            dgvDeTai.AllowUserToAddRows = false;
            dgvDeTai.AllowUserToDeleteRows = false;
            dgvDeTai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDeTai.BackgroundColor = Color.White;
            dgvDeTai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDeTai.Dock = DockStyle.Fill;
            dgvDeTai.Location = new Point(10, 0);
            dgvDeTai.MultiSelect = false;
            dgvDeTai.Name = "dgvDeTai";
            dgvDeTai.ReadOnly = true;
            dgvDeTai.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDeTai.Size = new Size(1475, 476);
            dgvDeTai.TabIndex = 0;
            dgvDeTai.CellClick += dgvDeTai_CellClick;
            dgvDeTai.CellContentClick += dgvDeTai_CellContentClick;
            dgvDeTai.CellDoubleClick += dgvDeTai_CellDoubleClick;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(lblTongSo);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 650);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(10, 5, 10, 5);
            panelBottom.Size = new Size(1495, 30);
            panelBottom.TabIndex = 3;
            // 
            // lblTongSo
            // 
            lblTongSo.AutoSize = true;
            lblTongSo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTongSo.Location = new Point(10, 8);
            lblTongSo.Name = "lblTongSo";
            lblTongSo.Size = new Size(98, 15);
            lblTongSo.TabIndex = 0;
            lblTongSo.Text = "Tổng số: 0 đề tài";
            // 
            // frmDeTai
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1495, 680);
            Controls.Add(panelMain);
            Controls.Add(panelBottom);
            Controls.Add(panelButtons);
            Controls.Add(panelTop);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmDeTai";
            Text = "Quản lý đề tài";
            panelTop.ResumeLayout(false);
            groupBoxFilter.ResumeLayout(false);
            groupBoxFilter.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDeTai).EndInit();
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private GroupBox groupBoxFilter;
        private TextBox txtTimKiem;
        private Label lblTimKiem;
        private DateTimePicker dtpTuNgay;
        private Label lblTuNgay;
        private DateTimePicker dtpDenNgay;
        private Label lblDenNgay;
        private ComboBox cmbLinhVuc;
        private Label lblLinhVuc;
        private ComboBox cmbCapQuanLy;
        private Label lblCapQuanLy;
        private Button btnLamMoi;
        private Button btnXuatWord;
        private Button btnXuatExcel;
        private Panel panelButtons;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnXemChiTiet;
        private Panel panelMain;
        private DataGridView dgvDeTai;
        private Panel panelBottom;
        private Label lblTongSo;
    }
}