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
    public class YearConfiguration : IEntityTypeConfiguration<Year>
    {
        public void Configure(EntityTypeBuilder<Year> entity)
        {
            entity.HasKey(e => e.IdYear)
                                .HasName("PK_YEAR");

            entity.ToTable("Year");
            entity.Property(e => e.IdYear).ValueGeneratedOnAdd();

            entity.Property(e => e.Year1).HasColumnName("Year");
        }
    }
}
