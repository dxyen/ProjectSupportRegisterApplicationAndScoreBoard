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
            entity.HasKey(e => new { e.RegisId, e.SemesterId, e.StudentId, e.YearId })
                     .HasName("PK__DetailRe__B873A826F6F01A76");

            entity.ToTable("DetailRegisterScoreboard");

            entity.HasOne(d => d.Regis)
                .WithMany(p => p.DetailRegisterScoreboards)
                .HasForeignKey(d => d.RegisId)
                .HasConstraintName("Fk_regis_score");

            entity.HasOne(d => d.Semester)
                .WithMany(p => p.DetailRegisterScoreboards)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("Fk_detail_semester");

            entity.HasOne(d => d.Student)
                .WithMany(p => p.DetailRegisterScoreboards)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_detail_stu");

            entity.HasOne(d => d.Year)
                .WithMany(p => p.DetailRegisterScoreboards)
                .HasForeignKey(d => d.YearId)
                .HasConstraintName("Fk_detail_year");
        }
    }
}
