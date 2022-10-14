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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> entity)
        {

            entity.Property(e => e.StudentId).ValueGeneratedOnAdd();

            entity.Property(e => e.IdCourse)
                     .IsRequired()
                     .HasMaxLength(5)
                     .IsUnicode(false)
                     .IsFixedLength(true);

            entity.HasOne(d => d.Class)
                .WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("Fk_student_class");

            entity.HasOne(d => d.IdCourseNavigation)
                .WithMany(p => p.Students)
                .HasForeignKey(d => d.IdCourse)
                .HasConstraintName("Fk_stu_course");

            entity.HasOne(d => d.User)
                .WithMany(p => p.Students)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_STUDENTS_USERS");
        }
    }
}
