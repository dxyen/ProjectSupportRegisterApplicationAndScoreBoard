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
    internal class DetailRegisterScoreboardConfiguration : IEntityTypeConfiguration<DetailRegisterScoreboard>
    {
        public void Configure(EntityTypeBuilder<DetailRegisterScoreboard> entity)
        {
            entity.HasKey(e => new { e.IdRegisterScoreboard, e.IdScore })
                    .HasName("PK_DETAILREGISTERSCOREBOARD");

            entity.ToTable("DetailRegisterScoreboard");
            entity.Property(e => e.IdRegisterScoreboard).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdRegisterScoreboardNavigation)
                .WithMany(p => p.DetailRegisterScoreboards)
                .HasForeignKey(d => d.IdRegisterScoreboard)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETAILRE_REGISTERSCOREBOARD");

            entity.HasOne(d => d.IdScoreNavigation)
                .WithMany(p => p.DetailRegisterScoreboards)
                .HasForeignKey(d => d.IdScore)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETAILRE_SCORE");
        }
    }
}
