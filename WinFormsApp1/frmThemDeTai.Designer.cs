namespace WinFormsApp1
{
    partial class frmThemDeTai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemDeTai));
            lblTenDeTai = new Label();
            txtTenDeTai = new TextBox();
            lblMoTa = new Label();
            txtMoTa = new TextBox();
            lblLinhVuc = new Label();
            txtLinhVuc = new TextBox();
            lblCapQuanLy = new Label();
            cmbCapQuanLy = new ComboBox();
            lblThoiGianBatDau = new Label();
            dtpThoiGianBatDau = new DateTimePicker();
            lblThoiGianKetThuc = new Label();
            dtpThoiGianKetThuc = new DateTimePicker();
            btnLuu = new Button();
            btnHuy = new Button();
            lblErrorTenDeTai = new Label();
            lblErrorLinhVuc = new Label();
            lblErrorCapQuanLy = new Label();
            lblErrorThoiGian = new Label();
            SuspendLayout();
            // 
            // lblTenDeTai
            // 
            lblTenDeTai.AutoSize = true;
            lblTenDeTai.Location = new Point(20, 30);
            lblTenDeTai.Name = "lblTenDeTai";
            lblTenDeTai.Size = new Size(61, 15);
            lblTenDeTai.TabIndex = 0;
            lblTenDeTai.Text = "Tên đề tài:";
            // 
            // txtTenDeTai
            // 
            txtTenDeTai.Location = new Point(20, 50);
            txtTenDeTai.Name = "txtTenDeTai";
            txtTenDeTai.Size = new Size(550, 23);
            txtTenDeTai.TabIndex = 1;
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(20, 80);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(83, 15);
            lblMoTa.TabIndex = 2;
            lblMoTa.Text = "Mô tả tóm tắt:";
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(20, 100);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.ScrollBars = ScrollBars.Vertical;
            txtMoTa.Size = new Size(550, 80);
            txtMoTa.TabIndex = 3;
            // 
            // lblLinhVuc
            // 
            lblLinhVuc.AutoSize = true;
            lblLinhVuc.Location = new Point(20, 190);
            lblLinhVuc.Name = "lblLinhVuc";
            lblLinhVuc.Size = new Size(55, 15);
            lblLinhVuc.TabIndex = 4;
            lblLinhVuc.Text = "Lĩnh vực:";
            // 
            // txtLinhVuc
            // 
            txtLinhVuc.Location = new Point(20, 210);
            txtLinhVuc.Name = "txtLinhVuc";
            txtLinhVuc.Size = new Size(250, 23);
            txtLinhVuc.TabIndex = 5;
            // 
            // lblCapQuanLy
            // 
            lblCapQuanLy.AutoSize = true;
            lblCapQuanLy.Location = new Point(290, 190);
            lblCapQuanLy.Name = "lblCapQuanLy";
            lblCapQuanLy.Size = new Size(73, 15);
            lblCapQuanLy.TabIndex = 6;
            lblCapQuanLy.Text = "Cấp quản lý:";
            // 
            // cmbCapQuanLy
            // 
            cmbCapQuanLy.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCapQuanLy.FormattingEnabled = true;
            cmbCapQuanLy.Items.AddRange(new object[] { "Nhà nước", "Bộ", "Ngành", "Cơ sở" });
            cmbCapQuanLy.Location = new Point(290, 210);
            cmbCapQuanLy.Name = "cmbCapQuanLy";
            cmbCapQuanLy.Size = new Size(280, 23);
            cmbCapQuanLy.TabIndex = 7;
            // 
            // lblThoiGianBatDau
            // 
            lblThoiGianBatDau.AutoSize = true;
            lblThoiGianBatDau.Location = new Point(20, 250);
            lblThoiGianBatDau.Name = "lblThoiGianBatDau";
            lblThoiGianBatDau.Size = new Size(103, 15);
            lblThoiGianBatDau.TabIndex = 8;
            lblThoiGianBatDau.Text = "Thời gian bắt đầu:";
            // 
            // dtpThoiGianBatDau
            // 
            dtpThoiGianBatDau.Format = DateTimePickerFormat.Short;
            dtpThoiGianBatDau.Location = new Point(20, 270);
            dtpThoiGianBatDau.Name = "dtpThoiGianBatDau";
            dtpThoiGianBatDau.Size = new Size(250, 23);
            dtpThoiGianBatDau.TabIndex = 9;
            // 
            // lblThoiGianKetThuc
            // 
            lblThoiGianKetThuc.AutoSize = true;
            lblThoiGianKetThuc.Location = new Point(290, 250);
            lblThoiGianKetThuc.Name = "lblThoiGianKetThuc";
            lblThoiGianKetThuc.Size = new Size(106, 15);
            lblThoiGianKetThuc.TabIndex = 10;
            lblThoiGianKetThuc.Text = "Thời gian kết thúc:";
            // 
            // dtpThoiGianKetThuc
            // 
            dtpThoiGianKetThuc.Format = DateTimePickerFormat.Short;
            dtpThoiGianKetThuc.Location = new Point(290, 270);
            dtpThoiGianKetThuc.Name = "dtpThoiGianKetThuc";
            dtpThoiGianKetThuc.Size = new Size(280, 23);
            dtpThoiGianKetThuc.TabIndex = 11;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(40, 167, 69);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(400, 322);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(80, 30);
            btnLuu.TabIndex = 12;
            btnLuu.Text = "💾 Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += BtnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.FromArgb(220, 53, 69);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(490, 322);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(80, 30);
            btnHuy.TabIndex = 13;
            btnHuy.Text = "❌ Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += BtnHuy_Click;
            // 
            // lblErrorTenDeTai
            // 
            lblErrorTenDeTai.AutoSize = true;
            lblErrorTenDeTai.ForeColor = Color.Red;
            lblErrorTenDeTai.Location = new Point(20, 100);
            lblErrorTenDeTai.Name = "lblErrorTenDeTai";
            lblErrorTenDeTai.Size = new Size(0, 15);
            lblErrorTenDeTai.TabIndex = 14;
            lblErrorTenDeTai.Visible = false;
            // 
            // lblErrorLinhVuc
            // 
            lblErrorLinhVuc.AutoSize = true;
            lblErrorLinhVuc.ForeColor = Color.Red;
            lblErrorLinhVuc.Location = new Point(20, 200);
            lblErrorLinhVuc.Name = "lblErrorLinhVuc";
            lblErrorLinhVuc.Size = new Size(0, 15);
            lblErrorLinhVuc.TabIndex = 15;
            lblErrorLinhVuc.Visible = false;
            // 
            // lblErrorCapQuanLy
            // 
            lblErrorCapQuanLy.AutoSize = true;
            lblErrorCapQuanLy.ForeColor = Color.Red;
            lblErrorCapQuanLy.Location = new Point(20, 250);
            lblErrorCapQuanLy.Name = "lblErrorCapQuanLy";
            lblErrorCapQuanLy.Size = new Size(0, 15);
            lblErrorCapQuanLy.TabIndex = 16;
            lblErrorCapQuanLy.Visible = false;
            // 
            // lblErrorThoiGian
            // 
            lblErrorThoiGian.AutoSize = true;
            lblErrorThoiGian.ForeColor = Color.Red;
            lblErrorThoiGian.Location = new Point(320, 300);
            lblErrorThoiGian.Name = "lblErrorThoiGian";
            lblErrorThoiGian.Size = new Size(0, 15);
            lblErrorThoiGian.TabIndex = 17;
            lblErrorThoiGian.Visible = false;
            // 
            // frmThemDeTai
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 400);
            Controls.Add(lblErrorThoiGian);
            Controls.Add(lblErrorCapQuanLy);
            Controls.Add(lblErrorLinhVuc);
            Controls.Add(lblErrorTenDeTai);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(dtpThoiGianKetThuc);
            Controls.Add(lblThoiGianKetThuc);
            Controls.Add(dtpThoiGianBatDau);
            Controls.Add(lblThoiGianBatDau);
            Controls.Add(cmbCapQuanLy);
            Controls.Add(lblCapQuanLy);
            Controls.Add(txtLinhVuc);
            Controls.Add(lblLinhVuc);
            Controls.Add(txtMoTa);
            Controls.Add(lblMoTa);
            Controls.Add(txtTenDeTai);
            Controls.Add(lblTenDeTai);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmThemDeTai";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm đề tài mới";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTenDeTai;
        private TextBox txtTenDeTai;
        private Label lblMoTa;
        private TextBox txtMoTa;
        private Label lblLinhVuc;
        private TextBox txtLinhVuc;
        private Label lblCapQuanLy;
        private ComboBox cmbCapQuanLy;
        private Label lblThoiGianBatDau;
        private DateTimePicker dtpThoiGianBatDau;
        private Label lblThoiGianKetThuc;
        private DateTimePicker dtpThoiGianKetThuc;
        private Button btnLuu;
        private Button btnHuy;
        private Label lblErrorTenDeTai;
        private Label lblErrorLinhVuc;
        private Label lblErrorCapQuanLy;
        private Label lblErrorThoiGian;
    }
}
