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
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> entity)
        {
            entity.ToTable("Class");

            entity.Property(e => e.ClassId).ValueGeneratedOnAdd();

            entity.Property(e => e.NameClass)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Teacher)
                .HasMaxLength(255)
                .HasColumnName("teacher");
        }
    }
}
