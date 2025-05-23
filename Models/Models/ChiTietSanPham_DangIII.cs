namespace Models.Models
{
    public class ChiTietSanPham_DangIII
    {
        public int MaBaiBao { get; set; }
        public int MaDeTai { get; set; }
        public string? TieuDe { get; set; }
        public string? TacGia { get; set; }
        public string? TenTapChi { get; set; }
        public string? ISSN { get; set; }
        public int? Nam { get; set; }
        public int? So { get; set; }
        public string? Trang { get; set; }
        public string? DOI { get; set; }
        public string? LoaiBaiBao { get; set; }
        public string? TrangThai { get; set; }
        public DateTime? NgayXuatBan { get; set; }
        public string? TomTat { get; set; }

        // Navigation properties
        public virtual DeTai DeTai { get; set; } = null!;
    }
}
