namespace Models.Models
{
    public class DacTinhKyThuat
    {
        public int MaDacTinhKyThuat { get; set; }
        public int MaSanPham_I { get; set; }
        public string? ThongSo { get; set; }
        public string? DonViDo { get; set; }
        public decimal? GiaTri { get; set; }
        public string? ChiChu { get; set; }

        // Navigation properties
        public virtual ChiTietSanPham_DangI ChiTietSanPham_DangI { get; set; } = null!;
    }
}
