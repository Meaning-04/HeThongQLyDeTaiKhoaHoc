namespace Models.Models
{
    public class DonViPhoiHop
    {
        public int MaDonVi { get; set; }
        public string? TenDonVi { get; set; }
        public string? DiaChi { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }

        // Navigation properties
        public virtual ICollection<DeTai_DonVi> DeTai_DonVi { get; set; } = new List<DeTai_DonVi>();
    }
}
