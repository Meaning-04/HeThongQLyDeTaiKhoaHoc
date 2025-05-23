namespace Models.Models
{
    public class DeTai
    {
        public int MaDeTai { get; set; }
        public string? TenDeTai { get; set; }
        public string? MoTaTomTat { get; set; }
        public string? LinhVuc { get; set; }
        public DateTime? ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
        public CapQuanLy CapQuanLy { get; set; }

        // Navigation properties
        public virtual ICollection<DeTai_DonVi> DeTai_DonVi { get; set; } = new List<DeTai_DonVi>();
        public virtual ICollection<VaiTroThamGia> VaiTroThamGia { get; set; } = new List<VaiTroThamGia>();
        public virtual ICollection<ChiTietSanPham_DangI> ChiTietSanPham_DangI { get; set; } = new List<ChiTietSanPham_DangI>();
        public virtual ICollection<ChiTietSanPham_DangII> ChiTietSanPham_DangII { get; set; } = new List<ChiTietSanPham_DangII>();
        public virtual ICollection<ChiTietSanPham_DangIII> ChiTietSanPham_DangIII { get; set; } = new List<ChiTietSanPham_DangIII>();
        public virtual ICollection<KinhPhi> KinhPhi { get; set; } = new List<KinhPhi>();
    }
}
