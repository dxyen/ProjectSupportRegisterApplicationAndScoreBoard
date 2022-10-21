using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SupportRegister.Data.Configuration;
using SupportRegister.Data.Extensions;
using SupportRegister.Data.Models;

#nullable disable

namespace SupportRegister.Data.EF
{
    public class ProjectSupportRegisterContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public ProjectSupportRegisterContext(DbContextOptions<ProjectSupportRegisterContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API in config file
            modelBuilder
                .ApplyConfiguration(new AppUserConfiguration())
                .ApplyConfiguration(new AppRoleConfiguration())
                .ApplyConfiguration(new ApplicationConfiguration())
                .ApplyConfiguration(new RegisterApplicationConfiguration())
                .ApplyConfiguration(new DetailRegisterApplicationConfiguration())
                .ApplyConfiguration(new RegisterScoreboardConfiguration())
                .ApplyConfiguration(new DetailRegisterScoreboardConfiguration())
                .ApplyConfiguration(new FeedbackConfiguration())
                .ApplyConfiguration(new ClassConfiguration())
                .ApplyConfiguration(new CourseConfiguration())
                .ApplyConfiguration(new SemesterConfiguration())
                .ApplyConfiguration(new StaffConfiguration())
                .ApplyConfiguration(new StatusConfiguration())
                .ApplyConfiguration(new StudentConfiguration())
                .ApplyConfiguration(new YearSemesterConfiguration())
                .ApplyConfiguration(new YearConfiguration());
            // Data seeding in ModelBuilderExtenions
            modelBuilder.Seed();

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
        }

        public DbSet<Application> Applications { get; set; }
        public DbSet<DetailRegisterApplication> DetailRegisterApplications { get; set; }
        public DbSet<DetailRegisterScoreboard> DetailRegisterScoreboards { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<RegisterApplication> RegisterApplications { get; set; }
        public DbSet<RegisterScoreboard> RegisterScoreboards { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<YearSemester> YearSemesters { get; set; }
    }
}
