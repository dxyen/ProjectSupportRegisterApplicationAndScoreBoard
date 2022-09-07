using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SupportRegister.Data.Configuration;
using SupportRegister.Data.Extensions;
using SupportRegister.Data.Models;

#nullable disable

namespace SupportRegister.Data.EF
{
    public partial class ProjectSupportRegisterContext : DbContext
    {

        public ProjectSupportRegisterContext(DbContextOptions<ProjectSupportRegisterContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=MSI\\SQLSERVER;Database=ProjectSupportRegister;Trusted_Connection=True;");
            }
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
                .ApplyConfiguration(new ScoreboardConfiguration())
                .ApplyConfiguration(new SemesterConfiguration())
                .ApplyConfiguration(new StaffConfiguration())
                .ApplyConfiguration(new StatusConfiguration())
                .ApplyConfiguration(new StudentConfiguration())
                .ApplyConfiguration(new TypeApplicationConfiguration())
                .ApplyConfiguration(new YearConfiguration());
            // Data seeding in ModelBuilderExtenions
            modelBuilder.Seed();

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
        }

        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<DetailRegisterApplication> DetailRegisterApplications { get; set; }
        public virtual DbSet<DetailRegisterScoreboard> DetailRegisterScoreboards { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<RegisterApplication> RegisterApplications { get; set; }
        public virtual DbSet<RegisterScoreboard> RegisterScoreboards { get; set; }
        public virtual DbSet<Scoreboard> Scoreboards { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<TypeApplication> TypeApplications { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<AppRole> AppRoles { get; set; }
        public virtual DbSet<Year> Years { get; set; }
    }
}
