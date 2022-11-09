using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupportRegister.Data.Models;

namespace SupportRegister.Data.Configuration
{
    public class MinusPointConfiguration : IEntityTypeConfiguration<MinusPoint>
    {
        public void Configure(EntityTypeBuilder<MinusPoint> entity)
        {
            entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

            entity.HasOne(d => d.Student)
                .WithMany(p => p.MinusPoints)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("Fk_stu_minus");
        }
    }
}
