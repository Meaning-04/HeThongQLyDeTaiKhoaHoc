namespace Models.Models
{
    public class DeTai_DonVi
    {
        public int MaDeTai { get; set; }
        public int MaDonVi { get; set; }
        public string? GhiChu { get; set; }

        // Navigation properties
        public virtual DeTai DeTai { get; set; } = null!;
        public virtual DonViPhoiHop DonViPhoiHop { get; set; } = null!;
    }
}
