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
    internal class ScoreboardConfiguration : IEntityTypeConfiguration<Scoreboard>
    {
        public void Configure(EntityTypeBuilder<Scoreboard> entity)
        {
            entity.HasKey(e => e.IdScore)
                    .HasName("PK_SCOREBOARD");

            entity.ToTable("Scoreboard");

            entity.Property(e => e.IdScore).ValueGeneratedNever();

            entity.Property(e => e.NameScore)
                .HasMaxLength(1000)
                .IsUnicode(true)
                .IsRequired(true);

            entity.Property(e => e.Price).HasColumnType("numeric(8, 2)");

            entity.Property(e => e.Status)
                .HasMaxLength(1000)
                .IsUnicode(true)
                .IsRequired(true);
        }
    }
}
