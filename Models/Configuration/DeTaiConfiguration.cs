using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Models.Configuration
{
    public class DeTaiConfiguration : IEntityTypeConfiguration<DeTai>
    {
        public void Configure(EntityTypeBuilder<DeTai> builder)
        {
            builder.ToTable("DeTai");

            builder.HasKey(e => e.MaDeTai);

            builder.Property(e => e.MaDeTai)
                .ValueGeneratedOnAdd()
                .HasColumnName("MaDeTai");

            builder.Property(e => e.TenDeTai)
                .HasColumnType("TEXT")
                .HasColumnName("TenDeTai");

            builder.Property(e => e.MoTaTomTat)
                .HasColumnType("TEXT")
                .HasColumnName("MoTaTomTat");

            builder.Property(e => e.LinhVuc)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("LinhVuc");

            builder.Property(e => e.ThoiGianBatDau)
                .HasColumnType("DATE")
                .HasColumnName("ThoiGianBatDau");

            builder.Property(e => e.ThoiGianKetThuc)
                .HasColumnType("DATE")
                .HasColumnName("ThoiGianKetThuc");

            builder.Property(e => e.CapQuanLy)
                .HasConversion<string>()
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("CapQuanLy");

            // Configure relationships
            builder.HasMany(e => e.DeTai_DonVi)
                .WithOne(e => e.DeTai)
                .HasForeignKey(e => e.MaDeTai)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.VaiTroThamGia)
                .WithOne(e => e.DeTai)
                .HasForeignKey(e => e.MaDeTai)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.ChiTietSanPham_DangI)
                .WithOne(e => e.DeTai)
                .HasForeignKey(e => e.MaDeTai)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.ChiTietSanPham_DangII)
                .WithOne(e => e.DeTai)
                .HasForeignKey(e => e.MaDeTai)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.ChiTietSanPham_DangIII)
                .WithOne(e => e.DeTai)
                .HasForeignKey(e => e.MaDeTai)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.KinhPhi)
                .WithOne(e => e.DeTai)
                .HasForeignKey(e => e.MaDeTai)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
