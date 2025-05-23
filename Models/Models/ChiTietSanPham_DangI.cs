namespace Models.Models
{
    public class ChiTietSanPham_DangI
    {
        public int MaSanPham_I { get; set; }
        public int MaDeTai { get; set; }
        public int MaDonViHC { get; set; }
        public string TenSanPham_I { get; set; } = string.Empty;
        public byte[]? file_SanPham_I { get; set; }

        // Navigation properties
        public virtual DeTai DeTai { get; set; } = null!;
        public virtual DonViHanhChinh DonViHanhChinh { get; set; } = null!;
        public virtual ICollection<DacTinhKyThuat> DacTinhKyThuat { get; set; } = new List<DacTinhKyThuat>();
    }
}
