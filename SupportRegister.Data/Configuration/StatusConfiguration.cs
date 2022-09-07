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
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> entity)
        {
            entity.HasKey(e => e.IdStatus)
                    .HasName("PK_STATUS");

            entity.ToTable("Status");

            entity.Property(e => e.IdStatus).ValueGeneratedNever();

            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(true);

            entity.Property(e => e.NameStatus)
                .HasMaxLength(1000)
                .IsUnicode(true)
                .IsRequired(true);
        }
    }
}
