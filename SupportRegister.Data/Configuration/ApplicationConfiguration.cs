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
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> entity)
        {
            entity.HasKey(e => e.IdApplication)
                    .HasName("PK_APPLICATION");

            entity.ToTable("Application");
            entity.Property(e => e.IdApplication).ValueGeneratedOnAdd();


            entity.Property(e => e.Description).HasMaxLength(1000);

            entity.Property(e => e.NameApplication)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}
