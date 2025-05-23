using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Models.Configuration
{
    public class DacTinhKyThuatConfiguration : IEntityTypeConfiguration<DacTinhKyThuat>
    {
        public void Configure(EntityTypeBuilder<DacTinhKyThuat> builder)
        {
            builder.ToTable("DacTinhKyThuat");

            builder.HasKey(e => e.MaDacTinhKyThuat);

            builder.Property(e => e.MaDacTinhKyThuat)
                .ValueGeneratedOnAdd()
                .HasColumnName("MaDacTinhKyThuat");

            builder.Property(e => e.MaSanPham_I)
                .HasColumnName("MaSanPham_I");

            builder.Property(e => e.ThongSo)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("ThongSo");

            builder.Property(e => e.DonViDo)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("DonViDo");

            builder.Property(e => e.GiaTri)
                .HasColumnType("NUMERIC(10,6)")
                .HasColumnName("GiaTri");

            builder.Property(e => e.ChiChu)
                .HasColumnType("TEXT")
                .HasColumnName("ChiChu");

            // Configure relationships
            builder.HasOne(e => e.ChiTietSanPham_DangI)
                .WithMany(e => e.DacTinhKyThuat)
                .HasForeignKey(e => e.MaSanPham_I)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
