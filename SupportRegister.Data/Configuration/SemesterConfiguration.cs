using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupportRegister.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportRegister.Data.Configuration
{
    public class SemesterConfiguration : IEntityTypeConfiguration<Semester>
    {
        public void Configure(EntityTypeBuilder<Semester> entity)
        {
            entity.HasKey(e => e.IdSemester)
                   .HasName("PK_SEMESTER");

            entity.ToTable("Semester");
            entity.Property(e => e.IdSemester).ValueGeneratedOnAdd();

            entity.Property(e => e.NameSemester)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}
