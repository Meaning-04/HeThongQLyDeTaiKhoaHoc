using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Models.Configuration
{
    public class TaiKhoanConfiguration : IEntityTypeConfiguration<TaiKhoan>
    {
        public void Configure(EntityTypeBuilder<TaiKhoan> builder)
        {
            builder.ToTable("TaiKhoan");

            builder.HasKey(e => e.MaTaiKhoan);

            builder.Property(e => e.MaTaiKhoan)
                .ValueGeneratedOnAdd()
                .HasColumnName("MaTaiKhoan");

            builder.Property(e => e.TenDangNhap)
                .IsRequired()
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("TenDangNhap");

            builder.Property(e => e.MatKhau)
                .IsRequired()
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("MatKhau");

            builder.Property(e => e.VaiTro)
                .HasConversion<string>()
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("VaiTro");

            builder.Property(e => e.MaCanBo)
                .HasColumnName("MaCanBo");

            // Configure unique constraint for username
            builder.HasIndex(e => e.TenDangNhap)
                .IsUnique();

            // Configure relationships
            builder.HasOne(e => e.CanBo)
                .WithOne(e => e.TaiKhoan)
                .HasForeignKey<TaiKhoan>(e => e.MaCanBo)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
