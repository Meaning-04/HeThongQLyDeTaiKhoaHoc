using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Models.Configuration
{
    public class ChiTietSanPham_DangIIConfiguration : IEntityTypeConfiguration<ChiTietSanPham_DangII>
    {
        public void Configure(EntityTypeBuilder<ChiTietSanPham_DangII> builder)
        {
            builder.ToTable("ChiTietSanPham_DangII");

            builder.HasKey(e => e.MaSanPham_II);

            builder.Property(e => e.MaSanPham_II)
                .ValueGeneratedOnAdd()
                .HasColumnName("MaSanPham_II");

            builder.Property(e => e.MaDeTai)
                .HasColumnName("MaDeTai");

            builder.Property(e => e.TenSanPham_II)
                .HasColumnType("TEXT")
                .HasColumnName("TenSanPham_II")
                .IsRequired();

            builder.Property(e => e.LoaiSanPham_II)
                .HasConversion<string>()
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("LoaiSanPham_II")
                .HasDefaultValue(LoaiSanPham_II.BaoCao);

            builder.Property(e => e.file_SanPham_II)
                .HasColumnType("VARBINARY(MAX)")
                .HasColumnName("file_SanPham_II");

            // Configure relationships
            builder.HasOne(e => e.DeTai)
                .WithMany(e => e.ChiTietSanPham_DangII)
                .HasForeignKey(e => e.MaDeTai)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
