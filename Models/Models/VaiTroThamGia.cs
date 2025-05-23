namespace Models.Models
{
    public class VaiTroThamGia
    {
        public int MaDeTai { get; set; }
        public int MaCanBo { get; set; }
        public VaiTroThamGiaEnum VaiTro { get; set; }

        // Navigation properties
        public virtual DeTai DeTai { get; set; } = null!;
        public virtual CanBo CanBo { get; set; } = null!;
    }
}
