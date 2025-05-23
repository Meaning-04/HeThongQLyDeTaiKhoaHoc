namespace WinFormsApp1
{
    partial class MainFormNew
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormNew));
            menuStrip = new MenuStrip();
            thongKeMenuItem = new ToolStripMenuItem();
            canBoMenuItem = new ToolStripMenuItem();
            deTaiMenuItem = new ToolStripMenuItem();
            quanTriMenuItem = new ToolStripMenuItem();
            thoatMenuItem = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            lblUserName = new ToolStripStatusLabel();
            lblUserRole = new ToolStripStatusLabel();
            lblDateTime = new ToolStripStatusLabel();
            panelHeader = new Panel();
            lblSystemTitle = new Label();
            panelMain = new Panel();
            lblWelcome = new Label();
            timer = new System.Windows.Forms.Timer(components);
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            panelHeader.SuspendLayout();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.BackColor = Color.FromArgb(240, 248, 255);
            menuStrip.Font = new Font("Segoe UI", 11F);
            menuStrip.Items.AddRange(new ToolStripItem[] { thongKeMenuItem, canBoMenuItem, deTaiMenuItem, quanTriMenuItem, thoatMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(8, 3, 0, 3);
            menuStrip.Size = new Size(1200, 30);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // thongKeMenuItem
            // 
            thongKeMenuItem.Name = "thongKeMenuItem";
            thongKeMenuItem.Size = new Size(107, 24);
            thongKeMenuItem.Text = "📊 Thống kê";
            thongKeMenuItem.Click += thongKeMenuItem_Click;
            // 
            // canBoMenuItem
            // 
            canBoMenuItem.Name = "canBoMenuItem";
            canBoMenuItem.Size = new Size(145, 24);
            canBoMenuItem.Text = "👥 Quản lý cán bộ";
            canBoMenuItem.Click += canBoMenuItem_Click;
            // 
            // deTaiMenuItem
            // 
            deTaiMenuItem.Name = "deTaiMenuItem";
            deTaiMenuItem.Size = new Size(138, 24);
            deTaiMenuItem.Text = "📋 Quản lý đề tài";
            deTaiMenuItem.Click += deTaiMenuItem_Click;
            // 
            // quanTriMenuItem
            // 
            quanTriMenuItem.Name = "quanTriMenuItem";
            quanTriMenuItem.Size = new Size(162, 24);
            quanTriMenuItem.Text = "⚙️ Quản trị hệ thống";
            quanTriMenuItem.Click += quanTriMenuItem_Click;
            // 
            // thoatMenuItem
            // 
            thoatMenuItem.Name = "thoatMenuItem";
            thoatMenuItem.Size = new Size(84, 24);
            thoatMenuItem.Text = "🚪 Thoát";
            thoatMenuItem.Click += thoatMenuItem_Click;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.FromArgb(240, 248, 255);
            statusStrip.Font = new Font("Segoe UI", 9F);
            statusStrip.Items.AddRange(new ToolStripItem[] { lblUserName, lblUserRole, lblDateTime });
            statusStrip.Location = new Point(0, 676);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1200, 24);
            statusStrip.TabIndex = 1;
            statusStrip.Text = "statusStrip1";
            // 
            // lblUserName
            // 
            lblUserName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(107, 19);
            lblUserName.Text = "Người dùng: [Tên]";
            // 
            // lblUserRole
            // 
            lblUserRole.BorderSides = ToolStripStatusLabelBorderSides.Left;
            lblUserRole.Font = new Font("Segoe UI", 9F);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(81, 19);
            lblUserRole.Text = "Vai trò: [Role]";
            // 
            // lblDateTime
            // 
            lblDateTime.BorderSides = ToolStripStatusLabelBorderSides.Left;
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(997, 19);
            lblDateTime.Spring = true;
            lblDateTime.Text = "Ngày giờ: [DateTime]";
            lblDateTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(70, 130, 180);
            panelHeader.Controls.Add(lblSystemTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 30);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1200, 80);
            panelHeader.TabIndex = 2;
            // 
            // lblSystemTitle
            // 
            lblSystemTitle.AutoSize = true;
            lblSystemTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblSystemTitle.ForeColor = Color.White;
            lblSystemTitle.Location = new Point(12, 25);
            lblSystemTitle.Name = "lblSystemTitle";
            lblSystemTitle.Size = new Size(466, 32);
            lblSystemTitle.TabIndex = 1;
            lblSystemTitle.Text = "HỆ THỐNG QUẢN LÝ ĐỀ TÀI KHOA HỌC";
            lblSystemTitle.Click += lblSystemTitle_Click;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.BorderStyle = BorderStyle.FixedSingle;
            panelMain.Controls.Add(lblWelcome);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 110);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(10);
            panelMain.Size = new Size(1200, 566);
            panelMain.TabIndex = 3;
            // 
            // lblWelcome
            // 
            lblWelcome.Anchor = AnchorStyles.None;
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 16F);
            lblWelcome.ForeColor = Color.Gray;
            lblWelcome.Location = new Point(450, 249);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(303, 30);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Chào mừng đến với hệ thống!";
            lblWelcome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // MainFormNew
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(panelMain);
            Controls.Add(panelHeader);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(1000, 600);
            Name = "MainFormNew";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống quản lý đề tài khoa học";
            WindowState = FormWindowState.Maximized;
            FormClosing += MainFormNew_FormClosing;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem thongKeMenuItem;
        private ToolStripMenuItem canBoMenuItem;
        private ToolStripMenuItem deTaiMenuItem;
        private ToolStripMenuItem quanTriMenuItem;
        private ToolStripMenuItem thoatMenuItem;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblUserName;
        private ToolStripStatusLabel lblUserRole;
        private ToolStripStatusLabel lblDateTime;
        private Panel panelHeader;
        private Label lblSystemTitle;
        private Panel panelMain;
        private Label lblWelcome;
        private System.Windows.Forms.Timer timer;
    }
}
