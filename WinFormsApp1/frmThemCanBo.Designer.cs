namespace WinFormsApp1
{
    partial class frmThemCanBo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemCanBo));
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblChucVu = new Label();
            txtChucVu = new TextBox();
            lblQuanHam = new Label();
            txtQuanHam = new TextBox();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblGioiTinh = new Label();
            cmbGioiTinh = new ComboBox();
            lblHocVi = new Label();
            txtHocVi = new TextBox();
            lblNamHocVi = new Label();
            numNamHocVi = new NumericUpDown();
            lblHocHam = new Label();
            txtHocHam = new TextBox();
            lblNamHocHam = new Label();
            numNamHocHam = new NumericUpDown();
            lblChucDanhCMKTNV = new Label();
            txtChucDanhCMKTNV = new TextBox();
            lblNamPhongChucDanh = new Label();
            numNamPhongChucDanh = new NumericUpDown();
            lblChuyenNganh = new Label();
            txtChuyenNganh = new TextBox();
            lblDienThoai = new Label();
            txtDienThoai = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblDiaChi = new Label();
            txtDiaChi = new TextBox();
            lblPhongBan = new Label();
            txtPhongBan = new TextBox();
            groupBoxFile = new GroupBox();
            btnXoaFile = new Button();
            btnChonFile = new Button();
            lblFileStatus = new Label();
            btnLuu = new Button();
            btnHuy = new Button();
            lblErrorHoTen = new Label();
            lblErrorDienThoai = new Label();
            lblErrorEmail = new Label();
            ((System.ComponentModel.ISupportInitialize)numNamHocVi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numNamHocHam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numNamPhongChucDanh).BeginInit();
            groupBoxFile.SuspendLayout();
            SuspendLayout();
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(20, 20);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(66, 15);
            lblHoTen.TabIndex = 0;
            lblHoTen.Text = "Họ và tên:*";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(20, 40);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(250, 23);
            txtHoTen.TabIndex = 1;
            // 
            // lblChucVu
            // 
            lblChucVu.AutoSize = true;
            lblChucVu.Location = new Point(290, 20);
            lblChucVu.Name = "lblChucVu";
            lblChucVu.Size = new Size(54, 15);
            lblChucVu.TabIndex = 2;
            lblChucVu.Text = "Chức vụ:";
            // 
            // txtChucVu
            // 
            txtChucVu.Location = new Point(290, 40);
            txtChucVu.Name = "txtChucVu";
            txtChucVu.Size = new Size(250, 23);
            txtChucVu.TabIndex = 3;
            // 
            // lblQuanHam
            // 
            lblQuanHam.AutoSize = true;
            lblQuanHam.Location = new Point(560, 20);
            lblQuanHam.Name = "lblQuanHam";
            lblQuanHam.Size = new Size(66, 15);
            lblQuanHam.TabIndex = 4;
            lblQuanHam.Text = "Quân hàm:";
            // 
            // txtQuanHam
            // 
            txtQuanHam.Location = new Point(560, 40);
            txtQuanHam.Name = "txtQuanHam";
            txtQuanHam.Size = new Size(210, 23);
            txtQuanHam.TabIndex = 5;
            // 
            // lblNgaySinh
            // 
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(20, 80);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(63, 15);
            lblNgaySinh.TabIndex = 6;
            lblNgaySinh.Text = "Ngày sinh:";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(20, 100);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(150, 23);
            dtpNgaySinh.TabIndex = 7;
            // 
            // lblGioiTinh
            // 
            lblGioiTinh.AutoSize = true;
            lblGioiTinh.Location = new Point(190, 80);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(55, 15);
            lblGioiTinh.TabIndex = 8;
            lblGioiTinh.Text = "Giới tính:";
            // 
            // cmbGioiTinh
            // 
            cmbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGioiTinh.FormattingEnabled = true;
            cmbGioiTinh.Location = new Point(190, 100);
            cmbGioiTinh.Name = "cmbGioiTinh";
            cmbGioiTinh.Size = new Size(80, 23);
            cmbGioiTinh.TabIndex = 9;
            // 
            // lblHocVi
            // 
            lblHocVi.AutoSize = true;
            lblHocVi.Location = new Point(290, 80);
            lblHocVi.Name = "lblHocVi";
            lblHocVi.Size = new Size(44, 15);
            lblHocVi.TabIndex = 10;
            lblHocVi.Text = "Học vị:";
            // 
            // txtHocVi
            // 
            txtHocVi.Location = new Point(290, 100);
            txtHocVi.Name = "txtHocVi";
            txtHocVi.Size = new Size(150, 23);
            txtHocVi.TabIndex = 11;
            // 
            // lblNamHocVi
            // 
            lblNamHocVi.AutoSize = true;
            lblNamHocVi.Location = new Point(460, 80);
            lblNamHocVi.Name = "lblNamHocVi";
            lblNamHocVi.Size = new Size(71, 15);
            lblNamHocVi.TabIndex = 12;
            lblNamHocVi.Text = "Năm học vị:";
            // 
            // numNamHocVi
            // 
            numNamHocVi.Location = new Point(460, 100);
            numNamHocVi.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numNamHocVi.Name = "numNamHocVi";
            numNamHocVi.Size = new Size(80, 23);
            numNamHocVi.TabIndex = 13;
            // 
            // lblHocHam
            // 
            lblHocHam.AutoSize = true;
            lblHocHam.Location = new Point(560, 80);
            lblHocHam.Name = "lblHocHam";
            lblHocHam.Size = new Size(59, 15);
            lblHocHam.TabIndex = 14;
            lblHocHam.Text = "Học hàm:";
            // 
            // txtHocHam
            // 
            txtHocHam.Location = new Point(560, 100);
            txtHocHam.Name = "txtHocHam";
            txtHocHam.Size = new Size(120, 23);
            txtHocHam.TabIndex = 15;
            // 
            // lblNamHocHam
            // 
            lblNamHocHam.AutoSize = true;
            lblNamHocHam.Location = new Point(690, 80);
            lblNamHocHam.Name = "lblNamHocHam";
            lblNamHocHam.Size = new Size(86, 15);
            lblNamHocHam.TabIndex = 16;
            lblNamHocHam.Text = "Năm học hàm:";
            // 
            // numNamHocHam
            // 
            numNamHocHam.Location = new Point(690, 100);
            numNamHocHam.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numNamHocHam.Name = "numNamHocHam";
            numNamHocHam.Size = new Size(80, 23);
            numNamHocHam.TabIndex = 17;
            // 
            // lblChucDanhCMKTNV
            // 
            lblChucDanhCMKTNV.AutoSize = true;
            lblChucDanhCMKTNV.Location = new Point(20, 140);
            lblChucDanhCMKTNV.Name = "lblChucDanhCMKTNV";
            lblChucDanhCMKTNV.Size = new Size(120, 15);
            lblChucDanhCMKTNV.TabIndex = 18;
            lblChucDanhCMKTNV.Text = "Chức danh CMKTNV:";
            // 
            // txtChucDanhCMKTNV
            // 
            txtChucDanhCMKTNV.Location = new Point(20, 160);
            txtChucDanhCMKTNV.Name = "txtChucDanhCMKTNV";
            txtChucDanhCMKTNV.Size = new Size(250, 23);
            txtChucDanhCMKTNV.TabIndex = 19;
            // 
            // lblNamPhongChucDanh
            // 
            lblNamPhongChucDanh.AutoSize = true;
            lblNamPhongChucDanh.Location = new Point(290, 140);
            lblNamPhongChucDanh.Name = "lblNamPhongChucDanh";
            lblNamPhongChucDanh.Size = new Size(133, 15);
            lblNamPhongChucDanh.TabIndex = 20;
            lblNamPhongChucDanh.Text = "Năm phong chức danh:";
            // 
            // numNamPhongChucDanh
            // 
            numNamPhongChucDanh.Location = new Point(290, 160);
            numNamPhongChucDanh.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numNamPhongChucDanh.Name = "numNamPhongChucDanh";
            numNamPhongChucDanh.Size = new Size(80, 23);
            numNamPhongChucDanh.TabIndex = 21;
            // 
            // lblChuyenNganh
            // 
            lblChuyenNganh.AutoSize = true;
            lblChuyenNganh.Location = new Point(390, 140);
            lblChuyenNganh.Name = "lblChuyenNganh";
            lblChuyenNganh.Size = new Size(88, 15);
            lblChuyenNganh.TabIndex = 22;
            lblChuyenNganh.Text = "Chuyên ngành:";
            // 
            // txtChuyenNganh
            // 
            txtChuyenNganh.Location = new Point(390, 160);
            txtChuyenNganh.Name = "txtChuyenNganh";
            txtChuyenNganh.Size = new Size(200, 23);
            txtChuyenNganh.TabIndex = 23;
            // 
            // lblDienThoai
            // 
            lblDienThoai.AutoSize = true;
            lblDienThoai.Location = new Point(610, 140);
            lblDienThoai.Name = "lblDienThoai";
            lblDienThoai.Size = new Size(64, 15);
            lblDienThoai.TabIndex = 24;
            lblDienThoai.Text = "Điện thoại:";
            // 
            // txtDienThoai
            // 
            txtDienThoai.Location = new Point(610, 160);
            txtDienThoai.Name = "txtDienThoai";
            txtDienThoai.Size = new Size(160, 23);
            txtDienThoai.TabIndex = 25;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(20, 200);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 26;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(20, 220);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(300, 23);
            txtEmail.TabIndex = 27;
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Location = new Point(340, 200);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(46, 15);
            lblDiaChi.TabIndex = 28;
            lblDiaChi.Text = "Địa chỉ:";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(340, 220);
            txtDiaChi.Multiline = true;
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.ScrollBars = ScrollBars.Vertical;
            txtDiaChi.Size = new Size(250, 60);
            txtDiaChi.TabIndex = 29;
            // 
            // lblPhongBan
            // 
            lblPhongBan.AutoSize = true;
            lblPhongBan.Location = new Point(610, 200);
            lblPhongBan.Name = "lblPhongBan";
            lblPhongBan.Size = new Size(68, 15);
            lblPhongBan.TabIndex = 30;
            lblPhongBan.Text = "Phòng ban:";
            // 
            // txtPhongBan
            // 
            txtPhongBan.Location = new Point(610, 220);
            txtPhongBan.Name = "txtPhongBan";
            txtPhongBan.Size = new Size(160, 23);
            txtPhongBan.TabIndex = 31;
            // 
            // groupBoxFile
            // 
            groupBoxFile.Controls.Add(btnXoaFile);
            groupBoxFile.Controls.Add(btnChonFile);
            groupBoxFile.Controls.Add(lblFileStatus);
            groupBoxFile.Location = new Point(20, 300);
            groupBoxFile.Name = "groupBoxFile";
            groupBoxFile.Size = new Size(750, 80);
            groupBoxFile.TabIndex = 32;
            groupBoxFile.TabStop = false;
            groupBoxFile.Text = "File lý lịch";
            // 
            // btnXoaFile
            // 
            btnXoaFile.BackColor = Color.FromArgb(220, 53, 69);
            btnXoaFile.ForeColor = Color.White;
            btnXoaFile.Location = new Point(150, 45);
            btnXoaFile.Name = "btnXoaFile";
            btnXoaFile.Size = new Size(80, 25);
            btnXoaFile.TabIndex = 2;
            btnXoaFile.Text = "🗑️ Xóa";
            btnXoaFile.UseVisualStyleBackColor = false;
            btnXoaFile.Click += btnXoaFile_Click;
            // 
            // btnChonFile
            // 
            btnChonFile.BackColor = Color.FromArgb(0, 123, 255);
            btnChonFile.ForeColor = Color.White;
            btnChonFile.Location = new Point(20, 45);
            btnChonFile.Name = "btnChonFile";
            btnChonFile.Size = new Size(120, 25);
            btnChonFile.TabIndex = 1;
            btnChonFile.Text = "📁 Chọn file";
            btnChonFile.UseVisualStyleBackColor = false;
            btnChonFile.Click += btnChonFile_Click;
            // 
            // lblFileStatus
            // 
            lblFileStatus.AutoSize = true;
            lblFileStatus.ForeColor = Color.Red;
            lblFileStatus.Location = new Point(20, 25);
            lblFileStatus.Name = "lblFileStatus";
            lblFileStatus.Size = new Size(85, 15);
            lblFileStatus.TabIndex = 0;
            lblFileStatus.Text = "❌ Chưa có file";
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(40, 167, 69);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(604, 400);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(80, 30);
            btnLuu.TabIndex = 33;
            btnLuu.Text = "💾 Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += BtnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.FromArgb(220, 53, 69);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(690, 400);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(80, 30);
            btnHuy.TabIndex = 34;
            btnHuy.Text = "❌ Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += BtnHuy_Click;
            // 
            // lblErrorHoTen
            // 
            lblErrorHoTen.AutoSize = true;
            lblErrorHoTen.ForeColor = Color.Red;
            lblErrorHoTen.Location = new Point(20, 66);
            lblErrorHoTen.Name = "lblErrorHoTen";
            lblErrorHoTen.Size = new Size(0, 15);
            lblErrorHoTen.TabIndex = 35;
            lblErrorHoTen.Visible = false;
            // 
            // lblErrorDienThoai
            // 
            lblErrorDienThoai.AutoSize = true;
            lblErrorDienThoai.ForeColor = Color.Red;
            lblErrorDienThoai.Location = new Point(610, 186);
            lblErrorDienThoai.Name = "lblErrorDienThoai";
            lblErrorDienThoai.Size = new Size(0, 15);
            lblErrorDienThoai.TabIndex = 36;
            lblErrorDienThoai.Visible = false;
            // 
            // lblErrorEmail
            // 
            lblErrorEmail.AutoSize = true;
            lblErrorEmail.ForeColor = Color.Red;
            lblErrorEmail.Location = new Point(20, 246);
            lblErrorEmail.Name = "lblErrorEmail";
            lblErrorEmail.Size = new Size(0, 15);
            lblErrorEmail.TabIndex = 37;
            lblErrorEmail.Visible = false;
            // 
            // frmThemCanBo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(786, 450);
            Controls.Add(lblErrorEmail);
            Controls.Add(lblErrorDienThoai);
            Controls.Add(lblErrorHoTen);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(groupBoxFile);
            Controls.Add(txtPhongBan);
            Controls.Add(lblPhongBan);
            Controls.Add(txtDiaChi);
            Controls.Add(lblDiaChi);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtDienThoai);
            Controls.Add(lblDienThoai);
            Controls.Add(txtChuyenNganh);
            Controls.Add(lblChuyenNganh);
            Controls.Add(numNamPhongChucDanh);
            Controls.Add(lblNamPhongChucDanh);
            Controls.Add(txtChucDanhCMKTNV);
            Controls.Add(lblChucDanhCMKTNV);
            Controls.Add(numNamHocHam);
            Controls.Add(lblNamHocHam);
            Controls.Add(txtHocHam);
            Controls.Add(lblHocHam);
            Controls.Add(numNamHocVi);
            Controls.Add(lblNamHocVi);
            Controls.Add(txtHocVi);
            Controls.Add(lblHocVi);
            Controls.Add(cmbGioiTinh);
            Controls.Add(lblGioiTinh);
            Controls.Add(dtpNgaySinh);
            Controls.Add(lblNgaySinh);
            Controls.Add(txtQuanHam);
            Controls.Add(lblQuanHam);
            Controls.Add(txtChucVu);
            Controls.Add(lblChucVu);
            Controls.Add(txtHoTen);
            Controls.Add(lblHoTen);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmThemCanBo";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm cán bộ mới";
            ((System.ComponentModel.ISupportInitialize)numNamHocVi).EndInit();
            ((System.ComponentModel.ISupportInitialize)numNamHocHam).EndInit();
            ((System.ComponentModel.ISupportInitialize)numNamPhongChucDanh).EndInit();
            groupBoxFile.ResumeLayout(false);
            groupBoxFile.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblChucVu;
        private TextBox txtChucVu;
        private Label lblQuanHam;
        private TextBox txtQuanHam;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private Label lblGioiTinh;
        private ComboBox cmbGioiTinh;
        private Label lblHocVi;
        private TextBox txtHocVi;
        private Label lblNamHocVi;
        private NumericUpDown numNamHocVi;
        private Label lblHocHam;
        private TextBox txtHocHam;
        private Label lblNamHocHam;
        private NumericUpDown numNamHocHam;
        private Label lblChucDanhCMKTNV;
        private TextBox txtChucDanhCMKTNV;
        private Label lblNamPhongChucDanh;
        private NumericUpDown numNamPhongChucDanh;
        private Label lblChuyenNganh;
        private TextBox txtChuyenNganh;
        private Label lblDienThoai;
        private TextBox txtDienThoai;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblDiaChi;
        private TextBox txtDiaChi;
        private Label lblPhongBan;
        private TextBox txtPhongBan;
        private GroupBox groupBoxFile;
        private Label lblFileStatus;
        private Button btnChonFile;
        private Button btnXoaFile;
        private Button btnLuu;
        private Button btnHuy;
        private Label lblErrorHoTen;
        private Label lblErrorDienThoai;
        private Label lblErrorEmail;
    }
}
