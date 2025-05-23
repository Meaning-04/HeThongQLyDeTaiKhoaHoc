namespace Models.Models
{
    public class CanBo
    {
        public int MaCanBo { get; set; }
        public string? HoTen { get; set; }
        public string? ChucVu { get; set; }
        public string? QuanHam { get; set; }
        public DateTime? NgaySinh { get; set; }
        public GioiTinh GioiTinh { get; set; }
        public string? HocVi { get; set; }
        public int? Nam_HocVi { get; set; }
        public string? HocHam { get; set; }
        public int? Nam_HocHam { get; set; }
        public string? ChucDanhCMKTNV { get; set; }
        public int? Nam_PhongChucDanh { get; set; }
        public string? ChuyenNganh { get; set; }
        public string? DienThoai { get; set; }
        public string? Email { get; set; }
        public string? DiaChi { get; set; }
        public string? PhongBan { get; set; }
        public byte[]? File_LyLich { get; set; }

        // Navigation properties
        public virtual TaiKhoan? TaiKhoan { get; set; }
        public virtual ICollection<VaiTroThamGia> VaiTroThamGia { get; set; } = new List<VaiTroThamGia>();
    }
}
