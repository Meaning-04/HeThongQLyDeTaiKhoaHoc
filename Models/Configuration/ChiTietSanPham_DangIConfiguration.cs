using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Models.Configuration
{
    public class ChiTietSanPham_DangIConfiguration : IEntityTypeConfiguration<ChiTietSanPham_DangI>
    {
        public void Configure(EntityTypeBuilder<ChiTietSanPham_DangI> builder)
        {
            builder.ToTable("ChiTietSanPham_DangI");

            builder.HasKey(e => e.MaSanPham);

            builder.Property(e => e.MaSanPham)
                .ValueGeneratedOnAdd()
                .HasColumnName("MaSanPham");

            builder.Property(e => e.MaDeTai)
                .HasColumnName("MaDeTai");

            builder.Property(e => e.TenSanPham)
                .HasColumnType("VARCHAR(500)")
                .HasColumnName("TenSanPham");

            builder.Property(e => e.MoTa)
                .HasColumnType("TEXT")
                .HasColumnName("MoTa");

            builder.Property(e => e.DonViTinh)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("DonViTinh");

            builder.Property(e => e.SoLuong)
                .HasColumnType("INT")
                .HasColumnName("SoLuong");

            builder.Property(e => e.GiaTri)
                .HasColumnType("DECIMAL(18,2)")
                .HasColumnName("GiaTri");

            builder.Property(e => e.NgayHoanThanh)
                .HasColumnType("DATE")
                .HasColumnName("NgayHoanThanh");

            builder.Property(e => e.TrangThai)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("TrangThai");

            builder.Property(e => e.MaDonViHC)
                .HasColumnName("MaDonViHC");

            // Configure relationships
            builder.HasOne(e => e.DeTai)
                .WithMany(e => e.ChiTietSanPham_DangI)
                .HasForeignKey(e => e.MaDeTai)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.DonViHanhChinh)
                .WithMany(e => e.ChiTietSanPham_DangI)
                .HasForeignKey(e => e.MaDonViHC)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(e => e.DacTinhKyThuat)
                .WithOne(e => e.ChiTietSanPham_DangI)
                .HasForeignKey(e => e.MaSanPham)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
