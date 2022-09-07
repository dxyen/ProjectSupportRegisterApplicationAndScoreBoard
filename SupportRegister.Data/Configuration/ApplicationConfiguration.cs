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

            entity.Property(e => e.IdApplication).ValueGeneratedNever();

            entity.Property(e => e.Content)
                .HasMaxLength(1000)
                .IsUnicode(true)
                .IsRequired(true);

            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(true);

            entity.Property(e => e.NameApplication)
                .HasMaxLength(1000)
                .IsUnicode(true)
                .IsRequired(true);

            entity.Property(e => e.Price).HasColumnType("numeric(8, 2)");

            entity.HasOne(d => d.IdTypeApplicationNavigation)
                .WithMany(p => p.Applications)
                .HasForeignKey(d => d.IdTypeApplication)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_APPLICATION_TYPEAPPLICATION");
        }
    }
}
