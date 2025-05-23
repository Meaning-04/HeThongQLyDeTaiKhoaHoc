using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Models.Configuration
{
    public class ChiTietSanPham_DangIIIConfiguration : IEntityTypeConfiguration<ChiTietSanPham_DangIII>
    {
        public void Configure(EntityTypeBuilder<ChiTietSanPham_DangIII> builder)
        {
            builder.ToTable("ChiTietSanPham_DangIII");

            builder.HasKey(e => e.MaSanPham_III);

            builder.Property(e => e.MaSanPham_III)
                .ValueGeneratedOnAdd()
                .HasColumnName("MaSanPham_III");

            builder.Property(e => e.MaDeTai)
                .HasColumnName("MaDeTai");

            builder.Property(e => e.TenSanPham_III)
                .HasColumnType("TEXT")
                .HasColumnName("TenSanPham_III")
                .IsRequired();

            builder.Property(e => e.LoaiSanPham_III)
                .HasConversion<string>()
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("LoaiSanPham_III")
                .HasDefaultValue(LoaiSanPham_III.BangSangChe);

            builder.Property(e => e.NoiCongBo)
                .HasColumnType("VARCHAR(500)")
                .HasColumnName("NoiCongBo");

            builder.Property(e => e.file_SanPham_III)
                .HasColumnType("VARBINARY(MAX)")
                .HasColumnName("file_SanPham_III");

            // Configure relationships
            builder.HasOne(e => e.DeTai)
                .WithMany(e => e.ChiTietSanPham_DangIII)
                .HasForeignKey(e => e.MaDeTai)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
