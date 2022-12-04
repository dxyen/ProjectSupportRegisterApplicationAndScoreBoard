using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SupportRegister.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SupportRegister.Data.Extensions
{
    public static class ModelBuilderExtention
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Random random = new Random();

            #region User
            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
             new AppUser()
             {
                 Id = new Guid("BFF91064-DC92-421E-A233-D1080F630928"),
                 Address = "Hưng Lợi, Cần Thơ",
                 FullName = "Đỗ Xuân Yên",
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

            List<Guid> listUserId = new List<Guid>();
            List<AppUser> listUser = new();
            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            var randumName = new string[] { "Trúc", "Hảo", "Vy", "Toàn", "Nghĩa", "Thịnh", "Nhẫn", "Trung", "Lộc", "Nhựt", "Khánh", "Lâm", "Khánh" };
            var randumLastName = new string[] { "Nguyễn Văn ", "Trần ", "Đỗ ", "Nguyễn Hoàng ", "Trần Văn ", "Nguyễn ", "Lê Văn ", "Trương Văn ", "Phạm Thị ", "Lê ", "Thái " };
            var randumYear = new int[] { 2000, 2001, 2002, 2003 };
            var randumAddress = new string[] { "Tam Bình, Vĩnh Long", "Ninh Kiêu, Cần Thơ", "Phong Điền, Cần Thơ", "Giồng Riềng, Kiên Giang", "Tháp Mười, Đồng Tháp", "Hà Tiên, Kiên Giang", "Rạch Giá, Kiên Giang", "Phú Quốc, Kiên Giang" };
            for (int i = 0; i < 300; i++)
            {
                int idx = random.Next(randumLastName.Length);
                int idx2 = random.Next(randumName.Length);
                var fullname = randumLastName[idx] + randumName[idx2];
                int year = random.Next(randumYear.Length);
                int address = random.Next(randumAddress.Length);
                Guid tempGuid = Guid.NewGuid();
                listUserId.Add(tempGuid);
                AppUser user = new AppUser()
                {
                    Id = tempGuid,
                    Address = randumAddress[address],
                    FullName = fullname,
                    Birthday = new DateTime(randumYear[year], 3, 3),
                    UserName = "B18099" + i,
                    Email = "B18099" + i + "@student.ctu.edu.vn",
                    PhoneNumber = "0981774461" + i,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    NormalizedEmail = ("B18099" + i + "@student.ctu.edu.vn").ToUpper(),
                    NormalizedUserName = ("B18099" + i).ToUpper(),
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                };
                user.PasswordHash = passwordHasher.HashPassword(user, "Student@123");
                listUser.Add(user);
            }

            foreach (AppUser tempUser in listUser)
            {
                modelBuilder.Entity<AppUser>().HasData(tempUser);
            }
            #endregion

            #region Role
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
            #endregion

            #region UserRoles
            HashSet<UserRolePK> uniqueUserRole = new(new GenericEqualityComparer<UserRolePK>());
            for (int i = 0; i < 100; i++)
            {
                UserRolePK tempUserRole = new UserRolePK()
                {
                    UserId = random.Next(listUserId.Count)
                };
                uniqueUserRole.Add(tempUserRole);
            }

            foreach (UserRolePK userRole in uniqueUserRole)
            {
                modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                    new IdentityUserRole<Guid>
                    {
                        UserId = listUserId[userRole.UserId],
                        RoleId = new Guid("BFF91054-DC92-421E-A233-D1080F630928")
                    }
                );
            }
            #endregion

            #region Course
            const int COURSE_COUNT = 48;
            List<string> listCourseId = new List<string>();
            for (int i = 44; i <= COURSE_COUNT; i++)
            {
                listCourseId.Add("K" + i);
                modelBuilder.Entity<Course>().HasData(
                    new Course
                    {
                        IdCourse = "K" + i,
                        NameCourse = "Khóa " + i
                    }
                );
            }
            #endregion

            #region Class
            const int CLASS_COUNT = 5;
            var randumTeacher = new string[] { "Trần Minh Tân", "Thái Minh Tuấn", "Lâm Nhựt Khang", "Trần Cao Đệ", "Trần Công Án" };
            for (int i = 1; i <= CLASS_COUNT; i++)
            {
                int teacher = random.Next(randumTeacher.Length);
                modelBuilder.Entity<Class>().HasData(
                    new Class
                    {
                        ClassId = i,
                        NameClass = "Công nghệ thông tin " + i,
                        Teacher = randumTeacher[teacher]
                    }
                );
            }
            #endregion

            #region Student
            const int TRAINER_COUNT = 300;
            var randumYearStart = new int[] { 2018, 2019, 2020, 2021 };
            var randumYearEnd = new int[] { 2022, 2023, 2024, 2025 };
            for (int i = 1; i < TRAINER_COUNT; i++)
            {
                int start = random.Next(randumYearStart.Length);
                int end = random.Next(randumYearEnd.Length);
                modelBuilder.Entity<Student>().HasData(
                    new Student
                    {
                        StudentId = i,
                        UserId = listUserId[random.Next(listUserId.Count)],
                        IdCourse = listCourseId[random.Next(listCourseId.Count)],
                        ClassId = random.Next(1, CLASS_COUNT),
                        YearStart = randumYearStart[start],
                        YearEnd = randumYearEnd[end],
                    }
                );
            }
            #endregion

            #region Feedbacks
            const int FEEDBACK_COUNT = 30;
            for (int i = 1; i <= FEEDBACK_COUNT; i++)
            {
                modelBuilder.Entity<Feedback>().HasData(
                    new Feedback
                    {
                        IdFeedback = i,
                        StudentId = random.Next(1, TRAINER_COUNT),
                        TitleFeedback = "Sinh Viên Gửi Phản Hồi " + i,
                        ContentFeedback = "Nội dung của phản hồi do sinh viên gửi" + i
                    }
                );
            }
            #endregion

            #region Status
            modelBuilder.Entity<Status>().HasData(
                new Status()
                {
                    Id = 1,
                    Name = "Đăng ký"
                },
                new Status()
                {
                    Id = 2,
                    Name = "Hủy đăng ký"
                },
                new Status()
                {
                    Id = 3,
                    Name = "Xác nhận yêu cầu"
                },
                new Status()
                {
                    Id = 4,
                    Name = "Lưu đơn"
                },
                new Status()
                {
                    Id = 5,
                    Name = "Đã in"
                }, new Status()
                {
                    Id = 6,
                    Name = "Đã nhận"
                });
            #endregion

            #region RegisScore
            const int STATUS_COUNT = 6;
            const int RegisScore_COUNT = 200;
            for (int i = 1; i <= RegisScore_COUNT; i++)
            {
                modelBuilder.Entity<RegisterScoreboard>().HasData(
                    new RegisterScoreboard
                    {
                        IdStatus = random.Next(1, STATUS_COUNT),
                        DateRegister = DateTime.Now,
                        DateReceived = DateTime.Now.AddDays(2),
                        IdRegisterScoreboard = i,
                    }
                );
            }
            #endregion
            #region App
            modelBuilder.Entity<Application>().HasData(
                new Application()
                {
                    IdApplication = 2,
                    NameApplication = "Đơn xin xác nhận (sử dụng trong trường)-(SV chỉ chọn 'Nộp đơn' không cần phải in đơn này)",
                    Description = "Không có"
                },
                new Application()
                {
                    IdApplication = 4,
                    NameApplication = "Đơn xin xác nhận (sử dụng ngoài trường - mẫu đơn này không dùng để vay vốn theo diện chính sách được)",
                    Description = "Không có"
                },
                new Application()
                {
                    IdApplication = 5,
                    NameApplication = "Đơn xin tạm nghỉ học: SV in đơn cho PH ký, GVCV xác nhận, SV nộp tại VPK, Khoa ký xong SV nộp PCTSV",
                    Description = "Không có"
                },
                new Application()
                {
                    IdApplication = 6,
                    NameApplication = "Đơn xin tạm nghỉ học (Để điều trị bệnh: PH ký; GVCV ký; SV nộp tại VPK, Khoa ký xong SV nộp PCTSV)",
                    Description = "Không có"
                },
                new Application()
                {
                    IdApplication = 7,
                    NameApplication = "Đơn xin thôi học (SV in đơn cho phụ huynh ký và nộp tại VPK, Khoa ký xong SV nộp tại PCTSV)",
                    Description = "Không có"
                },
                new Application()
                {
                    IdApplication = 8,
                    NameApplication = "Đơn xét trợ cấp khó khăn đột xuất (SV in đơn, gởi BCS và GVCV xác nhận, sau đó nộp tại VPK)",
                    Description = "Không có"
                },
                new Application()
                {
                    IdApplication = 9,
                    NameApplication = "Đơn xin trợ cấp khó khăn đột xuất",
                    Description = "Không có"
                },
                new Application()
                {
                    IdApplication = 10,
                    NameApplication = "Đơn xin bảo lưu học phần (SV in đơn và nộp tại thư viện khoa CNTT&TT)",
                    Description = "Không có"
                },
                new Application()
                {
                    IdApplication = 11,
                    NameApplication = "Đơn xin miễn học phần Ngoại ngữ, Tin học, GDQP, GDTC (SV in đơn và nộp tại thư viện Khoa CNTT&TT)",
                    Description = "Không có"
                },
                new Application()
                {
                    IdApplication = 12,
                    NameApplication = "Đơn xác nhận (sử dụng  ngoài trường - không cần ghi lý do)-SV chỉ chọn 'Nộp đơn' không cần phải in",
                    Description = "Không có"
                },
                new Application()
                {
                    IdApplication = 13,
                    NameApplication = "Đơn xin vắng thi (Điểm I)",
                    Description = "Không có"
                },
                new Application()
                {
                    IdApplication = 14,
                    NameApplication = "Đơn đề nghị xét miễn và công nhận điểm HP do đã tham gia học tập ở nước ngoài",
                    Description = "Không có"
                });
            #endregion

            #region RegisApp

            var randumId = new int[] { 2, 4, 5 };
            const int RegisApp_COUNT = 200;
            for (int i = 1; i <= RegisApp_COUNT; i++)
            {
                int id = random.Next(randumId.Length);
                modelBuilder.Entity<RegisterApplication>().HasData(
                    new RegisterApplication
                    {
                        IdStatus = random.Next(1, STATUS_COUNT),
                        DateRegister = DateTime.Now,
                        DateReceived = DateTime.Now.AddDays(2),
                        Id = i,
                        Content = $"Lý do xin xác nhận: {i}",
                        Dear = $"Kính gửi: {i}",
                        StudentId = random.Next(1, TRAINER_COUNT),
                        ApplicationId = randumId[id]
                    }
                );
            }
            #endregion
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
                Year1 = 2018
            },
             new Year()
             {
                 IdYear = 2,
                 Year1 = 2019
             },
             new Year()
             {
                 IdYear = 3,
                 Year1 = 2020
             },
             new Year()
             {
                 IdYear = 4,
                 Year1 = 2021
             },
              new Year()
              {
                  IdYear = 5,
                  Year1 = 2022
              },
             new Year()
             {
                 IdYear = 6,
                 Year1 = 2023
             });
        }
    }
    class UserRolePK
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

    }
    class GenericEqualityComparer<T> : IEqualityComparer<T>
    {
        public bool Equals(T x, T y)
        {
            return GetHashCode(x) == GetHashCode(y);
        }

        public int GetHashCode([DisallowNull] T obj)
        {
            int hashCode = 0;
            var listProperties = obj.GetType().GetProperties();

            for (int i = 0; i < listProperties.Length; i++)
            {
                hashCode += listProperties[i].GetValue(obj).GetHashCode();
            }
            return hashCode;
        }
    }
}