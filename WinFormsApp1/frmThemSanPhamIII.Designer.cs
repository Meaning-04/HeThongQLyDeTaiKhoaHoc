namespace WinFormsApp1
{
    partial class frmThemSanPhamIII
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemSanPhamIII));
            lblTieuDe = new Label();
            lblTacGia = new Label();
            lblLoaiBaiBao = new Label();
            lblFileAttach = new Label();
            txtTieuDe = new TextBox();
            txtTacGia = new TextBox();
            cmbLoaiBaiBao = new ComboBox();
            btnChonFile = new Button();
            lblFile = new Label();
            btnLuu = new Button();
            btnHuy = new Button();
            lblErrorTieuDe = new Label();
            lblErrorLoaiBaiBao = new Label();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Location = new Point(20, 30);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(84, 15);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "Tên sản phẩm:";
            // 
            // lblTacGia
            // 
            lblTacGia.AutoSize = true;
            lblTacGia.Location = new Point(20, 80);
            lblTacGia.Name = "lblTacGia";
            lblTacGia.Size = new Size(76, 15);
            lblTacGia.TabIndex = 1;
            lblTacGia.Text = "Nơi công bố:";
            // 
            // lblLoaiBaiBao
            // 
            lblLoaiBaiBao.AutoSize = true;
            lblLoaiBaiBao.Location = new Point(20, 130);
            lblLoaiBaiBao.Name = "lblLoaiBaiBao";
            lblLoaiBaiBao.Size = new Size(99, 15);
            lblLoaiBaiBao.TabIndex = 2;
            lblLoaiBaiBao.Text = "Loại sản phẩm III:";
            // 
            // lblFileAttach
            // 
            lblFileAttach.AutoSize = true;
            lblFileAttach.Location = new Point(20, 180);
            lblFileAttach.Name = "lblFileAttach";
            lblFileAttach.Size = new Size(81, 15);
            lblFileAttach.TabIndex = 3;
            lblFileAttach.Text = "File đính kèm:";
            // 
            // txtTieuDe
            // 
            txtTieuDe.Location = new Point(20, 50);
            txtTieuDe.Name = "txtTieuDe";
            txtTieuDe.Size = new Size(550, 23);
            txtTieuDe.TabIndex = 4;
            // 
            // txtTacGia
            // 
            txtTacGia.Location = new Point(20, 100);
            txtTacGia.Name = "txtTacGia";
            txtTacGia.Size = new Size(550, 23);
            txtTacGia.TabIndex = 5;
            // 
            // cmbLoaiBaiBao
            // 
            cmbLoaiBaiBao.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLoaiBaiBao.FormattingEnabled = true;
            cmbLoaiBaiBao.Items.AddRange(new object[] { "BangSangChe", "GiaiPhapHuuIch", "BaiBao" });
            cmbLoaiBaiBao.Location = new Point(20, 150);
            cmbLoaiBaiBao.Name = "cmbLoaiBaiBao";
            cmbLoaiBaiBao.Size = new Size(200, 23);
            cmbLoaiBaiBao.TabIndex = 6;
            // 
            // btnChonFile
            // 
            btnChonFile.BackColor = Color.FromArgb(23, 162, 184);
            btnChonFile.ForeColor = Color.White;
            btnChonFile.Location = new Point(20, 200);
            btnChonFile.Name = "btnChonFile";
            btnChonFile.Size = new Size(100, 30);
            btnChonFile.TabIndex = 7;
            btnChonFile.Text = "📎 Chọn file";
            btnChonFile.UseVisualStyleBackColor = false;
            btnChonFile.Click += BtnChonFile_Click;
            // 
            // lblFile
            // 
            lblFile.AutoSize = true;
            lblFile.ForeColor = Color.Gray;
            lblFile.Location = new Point(126, 208);
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(70, 15);
            lblFile.TabIndex = 9;
            lblFile.Text = "Chưa có file";
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(40, 167, 69);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(400, 250);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(80, 30);
            btnLuu.TabIndex = 10;
            btnLuu.Text = "💾 Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += BtnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.FromArgb(220, 53, 69);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(490, 250);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(80, 30);
            btnHuy.TabIndex = 11;
            btnHuy.Text = "❌ Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += BtnHuy_Click;
            // 
            // lblErrorTieuDe
            // 
            lblErrorTieuDe.AutoSize = true;
            lblErrorTieuDe.ForeColor = Color.Red;
            lblErrorTieuDe.Location = new Point(20, 76);
            lblErrorTieuDe.Name = "lblErrorTieuDe";
            lblErrorTieuDe.Size = new Size(0, 15);
            lblErrorTieuDe.TabIndex = 12;
            lblErrorTieuDe.Visible = false;
            // 
            // lblErrorLoaiBaiBao
            // 
            lblErrorLoaiBaiBao.AutoSize = true;
            lblErrorLoaiBaiBao.ForeColor = Color.Red;
            lblErrorLoaiBaiBao.Location = new Point(20, 176);
            lblErrorLoaiBaiBao.Name = "lblErrorLoaiBaiBao";
            lblErrorLoaiBaiBao.Size = new Size(0, 15);
            lblErrorLoaiBaiBao.TabIndex = 13;
            lblErrorLoaiBaiBao.Visible = false;
            // 
            // frmThemSanPhamIII
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 310);
            Controls.Add(lblErrorLoaiBaiBao);
            Controls.Add(lblErrorTieuDe);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(lblFile);
            Controls.Add(btnChonFile);
            Controls.Add(cmbLoaiBaiBao);
            Controls.Add(txtTacGia);
            Controls.Add(txtTieuDe);
            Controls.Add(lblFileAttach);
            Controls.Add(lblLoaiBaiBao);
            Controls.Add(lblTacGia);
            Controls.Add(lblTieuDe);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmThemSanPhamIII";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm sản phẩm dạng III";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private Label lblTacGia;
        private Label lblLoaiBaiBao;
        private Label lblFileAttach;
        private TextBox txtTieuDe;
        private TextBox txtTacGia;
        private ComboBox cmbLoaiBaiBao;
        private Button btnChonFile;
        private Label lblFile;
        private Button btnLuu;
        private Button btnHuy;
        private Label lblErrorTieuDe;
        private Label lblErrorLoaiBaiBao;
    }
}
