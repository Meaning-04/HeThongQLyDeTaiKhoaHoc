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

            builder.HasKey(e => e.MaDacTinh);

            builder.Property(e => e.MaDacTinh)
                .ValueGeneratedOnAdd()
                .HasColumnName("MaDacTinh");

            builder.Property(e => e.MaSanPham)
                .HasColumnName("MaSanPham");

            builder.Property(e => e.TenDacTinh)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("TenDacTinh");

            builder.Property(e => e.GiaTri)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("GiaTri");

            builder.Property(e => e.DonVi)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("DonVi");

            builder.Property(e => e.MoTa)
                .HasColumnType("TEXT")
                .HasColumnName("MoTa");

            // Configure relationships
            builder.HasOne(e => e.ChiTietSanPham_DangI)
                .WithMany(e => e.DacTinhKyThuat)
                .HasForeignKey(e => e.MaSanPham)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
