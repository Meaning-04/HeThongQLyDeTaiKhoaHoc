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

            builder.HasKey(e => e.MaBaoCao);

            builder.Property(e => e.MaBaoCao)
                .ValueGeneratedOnAdd()
                .HasColumnName("MaBaoCao");

            builder.Property(e => e.MaDeTai)
                .HasColumnName("MaDeTai");

            builder.Property(e => e.TenBaoCao)
                .HasColumnType("VARCHAR(500)")
                .HasColumnName("TenBaoCao");

            builder.Property(e => e.LoaiBaoCao)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("LoaiBaoCao");

            builder.Property(e => e.MoTa)
                .HasColumnType("TEXT")
                .HasColumnName("MoTa");

            builder.Property(e => e.NgayHoanThanh)
                .HasColumnType("DATE")
                .HasColumnName("NgayHoanThanh");

            builder.Property(e => e.TrangThai)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("TrangThai");

            builder.Property(e => e.FileBaoCao)
                .HasColumnType("VARBINARY(MAX)")
                .HasColumnName("FileBaoCao");

            builder.Property(e => e.TomTatNoiDung)
                .HasColumnType("TEXT")
                .HasColumnName("TomTatNoiDung");

            // Configure relationships
            builder.HasOne(e => e.DeTai)
                .WithMany(e => e.ChiTietSanPham_DangII)
                .HasForeignKey(e => e.MaDeTai)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
