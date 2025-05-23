using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Models.Configuration
{
    public class DonViHanhChinhConfiguration : IEntityTypeConfiguration<DonViHanhChinh>
    {
        public void Configure(EntityTypeBuilder<DonViHanhChinh> builder)
        {
            builder.ToTable("DonViHanhChinh");

            builder.HasKey(e => e.MaDonViHC);

            builder.Property(e => e.MaDonViHC)
                .ValueGeneratedOnAdd()
                .HasColumnName("MaDonViHC");

            builder.Property(e => e.TinhThanh)
                .IsRequired()
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("TinhThanh");

            // Configure relationships
            builder.HasMany(e => e.ChiTietSanPham_DangI)
                .WithOne(e => e.DonViHanhChinh)
                .HasForeignKey(e => e.MaDonViHC)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
