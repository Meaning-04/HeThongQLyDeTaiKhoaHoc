using Microsoft.EntityFrameworkCore;
using Models.HandleData;
using Models.Models;

namespace WinFormsApp1
{
    public partial class frmDeTaiChiTiet : Form
    {
        // Private fields
        private int currentDeTaiId = 0; // Mặc định load đề tài đầu tiên
        private TaiKhoan currentUser; // Thông tin user hiện tại
        private readonly Action? onBackCallback; // Callback để quay lại form cha
        private readonly bool isPanelMode = false; // Kiểm tra xem có đang chạy trong panel mode không

        // Controls are now defined in Designer.cs

        public frmDeTaiChiTiet(TaiKhoan user, int? deTaiId = null, Action? backCallback = null)
        {
            currentUser = user;
            InitializeComponent();
            SetupUserPermissions(); // Thiết lập quyền hạn

            if (deTaiId.HasValue)
            {
                currentDeTaiId = deTaiId.Value;
                // Debug: Log thông tin đề tài được truyền vào
                System.Diagnostics.Debug.WriteLine($"frmDeTaiChiTiet Constructor: deTaiId = {deTaiId.Value}, currentDeTaiId = {currentDeTaiId}");
            }
            else
            {
                // Debug: Log khi không có deTaiId
                System.Diagnostics.Debug.WriteLine($"frmDeTaiChiTiet Constructor: No deTaiId provided, using default currentDeTaiId = {currentDeTaiId}");
            }

            // Thiết lập panel mode
            onBackCallback = backCallback;
            isPanelMode = backCallback != null;

            // Ẩn/hiện nút quay lại tùy theo mode
            btnQuayLai.Visible = isPanelMode;
        }

        private void SetupUserPermissions()
        {
            // Kiểm tra quyền hạn và ẩn/hiện các nút tương ứng
            bool isAdmin = currentUser.VaiTro == VaiTroTaiKhoan.Admin;

            // Ẩn/hiện các nút CRUD chính
            btnLuu.Visible = isAdmin;

            // Ẩn/hiện các nút CRUD đề tài
            btnSuaDeTai.Visible = isAdmin;
            btnXoaDeTai.Visible = isAdmin;

            // Ẩn/hiện các nút quản lý thành viên
            btnThemThanhVien.Visible = isAdmin;
            btnXoaThanhVien.Visible = isAdmin;

            // Ẩn/hiện các nút quản lý đơn vị phối hợp
            btnThemDonVi.Visible = isAdmin;
            btnSuaDonVi.Visible = isAdmin;
            btnXoaDonVi.Visible = isAdmin;

            // Ẩn/hiện các nút quản lý sản phẩm
            btnThemSanPhamI.Visible = isAdmin;
            btnSuaSanPhamI.Visible = isAdmin;
            btnXoaSanPhamI.Visible = isAdmin;
            // Nút tải file sản phẩm I hiển thị cho cả Admin và User
            btnTaiFile.Visible = true;

            btnThemSanPhamII.Visible = isAdmin;
            btnSuaSanPhamII.Visible = isAdmin;
            btnXoaSanPhamII.Visible = isAdmin;
            // Nút tải file sản phẩm II hiển thị cho cả Admin và User
            btnTaiFileSanPhamII.Visible = true;

            btnThemSanPhamIII.Visible = isAdmin;
            btnSuaSanPhamIII.Visible = isAdmin;
            btnXoaSanPhamIII.Visible = isAdmin;
            // Nút tải file sản phẩm III hiển thị cho cả Admin và User
            btnTaiFileSanPhamIII.Visible = true;

            // Ẩn/hiện các nút quản lý đặc tính kỹ thuật
            btnThemDacTinh.Visible = isAdmin;
            btnSuaDacTinh.Visible = isAdmin;
            btnXoaDacTinh.Visible = isAdmin;

            // Đặt các textbox và controls thành ReadOnly cho User
            if (!isAdmin)
            {
                txtTenDeTai.ReadOnly = true;
                txtMoTa.ReadOnly = true;
                txtLinhVuc.ReadOnly = true;
                dtpThoiGianBatDau.Enabled = false;
                dtpThoiGianKetThuc.Enabled = false;
                cmbCapQuanLy.Enabled = false;

                // Kinh phí controls
                txtKinhPhiNganSach.ReadOnly = true;
                txtKinhPhiKhac.ReadOnly = true;
                txtTongKinhPhi.ReadOnly = true;
            }
        }

        // Helper method để kiểm tra quyền hạn
        private bool CheckAdminPermission()
        {
            if (currentUser.VaiTro != VaiTroTaiKhoan.Admin)
            {
                MessageBox.Show("Bạn không có quyền thực hiện thao tác này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }



        private async void frmDeTaiChiTiet_Load(object sender, EventArgs e)
        {
            // Setup events for data change tracking and budget calculation
            txtKinhPhiNganSach.TextChanged += CalculateTotalBudget;
            txtKinhPhiKhac.TextChanged += CalculateTotalBudget;


            await LoadRealData();
        }





        private async Task LoadRealData()
        {
            try
            {
                using (var context = new DAContext())
                {
                    // Load danh sách đề tài vào ComboBox
                    var deTaiList = await context.DeTai.ToListAsync();
                    cmbDeTaiList.Items.Clear();
                    foreach (var dt in deTaiList)
                    {
                        cmbDeTaiList.Items.Add($"DT{dt.MaDeTai:D6} - {dt.TenDeTai}");
                    }

                    if (cmbDeTaiList.Items.Count > 0)
                    {
                        // Tìm index của đề tài hiện tại (currentDeTaiId)
                        int selectedIndex = 0;
                        for (int i = 0; i < deTaiList.Count; i++)
                        {
                            if (deTaiList[i].MaDeTai == currentDeTaiId)
                            {
                                selectedIndex = i;
                                break;
                            }
                        }

                        // Debug: Log thông tin đang được chọn
                        System.Diagnostics.Debug.WriteLine($"LoadRealData: currentDeTaiId = {currentDeTaiId}, selectedIndex = {selectedIndex}");

                        cmbDeTaiList.SelectedIndex = selectedIndex;
                        // currentDeTaiId đã được set trong constructor, không cần thay đổi
                        await LoadDeTaiDetails(currentDeTaiId);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CmbDeTaiList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDeTaiList.SelectedIndex >= 0)
            {
                using (var context = new DAContext())
                {
                    var deTaiList = await context.DeTai.ToListAsync();
                    if (cmbDeTaiList.SelectedIndex < deTaiList.Count)
                    {
                        currentDeTaiId = deTaiList[cmbDeTaiList.SelectedIndex].MaDeTai;
                        await LoadDeTaiDetails(currentDeTaiId);
                    }
                }
            }
        }

        private async Task LoadDeTaiDetails(int deTaiId)
        {
            try
            {
                using (var context = new DAContext())
                {
                    // Load thông tin đề tài
                    var deTai = await context.DeTai.FirstOrDefaultAsync(dt => dt.MaDeTai == deTaiId);
                    if (deTai != null)
                    {
                        txtMaDeTai.Text = $"DT{deTai.MaDeTai:D6}";
                        txtTenDeTai.Text = deTai.TenDeTai;
                        txtMoTa.Text = deTai.MoTaTomTat;
                        txtLinhVuc.Text = deTai.LinhVuc;

                        // Set thời gian
                        if (deTai.ThoiGianBatDau.HasValue)
                            dtpThoiGianBatDau.Value = deTai.ThoiGianBatDau.Value;
                        if (deTai.ThoiGianKetThuc.HasValue)
                            dtpThoiGianKetThuc.Value = deTai.ThoiGianKetThuc.Value;

                        // Set cấp quản lý - mapping enum to display text
                        var capQuanLyMapping = new Dictionary<string, int>
                        {
                            { "NhaNuoc", 0 },  // "Nhà nước"
                            { "Bo", 1 },       // "Bộ"
                            { "Nganh", 2 },    // "Ngành"
                            { "CoSo", 3 }      // "Cơ sở"
                        };

                        if (capQuanLyMapping.ContainsKey(deTai.CapQuanLy.ToString()))
                        {
                            cmbCapQuanLy.SelectedIndex = capQuanLyMapping[deTai.CapQuanLy.ToString()];
                        }
                    }

                    // Load kinh phí
                    var kinhPhi = await context.KinhPhi.FirstOrDefaultAsync(kp => kp.MaDeTai == deTaiId);
                    if (kinhPhi != null)
                    {
                        txtKinhPhiNganSach.Text = kinhPhi.NganSach?.ToString() ?? "0";
                        txtKinhPhiKhac.Text = kinhPhi.Khac?.ToString() ?? "0";

                        // Tính và hiển thị tổng kinh phí
                        long tong = (kinhPhi.NganSach ?? 0) + (kinhPhi.Khac ?? 0);
                        txtTongKinhPhi.Text = tong.ToString();
                    }
                    else
                    {
                        txtKinhPhiNganSach.Text = "0";
                        txtKinhPhiKhac.Text = "0";
                        txtTongKinhPhi.Text = "0";
                    }

                    // Load thành viên tham gia
                    await LoadThanhVien(deTaiId);

                    // Load đơn vị phối hợp
                    await LoadDonViPhoiHop(deTaiId);

                    // Load sản phẩm
                    await LoadSanPham(deTaiId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết đề tài: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadThanhVien(int deTaiId)
        {
            using (var context = new DAContext())
            {
                var thanhVienList = await context.VaiTroThamGia
                    .Include(vt => vt.CanBo)
                    .Where(vt => vt.MaDeTai == deTaiId)
                    .ToListAsync();

                dgvThanhVien.Rows.Clear();
                int stt = 1;
                foreach (var tv in thanhVienList)
                {
                    // Map enum to display text
                    string vaiTroDisplay = tv.VaiTro.ToString() == "ChuNhiem" ? "Chủ nhiệm" : "Tham gia";
                    dgvThanhVien.Rows.Add(stt++, tv.CanBo?.HoTen ?? "N/A", vaiTroDisplay);
                }
            }
        }

        private async Task LoadDonViPhoiHop(int deTaiId)
        {
            using (var context = new DAContext())
            {
                // Lấy danh sách MaDonVi từ bảng DeTai_DonVi
                var donViIds = await context.DeTai_DonVi
                    .Where(dd => dd.MaDeTai == deTaiId)
                    .Select(dd => dd.MaDonVi)
                    .ToListAsync();

                // Lấy thông tin chi tiết đơn vị
                var donViList = await context.DonViPhoiHop
                    .Where(dv => donViIds.Contains(dv.MaDonVi))
                    .ToListAsync();

                dgvDonVi.Rows.Clear();
                int stt = 1;
                foreach (var dv in donViList)
                {
                    dgvDonVi.Rows.Add(stt++, dv.TenDonVi ?? "N/A",
                        dv.DiaChi ?? "N/A",
                        dv.SoDienThoai ?? "N/A",
                        dv.Email ?? "N/A");
                }
            }
        }

        private async Task LoadSanPham(int deTaiId)
        {
            using (var context = new DAContext())
            {
                // Load sản phẩm Dạng I
                var sanPhamI = await context.ChiTietSanPham_DangI
                    .Include(sp => sp.DonViHanhChinh)
                    .Where(sp => sp.MaDeTai == deTaiId)
                    .ToListAsync();

                dgvSanPhamI.Rows.Clear();
                int stt = 1;
                foreach (var sp in sanPhamI)
                {
                    dgvSanPhamI.Rows.Add(stt++, sp.TenSanPham_I,
                        sp.DonViHanhChinh?.TinhThanh ?? "N/A",
                        sp.file_SanPham_I != null ? "Có file" : "Không có file");
                }

                // Load sản phẩm Dạng II
                var sanPhamII = await context.ChiTietSanPham_DangII
                    .Where(sp => sp.MaDeTai == deTaiId)
                    .ToListAsync();

                dgvSanPhamII.Rows.Clear();
                stt = 1;
                foreach (var sp in sanPhamII)
                {
                    string fileStatus = sp.file_SanPham_II != null && sp.file_SanPham_II.Length > 0 ? "Có file" : "Không có file";
                    dgvSanPhamII.Rows.Add(stt++, sp.TenSanPham_II, sp.LoaiSanPham_II.ToString(), fileStatus);
                }

                // Load sản phẩm Dạng III
                var sanPhamIII = await context.ChiTietSanPham_DangIII
                    .Where(sp => sp.MaDeTai == deTaiId)
                    .ToListAsync();

                dgvSanPhamIII.Rows.Clear();
                stt = 1;
                foreach (var sp in sanPhamIII)
                {
                    string fileStatus = sp.file_SanPham_III != null && sp.file_SanPham_III.Length > 0 ? "Có file" : "Không có file";
                    dgvSanPhamIII.Rows.Add(stt++, sp.TenSanPham_III, sp.LoaiSanPham_III.ToString(), sp.NoiCongBo ?? "N/A", fileStatus);
                }
            }
        }

        private async void DgvSanPhamI_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSanPhamI.SelectedRows.Count > 0)
            {
                var selectedIndex = dgvSanPhamI.SelectedRows[0].Index;
                using (var context = new DAContext())
                {
                    var sanPhamI = await context.ChiTietSanPham_DangI
                        .Where(sp => sp.MaDeTai == currentDeTaiId)
                        .ToListAsync();

                    if (selectedIndex < sanPhamI.Count)
                    {
                        var selectedSanPham = sanPhamI[selectedIndex];
                        await LoadDacTinhKyThuat(selectedSanPham.MaSanPham_I);
                    }
                }
            }
        }

        private async Task LoadDacTinhKyThuat(int maSanPham)
        {
            using (var context = new DAContext())
            {
                var dacTinhList = await context.DacTinhKyThuat
                    .Where(dt => dt.MaSanPham_I == maSanPham)
                    .ToListAsync();

                dgvDacTinhKyThuat.Rows.Clear();
                int stt = 1;
                foreach (var dt in dacTinhList)
                {
                    dgvDacTinhKyThuat.Rows.Add(stt++, dt.ThongSo, dt.GiaTri?.ToString() ?? "N/A", dt.DonViDo, dt.ChiChu);
                }
            }
        }

        private void CalculateTotalBudget(object sender, EventArgs e)
        {
            try
            {
                // Validate và parse kinh phí ngân sách
                long nganSach = 0;
                if (!string.IsNullOrEmpty(txtKinhPhiNganSach.Text))
                {
                    if (!long.TryParse(txtKinhPhiNganSach.Text.Replace(",", string.Empty), out nganSach) || nganSach < 0)
                    {
                        // Nếu không parse được hoặc âm, reset về 0
                        txtKinhPhiNganSach.Text = "0";
                        nganSach = 0;
                    }
                }

                // Validate và parse kinh phí khác
                long khac = 0;
                if (!string.IsNullOrEmpty(txtKinhPhiKhac.Text))
                {
                    if (!long.TryParse(txtKinhPhiKhac.Text.Replace(",", string.Empty), out khac) || khac < 0)
                    {
                        // Nếu không parse được hoặc âm, reset về 0
                        txtKinhPhiKhac.Text = "0";
                        khac = 0;
                    }
                }

                // Tính tổng và hiển thị (không format với dấu phẩy)
                long tong = nganSach + khac;
                txtTongKinhPhi.Text = tong.ToString();
            }
            catch
            {
                txtTongKinhPhi.Text = "0";
            }
        }

        #region Event Handlers - Main Buttons

        private async void BtnLuu_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            try
            {
                await SaveDeTaiInfo();
                await SaveKinhPhiInfo();
                MessageBox.Show("Lưu thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Save Methods

        private async Task SaveDeTaiInfo()
        {
            using (var context = new DAContext())
            {
                var deTai = await context.DeTai.FirstOrDefaultAsync(dt => dt.MaDeTai == currentDeTaiId);
                if (deTai != null)
                {
                    deTai.TenDeTai = txtTenDeTai.Text;
                    deTai.MoTaTomTat = txtMoTa.Text;
                    deTai.LinhVuc = txtLinhVuc.Text;
                    deTai.ThoiGianBatDau = dtpThoiGianBatDau.Value;
                    deTai.ThoiGianKetThuc = dtpThoiGianKetThuc.Value;

                    // Map ComboBox selection to enum
                    var capQuanLyValues = new[] { CapQuanLy.NhaNuoc, CapQuanLy.Bo, CapQuanLy.Nganh, CapQuanLy.CoSo };
                    if (cmbCapQuanLy.SelectedIndex >= 0 && cmbCapQuanLy.SelectedIndex < capQuanLyValues.Length)
                    {
                        deTai.CapQuanLy = capQuanLyValues[cmbCapQuanLy.SelectedIndex];
                    }

                    await context.SaveChangesAsync();
                }
            }
        }

        private async Task SaveKinhPhiInfo()
        {
            using (var context = new DAContext())
            {
                var kinhPhi = await context.KinhPhi.FirstOrDefaultAsync(kp => kp.MaDeTai == currentDeTaiId);
                if (kinhPhi == null)
                {
                    kinhPhi = new KinhPhi { MaDeTai = currentDeTaiId };
                    context.KinhPhi.Add(kinhPhi);
                }

                // Parse kinh phí, loại bỏ dấu phẩy nếu có
                kinhPhi.NganSach = string.IsNullOrEmpty(txtKinhPhiNganSach.Text) ? 0 : long.Parse(txtKinhPhiNganSach.Text.Replace(",", string.Empty));
                kinhPhi.Khac = string.IsNullOrEmpty(txtKinhPhiKhac.Text) ? 0 : long.Parse(txtKinhPhiKhac.Text.Replace(",", string.Empty));

                await context.SaveChangesAsync();
            }
        }

        #endregion

        #region Event Handlers - Thành viên

        private async void BtnThemThanhVien_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            try
            {
                // Debug: Log thông tin đề tài hiện tại
                System.Diagnostics.Debug.WriteLine($"BtnThemThanhVien_Click: currentDeTaiId = {currentDeTaiId}");

                if (currentDeTaiId < 0)
                {
                    MessageBox.Show("Vui lòng chọn đề tài trước khi thêm thành viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var frmThem = new frmThemThanhVien(currentDeTaiId);
                if (frmThem.ShowDialog() == DialogResult.OK)
                {
                    // Debug: Log thông tin được chọn
                    System.Diagnostics.Debug.WriteLine($"Selected CanBo: {frmThem.SelectedCanBoId}, VaiTro: {frmThem.SelectedVaiTro}");

                    using (var context = new DAContext())
                    {
                        // Kiểm tra nếu vai trò là chủ nhiệm thì đề tài chưa được có chủ nhiệm
                        if (frmThem.SelectedVaiTro == VaiTroThamGiaEnum.ChuNhiem)
                        {
                            bool hasExistingChuNhiem = await context.VaiTroThamGia
                                .AnyAsync(vt => vt.MaDeTai == currentDeTaiId && vt.VaiTro == VaiTroThamGiaEnum.ChuNhiem);

                            if (hasExistingChuNhiem)
                            {
                                MessageBox.Show("Mỗi đề tài chỉ có 1 chủ nhiệm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        // Kiểm tra cán bộ chưa tham gia đề tài này
                        var alreadyExists = await context.VaiTroThamGia
                            .AnyAsync(vt => vt.MaDeTai == currentDeTaiId && vt.MaCanBo == frmThem.SelectedCanBoId);

                        if (alreadyExists)
                        {
                            MessageBox.Show("Cán bộ này đã tham gia đề tài!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Tạo và lưu vai trò tham gia
                        var vaiTro = new VaiTroThamGia
                        {
                            MaDeTai = currentDeTaiId,
                            MaCanBo = frmThem.SelectedCanBoId,
                            VaiTro = frmThem.SelectedVaiTro
                        };

                        System.Diagnostics.Debug.WriteLine($"Creating VaiTroThamGia: MaDeTai={vaiTro.MaDeTai}, MaCanBo={vaiTro.MaCanBo}, VaiTro={vaiTro.VaiTro}");

                        context.VaiTroThamGia.Add(vaiTro);
                        await context.SaveChangesAsync();

                        // Reload dữ liệu và thông báo thành công
                        await LoadThanhVien(currentDeTaiId);
                        MessageBox.Show("Thêm thành viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm thành viên: {ex.Message}\n\nChi tiết: {ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"Error in BtnThemThanhVien_Click: {ex}");
            }
        }

        private async void BtnXoaThanhVien_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            if (dgvThanhVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thành viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa thành viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var context = new DAContext())
                    {
                        var selectedIndex = dgvThanhVien.SelectedRows[0].Index;

                        // Load danh sách thành viên với thông tin đầy đủ
                        var thanhVienList = await context.VaiTroThamGia
                            .Include(vt => vt.CanBo)
                            .Where(vt => vt.MaDeTai == currentDeTaiId)
                            .OrderBy(vt => vt.CanBo.HoTen)
                            .ToListAsync();

                        if (selectedIndex >= 0 && selectedIndex < thanhVienList.Count)
                        {
                            var vaiTroToDelete = thanhVienList[selectedIndex];

                            // Kiểm tra xem thành viên có tồn tại không
                            var exists = await context.VaiTroThamGia
                                .AnyAsync(vt => vt.MaDeTai == vaiTroToDelete.MaDeTai && vt.MaCanBo == vaiTroToDelete.MaCanBo);

                            if (!exists)
                            {
                                MessageBox.Show("Thành viên không tồn tại hoặc đã bị xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                await LoadThanhVien(currentDeTaiId);
                                return;
                            }

                            // Xóa thành viên
                            context.VaiTroThamGia.Remove(vaiTroToDelete);
                            await context.SaveChangesAsync();

                            // Reload dữ liệu
                            await LoadThanhVien(currentDeTaiId);
                            MessageBox.Show("Xóa thành viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Chỉ mục không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            await LoadThanhVien(currentDeTaiId);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa thành viên: {ex.Message}\n\nChi tiết: {ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Reload dữ liệu để đảm bảo tính nhất quán
                    await LoadThanhVien(currentDeTaiId);
                }
            }
        }

        #endregion

        #region Event Handlers - Đơn vị phối hợp

        private async void BtnThemDonVi_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            try
            {
                var frmThem = new frmThemDonVi(currentDeTaiId);
                if (frmThem.ShowDialog() == DialogResult.OK)
                {
                    await LoadDonViPhoiHop(currentDeTaiId);
                    MessageBox.Show("Thêm đơn vị phối hợp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm đơn vị phối hợp: {ex.Message}\n\nChi tiết: {ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Reload dữ liệu để đảm bảo tính nhất quán
                await LoadDonViPhoiHop(currentDeTaiId);
            }
        }

        private async void BtnSuaDonVi_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            if (dgvDonVi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đơn vị cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new DAContext())
                {
                    var selectedIndex = dgvDonVi.SelectedRows[0].Index;
                    var donViIds = await context.DeTai_DonVi
                        .Where(dd => dd.MaDeTai == currentDeTaiId)
                        .Select(dd => dd.MaDonVi)
                        .ToListAsync();

                    if (selectedIndex < donViIds.Count)
                    {
                        var donViId = donViIds[selectedIndex];
                        var frmSua = new frmThemDonVi(currentDeTaiId, donViId);
                        if (frmSua.ShowDialog() == DialogResult.OK)
                        {
                            await LoadDonViPhoiHop(currentDeTaiId);
                            MessageBox.Show("Cập nhật đơn vị phối hợp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa đơn vị: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnXoaDonVi_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            if (dgvDonVi.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đơn vị cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa đơn vị này khỏi đề tài?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var context = new DAContext())
                    {
                        var selectedIndex = dgvDonVi.SelectedRows[0].Index;

                        // Load danh sách đơn vị phối hợp với thông tin đầy đủ
                        var donViIds = await context.DeTai_DonVi
                            .Where(dd => dd.MaDeTai == currentDeTaiId)
                            .Select(dd => dd.MaDonVi)
                            .ToListAsync();

                        var donViList = await context.DonViPhoiHop
                            .Where(dv => donViIds.Contains(dv.MaDonVi))
                            .OrderBy(dv => dv.TenDonVi)
                            .ToListAsync();

                        if (selectedIndex >= 0 && selectedIndex < donViList.Count)
                        {
                            var donViToRemove = donViList[selectedIndex];

                            // Tìm liên kết DeTai_DonVi cần xóa
                            var deTaiDonViToDelete = await context.DeTai_DonVi
                                .FirstOrDefaultAsync(dd => dd.MaDeTai == currentDeTaiId && dd.MaDonVi == donViToRemove.MaDonVi);

                            if (deTaiDonViToDelete == null)
                            {
                                MessageBox.Show("Liên kết đơn vị với đề tài không tồn tại hoặc đã bị xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                await LoadDonViPhoiHop(currentDeTaiId);
                                return;
                            }

                            // Xóa liên kết (không xóa đơn vị, chỉ xóa liên kết với đề tài)
                            context.DeTai_DonVi.Remove(deTaiDonViToDelete);
                            await context.SaveChangesAsync();

                            // Reload dữ liệu
                            await LoadDonViPhoiHop(currentDeTaiId);
                            MessageBox.Show("Xóa đơn vị phối hợp khỏi đề tài thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Chỉ mục không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            await LoadDonViPhoiHop(currentDeTaiId);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa đơn vị: {ex.Message}\n\nChi tiết: {ex.InnerException?.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Reload dữ liệu để đảm bảo tính nhất quán
                    await LoadDonViPhoiHop(currentDeTaiId);
                }
            }
        }

        #endregion

        #region Event Handlers - Sản phẩm Dạng I

        private async void BtnThemSanPhamI_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            var frmThem = new frmThemSanPhamI(currentDeTaiId);
            if (frmThem.ShowDialog() == DialogResult.OK)
            {
                await LoadSanPham(currentDeTaiId);
                MessageBox.Show("Thêm sản phẩm dạng I thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void BtnSuaSanPhamI_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            if (dgvSanPhamI.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new DAContext())
                {
                    var selectedIndex = dgvSanPhamI.SelectedRows[0].Index;
                    var sanPhamList = await context.ChiTietSanPham_DangI
                        .Where(sp => sp.MaDeTai == currentDeTaiId)
                        .ToListAsync();

                    if (selectedIndex < sanPhamList.Count)
                    {
                        var sanPhamId = sanPhamList[selectedIndex].MaSanPham_I;
                        var frmSua = new frmThemSanPhamI(currentDeTaiId, sanPhamId);
                        if (frmSua.ShowDialog() == DialogResult.OK)
                        {
                            await LoadSanPham(currentDeTaiId);
                            MessageBox.Show("Cập nhật sản phẩm dạng I thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnXoaSanPhamI_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            if (dgvSanPhamI.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var context = new DAContext())
                    {
                        var selectedIndex = dgvSanPhamI.SelectedRows[0].Index;
                        var sanPhamList = await context.ChiTietSanPham_DangI
                            .Where(sp => sp.MaDeTai == currentDeTaiId)
                            .ToListAsync();

                        if (selectedIndex < sanPhamList.Count)
                        {
                            var sanPhamToDelete = sanPhamList[selectedIndex];
                            context.ChiTietSanPham_DangI.Remove(sanPhamToDelete);
                            await context.SaveChangesAsync();

                            await LoadSanPham(currentDeTaiId);
                            MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void BtnThemDacTinh_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            if (dgvSanPhamI.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm dạng I trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new DAContext())
                {
                    var selectedIndex = dgvSanPhamI.SelectedRows[0].Index;
                    var sanPhamList = await context.ChiTietSanPham_DangI
                        .Where(sp => sp.MaDeTai == currentDeTaiId)
                        .ToListAsync();

                    if (selectedIndex < sanPhamList.Count)
                    {
                        var sanPhamId = sanPhamList[selectedIndex].MaSanPham_I;
                        var frmThem = new frmThemDacTinh(sanPhamId);
                        if (frmThem.ShowDialog() == DialogResult.OK)
                        {
                            await LoadDacTinhKyThuat(sanPhamId);
                            MessageBox.Show("Thêm đặc tính kỹ thuật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm đặc tính: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnSuaDacTinh_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            if (dgvSanPhamI.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm dạng I trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvDacTinhKyThuat.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đặc tính cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new DAContext())
                {
                    var selectedSanPhamIndex = dgvSanPhamI.SelectedRows[0].Index;
                    var sanPhamList = await context.ChiTietSanPham_DangI
                        .Where(sp => sp.MaDeTai == currentDeTaiId)
                        .ToListAsync();

                    if (selectedSanPhamIndex < sanPhamList.Count)
                    {
                        var sanPhamId = sanPhamList[selectedSanPhamIndex].MaSanPham_I;
                        var selectedDacTinhIndex = dgvDacTinhKyThuat.SelectedRows[0].Index;
                        var dacTinhList = await context.DacTinhKyThuat
                            .Where(dt => dt.MaSanPham_I == sanPhamId)
                            .ToListAsync();

                        if (selectedDacTinhIndex < dacTinhList.Count)
                        {
                            var dacTinhId = dacTinhList[selectedDacTinhIndex].MaDacTinhKyThuat;
                            var frmSua = new frmThemDacTinh(sanPhamId, dacTinhId);
                            if (frmSua.ShowDialog() == DialogResult.OK)
                            {
                                await LoadDacTinhKyThuat(sanPhamId);
                                MessageBox.Show("Cập nhật đặc tính kỹ thuật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa đặc tính: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnXoaDacTinh_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            if (dgvSanPhamI.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm dạng I trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvDacTinhKyThuat.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đặc tính cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa đặc tính này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var context = new DAContext())
                    {
                        var selectedSanPhamIndex = dgvSanPhamI.SelectedRows[0].Index;
                        var sanPhamList = await context.ChiTietSanPham_DangI
                            .Where(sp => sp.MaDeTai == currentDeTaiId)
                            .ToListAsync();

                        if (selectedSanPhamIndex < sanPhamList.Count)
                        {
                            var sanPhamId = sanPhamList[selectedSanPhamIndex].MaSanPham_I;
                            var selectedDacTinhIndex = dgvDacTinhKyThuat.SelectedRows[0].Index;
                            var dacTinhList = await context.DacTinhKyThuat
                                .Where(dt => dt.MaSanPham_I == sanPhamId)
                                .ToListAsync();

                            if (selectedDacTinhIndex < dacTinhList.Count)
                            {
                                var dacTinhToDelete = dacTinhList[selectedDacTinhIndex];
                                context.DacTinhKyThuat.Remove(dacTinhToDelete);
                                await context.SaveChangesAsync();

                                await LoadDacTinhKyThuat(sanPhamId);
                                MessageBox.Show("Xóa đặc tính kỹ thuật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa đặc tính: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Event Handlers - Sản phẩm Dạng II

        private async void BtnThemSanPhamII_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            var frmThem = new frmThemSanPhamII(currentDeTaiId);
            if (frmThem.ShowDialog() == DialogResult.OK)
            {
                await LoadSanPham(currentDeTaiId);
                MessageBox.Show("Thêm sản phẩm dạng II thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void BtnSuaSanPhamII_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            if (dgvSanPhamII.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new DAContext())
                {
                    var selectedIndex = dgvSanPhamII.SelectedRows[0].Index;
                    var sanPhamList = await context.ChiTietSanPham_DangII
                        .Where(sp => sp.MaDeTai == currentDeTaiId)
                        .ToListAsync();

                    if (selectedIndex < sanPhamList.Count)
                    {
                        var sanPhamId = sanPhamList[selectedIndex].MaSanPham_II;
                        var frmSua = new frmThemSanPhamII(currentDeTaiId, sanPhamId);
                        if (frmSua.ShowDialog() == DialogResult.OK)
                        {
                            await LoadSanPham(currentDeTaiId);
                            MessageBox.Show("Cập nhật sản phẩm dạng II thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnXoaSanPhamII_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            if (dgvSanPhamII.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var context = new DAContext())
                    {
                        var selectedIndex = dgvSanPhamII.SelectedRows[0].Index;
                        var sanPhamList = await context.ChiTietSanPham_DangII
                            .Where(sp => sp.MaDeTai == currentDeTaiId)
                            .ToListAsync();

                        if (selectedIndex < sanPhamList.Count)
                        {
                            var sanPhamToDelete = sanPhamList[selectedIndex];
                            context.ChiTietSanPham_DangII.Remove(sanPhamToDelete);
                            await context.SaveChangesAsync();

                            await LoadSanPham(currentDeTaiId);
                            MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Event Handlers - Sản phẩm Dạng III

        private async void BtnThemSanPhamIII_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            var frmThem = new frmThemSanPhamIII(currentDeTaiId);
            if (frmThem.ShowDialog() == DialogResult.OK)
            {
                await LoadSanPham(currentDeTaiId);
                MessageBox.Show("Thêm sản phẩm dạng III thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void BtnSuaSanPhamIII_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            if (dgvSanPhamIII.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new DAContext())
                {
                    var selectedIndex = dgvSanPhamIII.SelectedRows[0].Index;
                    var sanPhamList = await context.ChiTietSanPham_DangIII
                        .Where(sp => sp.MaDeTai == currentDeTaiId)
                        .ToListAsync();

                    if (selectedIndex < sanPhamList.Count)
                    {
                        var sanPhamId = sanPhamList[selectedIndex].MaSanPham_III;
                        var frmSua = new frmThemSanPhamIII(currentDeTaiId, sanPhamId);
                        if (frmSua.ShowDialog() == DialogResult.OK)
                        {
                            await LoadSanPham(currentDeTaiId);
                            MessageBox.Show("Cập nhật sản phẩm dạng III thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnXoaSanPhamIII_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            if (dgvSanPhamIII.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var context = new DAContext())
                    {
                        var selectedIndex = dgvSanPhamIII.SelectedRows[0].Index;
                        var sanPhamList = await context.ChiTietSanPham_DangIII
                            .Where(sp => sp.MaDeTai == currentDeTaiId)
                            .ToListAsync();

                        if (selectedIndex < sanPhamList.Count)
                        {
                            var sanPhamToDelete = sanPhamList[selectedIndex];
                            context.ChiTietSanPham_DangIII.Remove(sanPhamToDelete);
                            await context.SaveChangesAsync();

                            await LoadSanPham(currentDeTaiId);
                            MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Event Handlers - CRUD Đề tài

        private async void BtnThemDeTai_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            var frmThem = new frmThemDeTai();
            if (frmThem.ShowDialog() == DialogResult.OK)
            {
                await LoadRealData();
                if (frmThem.NewDeTaiId.HasValue)
                {
                    // Chọn đề tài vừa tạo
                    using (var context = new DAContext())
                    {
                        var deTaiList = await context.DeTai.ToListAsync();
                        for (int i = 0; i < deTaiList.Count; i++)
                        {
                            if (deTaiList[i].MaDeTai == frmThem.NewDeTaiId.Value)
                            {
                                cmbDeTaiList.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                MessageBox.Show("Thêm đề tài thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void BtnSuaDeTai_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            if (currentDeTaiId <= 0)
            {
                MessageBox.Show("Vui lòng chọn đề tài cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var frmSua = new frmThemDeTai(currentDeTaiId);
            if (frmSua.ShowDialog() == DialogResult.OK)
            {
                await LoadDeTaiDetails(currentDeTaiId);
                await LoadRealData(); // Refresh ComboBox
                MessageBox.Show("Cập nhật đề tài thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void BtnXoaDeTai_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission()) return;

            if (currentDeTaiId <= 0)
            {
                MessageBox.Show("Vui lòng chọn đề tài cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa đề tài này?\nTất cả dữ liệu liên quan sẽ bị xóa!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var context = new DAContext())
                    {
                        var deTai = await context.DeTai.FirstOrDefaultAsync(dt => dt.MaDeTai == currentDeTaiId);
                        if (deTai != null)
                        {
                            context.DeTai.Remove(deTai);
                            await context.SaveChangesAsync();

                            await LoadRealData();
                            MessageBox.Show("Xóa đề tài thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa đề tài: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Event Handlers - Navigation

        private void BtnQuayLai_Click(object sender, EventArgs e)
        {
            if (onBackCallback != null)
            {
                onBackCallback.Invoke();
            }
            else
            {
                // Fallback: đóng form nếu không có callback
                this.Close();
            }
        }

        #endregion

        #region Event Handlers - Tải file sản phẩm

        private async void btnTaiFile_Click(object sender, EventArgs e)
        {
            await TaiFileSanPhamI();
        }

        private async void btnTaiFileSanPhamII_Click(object sender, EventArgs e)
        {
            await TaiFileSanPhamII();
        }

        private async void btnTaiFileSanPhamIII_Click(object sender, EventArgs e)
        {
            await TaiFileSanPhamIII();
        }

        #endregion

        #region Helper Methods - Tải file sản phẩm

        private async Task TaiFileSanPhamI()
        {
            if (dgvSanPhamI.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để tải file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new DAContext())
                {
                    var selectedIndex = dgvSanPhamI.SelectedRows[0].Index;
                    var sanPhamList = await context.ChiTietSanPham_DangI
                        .Where(sp => sp.MaDeTai == currentDeTaiId)
                        .ToListAsync();

                    if (selectedIndex < sanPhamList.Count)
                    {
                        var selectedSanPham = sanPhamList[selectedIndex];

                        if (selectedSanPham.file_SanPham_I == null || selectedSanPham.file_SanPham_I.Length == 0)
                        {
                            MessageBox.Show("Sản phẩm này không có file đính kèm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        using (var saveDialog = new SaveFileDialog())
                        {
                            saveDialog.Filter = "All files (*.*)|*.*|PDF files (*.pdf)|*.pdf|Word files (*.docx)|*.docx|Excel files (*.xlsx)|*.xlsx|Image files (*.jpg;*.png)|*.jpg;*.png";
                            saveDialog.Title = "Lưu file sản phẩm - Vui lòng chọn định dạng phù hợp";
                            saveDialog.FileName = $"SanPhamI_{selectedSanPham.TenSanPham_I?.Replace(" ", "_").Replace("/", "_").Replace("\\", "_")}";
                            saveDialog.FilterIndex = 1; // Mặc định chọn "All files"

                            if (saveDialog.ShowDialog() == DialogResult.OK)
                            {
                                await File.WriteAllBytesAsync(saveDialog.FileName, selectedSanPham.file_SanPham_I);
                                MessageBox.Show("Tải file thành công!\nLưu ý: Hãy đảm bảo extension file phù hợp với nội dung để mở được file.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Mở file sau khi tải
                                try
                                {
                                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(saveDialog.FileName) { UseShellExecute = true });
                                }
                                catch
                                {
                                    // Nếu không mở được file, chỉ thông báo đã tải thành công
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task TaiFileSanPhamII()
        {
            if (dgvSanPhamII.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để tải file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new DAContext())
                {
                    var selectedIndex = dgvSanPhamII.SelectedRows[0].Index;
                    var sanPhamList = await context.ChiTietSanPham_DangII
                        .Where(sp => sp.MaDeTai == currentDeTaiId)
                        .ToListAsync();

                    if (selectedIndex < sanPhamList.Count)
                    {
                        var selectedSanPham = sanPhamList[selectedIndex];

                        if (selectedSanPham.file_SanPham_II == null || selectedSanPham.file_SanPham_II.Length == 0)
                        {
                            MessageBox.Show("Sản phẩm này không có file đính kèm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        using (var saveDialog = new SaveFileDialog())
                        {
                            saveDialog.Filter = "All files (*.*)|*.*|PDF files (*.pdf)|*.pdf|Word files (*.docx)|*.docx|Excel files (*.xlsx)|*.xlsx|Image files (*.jpg;*.png)|*.jpg;*.png";
                            saveDialog.Title = "Lưu file sản phẩm - Vui lòng chọn định dạng phù hợp";
                            saveDialog.FileName = $"SanPhamII_{selectedSanPham.TenSanPham_II?.Replace(" ", "_").Replace("/", "_").Replace("\\", "_")}";
                            saveDialog.FilterIndex = 1; // Mặc định chọn "All files"

                            if (saveDialog.ShowDialog() == DialogResult.OK)
                            {
                                await File.WriteAllBytesAsync(saveDialog.FileName, selectedSanPham.file_SanPham_II);
                                MessageBox.Show("Tải file thành công!\nLưu ý: Hãy đảm bảo extension file phù hợp với nội dung để mở được file.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Mở file sau khi tải
                                try
                                {
                                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(saveDialog.FileName) { UseShellExecute = true });
                                }
                                catch
                                {
                                    // Nếu không mở được file, chỉ thông báo đã tải thành công
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task TaiFileSanPhamIII()
        {
            if (dgvSanPhamIII.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để tải file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new DAContext())
                {
                    var selectedIndex = dgvSanPhamIII.SelectedRows[0].Index;
                    var sanPhamList = await context.ChiTietSanPham_DangIII
                        .Where(sp => sp.MaDeTai == currentDeTaiId)
                        .ToListAsync();

                    if (selectedIndex < sanPhamList.Count)
                    {
                        var selectedSanPham = sanPhamList[selectedIndex];

                        if (selectedSanPham.file_SanPham_III == null || selectedSanPham.file_SanPham_III.Length == 0)
                        {
                            MessageBox.Show("Sản phẩm này không có file đính kèm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        using (var saveDialog = new SaveFileDialog())
                        {
                            saveDialog.Filter = "All files (*.*)|*.*|PDF files (*.pdf)|*.pdf|Word files (*.docx)|*.docx|Excel files (*.xlsx)|*.xlsx|Image files (*.jpg;*.png)|*.jpg;*.png";
                            saveDialog.Title = "Lưu file sản phẩm - Vui lòng chọn định dạng phù hợp";
                            saveDialog.FileName = $"SanPhamIII_{selectedSanPham.TenSanPham_III?.Replace(" ", "_").Replace("/", "_").Replace("\\", "_")}";
                            saveDialog.FilterIndex = 1; // Mặc định chọn "All files"

                            if (saveDialog.ShowDialog() == DialogResult.OK)
                            {
                                await File.WriteAllBytesAsync(saveDialog.FileName, selectedSanPham.file_SanPham_III);
                                MessageBox.Show("Tải file thành công!\nLưu ý: Hãy đảm bảo extension file phù hợp với nội dung để mở được file.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Mở file sau khi tải
                                try
                                {
                                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(saveDialog.FileName) { UseShellExecute = true });
                                }
                                catch
                                {
                                    // Nếu không mở được file, chỉ thông báo đã tải thành công
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
