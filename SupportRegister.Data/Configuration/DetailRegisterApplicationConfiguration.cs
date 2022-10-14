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
            entity.HasKey(e => new { e.StudentId, e.RegisId })
                     .HasName("PK__DetailRe__D170D43024840281");

            entity.ToTable("DetailRegisterApplication");

            entity.HasOne(d => d.Regis)
                .WithMany(p => p.DetailRegisterApplications)
                .HasForeignKey(d => d.RegisId)
                .HasConstraintName("Fk_detailapp_regisapp");

            entity.HasOne(d => d.Student)
                .WithMany(p => p.DetailRegisterApplications)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("Fk_detailapp_stu");
        }
    }
}
