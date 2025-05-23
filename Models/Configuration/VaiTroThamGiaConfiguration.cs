using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Models.Configuration
{
    public class VaiTroThamGiaConfiguration : IEntityTypeConfiguration<VaiTroThamGia>
    {
        public void Configure(EntityTypeBuilder<VaiTroThamGia> builder)
        {
            builder.ToTable("VaiTroThamGia");

            // Configure composite primary key
            builder.HasKey(e => new { e.MaDeTai, e.MaCanBo });

            builder.Property(e => e.MaDeTai)
                .HasColumnName("MaDeTai");

            builder.Property(e => e.MaCanBo)
                .HasColumnName("MaCanBo");

            builder.Property(e => e.VaiTro)
                .HasConversion<string>()
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("VaiTro");

            // Configure relationships
            builder.HasOne(e => e.DeTai)
                .WithMany(e => e.VaiTroThamGia)
                .HasForeignKey(e => e.MaDeTai)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.CanBo)
                .WithMany(e => e.VaiTroThamGia)
                .HasForeignKey(e => e.MaCanBo)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
