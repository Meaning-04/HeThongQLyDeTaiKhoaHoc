using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsApp1
{
    partial class frmThongKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongKe));
            panelFilter = new Panel();
            groupBoxFilter = new GroupBox();
            btnExportExcel = new Button();
            clbLinhVuc = new CheckedListBox();
            lblLinhVuc = new Label();
            clbCapQuanLy = new CheckedListBox();
            lblCapQuanLy = new Label();
            dtpDenNgay = new DateTimePicker();
            lblDenNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            lblTuNgay = new Label();
            tabControlReports = new TabControl();
            tabCapQuanLy = new TabPage();
            splitContainer1 = new SplitContainer();
            chartCapQuanLy = new Chart();
            dgvCapQuanLy = new DataGridView();
            tabDonViHanhChinh = new TabPage();
            splitContainer2 = new SplitContainer();
            chartDonViHanhChinh = new Chart();
            dgvDonViHanhChinh = new DataGridView();
            tabKinhPhi = new TabPage();
            splitContainer3 = new SplitContainer();
            chartKinhPhi = new Chart();
            dgvKinhPhi = new DataGridView();
            panelFilter.SuspendLayout();
            groupBoxFilter.SuspendLayout();
            tabControlReports.SuspendLayout();
            tabCapQuanLy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartCapQuanLy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCapQuanLy).BeginInit();
            tabDonViHanhChinh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartDonViHanhChinh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDonViHanhChinh).BeginInit();
            tabKinhPhi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartKinhPhi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvKinhPhi).BeginInit();
            SuspendLayout();
            //
            // panelFilter
            //
            panelFilter.Controls.Add(groupBoxFilter);
            panelFilter.Dock = DockStyle.Top;
            panelFilter.Location = new Point(0, 0);
            panelFilter.Name = "panelFilter";
            panelFilter.Padding = new Padding(10);
            panelFilter.Size = new Size(1200, 150);
            panelFilter.TabIndex = 0;
            //
            // groupBoxFilter
            //
            groupBoxFilter.Controls.Add(btnExportExcel);
            groupBoxFilter.Controls.Add(clbLinhVuc);
            groupBoxFilter.Controls.Add(lblLinhVuc);
            groupBoxFilter.Controls.Add(clbCapQuanLy);
            groupBoxFilter.Controls.Add(lblCapQuanLy);
            groupBoxFilter.Controls.Add(dtpDenNgay);
            groupBoxFilter.Controls.Add(lblDenNgay);
            groupBoxFilter.Controls.Add(dtpTuNgay);
            groupBoxFilter.Controls.Add(lblTuNgay);
            groupBoxFilter.Dock = DockStyle.Fill;
            groupBoxFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxFilter.Location = new Point(10, 10);
            groupBoxFilter.Name = "groupBoxFilter";
            groupBoxFilter.Size = new Size(1180, 130);
            groupBoxFilter.TabIndex = 0;
            groupBoxFilter.TabStop = false;
            groupBoxFilter.Text = "Điều kiện lọc";
            //
            // btnExportExcel
            //
            btnExportExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportExcel.BackColor = Color.FromArgb(0, 192, 0);
            btnExportExcel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExportExcel.ForeColor = Color.White;
            btnExportExcel.Location = new Point(1024, 88);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(150, 36);
            btnExportExcel.TabIndex = 10;
            btnExportExcel.Text = "📊 Xuất Excel";
            btnExportExcel.UseVisualStyleBackColor = false;
            btnExportExcel.Click += btnExportExcel_Click;
            //
            // clbLinhVuc
            //
            clbLinhVuc.CheckOnClick = true;
            clbLinhVuc.Font = new Font("Segoe UI", 9F);
            clbLinhVuc.FormattingEnabled = true;
            clbLinhVuc.Location = new Point(206, 48);
            clbLinhVuc.Name = "clbLinhVuc";
            clbLinhVuc.Size = new Size(180, 76);
            clbLinhVuc.TabIndex = 7;
            //
            // lblLinhVuc
            //
            lblLinhVuc.AutoSize = true;
            lblLinhVuc.Font = new Font("Segoe UI", 9F);
            lblLinhVuc.Location = new Point(206, 28);
            lblLinhVuc.Name = "lblLinhVuc";
            lblLinhVuc.Size = new Size(55, 15);
            lblLinhVuc.TabIndex = 6;
            lblLinhVuc.Text = "Lĩnh vực:";
            //
            // clbCapQuanLy
            //
            clbCapQuanLy.CheckOnClick = true;
            clbCapQuanLy.Font = new Font("Segoe UI", 9F);
            clbCapQuanLy.FormattingEnabled = true;
            clbCapQuanLy.Location = new Point(6, 48);
            clbCapQuanLy.Name = "clbCapQuanLy";
            clbCapQuanLy.Size = new Size(180, 76);
            clbCapQuanLy.TabIndex = 5;
            //
            // lblCapQuanLy
            //
            lblCapQuanLy.AutoSize = true;
            lblCapQuanLy.Font = new Font("Segoe UI", 9F);
            lblCapQuanLy.Location = new Point(6, 28);
            lblCapQuanLy.Name = "lblCapQuanLy";
            lblCapQuanLy.Size = new Size(73, 15);
            lblCapQuanLy.TabIndex = 4;
            lblCapQuanLy.Text = "Cấp quản lý:";
            //
            // dtpDenNgay
            //
            dtpDenNgay.Font = new Font("Segoe UI", 9F);
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(601, 48);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(180, 23);
            dtpDenNgay.TabIndex = 3;
            //
            // lblDenNgay
            //
            lblDenNgay.AutoSize = true;
            lblDenNgay.Font = new Font("Segoe UI", 9F);
            lblDenNgay.Location = new Point(601, 28);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(60, 15);
            lblDenNgay.TabIndex = 2;
            lblDenNgay.Text = "Đến ngày:";
            //
            // dtpTuNgay
            //
            dtpTuNgay.Font = new Font("Segoe UI", 9F);
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(402, 48);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(180, 23);
            dtpTuNgay.TabIndex = 1;
            //
            // lblTuNgay
            //
            lblTuNgay.AutoSize = true;
            lblTuNgay.Font = new Font("Segoe UI", 9F);
            lblTuNgay.Location = new Point(402, 28);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(53, 15);
            lblTuNgay.TabIndex = 0;
            lblTuNgay.Text = "Từ ngày:";
            //
            // tabControlReports
            //
            tabControlReports.Controls.Add(tabCapQuanLy);
            tabControlReports.Controls.Add(tabDonViHanhChinh);
            tabControlReports.Controls.Add(tabKinhPhi);
            tabControlReports.Dock = DockStyle.Fill;
            tabControlReports.Font = new Font("Segoe UI", 10F);
            tabControlReports.Location = new Point(0, 150);
            tabControlReports.Name = "tabControlReports";
            tabControlReports.SelectedIndex = 0;
            tabControlReports.Size = new Size(1200, 550);
            tabControlReports.TabIndex = 1;
            //
            // tabCapQuanLy
            //
            tabCapQuanLy.Controls.Add(splitContainer1);
            tabCapQuanLy.Location = new Point(4, 26);
            tabCapQuanLy.Name = "tabCapQuanLy";
            tabCapQuanLy.Padding = new Padding(3);
            tabCapQuanLy.Size = new Size(1192, 520);
            tabCapQuanLy.TabIndex = 0;
            tabCapQuanLy.Text = "📊 Thống kê theo Cấp quản lý";
            tabCapQuanLy.UseVisualStyleBackColor = true;
            //
            // splitContainer1
            //
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            //
            // splitContainer1.Panel1
            //
            splitContainer1.Panel1.Controls.Add(chartCapQuanLy);
            //
            // splitContainer1.Panel2
            //
            splitContainer1.Panel2.Controls.Add(dgvCapQuanLy);
            splitContainer1.Size = new Size(1186, 514);
            splitContainer1.SplitterDistance = 300;
            splitContainer1.TabIndex = 0;
            //
            // chartCapQuanLy
            //
            chartCapQuanLy.Dock = DockStyle.Fill;
            chartCapQuanLy.Location = new Point(0, 0);
            chartCapQuanLy.Name = "chartCapQuanLy";
            chartCapQuanLy.Size = new Size(1186, 300);
            chartCapQuanLy.TabIndex = 0;
            //
            // dgvCapQuanLy
            //
            dgvCapQuanLy.AllowUserToAddRows = false;
            dgvCapQuanLy.AllowUserToDeleteRows = false;
            dgvCapQuanLy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCapQuanLy.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCapQuanLy.Dock = DockStyle.Fill;
            dgvCapQuanLy.Location = new Point(0, 0);
            dgvCapQuanLy.Name = "dgvCapQuanLy";
            dgvCapQuanLy.ReadOnly = true;
            dgvCapQuanLy.Size = new Size(1186, 210);
            dgvCapQuanLy.TabIndex = 0;
            //
            // tabDonViHanhChinh
            //
            tabDonViHanhChinh.Controls.Add(splitContainer2);
            tabDonViHanhChinh.Location = new Point(4, 26);
            tabDonViHanhChinh.Name = "tabDonViHanhChinh";
            tabDonViHanhChinh.Padding = new Padding(3);
            tabDonViHanhChinh.Size = new Size(1192, 520);
            tabDonViHanhChinh.TabIndex = 1;
            tabDonViHanhChinh.Text = "🏢 Thống kê theo Đơn vị hành chính";
            tabDonViHanhChinh.UseVisualStyleBackColor = true;
            //
            // splitContainer2
            //
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            //
            // splitContainer2.Panel1
            //
            splitContainer2.Panel1.Controls.Add(chartDonViHanhChinh);
            //
            // splitContainer2.Panel2
            //
            splitContainer2.Panel2.Controls.Add(dgvDonViHanhChinh);
            splitContainer2.Size = new Size(1186, 514);
            splitContainer2.SplitterDistance = 300;
            splitContainer2.TabIndex = 0;
            //
            // chartDonViHanhChinh
            //
            chartDonViHanhChinh.Dock = DockStyle.Fill;
            chartDonViHanhChinh.Location = new Point(0, 0);
            chartDonViHanhChinh.Name = "chartDonViHanhChinh";
            chartDonViHanhChinh.Size = new Size(1186, 300);
            chartDonViHanhChinh.TabIndex = 0;
            //
            // dgvDonViHanhChinh
            //
            dgvDonViHanhChinh.AllowUserToAddRows = false;
            dgvDonViHanhChinh.AllowUserToDeleteRows = false;
            dgvDonViHanhChinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDonViHanhChinh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDonViHanhChinh.Dock = DockStyle.Fill;
            dgvDonViHanhChinh.Location = new Point(0, 0);
            dgvDonViHanhChinh.Name = "dgvDonViHanhChinh";
            dgvDonViHanhChinh.ReadOnly = true;
            dgvDonViHanhChinh.Size = new Size(1186, 210);
            dgvDonViHanhChinh.TabIndex = 0;
            //
            // tabKinhPhi
            //
            tabKinhPhi.Controls.Add(splitContainer3);
            tabKinhPhi.Location = new Point(4, 26);
            tabKinhPhi.Name = "tabKinhPhi";
            tabKinhPhi.Size = new Size(1192, 520);
            tabKinhPhi.TabIndex = 2;
            tabKinhPhi.Text = "💰 Thống kê Kinh phí";
            tabKinhPhi.UseVisualStyleBackColor = true;
            //
            // splitContainer3
            //
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            //
            // splitContainer3.Panel1
            //
            splitContainer3.Panel1.Controls.Add(chartKinhPhi);
            //
            // splitContainer3.Panel2
            //
            splitContainer3.Panel2.Controls.Add(dgvKinhPhi);
            splitContainer3.Size = new Size(1192, 520);
            splitContainer3.SplitterDistance = 300;
            splitContainer3.TabIndex = 0;
            //
            // chartKinhPhi
            //
            chartKinhPhi.Dock = DockStyle.Fill;
            chartKinhPhi.Location = new Point(0, 0);
            chartKinhPhi.Name = "chartKinhPhi";
            chartKinhPhi.Size = new Size(1192, 300);
            chartKinhPhi.TabIndex = 0;
            //
            // dgvKinhPhi
            //
            dgvKinhPhi.AllowUserToAddRows = false;
            dgvKinhPhi.AllowUserToDeleteRows = false;
            dgvKinhPhi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKinhPhi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKinhPhi.Dock = DockStyle.Fill;
            dgvKinhPhi.Location = new Point(0, 0);
            dgvKinhPhi.Name = "dgvKinhPhi";
            dgvKinhPhi.ReadOnly = true;
            dgvKinhPhi.Size = new Size(1192, 216);
            dgvKinhPhi.TabIndex = 0;
            //
            // frmThongKe
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(tabControlReports);
            Controls.Add(panelFilter);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmThongKe";
            Text = "Thống kê chung";
            panelFilter.ResumeLayout(false);
            groupBoxFilter.ResumeLayout(false);
            groupBoxFilter.PerformLayout();
            tabControlReports.ResumeLayout(false);
            tabCapQuanLy.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartCapQuanLy).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCapQuanLy).EndInit();
            tabDonViHanhChinh.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartDonViHanhChinh).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDonViHanhChinh).EndInit();
            tabKinhPhi.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartKinhPhi).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvKinhPhi).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelFilter;
        private GroupBox groupBoxFilter;
        private DateTimePicker dtpTuNgay;
        private Label lblTuNgay;
        private DateTimePicker dtpDenNgay;
        private Label lblDenNgay;
        private CheckedListBox clbCapQuanLy;
        private Label lblCapQuanLy;
        private CheckedListBox clbLinhVuc;
        private Label lblLinhVuc;
        private Button btnExportExcel;
        private TabControl tabControlReports;
        private TabPage tabCapQuanLy;
        private TabPage tabDonViHanhChinh;
        private TabPage tabKinhPhi;
        private SplitContainer splitContainer1;
        private Chart chartCapQuanLy;
        private DataGridView dgvCapQuanLy;
        private SplitContainer splitContainer2;
        private Chart chartDonViHanhChinh;
        private DataGridView dgvDonViHanhChinh;
        private SplitContainer splitContainer3;
        private Chart chartKinhPhi;
        private DataGridView dgvKinhPhi;
    }
}
