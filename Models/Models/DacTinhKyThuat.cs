namespace Models.Models
{
    public class DacTinhKyThuat
    {
        public int MaDacTinh { get; set; }
        public int MaSanPham { get; set; }
        public string? TenDacTinh { get; set; }
        public string? GiaTri { get; set; }
        public string? DonVi { get; set; }
        public string? MoTa { get; set; }

        // Navigation properties
        public virtual ChiTietSanPham_DangI ChiTietSanPham_DangI { get; set; } = null!;
    }
}
