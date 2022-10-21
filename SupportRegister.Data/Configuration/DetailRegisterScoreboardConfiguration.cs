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
    public class DetailRegisterScoreboardConfiguration : IEntityTypeConfiguration<DetailRegisterScoreboard>
    {
        public void Configure(EntityTypeBuilder<DetailRegisterScoreboard> entity)
        {
            entity.HasKey(e => new { e.RegisId, e.StudentId, e.YearSemesterIdStart, e.YearSemesterIdEnd })
                     .HasName("PK__DetailRe__B873A826F6F01A76");

            entity.ToTable("DetailRegisterScoreboard");

            entity.HasIndex(e => e.StudentId, "IX_DetailRegisterScoreboard_StudentId");

            entity.Property(e => e.SemesterEnd).HasMaxLength(255);

            entity.Property(e => e.SemesterStart).HasMaxLength(255);

            entity.HasOne(d => d.Regis)
                .WithMany(p => p.DetailRegisterScoreboards)
                .HasForeignKey(d => d.RegisId)
                .HasConstraintName("Fk_detail_score");

            entity.HasOne(d => d.Student)
                .WithMany(p => p.DetailRegisterScoreboards)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_detail_stu");

            entity.HasOne(d => d.YearSemesterIdEndNavigation)
                .WithMany(p => p.DetailRegisterScoreboardYearSemesterIdEndNavigations)
                .HasForeignKey(d => d.YearSemesterIdEnd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_detail_end");

            entity.HasOne(d => d.YearSemesterIdStartNavigation)
                .WithMany(p => p.DetailRegisterScoreboardYearSemesterIdStartNavigations)
                .HasForeignKey(d => d.YearSemesterIdStart)
                .HasConstraintName("Fk_yearsemester_detail");
        }
    }
}
