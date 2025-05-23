namespace Models.Models
{
    public class KinhPhi
    {
        public int MaKinhPhi { get; set; }
        public int MaDeTai { get; set; }
        public long? NganSach { get; set; }
        public long? Khac { get; set; }

        // Navigation properties
        public virtual DeTai DeTai { get; set; } = null!;
    }
}
