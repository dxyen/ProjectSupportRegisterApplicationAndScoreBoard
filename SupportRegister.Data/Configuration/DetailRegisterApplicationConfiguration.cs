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
    public class DetailRegisterApplicationConfiguration : IEntityTypeConfiguration<DetailRegisterApplication>
    {
        public void Configure(EntityTypeBuilder<DetailRegisterApplication> entity)
        {
            entity.HasKey(e => new { e.IdApplication, e.IdRegisterApplication })
                     .HasName("PK_DETAILREGISTERAPPLICATION");

            entity.ToTable("DetailRegisterApplication");
            entity.HasOne(d => d.IdApplicationNavigation)
                .WithMany(p => p.DetailRegisterApplications)
                .HasForeignKey(d => d.IdApplication)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETAILRE_APPLICATION");

            entity.HasOne(d => d.IdRegisterApplicationNavigation)
                .WithMany(p => p.DetailRegisterApplications)
                .HasForeignKey(d => d.IdRegisterApplication)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DETAILRE_REGISTERAPPLICATION");
        }
    }
}
