namespace Models.Models
{
    public class TaiKhoan
    {
        public int MaTaiKhoan { get; set; }
        public string TenDangNhap { get; set; } = string.Empty;
        public string MatKhau { get; set; } = string.Empty;
        public VaiTroTaiKhoan VaiTro { get; set; }
        public int MaCanBo { get; set; }

        // Navigation properties
        public virtual CanBo CanBo { get; set; } = null!;
    }
}
