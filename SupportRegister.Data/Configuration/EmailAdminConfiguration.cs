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
    public class EmailAdminConfiguration : IEntityTypeConfiguration<EmailAdmin>
    {
        public void Configure(EntityTypeBuilder<EmailAdmin> entity)
        {
            entity.ToTable("EmailAdmin");

            entity.Property(e => e.EmailAdmin1)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EmailAdmin");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
