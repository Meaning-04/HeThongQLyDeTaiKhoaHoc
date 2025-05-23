namespace Models.Models
{
    public enum LoaiSanPham_II
    {
        BaoCao,
        QuyTrinh,
        BanVe,
        BanDo,
        Khac
    }

    public class ChiTietSanPham_DangII
    {
        public int MaSanPham_II { get; set; }
        public int MaDeTai { get; set; }
        public string TenSanPham_II { get; set; } = string.Empty;
        public LoaiSanPham_II LoaiSanPham_II { get; set; } = LoaiSanPham_II.BaoCao;
        public byte[]? file_SanPham_II { get; set; }

        // Navigation properties
        public virtual DeTai DeTai { get; set; } = null!;
    }
}
