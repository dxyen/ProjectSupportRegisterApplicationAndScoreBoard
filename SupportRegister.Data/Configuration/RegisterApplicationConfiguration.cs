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
    public class RegisterApplicationConfiguration : IEntityTypeConfiguration<RegisterApplication>
    {
        public void Configure(EntityTypeBuilder<RegisterApplication> entity)
        {
            entity.HasKey(e => new { e.ApplicationId, e.StudentId})
                    .HasName("PK_REGISTERAPPLICATION");

            entity.ToTable("RegisterApplication");

            entity.HasIndex(e => e.ApplicationId, "IX_RegisterApplication_ApplicationId");

            entity.HasIndex(e => e.IdStatus, "IX_RegisterApplication_IdStatus");

            entity.Property(e => e.Content).IsRequired();

            entity.Property(e => e.DateReceived).HasColumnType("date");

            entity.Property(e => e.DateRegister).HasColumnType("datetime");

            entity.HasOne(d => d.Application)
                .WithMany(p => p.RegisterApplications)
                .HasForeignKey(d => d.ApplicationId)
                .HasConstraintName("Fk_regis_app");

            entity.HasOne(d => d.IdStatusNavigation)
                .WithMany(p => p.RegisterApplications)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("Fk_regisapp_status");

            entity.HasOne(d => d.Student)
                .WithMany(p => p.RegisterApplications)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("Fk_stu_detailapp");
        }
    }
}
