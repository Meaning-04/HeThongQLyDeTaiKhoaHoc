using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Models.Configuration
{
    public class DeTai_DonViConfiguration : IEntityTypeConfiguration<DeTai_DonVi>
    {
        public void Configure(EntityTypeBuilder<DeTai_DonVi> builder)
        {
            builder.ToTable("DeTai_DonVi");

            // Configure composite primary key
            builder.HasKey(e => new { e.MaDeTai, e.MaDonVi });

            builder.Property(e => e.MaDeTai)
                .HasColumnName("MaDeTai");

            builder.Property(e => e.MaDonVi)
                .HasColumnName("MaDonVi");

            builder.Property(e => e.GhiChu)
                .HasColumnType("TEXT")
                .HasColumnName("GhiChu");

            // Configure relationships
            builder.HasOne(e => e.DeTai)
                .WithMany(e => e.DeTai_DonVi)
                .HasForeignKey(e => e.MaDeTai)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.DonViPhoiHop)
                .WithMany(e => e.DeTai_DonVi)
                .HasForeignKey(e => e.MaDonVi)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
