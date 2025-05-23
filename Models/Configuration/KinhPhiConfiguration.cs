using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Models.Configuration
{
    public class KinhPhiConfiguration : IEntityTypeConfiguration<KinhPhi>
    {
        public void Configure(EntityTypeBuilder<KinhPhi> builder)
        {
            builder.ToTable("KinhPhi");

            builder.HasKey(e => e.MaKinhPhi);

            builder.Property(e => e.MaKinhPhi)
                .ValueGeneratedOnAdd()
                .HasColumnName("MaKinhPhi");

            builder.Property(e => e.MaDeTai)
                .HasColumnName("MaDeTai");

            builder.Property(e => e.NganSach)
                .HasColumnType("BIGINT")
                .HasColumnName("NganSach");

            builder.Property(e => e.Khac)
                .HasColumnType("BIGINT")
                .HasColumnName("Khac");

            // Configure relationships
            builder.HasOne(e => e.DeTai)
                .WithMany(e => e.KinhPhi)
                .HasForeignKey(e => e.MaDeTai)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
