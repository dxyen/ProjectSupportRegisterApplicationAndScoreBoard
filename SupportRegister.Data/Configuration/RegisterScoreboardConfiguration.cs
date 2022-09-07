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
    public class RegisterScoreboardConfiguration : IEntityTypeConfiguration<RegisterScoreboard>
    {
        public void Configure(EntityTypeBuilder<RegisterScoreboard> entity)
        {
            entity.HasKey(e => e.IdRegisterScoreboard)
                    .HasName("PK_REGISTERSCOREBOARD");

            entity.ToTable("RegisterScoreboard");

            entity.Property(e => e.IdRegisterScoreboard).ValueGeneratedNever();

            entity.Property(e => e.DateReceived).HasColumnType("date");

            entity.Property(e => e.DateRegister).HasColumnType("date");

            entity.HasOne(d => d.IdStatusNavigation)
                .WithMany(p => p.RegisterScoreboards)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_REGISTERSCOREBOARD_STATUS");

            entity.HasOne(d => d.Staff)
                .WithMany(p => p.RegisterScoreboards)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_REGISTERSCOREBOARD_STAFF");

            entity.HasOne(d => d.Student)
                .WithMany(p => p.RegisterScoreboards)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_REGISTERSCOREBOARD_STUDENTS");
        }
    }
}
