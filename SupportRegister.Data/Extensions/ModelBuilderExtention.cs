using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SupportRegister.Data.Models;
using System;

namespace SupportRegister.Data.Extensions
{
    public static class ModelBuilderExtention
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
             new AppUser()
             {
                 Id = new Guid("BFF91064-DC92-421E-A233-D1080F630928"),
                 Address = "Hưng Lợi, Cần Thơ",
                 FullName ="Đỗ Xuân Yên",
                 Birthday = new DateTime(2000, 03, 03),
                 UserName = "YenDX",
                 NormalizedUserName = "YenDX",
                 Email = "yenb1809323@student.ctu.edu.vn",
                 NormalizedEmail = "yenb1809323@student.ctu.edu.vn",
                 SecurityStamp = string.Empty,
                 PasswordHash = hasher.HashPassword(null, "Admin@12345")
             },
             new AppUser()
             {
                 Id = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE"),
                 Address = "Hưng Lợi, Ninh Kiều, Cần Thơ",
                 FullName = "Võ Thị Thanh Trúc",
                 Birthday = new DateTime(2000, 03, 03),
                 UserName = "TrucVTT",
                 NormalizedUserName = "TrucVTT",
                 Email = "trucb1809323@student.ctu.edu.vn",
                 NormalizedEmail = "trucb1809323@student.ctu.edu.vn",
                 SecurityStamp = string.Empty,
                 PasswordHash = hasher.HashPassword(null, "Admin@12345")
             },
             new AppUser()
             {
                 Id = new Guid("BFF91065-DC92-421E-A233-D1080F630928"),
                 Address = "Hưng Lợi, Ninh Kiều, Cần Thơ",
                 FullName = "Vương Như Hảo",
                 Birthday = new DateTime(2000, 03, 03),
                 UserName = "HaoVN",
                 NormalizedUserName = "HaoVN",
                 Email = "haob1809323@student.ctu.edu.vn",
                 NormalizedEmail = "haob1809323@student.ctu.edu.vn",
                 SecurityStamp = string.Empty,
                 PasswordHash = hasher.HashPassword(null, "Student@12345")
             });

            modelBuilder.Entity<AppRole>().HasData(
             new AppRole()
             {
                 Id = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC"),
                 Name = "admin",
                 NormalizedName = "admin",
                 Description = "Administrator role"
             },
             new AppRole()
             {
                 Id = new Guid("BFF91064-DC92-421E-A233-D1080F630928"),
                 Name = "staff",
                 NormalizedName = "staff",
                 Description = "Staff role"
             },
             new AppRole()
             {
                 Id = new Guid("BFF91054-DC92-421E-A233-D1080F630928"),
                 Name = "student",
                 NormalizedName = "student",
                 Description = "Student role"
             });
            modelBuilder.Entity<Semester>().HasData(
            new Semester()
            {
                IdSemester = 1,
                NameSemester = "Học kỳ I"
            },
            new Semester()
            {
                IdSemester = 2,
                NameSemester = "Học kỳ II"
            },
            new Semester()
            {
                IdSemester = 3,
                NameSemester = "Học kỳ hè"
            });
            modelBuilder.Entity<Year>().HasData(
            new Year()
            {
                IdYear = 1,
                Year1 = "2019-2020"
            },
             new Year()
             {
                 IdYear = 2,
                 Year1 = "2020-2021"
             },
             new Year()
             {
                 IdYear = 3,
                 Year1 = "2021-2022"
             },
             new Year()
             {
                 IdYear = 4,
                 Year1 = "2022-2023"
             },
             new Year()
             {
                 IdYear = 5,
                 Year1 = "2023-2024"
             });
        }
    }
}
