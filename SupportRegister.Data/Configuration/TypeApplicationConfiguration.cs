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
    public class TypeApplicationConfiguration : IEntityTypeConfiguration<TypeApplication>
    {
        public void Configure(EntityTypeBuilder<TypeApplication> entity)
        {
            entity.HasKey(e => e.IdTypeApplication)
                    .HasName("PK_TYPEAPPLICATION");

            entity.ToTable("TypeApplication");

            entity.Property(e => e.IdTypeApplication).ValueGeneratedNever();

            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(true);

            entity.Property(e => e.NameTypeApplication)
                .HasMaxLength(1000)
                .IsUnicode(true)
                .IsRequired(true);
        }
    }
}
