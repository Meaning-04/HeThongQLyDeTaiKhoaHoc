namespace Models.Models
{
    public enum LoaiSanPham_III
    {
        BangSangChe,
        GiaiPhapHuuIch,
        BaiBao
    }

    public class ChiTietSanPham_DangIII
    {
        public int MaSanPham_III { get; set; }
        public int MaDeTai { get; set; }
        public string TenSanPham_III { get; set; } = string.Empty;
        public LoaiSanPham_III LoaiSanPham_III { get; set; } = LoaiSanPham_III.BangSangChe;
        public string? NoiCongBo { get; set; }
        public byte[]? file_SanPham_III { get; set; }

        // Navigation properties
        public virtual DeTai DeTai { get; set; } = null!;
    }
}
