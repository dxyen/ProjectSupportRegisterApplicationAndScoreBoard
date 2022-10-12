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

            entity.Property(e => e.IdScore).ValueGeneratedOnAdd();

            entity.Property(e => e.NameScore)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}
