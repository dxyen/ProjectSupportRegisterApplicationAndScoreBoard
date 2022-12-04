using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupportRegister.Data.Models;

namespace SupportRegister.Data.Configuration
{
    public class MinusPointConfiguration : IEntityTypeConfiguration<MinusPoint>
    {
        public void Configure(EntityTypeBuilder<MinusPoint> entity)
        {
            entity.Property(e => e.DateRegis).HasColumnType("date");

            entity.Property(e => e.NameMinus)
                .IsRequired()
                .HasMaxLength(255);

            entity.HasOne(d => d.Student)
                .WithMany(p => p.MinusPoints)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("Fk_stu_minus");
        }
    }
}
