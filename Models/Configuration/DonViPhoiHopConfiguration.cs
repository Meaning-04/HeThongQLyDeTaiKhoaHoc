using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Models.Configuration
{
    public class DonViPhoiHopConfiguration : IEntityTypeConfiguration<DonViPhoiHop>
    {
        public void Configure(EntityTypeBuilder<DonViPhoiHop> builder)
        {
            builder.ToTable("DonViPhoiHop");

            builder.HasKey(e => e.MaDonVi);

            builder.Property(e => e.MaDonVi)
                .ValueGeneratedOnAdd()
                .HasColumnName("MaDonVi");

            builder.Property(e => e.TenDonVi)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("TenDonVi");

            builder.Property(e => e.DiaChi)
                .HasColumnType("VARCHAR(500)")
                .HasColumnName("DiaChi");

            builder.Property(e => e.SoDienThoai)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("SoDienThoai");

            builder.Property(e => e.Email)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("Email");

            // Configure relationships
            builder.HasMany(e => e.DeTai_DonVi)
                .WithOne(e => e.DonViPhoiHop)
                .HasForeignKey(e => e.MaDonVi)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
