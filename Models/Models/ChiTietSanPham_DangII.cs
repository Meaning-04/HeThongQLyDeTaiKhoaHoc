namespace Models.Models
{
    public class ChiTietSanPham_DangII
    {
        public int MaBaoCao { get; set; }
        public int MaDeTai { get; set; }
        public string? TenBaoCao { get; set; }
        public string? LoaiBaoCao { get; set; }
        public string? MoTa { get; set; }
        public DateTime? NgayHoanThanh { get; set; }
        public string? TrangThai { get; set; }
        public byte[]? FileBaoCao { get; set; }
        public string? TomTatNoiDung { get; set; }

        // Navigation properties
        public virtual DeTai DeTai { get; set; } = null!;
    }
}
