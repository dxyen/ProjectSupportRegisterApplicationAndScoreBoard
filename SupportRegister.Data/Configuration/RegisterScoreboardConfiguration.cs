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
            entity.Property(e => e.IdRegisterScoreboard).ValueGeneratedOnAdd();

            entity.Property(e => e.DateReceived).HasColumnType("date");

            entity.Property(e => e.DateRegister).HasColumnType("date");

            entity.HasOne(d => d.IdStatusNavigation)
                .WithMany(p => p.RegisterScoreboards)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("Fk_status_score");
        }
    }
}
