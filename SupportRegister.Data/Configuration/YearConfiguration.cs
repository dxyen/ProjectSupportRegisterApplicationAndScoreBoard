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
    public class YearConfiguration : IEntityTypeConfiguration<Year>
    {
        public void Configure(EntityTypeBuilder<Year> entity)
        {
            entity.HasKey(e => e.IdYear)
                    .HasName("PK_YEAR");

            entity.ToTable("Year");

            entity.Property(e => e.IdYear).ValueGeneratedNever();

            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(true);

            entity.Property(e => e.Yearr)
                .HasColumnName("Year")
                .IsRequired(true);

            entity.HasOne(d => d.IdRegisterScoreboardNavigation)
                .WithMany(p => p.Years)
                .HasForeignKey(d => d.IdRegisterScoreboard)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_YEAR_FK_REGIST_REGISTER");
        }
    }
}
