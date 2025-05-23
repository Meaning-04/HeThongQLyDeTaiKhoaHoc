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

            builder.HasKey(e => e.MaSanPham_I);

            builder.Property(e => e.MaSanPham_I)
                .ValueGeneratedOnAdd()
                .HasColumnName("MaSanPham_I");

            builder.Property(e => e.MaDeTai)
                .HasColumnName("MaDeTai");

            builder.Property(e => e.MaDonViHC)
                .HasColumnName("MaDonViHC");

            builder.Property(e => e.TenSanPham_I)
                .HasColumnType("TEXT")
                .HasColumnName("TenSanPham_I")
                .IsRequired();

            builder.Property(e => e.file_SanPham_I)
                .HasColumnType("VARBINARY(MAX)")
                .HasColumnName("file_SanPham_I");

            // Configure relationships
            builder.HasOne(e => e.DeTai)
                .WithMany(e => e.ChiTietSanPham_DangI)
                .HasForeignKey(e => e.MaDeTai)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.DonViHanhChinh)
                .WithMany(e => e.ChiTietSanPham_DangI)
                .HasForeignKey(e => e.MaDonViHC)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(e => e.DacTinhKyThuat)
                .WithOne(e => e.ChiTietSanPham_DangI)
                .HasForeignKey(e => e.MaSanPham_I)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
