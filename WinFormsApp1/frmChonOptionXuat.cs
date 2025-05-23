using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class frmChonOptionXuat : Form
    {
        public enum ExportOption
        {
            SelectedRecord,
            AllRecords
        }

        public ExportOption SelectedOption { get; private set; }
        public bool IsWordExport { get; private set; }

        public frmChonOptionXuat(bool isWordExport)
        {
            InitializeComponent();
            IsWordExport = isWordExport;
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = IsWordExport ? "Xuất Word" : "Xuất Excel";
            lblTitle.Text = $"Chọn loại xuất {(IsWordExport ? "Word" : "Excel")}";
        }

        private void btnXuatBanGhiDangChon_Click(object sender, EventArgs e)
        {
            SelectedOption = ExportOption.SelectedRecord;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnXuatTatCa_Click(object sender, EventArgs e)
        {
            SelectedOption = ExportOption.AllRecords;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
