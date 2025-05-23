namespace WinFormsApp1
{
    partial class frmChonOptionXuat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonOptionXuat));
            lblTitle = new Label();
            btnXuatBanGhiDangChon = new Button();
            btnXuatTatCa = new Button();
            btnHuy = new Button();
            lblDescription1 = new Label();
            lblDescription2 = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(150, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Chọn loại xuất file";
            // 
            // btnXuatBanGhiDangChon
            // 
            btnXuatBanGhiDangChon.Font = new Font("Segoe UI", 10F);
            btnXuatBanGhiDangChon.Location = new Point(12, 80);
            btnXuatBanGhiDangChon.Name = "btnXuatBanGhiDangChon";
            btnXuatBanGhiDangChon.Size = new Size(400, 40);
            btnXuatBanGhiDangChon.TabIndex = 1;
            btnXuatBanGhiDangChon.Text = "Xuất bản ghi đang chọn (chi tiết đầy đủ)";
            btnXuatBanGhiDangChon.UseVisualStyleBackColor = true;
            btnXuatBanGhiDangChon.Click += btnXuatBanGhiDangChon_Click;
            // 
            // btnXuatTatCa
            // 
            btnXuatTatCa.Font = new Font("Segoe UI", 10F);
            btnXuatTatCa.Location = new Point(12, 160);
            btnXuatTatCa.Name = "btnXuatTatCa";
            btnXuatTatCa.Size = new Size(400, 40);
            btnXuatTatCa.TabIndex = 2;
            btnXuatTatCa.Text = "Xuất danh sách tất cả";
            btnXuatTatCa.UseVisualStyleBackColor = true;
            btnXuatTatCa.Click += btnXuatTatCa_Click;
            // 
            // btnHuy
            // 
            btnHuy.Font = new Font("Segoe UI", 10F);
            btnHuy.Location = new Point(337, 220);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(75, 30);
            btnHuy.TabIndex = 3;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // lblDescription1
            // 
            lblDescription1.AutoSize = true;
            lblDescription1.Font = new Font("Segoe UI", 9F);
            lblDescription1.ForeColor = Color.Gray;
            lblDescription1.Location = new Point(12, 125);
            lblDescription1.Name = "lblDescription1";
            lblDescription1.Size = new Size(431, 15);
            lblDescription1.TabIndex = 4;
            lblDescription1.Text = "Bao gồm: thông tin đề tài, người tham gia, kinh phí, sản phẩm, đặc tính kỹ thuật";
            // 
            // lblDescription2
            // 
            lblDescription2.AutoSize = true;
            lblDescription2.Font = new Font("Segoe UI", 9F);
            lblDescription2.ForeColor = Color.Gray;
            lblDescription2.Location = new Point(12, 205);
            lblDescription2.Name = "lblDescription2";
            lblDescription2.Size = new Size(257, 15);
            lblDescription2.TabIndex = 5;
            lblDescription2.Text = "Xuất danh sách tất cả đề tài theo bộ lọc hiện tại";
            // 
            // frmChonOptionXuat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 262);
            Controls.Add(lblDescription2);
            Controls.Add(lblDescription1);
            Controls.Add(btnHuy);
            Controls.Add(btnXuatTatCa);
            Controls.Add(btnXuatBanGhiDangChon);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmChonOptionXuat";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chọn loại xuất";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnXuatBanGhiDangChon;
        private Button btnXuatTatCa;
        private Button btnHuy;
        private Label lblDescription1;
        private Label lblDescription2;
    }
}
