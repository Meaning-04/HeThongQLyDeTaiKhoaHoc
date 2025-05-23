namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            taikhoan = new TextBox();
            button1 = new Button();
            matkhau = new TextBox();
            label1 = new Label();
            label2 = new Label();
            menuStrip1 = new MenuStrip();
            SuspendLayout();
            // 
            // taikhoan
            // 
            taikhoan.Location = new Point(185, 91);
            taikhoan.Name = "taikhoan";
            taikhoan.Size = new Size(224, 23);
            taikhoan.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(213, 165);
            button1.Name = "button1";
            button1.Size = new Size(145, 48);
            button1.TabIndex = 1;
            button1.Text = "Đăng nhập";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // matkhau
            // 
            matkhau.Location = new Point(185, 120);
            matkhau.Name = "matkhau";
            matkhau.Size = new Size(224, 23);
            matkhau.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(104, 94);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 2;
            label1.Text = "Tài khoản";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(105, 128);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 2;
            label2.Text = "Mật khẩu";
            // 
            // menuStrip1
            // 
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(562, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(562, 340);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(matkhau);
            Controls.Add(taikhoan);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox taikhoan;
        private Button button1;
        private TextBox matkhau;
        private Label label1;
        private Label label2;
        private MenuStrip menuStrip1;
    }
}
