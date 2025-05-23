using Microsoft.EntityFrameworkCore;
using Models.Models;
using Models.Configuration;

namespace Models
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=Tung_DB;Trusted_Connection=True;TrustServerCertificate=True");
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
