using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Models.Configuration
{
    public class CanBoConfiguration : IEntityTypeConfiguration<CanBo>
    {
        public void Configure(EntityTypeBuilder<CanBo> builder)
        {
            builder.ToTable("CanBo");

            builder.HasKey(e => e.MaCanBo);

            builder.Property(e => e.MaCanBo)
                .ValueGeneratedOnAdd()
                .HasColumnName("MaCanBo");

            builder.Property(e => e.HoTen)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("HoTen");

            builder.Property(e => e.ChucVu)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("ChucVu");

            builder.Property(e => e.QuanHam)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("QuanHam");

            builder.Property(e => e.NgaySinh)
                .HasColumnType("DATE")
                .HasColumnName("NgaySinh");

            builder.Property(e => e.GioiTinh)
                .HasConversion<string>()
                .HasColumnType("VARCHAR(10)")
                .HasColumnName("GioiTinh");

            builder.Property(e => e.HocVi)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("HocVi");

            builder.Property(e => e.Nam_HocVi)
                .HasColumnType("INT")
                .HasColumnName("Nam_HocVi");

            builder.Property(e => e.HocHam)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("HocHam");

            builder.Property(e => e.Nam_HocHam)
                .HasColumnType("INT")
                .HasColumnName("Nam_HocHam");

            builder.Property(e => e.ChucDanhCMKTNV)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("ChucDanhCMKTNV");

            builder.Property(e => e.Nam_PhongChucDanh)
                .HasColumnType("INT")
                .HasColumnName("Nam_PhongChucDanh");

            builder.Property(e => e.ChuyenNganh)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("ChuyenNganh");

            builder.Property(e => e.DienThoai)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("DienThoai");

            builder.Property(e => e.Email)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("Email");

            builder.Property(e => e.DiaChi)
                .HasColumnType("VARCHAR(500)")
                .HasColumnName("DiaChi");

            builder.Property(e => e.PhongBan)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("PhongBan");

            builder.Property(e => e.File_LyLich)
                .HasColumnType("VARBINARY(MAX)")
                .HasColumnName("File_LyLich");

            // Configure relationships
            builder.HasOne(e => e.TaiKhoan)
                .WithOne(e => e.CanBo)
                .HasForeignKey<TaiKhoan>(e => e.MaCanBo)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.VaiTroThamGia)
                .WithOne(e => e.CanBo)
                .HasForeignKey(e => e.MaCanBo)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
