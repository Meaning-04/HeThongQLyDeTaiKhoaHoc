namespace WinFormsApp1
{
    partial class frmQuanLyCanBo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyCanBo));
            panelTop = new Panel();
            groupBoxFilter = new GroupBox();
            cmbPhongBan = new ComboBox();
            lblPhongBan = new Label();
            cmbHocVi = new ComboBox();
            lblHocVi = new Label();
            txtTimKiem = new TextBox();
            lblTimKiem = new Label();
            btnXuatWord = new Button();
            btnLamMoi = new Button();
            panelButtons = new Panel();
            btnXuatPDF = new Button();
            btnXuatExcel = new Button();
            btnTaiFile = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            panelMain = new Panel();
            dgvCanBo = new DataGridView();
            panelBottom = new Panel();
            lblTongSo = new Label();
            panelTop.SuspendLayout();
            groupBoxFilter.SuspendLayout();
            panelButtons.SuspendLayout();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCanBo).BeginInit();
            panelBottom.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(groupBoxFilter);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(10);
            panelTop.Size = new Size(1200, 124);
            panelTop.TabIndex = 0;
            // 
            // groupBoxFilter
            // 
            groupBoxFilter.Controls.Add(cmbPhongBan);
            groupBoxFilter.Controls.Add(lblPhongBan);
            groupBoxFilter.Controls.Add(cmbHocVi);
            groupBoxFilter.Controls.Add(lblHocVi);
            groupBoxFilter.Controls.Add(txtTimKiem);
            groupBoxFilter.Controls.Add(lblTimKiem);
            groupBoxFilter.Dock = DockStyle.Fill;
            groupBoxFilter.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBoxFilter.Location = new Point(10, 10);
            groupBoxFilter.Name = "groupBoxFilter";
            groupBoxFilter.Size = new Size(1180, 104);
            groupBoxFilter.TabIndex = 0;
            groupBoxFilter.TabStop = false;
            groupBoxFilter.Text = "🔍 Tìm kiếm và lọc";
            // 
            // cmbPhongBan
            // 
            cmbPhongBan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPhongBan.Font = new Font("Segoe UI", 9F);
            cmbPhongBan.FormattingEnabled = true;
            cmbPhongBan.Location = new Point(650, 50);
            cmbPhongBan.Name = "cmbPhongBan";
            cmbPhongBan.Size = new Size(180, 23);
            cmbPhongBan.TabIndex = 5;
            cmbPhongBan.SelectedIndexChanged += cmbPhongBan_SelectedIndexChanged;
            // 
            // lblPhongBan
            // 
            lblPhongBan.AutoSize = true;
            lblPhongBan.Font = new Font("Segoe UI", 9F);
            lblPhongBan.Location = new Point(650, 30);
            lblPhongBan.Name = "lblPhongBan";
            lblPhongBan.Size = new Size(68, 15);
            lblPhongBan.TabIndex = 4;
            lblPhongBan.Text = "Phòng ban:";
            // 
            // cmbHocVi
            // 
            cmbHocVi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHocVi.Font = new Font("Segoe UI", 9F);
            cmbHocVi.FormattingEnabled = true;
            cmbHocVi.Location = new Point(450, 50);
            cmbHocVi.Name = "cmbHocVi";
            cmbHocVi.Size = new Size(180, 23);
            cmbHocVi.TabIndex = 3;
            cmbHocVi.SelectedIndexChanged += cmbHocVi_SelectedIndexChanged;
            // 
            // lblHocVi
            // 
            lblHocVi.AutoSize = true;
            lblHocVi.Font = new Font("Segoe UI", 9F);
            lblHocVi.Location = new Point(450, 30);
            lblHocVi.Name = "lblHocVi";
            lblHocVi.Size = new Size(44, 15);
            lblHocVi.TabIndex = 2;
            lblHocVi.Text = "Học vị:";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Segoe UI", 9F);
            txtTimKiem.Location = new Point(20, 50);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập tên, chức vụ, chuyên ngành, phòng ban...";
            txtTimKiem.Size = new Size(400, 23);
            txtTimKiem.TabIndex = 1;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // lblTimKiem
            // 
            lblTimKiem.AutoSize = true;
            lblTimKiem.Font = new Font("Segoe UI", 9F);
            lblTimKiem.Location = new Point(20, 30);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(60, 15);
            lblTimKiem.TabIndex = 0;
            lblTimKiem.Text = "Tìm kiếm:";
            // 
            // btnXuatWord
            // 
            btnXuatWord.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXuatWord.BackColor = Color.FromArgb(0, 123, 255);
            btnXuatWord.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnXuatWord.ForeColor = Color.White;
            btnXuatWord.Location = new Point(818, 4);
            btnXuatWord.Name = "btnXuatWord";
            btnXuatWord.Size = new Size(120, 40);
            btnXuatWord.TabIndex = 7;
            btnXuatWord.Text = "📄 Xuất Word";
            btnXuatWord.UseVisualStyleBackColor = false;
            btnXuatWord.Click += btnXuatWord_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.BackColor = Color.FromArgb(108, 117, 125);
            btnLamMoi.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(692, 4);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(120, 40);
            btnLamMoi.TabIndex = 6;
            btnLamMoi.Text = "🔄 Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnXuatPDF);
            panelButtons.Controls.Add(btnXuatWord);
            panelButtons.Controls.Add(btnXuatExcel);
            panelButtons.Controls.Add(btnTaiFile);
            panelButtons.Controls.Add(btnXoa);
            panelButtons.Controls.Add(btnLamMoi);
            panelButtons.Controls.Add(btnSua);
            panelButtons.Controls.Add(btnThem);
            panelButtons.Dock = DockStyle.Top;
            panelButtons.Location = new Point(0, 124);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(10, 5, 10, 5);
            panelButtons.Size = new Size(1200, 50);
            panelButtons.TabIndex = 1;
            // 
            // btnXuatPDF
            // 
            btnXuatPDF.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXuatPDF.BackColor = Color.IndianRed;
            btnXuatPDF.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnXuatPDF.ForeColor = Color.White;
            btnXuatPDF.Location = new Point(1070, 4);
            btnXuatPDF.Name = "btnXuatPDF";
            btnXuatPDF.Size = new Size(120, 40);
            btnXuatPDF.TabIndex = 14;
            btnXuatPDF.Text = "📄 Xuất PDF";
            btnXuatPDF.UseVisualStyleBackColor = false;
            btnXuatPDF.Click += btnXuatPDF_Click;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXuatExcel.BackColor = Color.FromArgb(40, 167, 69);
            btnXuatExcel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            btnXuatExcel.ForeColor = Color.White;
            btnXuatExcel.Location = new Point(944, 4);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(120, 40);
            btnXuatExcel.TabIndex = 13;
            btnXuatExcel.Text = "📊 Xuất Excel";
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // btnTaiFile
            // 
            btnTaiFile.BackColor = Color.FromArgb(0, 192, 192);
            btnTaiFile.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTaiFile.ForeColor = Color.White;
            btnTaiFile.Location = new Point(388, 4);
            btnTaiFile.Name = "btnTaiFile";
            btnTaiFile.Size = new Size(120, 40);
            btnTaiFile.TabIndex = 3;
            btnTaiFile.Text = "📥 Tải file";
            btnTaiFile.UseVisualStyleBackColor = false;
            btnTaiFile.Click += btnTaiFile_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(220, 53, 69);
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(262, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(120, 40);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(255, 193, 7);
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSua.ForeColor = Color.Black;
            btnSua.Location = new Point(136, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(120, 40);
            btnSua.TabIndex = 1;
            btnSua.Text = "✏️ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(40, 167, 69);
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(10, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(120, 40);
            btnThem.TabIndex = 0;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(dgvCanBo);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 174);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(10, 0, 10, 0);
            panelMain.Size = new Size(1200, 496);
            panelMain.TabIndex = 2;
            // 
            // dgvCanBo
            // 
            dgvCanBo.AllowUserToAddRows = false;
            dgvCanBo.AllowUserToDeleteRows = false;
            dgvCanBo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCanBo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCanBo.Dock = DockStyle.Fill;
            dgvCanBo.Location = new Point(10, 0);
            dgvCanBo.MultiSelect = false;
            dgvCanBo.Name = "dgvCanBo";
            dgvCanBo.ReadOnly = true;
            dgvCanBo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCanBo.Size = new Size(1180, 496);
            dgvCanBo.TabIndex = 0;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(lblTongSo);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 670);
            panelBottom.Name = "panelBottom";
            panelBottom.Padding = new Padding(10, 5, 10, 5);
            panelBottom.Size = new Size(1200, 30);
            panelBottom.TabIndex = 3;
            // 
            // lblTongSo
            // 
            lblTongSo.AutoSize = true;
            lblTongSo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTongSo.Location = new Point(10, 8);
            lblTongSo.Name = "lblTongSo";
            lblTongSo.Size = new Size(102, 15);
            lblTongSo.TabIndex = 0;
            lblTongSo.Text = "Tổng số: 0 cán bộ";
            // 
            // frmQuanLyCanBo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(panelMain);
            Controls.Add(panelBottom);
            Controls.Add(panelButtons);
            Controls.Add(panelTop);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmQuanLyCanBo";
            Text = "Quản lý cán bộ";
            Load += frmQuanLyCanBo_Load;
            panelTop.ResumeLayout(false);
            groupBoxFilter.ResumeLayout(false);
            groupBoxFilter.PerformLayout();
            panelButtons.ResumeLayout(false);
            panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCanBo).EndInit();
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private GroupBox groupBoxFilter;
        private TextBox txtTimKiem;
        private Label lblTimKiem;
        private ComboBox cmbHocVi;
        private Label lblHocVi;
        private ComboBox cmbPhongBan;
        private Label lblPhongBan;
        private Button btnLamMoi;
        private Button btnXuatWord;
        private Panel panelButtons;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnTaiFile;
        private Panel panelMain;
        private DataGridView dgvCanBo;
        private Panel panelBottom;
        private Label lblTongSo;
        private Button btnXuatExcel;
        private Button btnXuatPDF;
    }
}
