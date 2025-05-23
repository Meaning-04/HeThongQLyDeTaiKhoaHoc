namespace WinFormsApp1
{
    partial class frmThemDonVi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemDonVi));
            lblTenDonVi = new Label();
            txtTenDonVi = new TextBox();
            lblErrorTenDonVi = new Label();
            lblDiaChi = new Label();
            txtDiaChi = new TextBox();
            lblDienThoai = new Label();
            txtDienThoai = new TextBox();
            lblErrorDienThoai = new Label();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblErrorEmail = new Label();
            btnLuu = new Button();
            btnHuy = new Button();
            SuspendLayout();
            // 
            // lblTenDonVi
            // 
            lblTenDonVi.AutoSize = true;
            lblTenDonVi.Location = new Point(20, 30);
            lblTenDonVi.Name = "lblTenDonVi";
            lblTenDonVi.Size = new Size(65, 15);
            lblTenDonVi.TabIndex = 0;
            lblTenDonVi.Text = "Tên đơn vị:";
            // 
            // txtTenDonVi
            // 
            txtTenDonVi.Location = new Point(20, 50);
            txtTenDonVi.Name = "txtTenDonVi";
            txtTenDonVi.Size = new Size(450, 23);
            txtTenDonVi.TabIndex = 1;
            // 
            // lblErrorTenDonVi
            // 
            lblErrorTenDonVi.AutoSize = true;
            lblErrorTenDonVi.ForeColor = Color.Red;
            lblErrorTenDonVi.Location = new Point(20, 76);
            lblErrorTenDonVi.Name = "lblErrorTenDonVi";
            lblErrorTenDonVi.Size = new Size(0, 15);
            lblErrorTenDonVi.TabIndex = 10;
            lblErrorTenDonVi.Visible = false;
            // 
            // lblDiaChi
            // 
            lblDiaChi.AutoSize = true;
            lblDiaChi.Location = new Point(20, 100);
            lblDiaChi.Name = "lblDiaChi";
            lblDiaChi.Size = new Size(46, 15);
            lblDiaChi.TabIndex = 2;
            lblDiaChi.Text = "Địa chỉ:";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(20, 120);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(450, 23);
            txtDiaChi.TabIndex = 3;
            // 
            // lblDienThoai
            // 
            lblDienThoai.AutoSize = true;
            lblDienThoai.Location = new Point(20, 150);
            lblDienThoai.Name = "lblDienThoai";
            lblDienThoai.Size = new Size(64, 15);
            lblDienThoai.TabIndex = 4;
            lblDienThoai.Text = "Điện thoại:";
            // 
            // txtDienThoai
            // 
            txtDienThoai.Location = new Point(20, 170);
            txtDienThoai.Name = "txtDienThoai";
            txtDienThoai.Size = new Size(200, 23);
            txtDienThoai.TabIndex = 5;
            // 
            // lblErrorDienThoai
            // 
            lblErrorDienThoai.AutoSize = true;
            lblErrorDienThoai.ForeColor = Color.Red;
            lblErrorDienThoai.Location = new Point(20, 196);
            lblErrorDienThoai.Name = "lblErrorDienThoai";
            lblErrorDienThoai.Size = new Size(0, 15);
            lblErrorDienThoai.TabIndex = 11;
            lblErrorDienThoai.Visible = false;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(250, 150);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(250, 170);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 23);
            txtEmail.TabIndex = 7;
            // 
            // lblErrorEmail
            // 
            lblErrorEmail.AutoSize = true;
            lblErrorEmail.ForeColor = Color.Red;
            lblErrorEmail.Location = new Point(250, 196);
            lblErrorEmail.Name = "lblErrorEmail";
            lblErrorEmail.Size = new Size(0, 15);
            lblErrorEmail.TabIndex = 12;
            lblErrorEmail.Visible = false;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(40, 167, 69);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(300, 240);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(80, 30);
            btnLuu.TabIndex = 8;
            btnLuu.Text = "💾 Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += BtnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.FromArgb(220, 53, 69);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(390, 240);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(80, 30);
            btnHuy.TabIndex = 9;
            btnHuy.Text = "❌ Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += BtnHuy_Click;
            // 
            // frmThemDonVi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 320);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(lblErrorEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(lblErrorDienThoai);
            Controls.Add(txtDienThoai);
            Controls.Add(lblDienThoai);
            Controls.Add(txtDiaChi);
            Controls.Add(lblDiaChi);
            Controls.Add(lblErrorTenDonVi);
            Controls.Add(txtTenDonVi);
            Controls.Add(lblTenDonVi);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmThemDonVi";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm đơn vị phối hợp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTenDonVi;
        private TextBox txtTenDonVi;
        private Label lblErrorTenDonVi;
        private Label lblDiaChi;
        private TextBox txtDiaChi;
        private Label lblDienThoai;
        private TextBox txtDienThoai;
        private Label lblErrorDienThoai;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblErrorEmail;
        private Button btnLuu;
        private Button btnHuy;
    }
}
