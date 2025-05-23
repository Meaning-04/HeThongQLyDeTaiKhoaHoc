namespace WinFormsApp1
{
    partial class frmThemDacTinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemDacTinh));
            lblTenDacTinh = new Label();
            txtTenDacTinh = new TextBox();
            lblGiaTri = new Label();
            txtGiaTri = new TextBox();
            lblDonVi = new Label();
            txtDonVi = new TextBox();
            lblMoTa = new Label();
            txtMoTa = new TextBox();
            btnLuu = new Button();
            btnHuy = new Button();
            lblErrorTenDacTinh = new Label();
            lblErrorGiaTri = new Label();
            SuspendLayout();
            // 
            // lblTenDacTinh
            // 
            lblTenDacTinh.AutoSize = true;
            lblTenDacTinh.Location = new Point(20, 30);
            lblTenDacTinh.Name = "lblTenDacTinh";
            lblTenDacTinh.Size = new Size(75, 15);
            lblTenDacTinh.TabIndex = 0;
            lblTenDacTinh.Text = "Tên đặc tính:";
            // 
            // txtTenDacTinh
            // 
            txtTenDacTinh.Location = new Point(20, 50);
            txtTenDacTinh.Name = "txtTenDacTinh";
            txtTenDacTinh.Size = new Size(450, 23);
            txtTenDacTinh.TabIndex = 1;
            // 
            // lblGiaTri
            // 
            lblGiaTri.AutoSize = true;
            lblGiaTri.Location = new Point(20, 80);
            lblGiaTri.Name = "lblGiaTri";
            lblGiaTri.Size = new Size(41, 15);
            lblGiaTri.TabIndex = 2;
            lblGiaTri.Text = "Giá trị:";
            // 
            // txtGiaTri
            // 
            txtGiaTri.Location = new Point(20, 100);
            txtGiaTri.Name = "txtGiaTri";
            txtGiaTri.Size = new Size(200, 23);
            txtGiaTri.TabIndex = 3;
            // 
            // lblDonVi
            // 
            lblDonVi.AutoSize = true;
            lblDonVi.Location = new Point(240, 80);
            lblDonVi.Name = "lblDonVi";
            lblDonVi.Size = new Size(61, 15);
            lblDonVi.TabIndex = 4;
            lblDonVi.Text = "Đơn vị đo:";
            // 
            // txtDonVi
            // 
            txtDonVi.Location = new Point(240, 100);
            txtDonVi.Name = "txtDonVi";
            txtDonVi.Size = new Size(230, 23);
            txtDonVi.TabIndex = 5;
            // 
            // lblMoTa
            // 
            lblMoTa.AutoSize = true;
            lblMoTa.Location = new Point(20, 130);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(41, 15);
            lblMoTa.TabIndex = 6;
            lblMoTa.Text = "Mô tả:";
            // 
            // txtMoTa
            // 
            txtMoTa.Location = new Point(20, 150);
            txtMoTa.Multiline = true;
            txtMoTa.Name = "txtMoTa";
            txtMoTa.ScrollBars = ScrollBars.Vertical;
            txtMoTa.Size = new Size(450, 100);
            txtMoTa.TabIndex = 7;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(40, 167, 69);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(320, 280);
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
            btnHuy.Location = new Point(410, 280);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(80, 30);
            btnHuy.TabIndex = 9;
            btnHuy.Text = "❌ Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += BtnHuy_Click;
            // 
            // lblErrorTenDacTinh
            // 
            lblErrorTenDacTinh.AutoSize = true;
            lblErrorTenDacTinh.ForeColor = Color.Red;
            lblErrorTenDacTinh.Location = new Point(20, 100);
            lblErrorTenDacTinh.Name = "lblErrorTenDacTinh";
            lblErrorTenDacTinh.Size = new Size(0, 15);
            lblErrorTenDacTinh.TabIndex = 10;
            lblErrorTenDacTinh.Visible = false;
            // 
            // lblErrorGiaTri
            // 
            lblErrorGiaTri.AutoSize = true;
            lblErrorGiaTri.ForeColor = Color.Red;
            lblErrorGiaTri.Location = new Point(20, 150);
            lblErrorGiaTri.Name = "lblErrorGiaTri";
            lblErrorGiaTri.Size = new Size(0, 15);
            lblErrorGiaTri.TabIndex = 11;
            lblErrorGiaTri.Visible = false;
            // 
            // frmThemDacTinh
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 350);
            Controls.Add(lblErrorGiaTri);
            Controls.Add(lblErrorTenDacTinh);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(txtMoTa);
            Controls.Add(lblMoTa);
            Controls.Add(txtDonVi);
            Controls.Add(lblDonVi);
            Controls.Add(txtGiaTri);
            Controls.Add(lblGiaTri);
            Controls.Add(txtTenDacTinh);
            Controls.Add(lblTenDacTinh);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmThemDacTinh";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm đặc tính kỹ thuật";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTenDacTinh;
        private TextBox txtTenDacTinh;
        private Label lblGiaTri;
        private TextBox txtGiaTri;
        private Label lblDonVi;
        private TextBox txtDonVi;
        private Label lblMoTa;
        private TextBox txtMoTa;
        private Button btnLuu;
        private Button btnHuy;
        private Label lblErrorTenDacTinh;
        private Label lblErrorGiaTri;
    }
}
