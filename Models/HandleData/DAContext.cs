using Microsoft.EntityFrameworkCore;
using Models.Configuration;
using Models.Models;

namespace Models.HandleData
{
    public class DAContext : DbContext
    {
        // DbSets for all entities
        public DbSet<DonViHanhChinh> DonViHanhChinh { get; set; }
        public DbSet<DonViPhoiHop> DonViPhoiHop { get; set; }
        public DbSet<DeTai> DeTai { get; set; }
        public DbSet<CanBo> CanBo { get; set; }
        public DbSet<TaiKhoan> TaiKhoan { get; set; }
        public DbSet<DeTai_DonVi> DeTai_DonVi { get; set; }
        public DbSet<VaiTroThamGia> VaiTroThamGia { get; set; }
        public DbSet<ChiTietSanPham_DangI> ChiTietSanPham_DangI { get; set; }
        public DbSet<DacTinhKyThuat> DacTinhKyThuat { get; set; }
        public DbSet<ChiTietSanPham_DangII> ChiTietSanPham_DangII { get; set; }
        public DbSet<ChiTietSanPham_DangIII> ChiTietSanPham_DangIII { get; set; }
        public DbSet<KinhPhi> KinhPhi { get; set; }

        // Default constructor for existing code compatibility
        public DAContext() : base()
        {
        }

        // Constructor with options for dependency injection and service usage
        public DAContext(DbContextOptions<DAContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Only configure if no options are provided (for backward compatibility)
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=Tung_DB;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all configurations
            modelBuilder.ApplyConfiguration(new DonViHanhChinhConfiguration());
            modelBuilder.ApplyConfiguration(new DonViPhoiHopConfiguration());
            modelBuilder.ApplyConfiguration(new DeTaiConfiguration());
            modelBuilder.ApplyConfiguration(new CanBoConfiguration());
            modelBuilder.ApplyConfiguration(new TaiKhoanConfiguration());
            modelBuilder.ApplyConfiguration(new DeTai_DonViConfiguration());
            modelBuilder.ApplyConfiguration(new VaiTroThamGiaConfiguration());
            modelBuilder.ApplyConfiguration(new ChiTietSanPham_DangIConfiguration());
            modelBuilder.ApplyConfiguration(new DacTinhKyThuatConfiguration());
            modelBuilder.ApplyConfiguration(new ChiTietSanPham_DangIIConfiguration());
            modelBuilder.ApplyConfiguration(new ChiTietSanPham_DangIIIConfiguration());
            modelBuilder.ApplyConfiguration(new KinhPhiConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
