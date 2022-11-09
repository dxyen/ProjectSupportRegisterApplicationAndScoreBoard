using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupportRegister.Data.Models;

namespace SupportRegister.Data.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> entity)
        {
            entity.HasKey(e => e.IdCourse)
                    .HasName("PK__Course__E0B50B816A385DF6");

            entity.ToTable("Course");
            entity.Property(e => e.IdCourse).ValueGeneratedOnAdd();

            entity.Property(e => e.IdCourse)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength(true);

            entity.Property(e => e.NameCourse)
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
