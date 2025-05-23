namespace WinFormsApp1
{
    partial class frmThemSanPhamII
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemSanPhamII));
            lblTenBaoCao = new Label();
            txtTenBaoCao = new TextBox();
            lblLoaiBaoCao = new Label();
            cmbLoaiBaoCao = new ComboBox();
            lblFileAttach = new Label();
            btnChonFile = new Button();
            lblFile = new Label();
            btnLuu = new Button();
            btnHuy = new Button();
            lblErrorTenBaoCao = new Label();
            lblErrorLoaiBaoCao = new Label();
            SuspendLayout();
            // 
            // lblTenBaoCao
            // 
            lblTenBaoCao.AutoSize = true;
            lblTenBaoCao.Location = new Point(20, 30);
            lblTenBaoCao.Name = "lblTenBaoCao";
            lblTenBaoCao.Size = new Size(84, 15);
            lblTenBaoCao.TabIndex = 0;
            lblTenBaoCao.Text = "Tên sản phẩm:";
            // 
            // txtTenBaoCao
            // 
            txtTenBaoCao.Location = new Point(20, 50);
            txtTenBaoCao.Name = "txtTenBaoCao";
            txtTenBaoCao.Size = new Size(550, 23);
            txtTenBaoCao.TabIndex = 1;
            // 
            // lblLoaiBaoCao
            // 
            lblLoaiBaoCao.AutoSize = true;
            lblLoaiBaoCao.Location = new Point(20, 80);
            lblLoaiBaoCao.Name = "lblLoaiBaoCao";
            lblLoaiBaoCao.Size = new Size(96, 15);
            lblLoaiBaoCao.TabIndex = 2;
            lblLoaiBaoCao.Text = "Loại sản phẩm II:";
            // 
            // cmbLoaiBaoCao
            // 
            cmbLoaiBaoCao.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLoaiBaoCao.FormattingEnabled = true;
            cmbLoaiBaoCao.Items.AddRange(new object[] { "BaoCao", "QuyTrinh", "BanVe", "BanDo", "Khac" });
            cmbLoaiBaoCao.Location = new Point(20, 100);
            cmbLoaiBaoCao.Name = "cmbLoaiBaoCao";
            cmbLoaiBaoCao.Size = new Size(200, 23);
            cmbLoaiBaoCao.TabIndex = 3;
            // 
            // lblFileAttach
            // 
            lblFileAttach.AutoSize = true;
            lblFileAttach.Location = new Point(20, 140);
            lblFileAttach.Name = "lblFileAttach";
            lblFileAttach.Size = new Size(81, 15);
            lblFileAttach.TabIndex = 4;
            lblFileAttach.Text = "File đính kèm:";
            // 
            // btnChonFile
            // 
            btnChonFile.BackColor = Color.FromArgb(23, 162, 184);
            btnChonFile.ForeColor = Color.White;
            btnChonFile.Location = new Point(20, 160);
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
            lblFile.Location = new Point(126, 168);
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(70, 15);
            lblFile.TabIndex = 7;
            lblFile.Text = "Chưa có file";
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(40, 167, 69);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(404, 210);
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
            btnHuy.Location = new Point(490, 210);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(80, 30);
            btnHuy.TabIndex = 9;
            btnHuy.Text = "❌ Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += BtnHuy_Click;
            // 
            // lblErrorTenBaoCao
            // 
            lblErrorTenBaoCao.AutoSize = true;
            lblErrorTenBaoCao.ForeColor = Color.Red;
            lblErrorTenBaoCao.Location = new Point(20, 76);
            lblErrorTenBaoCao.Name = "lblErrorTenBaoCao";
            lblErrorTenBaoCao.Size = new Size(0, 15);
            lblErrorTenBaoCao.TabIndex = 10;
            lblErrorTenBaoCao.Visible = false;
            // 
            // lblErrorLoaiBaoCao
            // 
            lblErrorLoaiBaoCao.AutoSize = true;
            lblErrorLoaiBaoCao.ForeColor = Color.Red;
            lblErrorLoaiBaoCao.Location = new Point(20, 126);
            lblErrorLoaiBaoCao.Name = "lblErrorLoaiBaoCao";
            lblErrorLoaiBaoCao.Size = new Size(0, 15);
            lblErrorLoaiBaoCao.TabIndex = 11;
            lblErrorLoaiBaoCao.Visible = false;
            // 
            // frmThemSanPhamII
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 270);
            Controls.Add(lblErrorLoaiBaoCao);
            Controls.Add(lblErrorTenBaoCao);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(lblFile);
            Controls.Add(btnChonFile);
            Controls.Add(lblFileAttach);
            Controls.Add(cmbLoaiBaoCao);
            Controls.Add(lblLoaiBaoCao);
            Controls.Add(txtTenBaoCao);
            Controls.Add(lblTenBaoCao);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmThemSanPhamII";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm sản phẩm dạng II";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTenBaoCao;
        private TextBox txtTenBaoCao;
        private Label lblLoaiBaoCao;
        private ComboBox cmbLoaiBaoCao;
        private Label lblFileAttach;
        private Button btnChonFile;
        private Label lblFile;
        private Button btnLuu;
        private Button btnHuy;
        private Label lblErrorTenBaoCao;
        private Label lblErrorLoaiBaoCao;
    }
}
