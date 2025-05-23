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

            builder.HasKey(e => e.MaBaiBao);

            builder.Property(e => e.MaBaiBao)
                .ValueGeneratedOnAdd()
                .HasColumnName("MaBaiBao");

            builder.Property(e => e.MaDeTai)
                .HasColumnName("MaDeTai");

            builder.Property(e => e.TieuDe)
                .HasColumnType("VARCHAR(500)")
                .HasColumnName("TieuDe");

            builder.Property(e => e.TacGia)
                .HasColumnType("VARCHAR(500)")
                .HasColumnName("TacGia");

            builder.Property(e => e.TenTapChi)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("TenTapChi");

            builder.Property(e => e.ISSN)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("ISSN");

            builder.Property(e => e.Nam)
                .HasColumnType("INT")
                .HasColumnName("Nam");

            builder.Property(e => e.So)
                .HasColumnType("INT")
                .HasColumnName("So");

            builder.Property(e => e.Trang)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("Trang");

            builder.Property(e => e.DOI)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("DOI");

            builder.Property(e => e.LoaiBaiBao)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("LoaiBaiBao");

            builder.Property(e => e.TrangThai)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("TrangThai");

            builder.Property(e => e.NgayXuatBan)
                .HasColumnType("DATE")
                .HasColumnName("NgayXuatBan");

            builder.Property(e => e.TomTat)
                .HasColumnType("TEXT")
                .HasColumnName("TomTat");

            // Configure relationships
            builder.HasOne(e => e.DeTai)
                .WithMany(e => e.ChiTietSanPham_DangIII)
                .HasForeignKey(e => e.MaDeTai)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
