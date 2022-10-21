using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupportRegister.Data.Models;

namespace SupportRegister.Data.Configuration
{
    public class YearSemesterConfiguration : IEntityTypeConfiguration<YearSemester>
    {
        public void Configure(EntityTypeBuilder<YearSemester> entity)
        {
            entity.ToTable("YearSemester");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.YearSemester1)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("YearSemester");

            entity.HasOne(d => d.IdSemesterNavigation)
                .WithMany(p => p.YearSemesters)
                .HasForeignKey(d => d.IdSemester)
                .HasConstraintName("Fk_semester");

            entity.HasOne(d => d.IdYearNavigation)
                .WithMany(p => p.YearSemesters)
                .HasForeignKey(d => d.IdYear)
                .HasConstraintName("Fk_year_detail");
        }
    }
}
