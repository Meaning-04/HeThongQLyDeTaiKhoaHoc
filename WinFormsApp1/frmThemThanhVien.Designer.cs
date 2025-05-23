namespace WinFormsApp1
{
    partial class frmThemThanhVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemThanhVien));
            lblCanBo = new Label();
            cmbCanBo = new ComboBox();
            lblVaiTro = new Label();
            cmbVaiTro = new ComboBox();
            btnLuu = new Button();
            btnHuy = new Button();
            SuspendLayout();
            // 
            // lblCanBo
            // 
            lblCanBo.AutoSize = true;
            lblCanBo.Location = new Point(20, 30);
            lblCanBo.Name = "lblCanBo";
            lblCanBo.Size = new Size(78, 15);
            lblCanBo.TabIndex = 0;
            lblCanBo.Text = "Chọn cán bộ:";
            // 
            // cmbCanBo
            // 
            cmbCanBo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCanBo.FormattingEnabled = true;
            cmbCanBo.Location = new Point(20, 50);
            cmbCanBo.Name = "cmbCanBo";
            cmbCanBo.Size = new Size(350, 23);
            cmbCanBo.TabIndex = 1;
            // 
            // lblVaiTro
            // 
            lblVaiTro.AutoSize = true;
            lblVaiTro.Location = new Point(20, 80);
            lblVaiTro.Name = "lblVaiTro";
            lblVaiTro.Size = new Size(43, 15);
            lblVaiTro.TabIndex = 2;
            lblVaiTro.Text = "Vai trò:";
            // 
            // cmbVaiTro
            // 
            cmbVaiTro.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVaiTro.FormattingEnabled = true;
            cmbVaiTro.Items.AddRange(new object[] { "Chủ nhiệm", "Tham gia" });
            cmbVaiTro.Location = new Point(20, 100);
            cmbVaiTro.Name = "cmbVaiTro";
            cmbVaiTro.Size = new Size(350, 23);
            cmbVaiTro.TabIndex = 3;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(40, 167, 69);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(200, 141);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(80, 30);
            btnLuu.TabIndex = 4;
            btnLuu.Text = "💾 Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += BtnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.FromArgb(220, 53, 69);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(290, 141);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(80, 30);
            btnHuy.TabIndex = 5;
            btnHuy.Text = "❌ Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += BtnHuy_Click;
            // 
            // frmThemThanhVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 200);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(cmbVaiTro);
            Controls.Add(lblVaiTro);
            Controls.Add(cmbCanBo);
            Controls.Add(lblCanBo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmThemThanhVien";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm thành viên tham gia";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCanBo;
        private ComboBox cmbCanBo;
        private Label lblVaiTro;
        private ComboBox cmbVaiTro;
        private Button btnLuu;
        private Button btnHuy;
    }
}
