using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupportRegister.Data.Models;

namespace SupportRegister.Data.Configuration
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> entity)
        {
            entity.HasKey(e => e.IdFeedback)
                    .HasName("PK_FEEDBACKS");

            entity.Property(e => e.IdFeedback).ValueGeneratedOnAdd();

            entity.Property(e => e.ContentFeedback)
                .IsRequired()
                .HasMaxLength(1000);

            entity.Property(e => e.TitleFeedback)
              .IsRequired()
              .HasMaxLength(255);

            entity.HasOne(d => d.Student)
                .WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FEEDBACK_STUDENT");
        }
    }
}
