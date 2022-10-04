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
            entity.HasKey(e => e.IdRegisterApplication)
                    .HasName("PK_REGISTERAPPLICATION");

            entity.ToTable("RegisterApplication");

            entity.Property(e => e.IdRegisterApplication).ValueGeneratedNever();

            entity.Property(e => e.DateReceived).HasColumnType("date");

            entity.Property(e => e.DateRegister).HasColumnType("date");

            entity.HasOne(d => d.IdStatusNavigation)
                .WithMany(p => p.RegisterApplications)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_REGISTER_STATUS");

            entity.HasOne(d => d.Staff)
                .WithMany(p => p.RegisterApplications)
                .HasForeignKey(d => d.StaffId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_REGISTER_STAFF");

            entity.HasOne(d => d.Student)
                .WithMany(p => p.RegisterApplications)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_REGISTERAPPLICATION_STUDENT");
        }
    }
}
