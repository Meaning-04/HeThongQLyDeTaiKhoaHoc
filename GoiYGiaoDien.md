# 🖥️ Thiết Kế Chi Tiết Các Giao Diện

## 2.1. MainForm – Giao Diện Chính

### Thành Phần
- **MenuStrip Chính**:
  - Thống kê chung
  - Quản lý cán bộ
  - Quản lý đề tài (bao gồm sản phẩm)
  - Quản trị hệ thống
  - Thoát
- **StatusBar**:
  - Tên người dùng đăng nhập (Liên kết với tên cán bộ trong bảng `CanBo`)
  - Vai trò (Admin/User)
  - Ngày giờ hiện tại
- **Panel Nội Dung Chính**:
  - Vùng chứa để load các form con.
  - Mặc định hiển thị form **Thống kê** với dữ liệu tổng quan (dashboard).
- **Logo và Tên Hệ Thống**:
  - Hiển thị logo và tên hệ thống ở góc trên cùng (trái/phải tùy thiết kế).

### Chức Năng
- **Điều hướng**: Chuyển đổi giữa các module chính thông qua MenuStrip.
- **Quản lý session người dùng**: Hiển thị thông tin người dùng đang đăng nhập và vai trò.
- **Dashboard**: Hiển thị thông tin tổng quan (thống kê) khi khởi động hệ thống.

---

## 2.2. frmDangNhap – Đăng Nhập Hệ Thống

### Thành Phần
- **TextBox**:
  - Tên đăng nhập
  - Mật khẩu (masked để ẩn ký tự)
- **Button**:
  - Đăng nhập
- **CheckBox**:
  - "Remember me" (Lưu thông tin đăng nhập)
- **Link**:
  - "Quên mật khẩu" (Liên kết đến chức năng reset mật khẩu)

### Chức Năng
- **Xác thực người dùng**: Kiểm tra thông tin đăng nhập từ bảng `TaiKhoan`.
- **Phân quyền truy cập**: Phân biệt quyền Admin/User sau khi đăng nhập.
- **Lưu thông tin đăng nhập**: Lưu tên đăng nhập/mật khẩu nếu người dùng chọn "Remember me".

---

## 2.3. frmCanBo – Quản Lý Cán Bộ

### Thành Phần
- **DataGridView**:
  - Hiển thị danh sách cán bộ với các cột:
    - Mã cán bộ
    - Họ tên
    - Chức vụ
    - Học hàm/Học vị
    - Phòng ban
- **Panel Tìm Kiếm/Lọc**:
  - Các trường:
    - Họ tên
    - Chức vụ
    - Học hàm/Học vị
    - Phòng ban
- **GroupBox Thông Tin Chi Tiết** (Liên kết với bảng `CanBo`):
  - Mã cán bộ (Tự động sinh)
  - Họ tên
  - Chức vụ
  - Quân hàm
  - Ngày sinh (DateTimePicker)
  - Giới tính (ComboBox: Nam/Nữ)
  - Học vị
  - Năm nhận học vị
  - Học hàm
  - Năm nhận học hàm
  - Chức danh CMKTNV
  - Năm phong chức danh
  - Chuyên ngành
  - Điện thoại
  - Email
  - Địa chỉ
  - Phòng ban
  - File lý lịch (Button upload để tải file)
- **Button Panel**:
  - Thêm
  - Sửa
  - Xóa
  - Lưu
  - Hủy
- **Button Xuất Dữ Liệu**:
  - Xuất Excel
  - Xuất Word
  - Xuất PDF

### Chức Năng
- **CRUD cán bộ**:
  - **Create**: Thêm cán bộ mới và liên kết tài khoản.
  - **Read**: Hiển thị danh sách, chi tiết cán bộ, hỗ trợ lọc theo phòng ban.
  - **Update**: Sửa thông tin cán bộ, upload file lý lịch.
  - **Delete**: Xóa cán bộ (kiểm tra ràng buộc với các bảng liên quan).
- **Tìm kiếm và lọc**: Lọc cán bộ theo các tiêu chí (Họ tên, Chức vụ, Học hàm/Học vị, Phòng ban).
- **Upload/Download file lý lịch**: Quản lý file lý lịch khoa học (lưu dưới dạng BLOB).
- **Xuất dữ liệu**: Xuất danh sách cán bộ ra các định dạng Excel, Word, PDF.

---

## 2.4. frmDeTai – Quản Lý Đề Tài

### Thành Phần
- **DataGridView**:
  - Hiển thị danh sách đề tài với các cột:
    - Mã đề tài
    - Tên đề tài
    - Lĩnh vực
    - Cấp quản lý
    - Thời gian bắt đầu
    - Chủ nhiệm
- **Panel Tìm Kiếm/Lọc**:
  - Các trường:
    - Tên đề tài (Nhập để tìm kiếm)
    - Lĩnh vực
    - Cấp quản lý (ComboBox: Nhà nước, Bộ, Ngành, Cơ sở)
    - Thời gian thực hiện (DateTimePicker: từ - đến)
    - Chủ nhiệm (ComboBox liên kết với bảng `CanBo`)
- **Button Panel**:
  - Thêm
  - Sửa
  - Xóa
  - Xem chi tiết
  - Xuất Word
  - Xuất Excel

### Chức Năng
- **Hiển thị danh sách đề tài**: Hiển thị thông tin đề tài từ bảng `DeTai`.
- **Tìm kiếm và lọc**:
  - Tìm kiếm theo tên đề tài.
  - Lọc theo lĩnh vực, cấp quản lý, khoảng thời gian (dựa trên thời gian bắt đầu), chủ nhiệm.
- **Điều hướng**: Chuyển đến form `frmDeTaiChiTiet` khi chọn "Xem chi tiết".
- **Xuất dữ liệu**: Xuất danh sách đề tài đã lọc ra file Word hoặc Excel.

---

## 2.5. frmDeTaiChiTiet – Thông Tin Đề Tài và Sản Phẩm

### Thành Phần
- **Panel Thông Tin Cơ Bản** (Trên cùng):
  - Mã đề tài (Tự động sinh)
  - Tên đề tài
  - Mô tả tóm tắt
  - Lĩnh vực
  - Thời gian bắt đầu - kết thúc (DateTimePicker)
  - Cấp quản lý (ComboBox: Nhà nước, Bộ, Ngành, Cơ sở)
- **TabControl** với các tab:
  - **Tab 1: Thành Viên Tham Gia**:
    - **DataGridView**:
      - STT (Tự động đánh số, đảm bảo đủ số lượng thành viên)
      - Họ tên
      - Vai trò (ComboBox: Chủ nhiệm, Tham gia)
    - **Button**: Thêm, Xóa thành viên
  - **Tab 2: Đơn Vị Phối Hợp**:
    - **DataGridView**:
      - STT (Tự động đánh số, đảm bảo đủ số lượng đơn vị)
      - Tên đơn vị
      - Địa chỉ
      - Số điện thoại
      - Email
    - **Panel Thông Tin Đơn Vị**:
      - Tên đơn vị
      - Địa chỉ
      - Số điện thoại
      - Email
    - **Button**: Thêm, Sửa, Xóa đơn vị
  - **Tab 3: Kinh Phí**:
    - TextBox kinh phí ngân sách
    - TextBox kinh phí khác
    - Tổng kinh phí (Tự động tính)
  - **Tab 4: Quản Lý Sản Phẩm Dạng I**:
    - **DataGridView**:
      - STT (Tự động đánh số, đảm bảo đủ số lượng sản phẩm dạng I)
      - Tên sản phẩm
      - Đơn vị hành chính
    - **Panel Chi Tiết Sản Phẩm Dạng I**:
      - Tên sản phẩm
      - Đơn vị hành chính (ComboBox liên kết bảng `DonViHanhChinh`)
      - Upload file đính kèm
    - **DataGridView Đặc Tính Kỹ Thuật**:
      - STT (Tự động đánh số, đảm bảo đủ số lượng đặc tính)
      - Thông số
      - Đơn vị đo
      - Giá trị
      - Ghi chú
    - **Button**: Thêm, Sửa, Xóa đặc tính kỹ thuật
    - **Button Chung**: Thêm, Sửa, Xóa, Lưu, Hủy
  - **Tab 5: Quản Lý Sản Phẩm Dạng II**:
    - **DataGridView**:
      - STT (Tự động đánh số, đảm bảo đủ số lượng sản phẩm dạng II)
      - Tên sản phẩm
      - Loại sản phẩm II
    - **Panel Chi Tiết Sản Phẩm Dạng II**:
      - Tên sản phẩm
      - Loại sản phẩm II (ComboBox: Báo cáo, Quy trình, Bản vẽ, Bản đồ, Khác)
      - Upload file đính kèm
    - **Button Chung**: Thêm, Sửa, Xóa, Lưu, Hủy
  - **Tab 6: Quản Lý Sản Phẩm Dạng III**:
    - **DataGridView**:
      - STT (Tự động đánh số, đảm bảo đủ số lượng sản phẩm dạng III)
      - Tên sản phẩm
      - Loại sản phẩm III
    - **Panel Chi Tiết Sản Phẩm Dạng III**:
      - Tên sản phẩm
      - Loại sản phẩm III (ComboBox: Bằng sáng chế, Giải pháp hữu ích, Bài báo)
      - Nơi công bố
      - Upload file đính kèm
    - **Button Chung**: Thêm, Sửa, Xóa, Lưu, Hủy
- **Button Panel Chung**:
  - Lưu
  - Hủy
  - Đóng

### Chức Năng
- **CRUD thông tin đề tài**: Tạo, đọc, sửa, xóa thông tin đề tài.
- **Quản lý thành viên tham gia**: Thêm/xóa thành viên, gán vai trò.
- **Quản lý đơn vị phối hợp**: Thêm, sửa, xóa đơn vị phối hợp.
- **Quản lý kinh phí**: Nhập và tính toán kinh phí (ngân sách + nguồn khác).
- **CRUD sản phẩm**:
  - **Dạng I**: Quản lý sản phẩm vật chất và đặc tính kỹ thuật.
  - **Dạng II**: Quản lý báo cáo, quy trình, bản vẽ, v.v.
  - **Dạng III**: Quản lý công bố khoa học.
- **Upload/Download file đính kèm**: Lưu trữ file (BLOB) cho các sản phẩm.
- **Validation dữ liệu**: Kiểm tra tính hợp lệ của dữ liệu nhập (ví dụ: định dạng email, số điện thoại, ngày tháng).

---

## 2.6. frmThongKe – Thống Kê Chung

### Thành Phần
- **Panel Điều Kiện Lọc**:
  - Khoảng thời gian (DateTimePicker: từ - đến)
  - Cấp quản lý (CheckBoxList)
  - Lĩnh vực (CheckBoxList)
  - Loại thống kê (ComboBox)
- **TabControl Loại Báo Cáo**:
  - **Tab 1: Thống Kê Đề Tài Theo Cấp Quản Lý**:
    - Biểu đồ (Chart control): Cột, đường, pie
    - DataGridView tổng hợp
  - **Tab 2: Thống Kê Đề Tài Theo Đơn Vị Hành Chính**:
    - Biểu đồ (Chart control)
    - DataGridView tổng hợp
  - **Tab 3: Thống Kê Kinh Phí**:
    - Biểu đồ (Chart control)
    - DataGridView tổng hợp
- **Button Panel**:
  - Xuất biểu đồ thống kê dưới dạng file Excel

### Chức Năng
- **Hiển thị thống kê**: Trình bày dữ liệu dưới dạng biểu đồ và bảng.
- **Lọc theo tiêu chí**: Lọc dữ liệu theo thời gian, cấp quản lý, lĩnh vực, loại thống kê.
- **Xuất báo cáo**: Xuất dữ liệu thống kê ra file Excel (bao gồm biểu đồ).

---

## 2.7. frmTaiKhoan – Quản Trị Hệ Thống

### Thành Phần
- **DataGridView**:
  - Hiển thị danh sách tài khoản với các cột:
    - STT (Tự động đánh số tăng dần, đảm bảo đủ số lượng tài khoản)
    - Tên cán bộ (Liên kết với bảng `CanBo`)
    - Tên đăng nhập
    - Mật khẩu (masked)
    - Vai trò
- **Panel Thông Tin Chi Tiết**:
  - Mã tài khoản (Tự động sinh)
  - Tên đăng nhập
  - Mật khẩu (masked)
  - Vai trò (ComboBox: Admin, User)
  - Liên kết với cán bộ (ComboBox danh sách cán bộ từ bảng `CanBo`)
- **Button Panel**:
  - Thêm
  - Sửa
  - Xóa
  - Reset mật khẩu
  - Lưu
  - Hủy

### Chức Năng
- **Quản lý tài khoản người dùng**: Tạo, sửa, xóa tài khoản.
- **Phân quyền**: Gán vai trò Admin hoặc User.
- **Reset mật khẩu**: Cung cấp chức năng đặt lại mật khẩu cho tài khoản.

---

## 📋 Tổng Kết

Tài liệu trên mô tả chi tiết các giao diện của **Hệ thống Quản lý Đề tài Nghiên cứu Khoa học**, bao gồm tất cả thành phần giao diện và chức năng được yêu cầu. Mỗi giao diện được thiết kế để đảm bảo tính trực quan, dễ sử dụng và hỗ trợ đầy đủ các chức năng CRUD, tìm kiếm, lọc, xuất dữ liệu, và quản lý file đính kèm.
