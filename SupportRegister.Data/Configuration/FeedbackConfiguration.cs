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
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> entity)
        {
            entity.HasKey(e => e.IdFeedback)
                    .HasName("PK_FEEDBACKS");

            entity.Property(e => e.IdFeedback).ValueGeneratedNever();

            entity.Property(e => e.NameFeedback)
                .HasMaxLength(1000)
                .IsUnicode(true)
                .IsRequired(true);

            entity.HasOne(d => d.Student)
                .WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FEEDBACK_STUDENT");
        }
    }
}
