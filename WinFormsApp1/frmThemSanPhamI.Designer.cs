namespace WinFormsApp1
{
    partial class frmThemSanPhamI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemSanPhamI));
            lblTenSanPham = new Label();
            txtTenSanPham = new TextBox();
            lblDonViHanhChinh = new Label();
            cmbDonViHanhChinh = new ComboBox();
            lblFileAttach = new Label();
            btnChonFile = new Button();
            lblFile = new Label();
            btnLuu = new Button();
            btnHuy = new Button();
            lblErrorTenSanPham = new Label();
            SuspendLayout();
            // 
            // lblTenSanPham
            // 
            lblTenSanPham.AutoSize = true;
            lblTenSanPham.Location = new Point(20, 30);
            lblTenSanPham.Name = "lblTenSanPham";
            lblTenSanPham.Size = new Size(84, 15);
            lblTenSanPham.TabIndex = 0;
            lblTenSanPham.Text = "Tên sản phẩm:";
            // 
            // txtTenSanPham
            // 
            txtTenSanPham.Location = new Point(20, 50);
            txtTenSanPham.Name = "txtTenSanPham";
            txtTenSanPham.Size = new Size(550, 23);
            txtTenSanPham.TabIndex = 1;
            // 
            // lblDonViHanhChinh
            // 
            lblDonViHanhChinh.AutoSize = true;
            lblDonViHanhChinh.Location = new Point(20, 90);
            lblDonViHanhChinh.Name = "lblDonViHanhChinh";
            lblDonViHanhChinh.Size = new Size(107, 15);
            lblDonViHanhChinh.TabIndex = 2;
            lblDonViHanhChinh.Text = "Đơn vị hành chính:";
            // 
            // cmbDonViHanhChinh
            // 
            cmbDonViHanhChinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDonViHanhChinh.FormattingEnabled = true;
            cmbDonViHanhChinh.Location = new Point(20, 110);
            cmbDonViHanhChinh.Name = "cmbDonViHanhChinh";
            cmbDonViHanhChinh.Size = new Size(200, 23);
            cmbDonViHanhChinh.TabIndex = 3;
            // 
            // lblFileAttach
            // 
            lblFileAttach.AutoSize = true;
            lblFileAttach.Location = new Point(20, 150);
            lblFileAttach.Name = "lblFileAttach";
            lblFileAttach.Size = new Size(81, 15);
            lblFileAttach.TabIndex = 4;
            lblFileAttach.Text = "File đính kèm:";
            // 
            // btnChonFile
            // 
            btnChonFile.BackColor = Color.FromArgb(23, 162, 184);
            btnChonFile.ForeColor = Color.White;
            btnChonFile.Location = new Point(20, 170);
            btnChonFile.Name = "btnChonFile";
            btnChonFile.Size = new Size(100, 30);
            btnChonFile.TabIndex = 5;
            btnChonFile.Text = "📎 Chọn file";
            btnChonFile.UseVisualStyleBackColor = false;
            btnChonFile.Click += BtnChonFile_Click;
            // 
            // lblFile
            // 
            lblFile.AutoSize = true;
            lblFile.ForeColor = Color.Gray;
            lblFile.Location = new Point(130, 175);
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(84, 15);
            lblFile.TabIndex = 6;
            lblFile.Text = "Chưa chọn file";
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(40, 167, 69);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(400, 220);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(80, 30);
            btnLuu.TabIndex = 7;
            btnLuu.Text = "💾 Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += BtnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.FromArgb(220, 53, 69);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(490, 220);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(80, 30);
            btnHuy.TabIndex = 8;
            btnHuy.Text = "❌ Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += BtnHuy_Click;
            // 
            // lblErrorTenSanPham
            // 
            lblErrorTenSanPham.AutoSize = true;
            lblErrorTenSanPham.ForeColor = Color.Red;
            lblErrorTenSanPham.Location = new Point(20, 76);
            lblErrorTenSanPham.Name = "lblErrorTenSanPham";
            lblErrorTenSanPham.Size = new Size(0, 15);
            lblErrorTenSanPham.TabIndex = 9;
            lblErrorTenSanPham.Visible = false;
            // 
            // frmThemSanPhamI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 280);
            Controls.Add(lblErrorTenSanPham);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(lblFile);
            Controls.Add(btnChonFile);
            Controls.Add(lblFileAttach);
            Controls.Add(cmbDonViHanhChinh);
            Controls.Add(lblDonViHanhChinh);
            Controls.Add(txtTenSanPham);
            Controls.Add(lblTenSanPham);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmThemSanPhamI";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm sản phẩm dạng I";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTenSanPham;
        private TextBox txtTenSanPham;
        private Label lblDonViHanhChinh;
        private ComboBox cmbDonViHanhChinh;
        private Label lblFileAttach;
        private Button btnChonFile;
        private Label lblFile;
        private Button btnLuu;
        private Button btnHuy;
        private Label lblErrorTenSanPham;
    }
}
