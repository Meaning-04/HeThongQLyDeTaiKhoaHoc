namespace Models.Models
{
    public class DonViHanhChinh
    {
        public int MaDonViHC { get; set; }
        public string TinhThanh { get; set; } = string.Empty;

        // Navigation properties
        public virtual ICollection<ChiTietSanPham_DangI> ChiTietSanPham_DangI { get; set; } = new List<ChiTietSanPham_DangI>();
    }
}
