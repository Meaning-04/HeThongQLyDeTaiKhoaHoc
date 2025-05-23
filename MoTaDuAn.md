# 📋 HỆ THỐNG QUẢN LÝ ĐỀ TÀI NGHIÊN CỨU KHOA HỌC

## 🎯 Tổng Quan Hệ Thống

**Tên dự án**: Hệ thống Quản lý Đề tài Nghiên cứu Khoa học  
**Mục đích**: Quản lý toàn diện các đề tài nghiên cứu khoa học từ khởi tạo đến hoàn thành, bao gồm nhân sự, sản phẩm, kinh phí và báo cáo thống kê.

---

## 🏗️ Cấu Trúc Dữ Liệu

### 1. Nhóm Quản lý Hành chính
- **DonViHanhChinh**: Quản lý theo tỉnh/thành.
- **DonViPhoiHop**: Các đơn vị tham gia thực hiện.
- **DeTai_DonVi**: Liên kết đề tài với đơn vị.

### 2. Nhóm Quản lý Đề tài
- **DeTai**: Thông tin chính của đề tài (4 cấp: Nhà nước, Bộ, Ngành, Cơ sở).
- **KinhPhi**: Quản lý ngân sách đề tài.

### 3. Nhóm Quản lý Nhân sự
- **CanBo**: Thông tin chi tiết cán bộ.
- **TaiKhoan**: Hệ thống đăng nhập (Admin/User).
- **VaiTroThamGia**: Vai trò trong đề tài (Chủ nhiệm/Tham gia).

### 4. Nhóm Quản lý Sản phẩm
- **ChiTietSanPham_DangI**: Sản phẩm vật chất + Đặc tính kỹ thuật.
- **ChiTietSanPham_DangII**: Báo cáo, quy trình, bản vẽ.
- **ChiTietSanPham_DangIII**: Công bố khoa học.

---

## 🔧 Các Nhóm Chức Năng Chính

### 📊 1. Thống Kê & Báo Cáo
**Mục đích**: Cung cấp báo cáo tổng hợp và phân tích dữ liệu.

**Chức năng chi tiết**:
- Thống kê sản phẩm theo tỉnh (Dạng I, II).
- Thống kê số lượng đề tài theo 4 cấp quản lý.
- Thống kê đề tài theo khoảng thời gian.
- Thống kê kinh phí theo thời gian và cấp quản lý.
- Xuất báo cáo Excel với biểu đồ (charts/graphs).

**CRUD**:
- **READ**: Truy vấn dữ liệu từ nhiều bảng.
- **EXPORT**: Xuất báo cáo Excel.

### 👥 2. Quản Lý Cán Bộ
**Mục đích**: Quản lý thông tin nhân sự và phân công.

**Chức năng chi tiết**:
- Quản lý danh sách cán bộ.
- Xem chi tiết lý lịch khoa học.
- Phân công vai trò vào đề tài.
- Xuất danh sách cán bộ dưới dạng Word.

**CRUD**:
- **CREATE**: Thêm cán bộ mới + tạo tài khoản.
- **READ**: Xem danh sách, chi tiết, lọc theo phòng ban.
- **UPDATE**: Sửa thông tin, upload file lý lịch.
- **DELETE**: Xóa cán bộ (kiểm tra ràng buộc).

### 🔬 3. Quản Lý Đề Tài Khoa Học
**Mục đích**: Quản lý vòng đời đề tài từ A-Z.

**Chức năng chi tiết**:
- Quản lý danh sách đề tài.
- Lọc theo: cấp quản lý, thời gian, lĩnh vực.
- Tìm kiếm theo: tên đề tài, tên chủ nhiệm.
- Xuất danh sách đề tài dưới dạng Word.

**CRUD**:
- **CREATE**: Tạo đề tài + gán kinh phí + liên kết đơn vị.
- **READ**: Xem danh sách, chi tiết, lọc đa điều kiện.
- **UPDATE**: Sửa thông tin, thay đổi thành viên.
- **DELETE**: Xóa đề tài (xóa cascade toàn bộ liên kết).

### 📦 4. Quản Lý Sản Phẩm Đề Tài
**Mục đích**: Quản lý 3 loại sản phẩm nghiên cứu.

**Chức năng chi tiết**:
- 3 trang riêng cho 3 dạng sản phẩm.
- Quản lý file đính kèm (BLOB).
- Quản lý đặc tính kỹ thuật (Dạng I).

**CRUD**:
- **CREATE**: Thêm sản phẩm + upload file + nhập thông số.
- **READ**: Xem danh sách theo đề tài, chi tiết sản phẩm.
- **UPDATE**: Sửa thông tin, thay file, cập nhật thông số.
- **DELETE**: Xóa sản phẩm + file liên quan.

### ⚙️ 5. Quản Trị Hệ Thống
**Mục đích**: Quản lý người dùng và phân quyền.

**Chức năng chi tiết**:
- Quản lý tài khoản người dùng.
- Reset mật khẩu.
- Phân quyền: Admin (toàn quyền) vs User (chỉ xem).

**CRUD**:
- **CREATE**: Tạo tài khoản mới.
- **READ**: Xem danh sách user, log hoạt động.
- **UPDATE**: Sửa thông tin, đổi mật khẩu, phân quyền.
- **DELETE**: Xóa tài khoản.

---

## 🔄 Workflow Tổng Thể

### Giai Đoạn 1: Khởi Tạo Hệ Thống
1. Admin đăng nhập hệ thống.
2. Thiết lập danh sách đơn vị hành chính (tỉnh/thành).
3. Thêm các đơn vị phối hợp.
4. Tạo tài khoản cho cán bộ.
5. Nhập thông tin cán bộ + upload lý lịch.

### Giai Đoạn 2: Quản Lý Đề Tài
1. Tạo đề tài mới (chọn cấp quản lý, lĩnh vực).
2. Gán cán bộ chủ nhiệm.
3. Thêm thành viên tham gia.
4. Liên kết với đơn vị phối hợp.
5. Lập kế hoạch kinh phí (ngân sách + nguồn khác).

### Giai Đoạn 3: Thực Hiện Đề Tài
1. Theo dõi tiến độ đề tài.
2. Tạo sản phẩm theo 3 dạng:
   - **Dạng I**: Sản phẩm vật chất + thông số kỹ thuật.
   - **Dạng II**: Báo cáo, quy trình + file đính kèm.
   - **Dạng III**: Công bố khoa học + nơi công bố.
3. Upload file cho từng sản phẩm.
4. Cập nhật thông tin sản phẩm.

### Giai Đoạn 4: Báo Cáo & Thống Kê
1. Tạo báo cáo thống kê:
   - Theo tỉnh/thành (sản phẩm Dạng I, II).
   - Theo cấp quản lý (số lượng đề tài).
   - Theo thời gian (tiến độ thực hiện).
   - Theo kinh phí (phân bổ ngân sách).
2. Xuất báo cáo Excel.
3. Xuất danh sách Word (cán bộ, đề tài).

### Giai Đoạn 5: Quản Trị & Bảo Trì
1. Quản lý tài khoản người dùng.
2. Phân quyền Admin/User.
3. Reset mật khẩu khi cần.
4. Backup dữ liệu định kỳ.
5. Kiểm tra tính toàn vẹn dữ liệu.

---

## 🎯 Luồng Hoạt Động Chính

### 🔄 Quy Trình Tạo Đề Tài Mới
1. Đăng nhập → Chọn "Quản lý Đề tài" → "Thêm mới".
2. Nhập thông tin cơ bản → Chọn cấp quản lý.
3. Gán chủ nhiệm → Thêm thành viên → Liên kết đơn vị.
4. Lập kinh phí → Lưu đề tài.

### 🔄 Quy Trình Quản Lý Sản Phẩm
1. Chọn đề tài → "Quản lý Sản phẩm" → Chọn dạng sản phẩm.
2. "Thêm mới" → Nhập thông tin → Upload file.
3. Nhập thông số kỹ thuật (nếu Dạng I) → Lưu sản phẩm.

### 🔄 Quy Trình Thống Kê
1. Chọn "Thống kê" → Chọn loại báo cáo → Thiết lập bộ lọc.
2. Xem kết quả → Xuất Excel/Word.

---

## 📋 Danh Sách Bảng Database
| Bảng                    | Mô tả                              |
|-------------------------|------------------------------------|
| DonViHanhChinh          | Quản lý tỉnh/thành                |
| DonViPhoiHop            | Đơn vị tham gia                   |
| DeTai_DonVi             | Liên kết đề tài-đơn vị            |
| DeTai                   | Thông tin đề tài                  |
| CanBo                   | Thông tin cán bộ                  |
| TaiKhoan                | Đăng nhập hệ thống                |
| VaiTroThamGia           | Vai trò trong đề tài              |
| ChiTietSanPham_DangI    | Sản phẩm vật chất                 |
| DacTinhKyThuat          | Thông số kỹ thuật                 |
| ChiTietSanPham_DangII   | Báo cáo/Tài liệu                  |
| ChiTietSanPham_DangIII  | Công bố khoa học                  |
| KinhPhi                 | Quản lý ngân sách                 |

---

## 🔐 Phân Quyền Hệ Thống

### 👑 Admin (Toàn quyền)
- Tất cả chức năng CRUD.
- Quản trị hệ thống.
- Xuất báo cáo.
- Phân quyền user.

### 👤 User (Chỉ xem)
- Xem thông tin đề tài.
- Xem danh sách cán bộ.
- Xem sản phẩm.
- Xem thống kê.
- **Không được phép** sửa/xóa.

---

**Đây là tài liệu tổng hợp hoàn chỉnh cho Hệ thống Quản lý Đề tài Nghiên cứu Khoa học.**