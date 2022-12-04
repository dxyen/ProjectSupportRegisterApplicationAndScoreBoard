using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportRegister.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    IdApplication = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameApplication = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPLICATION", x => x.IdApplication);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false),
                    Avatar = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameClass = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    teacher = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    IdCourse = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    NameCourse = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Course__E0B50B816A385DF6", x => x.IdCourse);
                });

            migrationBuilder.CreateTable(
                name: "EmailAdmin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAdmin = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAdmin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    IdSemester = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSemester = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEMESTER", x => x.IdSemester);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Year",
                columns: table => new
                {
                    IdYear = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YEAR", x => x.IdYear);
                });

            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppRoleClaims_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserClaims_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AppUserLogins_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AppUserRoles_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserRoles_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AppUserTokens_AppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    YearStart = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    IdCourse = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    YearEnd = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "Fk_stu_course",
                        column: x => x.IdCourse,
                        principalTable: "Course",
                        principalColumn: "IdCourse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_student_class",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_STUDENTS_USERS",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegisterScoreboard",
                columns: table => new
                {
                    IdRegisterScoreboard = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdStatus = table.Column<int>(type: "int", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateReceived = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGISTERSCOREBOARD", x => x.IdRegisterScoreboard);
                    table.ForeignKey(
                        name: "Fk_status_score",
                        column: x => x.IdStatus,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YearSemester",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdYear = table.Column<int>(type: "int", nullable: false),
                    IdSemester = table.Column<int>(type: "int", nullable: false),
                    YearSemester = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearSemester", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_semester",
                        column: x => x.IdSemester,
                        principalTable: "Semester",
                        principalColumn: "IdSemester",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_year_detail",
                        column: x => x.IdYear,
                        principalTable: "Year",
                        principalColumn: "IdYear",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    IdFeedback = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ContentFeedback = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    TitleFeedback = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FEEDBACKS", x => x.IdFeedback);
                    table.ForeignKey(
                        name: "FK_FEEDBACK_STUDENT",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MinusPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    NameMinus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateRegis = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinusPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MinusPoints_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegisterApplication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    IdStatus = table.Column<int>(type: "int", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateReceived = table.Column<DateTime>(type: "date", nullable: false),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dear = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterApplication", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_regis_app",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "IdApplication",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_regisapp_status",
                        column: x => x.IdStatus,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_stu_detailapp",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailRegisterScoreboard",
                columns: table => new
                {
                    RegisId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    YearSemesterIdStart = table.Column<int>(type: "int", nullable: false),
                    YearSemesterIdEnd = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    YearStart = table.Column<int>(type: "int", nullable: false),
                    YearEnd = table.Column<int>(type: "int", nullable: false),
                    SemesterStart = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SemesterEnd = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetailRe__B873A826F6F01A76", x => new { x.RegisId, x.StudentId, x.YearSemesterIdStart, x.YearSemesterIdEnd });
                    table.ForeignKey(
                        name: "Fk_detail_end",
                        column: x => x.YearSemesterIdEnd,
                        principalTable: "YearSemester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Fk_detail_score",
                        column: x => x.RegisId,
                        principalTable: "RegisterScoreboard",
                        principalColumn: "IdRegisterScoreboard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_detail_stu",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Fk_yearsemester_detail",
                        column: x => x.YearSemesterIdStart,
                        principalTable: "YearSemester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "c8a4550b-a8ab-4aa2-8a6f-40f04a727192", "Administrator role", "admin", "admin" },
                    { new Guid("bff91064-dc92-421e-a233-d1080f630928"), "92352dd9-e93f-42be-978f-08e332b78014", "Staff role", "staff", "staff" },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), "ebef076b-1da8-4240-8cdc-d6a04fd37742", "Student role", "student", "student" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avatar", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("aff5e306-75cb-4779-b1ab-3d6cf23de72f"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "052396a6-41a6-4816-9767-f020444c737a", "B18099203@student.ctu.edu.vn", true, "Phạm Thị Nghĩa", false, null, "B18099203@STUDENT.CTU.EDU.VN", "B18099203", "AQAAAAEAACcQAAAAEJGPo/Pz2j/Lfnx45h9g4BX7gJIryYK0JB8Qum3D9WkxCZuC8jB/OZ99/IAVQE+xTg==", "0981774461203", true, "f0b54e56-48f0-43f0-87c2-43798e47594e", false, "B18099203" },
                    { new Guid("87dbd58a-08be-4527-9f0b-a5637720c6bd"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8137cc0-e41c-421b-a5ce-4c8c239391b3", "B18099202@student.ctu.edu.vn", true, "Trần Nhựt", false, null, "B18099202@STUDENT.CTU.EDU.VN", "B18099202", "AQAAAAEAACcQAAAAEGv6X2hhgGEhB+/yO6jTp9xtNvl/vjCamOw3w/5b6M91KcZV0JcHa5lX4QBO3rV+2w==", "0981774461202", true, "8a706557-e330-4ec4-8252-0e8a49f1f861", false, "B18099202" },
                    { new Guid("ba22fff6-ba45-43a7-9524-cf8bbd987330"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "920be0c0-5a1a-412f-8bbc-51410bcae066", "B18099201@student.ctu.edu.vn", true, "Phạm Thị Thịnh", false, null, "B18099201@STUDENT.CTU.EDU.VN", "B18099201", "AQAAAAEAACcQAAAAECzsgh8KITy5i8iF4m/68VaGEbN3MI4XWBvT7l659/WSG4gS3KELDAhZ1GZzyYBiWQ==", "0981774461201", true, "2126fdcd-9ad4-4967-930c-d745993fc3f8", false, "B18099201" },
                    { new Guid("0cdaa3a4-1d98-470a-82c6-e4f5f52e7606"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "f66eb3f5-3697-48e3-8424-fc1a2218a24d", "B18099200@student.ctu.edu.vn", true, "Trần Vy", false, null, "B18099200@STUDENT.CTU.EDU.VN", "B18099200", "AQAAAAEAACcQAAAAEJumRup5stGM4bozDXiFXhSUUeEVNejIrssDn/B5Y5WxtQrYCfyFV4SQ9qNU9YfTTg==", "0981774461200", true, "f32c19f1-5d6a-4368-b53f-baf289812429", false, "B18099200" },
                    { new Guid("5c5839b0-ed68-4539-8729-074e1bd0715a"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "14d6679c-4e20-4087-9c02-62f3bae93eb3", "B18099199@student.ctu.edu.vn", true, "Nguyễn Hoàng Trung", false, null, "B18099199@STUDENT.CTU.EDU.VN", "B18099199", "AQAAAAEAACcQAAAAEDcrlZ6Rvqbo29JydI6CR/q4x1IQzw87/v+3uKuSwjysdQYb4rLsrIAlG3CSvjsjBA==", "0981774461199", true, "5605d827-4511-4a7b-98a0-ebf656bb6713", false, "B18099199" },
                    { new Guid("c9d49df6-86d3-4eed-b145-83f7a89d4e28"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "f5ecd250-176e-4e89-81dd-8042fbaeafdd", "B18099198@student.ctu.edu.vn", true, "Phạm Thị Khánh", false, null, "B18099198@STUDENT.CTU.EDU.VN", "B18099198", "AQAAAAEAACcQAAAAENi0VW9binv+eJW15NZkDKzfJNHExB9LD9LbUpqEGnTil9cH/nNYcCmMcCeeat3xHQ==", "0981774461198", true, "4dbc0911-6e8e-4d23-ae61-7dec8eee5e82", false, "B18099198" },
                    { new Guid("d87f20ae-a7ca-4ea1-8fe3-9259e62e34db"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "3978aaba-3ed6-40d9-a112-d4810dd41d7a", "B18099197@student.ctu.edu.vn", true, "Trần Khánh", false, null, "B18099197@STUDENT.CTU.EDU.VN", "B18099197", "AQAAAAEAACcQAAAAELqy5CX8VhCeoNGCK5lEud/HCmP7frVU4E7Bjd5LeTo2z7pqPa51QhYKXtW88/7Thg==", "0981774461197", true, "db27ccd2-55b5-4b37-8511-2fde3409a561", false, "B18099197" },
                    { new Guid("6eecb6b8-67d5-420c-a111-933ca97a495c"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "49b723ab-e846-4003-9924-f57a61c6190a", "B18099195@student.ctu.edu.vn", true, "Phạm Thị Trúc", false, null, "B18099195@STUDENT.CTU.EDU.VN", "B18099195", "AQAAAAEAACcQAAAAEAKENj5EkaY+pqfPKHx9SmF15P7uv2wCcTY94Mbyva+BxS5MXpJ0zHqlHcL3uv2usg==", "0981774461195", true, "e2e43dc6-127a-4437-bb13-75807f122281", false, "B18099195" },
                    { new Guid("98dccdd4-d8ae-4d50-bf78-709f0aaa21d5"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "88c9d1ac-c5c0-489b-95e7-bca61f6c87a7", "B18099204@student.ctu.edu.vn", true, "Phạm Thị Trúc", false, null, "B18099204@STUDENT.CTU.EDU.VN", "B18099204", "AQAAAAEAACcQAAAAEPAX2ossLtsExK0secFmaKbg/c9zScSfWntfLaEeJtGBaZzoSQWEwxy1C3R3Skbx0g==", "0981774461204", true, "3bbc1e34-ef72-4b57-82ed-dd2a6bebc944", false, "B18099204" },
                    { new Guid("d418469e-cfe0-4f78-82e8-c28b3e15c819"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "616f45b7-e809-4957-aaf6-d5bf5b3ce345", "B18099194@student.ctu.edu.vn", true, "Nguyễn Trúc", false, null, "B18099194@STUDENT.CTU.EDU.VN", "B18099194", "AQAAAAEAACcQAAAAEOp22B+EzMkRGzkR6tPnOMWZn/4W4rmr908dSGpnJIuzKwzA6kr9BIrGJzw6jNl/dw==", "0981774461194", true, "07bbe168-fa94-4605-80e0-4ec0f1f77d35", false, "B18099194" },
                    { new Guid("86cdf93f-7053-493d-a389-191383b73a9b"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "63f374e1-bc8a-45b2-960b-33ad65b59b96", "B18099193@student.ctu.edu.vn", true, "Nguyễn Nghĩa", false, null, "B18099193@STUDENT.CTU.EDU.VN", "B18099193", "AQAAAAEAACcQAAAAEEeKxk0crfttZakz9mBQqClk1tOLTYSYvj1Gr4Ua4T8E93vkxdBPhBwAXRTvXuREjQ==", "0981774461193", true, "57477ffe-71bd-45dc-b2b7-19af98d9b9bd", false, "B18099193" },
                    { new Guid("e6881558-193e-4523-866d-dad134bf0e50"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "4c5b6c64-7ff4-4739-a821-4539ab436c87", "B18099192@student.ctu.edu.vn", true, "Trần Hảo", false, null, "B18099192@STUDENT.CTU.EDU.VN", "B18099192", "AQAAAAEAACcQAAAAEK5TtQz09FlyQvVuSsXAJBTZAdLYpMhXOzw3NGvtUZiDSDCg4DLaYqmlvGGSrpPMmA==", "0981774461192", true, "c0290d06-25e8-4a0c-a241-826ee7ee65d9", false, "B18099192" },
                    { new Guid("dabff61d-e067-4c3d-b0ba-834d4c466f97"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "eeb9ed6c-bb6f-4e6f-8405-efd994303568", "B18099191@student.ctu.edu.vn", true, "Nguyễn Hoàng Lâm", false, null, "B18099191@STUDENT.CTU.EDU.VN", "B18099191", "AQAAAAEAACcQAAAAECuONM+GI355mlKitH/MKDDKg2Ekiuqw4EWJElbYpHyZpxeAGgHfKsk5RQBc0xP8nQ==", "0981774461191", true, "c2d7d909-2f4e-4fa6-9652-f32e2870085f", false, "B18099191" },
                    { new Guid("8b12049b-7bb8-4573-b67a-03ffa91995a7"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "6632af45-956b-4e3e-b5aa-da6e333529d9", "B18099190@student.ctu.edu.vn", true, "Lê Văn Khánh", false, null, "B18099190@STUDENT.CTU.EDU.VN", "B18099190", "AQAAAAEAACcQAAAAEDMP5NtWb9g454O4/JucTSeVdNyV+3Eoz9VcUtii/W3FNE13oiYtSruKbOqL6ZhqMg==", "0981774461190", true, "d2f304bd-263c-46e9-a328-8bd86e7b8580", false, "B18099190" },
                    { new Guid("7e898cd0-2d72-4ac3-b1e6-601e3edfad00"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "607b5af4-df4b-4899-bda0-0bd310b6c78d", "B18099189@student.ctu.edu.vn", true, "Lê Văn Vy", false, null, "B18099189@STUDENT.CTU.EDU.VN", "B18099189", "AQAAAAEAACcQAAAAEABDBfmeo3zfYy69KE/TjpS3cWIvldmuro5zyi9AmiLSCkZ3Taw0WIEC0gARP8fM8Q==", "0981774461189", true, "c0de10b7-09ec-4c22-9a0a-e7fac0737b3c", false, "B18099189" },
                    { new Guid("634bcaf6-f0fb-4057-83c2-c4429a871287"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "3c128149-f2bb-444a-9881-55b7e8e36b46", "B18099196@student.ctu.edu.vn", true, "Lê Văn Trung", false, null, "B18099196@STUDENT.CTU.EDU.VN", "B18099196", "AQAAAAEAACcQAAAAEF9FSANd0aocE+Sg80nt6tZDa0Xjo2wvnRI6oxIOU14CKVJZTep355AtKSLYB9oquw==", "0981774461196", true, "4c9361b0-cdb2-4ec4-9794-1c7edf7c9cac", false, "B18099196" },
                    { new Guid("e2c45fb3-91b5-4945-a4f3-06ff08602135"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "1fee437d-d5bc-4069-96bd-4faeebdbe7c9", "B18099205@student.ctu.edu.vn", true, "Nguyễn Văn Trung", false, null, "B18099205@STUDENT.CTU.EDU.VN", "B18099205", "AQAAAAEAACcQAAAAEEQiVg0Opbvgm/fYNHxLgJi7brAaeqNF46l2d3taZ+Poh1L5Thn7CvsjFuN7xsK+Ww==", "0981774461205", true, "de07c768-13f4-430b-a4d9-028d772f0050", false, "B18099205" },
                    { new Guid("3f87e1c7-be78-484f-8f0f-6789984920b2"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "591d2d4e-9d82-43a3-afe5-8d6a57c046b3", "B18099206@student.ctu.edu.vn", true, "Thái Hảo", false, null, "B18099206@STUDENT.CTU.EDU.VN", "B18099206", "AQAAAAEAACcQAAAAEMbMxTHQ2QuFZTPaNZq8z+oPSkDNcm+6DSk8td3kkUIMhV5qvk8qE/fZL7/BYo8HaA==", "0981774461206", true, "d8e70cc3-1225-4925-a93d-d48edec6dcce", false, "B18099206" },
                    { new Guid("24d83dd1-5d54-4226-ba5d-ae95b87dbc39"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "783195e9-4c34-4a65-b728-ad711eff913c", "B18099207@student.ctu.edu.vn", true, "Lê Văn Nghĩa", false, null, "B18099207@STUDENT.CTU.EDU.VN", "B18099207", "AQAAAAEAACcQAAAAELCXDX6EiSJlyb9qtT6KjgIS8R5eR7JDM4rxt5mBmActP/4m3lz7Qnu09GnFrWbVJQ==", "0981774461207", true, "5fe60b33-3a1b-4f59-bcb1-687a572fdd4a", false, "B18099207" },
                    { new Guid("6d9d1618-d183-4711-977e-fb333baa8035"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "0f42340e-9f92-4566-9fa5-4a35f8b1cb6f", "B18099222@student.ctu.edu.vn", true, "Nguyễn Văn Nghĩa", false, null, "B18099222@STUDENT.CTU.EDU.VN", "B18099222", "AQAAAAEAACcQAAAAEEyifNkXeH+H/3r3C522Wo0wcwWfDAHlYCIFW6gPznOR5VM9UBRFF9qc03b7WCt5hA==", "0981774461222", true, "4ee3929b-e62c-439e-b934-6de4f0510b70", false, "B18099222" },
                    { new Guid("7c3810f4-46c5-4fe6-9641-71f4c7c646b4"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "23fd726e-8ea2-4a1b-a034-d2eecf71564e", "B18099221@student.ctu.edu.vn", true, "Trương Văn Vy", false, null, "B18099221@STUDENT.CTU.EDU.VN", "B18099221", "AQAAAAEAACcQAAAAEB0yn+F8oUg6cYrjNAMQW/B3G3xJWo8lxr2C4WCWZMdc0vHaBC4/j6cQDTMw3fY8tg==", "0981774461221", true, "569f85f1-ab2c-4a44-ba8c-9ab0c377b49c", false, "B18099221" },
                    { new Guid("0747e4f7-b6cd-473d-b17a-d0c8e3066f2f"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "b43fbb3c-8e10-45be-9bdd-154ec941d6bf", "B18099220@student.ctu.edu.vn", true, "Nguyễn Hoàng Thịnh", false, null, "B18099220@STUDENT.CTU.EDU.VN", "B18099220", "AQAAAAEAACcQAAAAEBrXd4hhXlX/gZZk/ayhRIBVnAuGD4DmGyE+yXvKYq5W3yEhys2PN1WDtigi4uPtIQ==", "0981774461220", true, "98cba86c-7642-437a-b414-82a39f7ac1ae", false, "B18099220" },
                    { new Guid("7860d176-cd9b-4fe6-9cdc-c6829bff2304"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "b00efa33-51a0-4bdf-82df-746a78f969b8", "B18099219@student.ctu.edu.vn", true, "Nguyễn Văn Lộc", false, null, "B18099219@STUDENT.CTU.EDU.VN", "B18099219", "AQAAAAEAACcQAAAAEEXghBz6Ko6G6RjRuQ/Zz2zLXYhuDsfa1jMFDbOnp0lMZZY6ch1fRAvTP6bhxul2Lg==", "0981774461219", true, "63304498-8647-4842-ba1d-580fb4b6248c", false, "B18099219" },
                    { new Guid("c7f17152-c5df-4389-9bc5-dd5beb67968f"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "fd937f37-18d6-45f9-bb64-25f557f087fe", "B18099218@student.ctu.edu.vn", true, "Nguyễn Vy", false, null, "B18099218@STUDENT.CTU.EDU.VN", "B18099218", "AQAAAAEAACcQAAAAEL0uqSZzGC9/j3pLvaRS2BPQuRr15K4DFHB/i0zZz1cpQPeBP8qk8jAsAY3Ifg7aNg==", "0981774461218", true, "0c6a267d-38cb-4c19-b057-183e2886aca3", false, "B18099218" },
                    { new Guid("b7fa6ab5-f298-4577-9c95-bb613ed53280"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "674da917-a58b-40a2-b524-d035ea6be743", "B18099217@student.ctu.edu.vn", true, "Nguyễn Nhẫn", false, null, "B18099217@STUDENT.CTU.EDU.VN", "B18099217", "AQAAAAEAACcQAAAAEKUm+FVRy/pU+7yS+l6koLlLa4QwdshDoFE3RB1PG6b9MQkJU1dHY26G25gNgSBAvQ==", "0981774461217", true, "24ff9401-4423-494a-a004-b3fc74b3945e", false, "B18099217" },
                    { new Guid("e00e393d-f54a-4d26-b6bc-8749ec429fc9"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "23d14291-6e6c-4275-a954-c2c744a6b3cf", "B18099216@student.ctu.edu.vn", true, "Đỗ Thịnh", false, null, "B18099216@STUDENT.CTU.EDU.VN", "B18099216", "AQAAAAEAACcQAAAAEK0IlAcC9+zlaRVXSMTx0yH6G+ZtdXrMHEgC3fZGFivf3HlGMqNHU5Q+C/55DJabtA==", "0981774461216", true, "f4d1e058-3605-4ab9-92e6-eb4ab39cee77", false, "B18099216" },
                    { new Guid("0d5327a5-6b00-4c5b-8983-3ec8d6e965fc"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "2bd0a1f9-bbaf-4b17-a4d1-aaeecdfbeab0", "B18099215@student.ctu.edu.vn", true, "Lê Văn Lâm", false, null, "B18099215@STUDENT.CTU.EDU.VN", "B18099215", "AQAAAAEAACcQAAAAEC6j/GaUFF7G+d/fDjmoR1Vyp68Lp+fATBqpGPz1ZsnSUA3lagy5kaBHYueE+pwkAg==", "0981774461215", true, "c77fb032-8408-4068-9359-437d54c6e7e0", false, "B18099215" },
                    { new Guid("6ce9d59b-0a62-4a94-b515-39084e7da946"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "cf9cd0dd-ec63-4676-8f33-e3d6f11d1671", "B18099214@student.ctu.edu.vn", true, "Trần Thịnh", false, null, "B18099214@STUDENT.CTU.EDU.VN", "B18099214", "AQAAAAEAACcQAAAAEIPKx/qi7whQB2M/zDwL/HF0u82DY44xZI6lLqbBhDSzaBRqqi0el/ywELJ68ZWRuA==", "0981774461214", true, "fda0d222-d255-4949-af4b-08077af4d28d", false, "B18099214" },
                    { new Guid("47024bc0-76fc-49dd-9560-5577b470e180"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "d74e0cd4-a82a-4c8e-b937-637f8ef1cb57", "B18099213@student.ctu.edu.vn", true, "Đỗ Toàn", false, null, "B18099213@STUDENT.CTU.EDU.VN", "B18099213", "AQAAAAEAACcQAAAAEC5QN20gNcq88I92M1wJHsA8MKoWFlVj9ZjIG3LmDe/GOgNK3wG70c9Wa2AiYctgjA==", "0981774461213", true, "f4828127-0367-44d6-a47f-a78095593960", false, "B18099213" },
                    { new Guid("a8502205-a79d-47dc-b8f9-8b8df983fe3f"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "de2bb21b-0ea9-4467-8278-4ffcfd806de2", "B18099212@student.ctu.edu.vn", true, "Phạm Thị Vy", false, null, "B18099212@STUDENT.CTU.EDU.VN", "B18099212", "AQAAAAEAACcQAAAAEHkcjT0eznww5st1jUfpsg0FghjxTO8mqniqQz7yM6yngE7PkltvgL5rHNUB7cyNcw==", "0981774461212", true, "3df3ab9b-de61-422b-a749-fe439c9565c9", false, "B18099212" },
                    { new Guid("e1607665-0b43-4b68-8132-86554a0e5f07"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "42e9db36-b723-4db1-bbd3-8410666e2e3d", "B18099211@student.ctu.edu.vn", true, "Lê Văn Nhựt", false, null, "B18099211@STUDENT.CTU.EDU.VN", "B18099211", "AQAAAAEAACcQAAAAEK0i+vlu+5zaUTYT2Zy4VBdkefn8Mr21tVQ2mqiWF1awGNh3jU50I5/g9VlQm+BY0A==", "0981774461211", true, "5178ec25-093e-4f66-90b3-cdb406894b9d", false, "B18099211" },
                    { new Guid("4e76012a-7b95-4513-9d46-91cd17741a2c"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "31cf4812-c755-484b-8aff-1b2d98725d08", "B18099210@student.ctu.edu.vn", true, "Thái Trung", false, null, "B18099210@STUDENT.CTU.EDU.VN", "B18099210", "AQAAAAEAACcQAAAAECVTUW1R93mU/5o+vfdC3tksrc58tbPLGmgFX4jiF9D/ITzyNJDrH9oeDAzPTGDXSQ==", "0981774461210", true, "7f875316-67e4-4e0b-911c-8d1834f9fcb7", false, "B18099210" },
                    { new Guid("5f01fe3c-3a60-4b2b-aa73-babce7c66c13"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "92a76d9c-e4ab-444a-9ba6-3612b4ff31b8", "B18099209@student.ctu.edu.vn", true, "Trần Văn Khánh", false, null, "B18099209@STUDENT.CTU.EDU.VN", "B18099209", "AQAAAAEAACcQAAAAEBDnPqIAP6eZ8mB1EFxU7b9GwKXgJkg8U/SR9VzirEiRZsMdh18YzQMKGVLHygX/5g==", "0981774461209", true, "2b84e2a5-f57e-4617-8565-a79dd0e9e2f5", false, "B18099209" },
                    { new Guid("049d0711-2893-4e0c-9830-79fcb87006ed"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "08c79412-3658-4900-b66e-2bf68352d6e6", "B18099208@student.ctu.edu.vn", true, "Thái Lộc", false, null, "B18099208@STUDENT.CTU.EDU.VN", "B18099208", "AQAAAAEAACcQAAAAEHYgi8y2qNY6bRIIap10V36VbH/VxbDtruDAX/dMuP4fF/Ggs3oPX8qpCebIxrFixw==", "0981774461208", true, "d1b5a983-b38b-4450-b478-2e3b9efbb83f", false, "B18099208" },
                    { new Guid("2ab41b5f-1e9f-4177-b164-f1885dad768e"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "9504dd3d-c2f9-47e9-ad45-fb5e7e1eeac1", "B18099188@student.ctu.edu.vn", true, "Lê Văn Khánh", false, null, "B18099188@STUDENT.CTU.EDU.VN", "B18099188", "AQAAAAEAACcQAAAAENrxJjx0FEukwINufXlRDjYRvMENx7LPyS4t4WRbBATSpkZ4U9y7fhi6qEXc+G8j1w==", "0981774461188", true, "a6b309be-8b9f-4487-bd99-798a3c82a401", false, "B18099188" },
                    { new Guid("9ccd656b-8be9-4cd9-a456-4a4446c7a5e5"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "d24a2816-477f-4de5-a086-ca539b315a41", "B18099187@student.ctu.edu.vn", true, "Trần Thịnh", false, null, "B18099187@STUDENT.CTU.EDU.VN", "B18099187", "AQAAAAEAACcQAAAAEESx9+IXM+bNp74sdlqcYhg1KyCh+5H7NQ7PQkm5u+amZPqYEwyX5rDLFoFq+m/sbQ==", "0981774461187", true, "9537693b-69de-430c-be1e-632747510785", false, "B18099187" },
                    { new Guid("dc2c4ceb-be0b-4342-888b-c4a40c3d52a3"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "cf4dc231-9c45-4dff-ad7d-e3846f7888a4", "B18099186@student.ctu.edu.vn", true, "Lê Văn Nhẫn", false, null, "B18099186@STUDENT.CTU.EDU.VN", "B18099186", "AQAAAAEAACcQAAAAEDh2s5xbqZ582C6yykUTTZ+THz4V1LhtDoxeIVrNXcGQAPeVgv31930H1WOISFmpqQ==", "0981774461186", true, "75a45d62-91a1-426b-aff2-b5d18caab2a6", false, "B18099186" },
                    { new Guid("3d6ef8e7-5af4-4f3d-bb56-66e56fd3fdac"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "b82560f0-ab1f-4e36-81bc-93b0e75aca14", "B18099185@student.ctu.edu.vn", true, "Nguyễn Hoàng Trung", false, null, "B18099185@STUDENT.CTU.EDU.VN", "B18099185", "AQAAAAEAACcQAAAAEIZcAgqPWj4mAmvVqNI3x/urA+GpsPIcXNtz0Y30U6Rw/S68+U7soJwMQ6CXmv7d1w==", "0981774461185", true, "4cff3a79-1906-4fc6-83ec-b418ef502106", false, "B18099185" },
                    { new Guid("8be85bd5-1095-46dd-98de-f158021c9f12"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "f29f05cd-6719-4011-931d-41c06889dd4b", "B18099164@student.ctu.edu.vn", true, "Phạm Thị Nhựt", false, null, "B18099164@STUDENT.CTU.EDU.VN", "B18099164", "AQAAAAEAACcQAAAAECke85SsVeMAH5XR7udk8cY2dRdQV20//Wn3Al97RVCytAIWS7P8jVfxHe97Nirazg==", "0981774461164", true, "a920bd23-15fb-43b2-a639-37419c74ea06", false, "B18099164" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avatar", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("17557f2a-be60-49b2-9cab-1bea6fe0fa01"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "456742d7-df24-4fb0-8959-51d99f4e11dd", "B18099163@student.ctu.edu.vn", true, "Nguyễn Hoàng Lâm", false, null, "B18099163@STUDENT.CTU.EDU.VN", "B18099163", "AQAAAAEAACcQAAAAEK+bNYMFsVmFGgeXaXtZsX4PDxGI2P+CEXfSQy2BQNUZxF16CaFSEkIyDqYR2Swv4A==", "0981774461163", true, "a6b2a929-6fda-4074-8e19-afc5232ad446", false, "B18099163" },
                    { new Guid("bed10234-220c-4521-865f-92d9cc2b6f23"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "b5f9ddc7-5bef-4d1b-9450-4ef23983a0eb", "B18099162@student.ctu.edu.vn", true, "Lê Nhựt", false, null, "B18099162@STUDENT.CTU.EDU.VN", "B18099162", "AQAAAAEAACcQAAAAEEhAo8zjGrNzscHubKk0aUc9FdHb/of7kydz0pk78iBDn9XhLDOZVWQ+LTbEgGA0Lg==", "0981774461162", true, "dd32e79e-889c-437e-a579-bbb270228c38", false, "B18099162" },
                    { new Guid("b691565f-72fb-4c5d-8451-63ff137f79ac"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "d0168ae2-9760-4a5d-86e9-2e9d1b84d94a", "B18099161@student.ctu.edu.vn", true, "Phạm Thị Khánh", false, null, "B18099161@STUDENT.CTU.EDU.VN", "B18099161", "AQAAAAEAACcQAAAAEFXU5ehK7k0i+0d6lkwFkrVJ3wWd9jTf08MF3Ohln5ESOHpdwvpC5i+GVQC/rcsclg==", "0981774461161", true, "4d0d6646-c5e9-4216-8b52-287de215fd3d", false, "B18099161" },
                    { new Guid("249f39b1-d370-4150-8689-b9c224d90d66"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "7e9fdf94-8a7c-45f9-a5ce-00f6c1ea0c28", "B18099160@student.ctu.edu.vn", true, "Đỗ Lộc", false, null, "B18099160@STUDENT.CTU.EDU.VN", "B18099160", "AQAAAAEAACcQAAAAEAwLeofEIDFZQ1oE0W9D9py9smoxU7VEcfppJA+PECkGMzT3O1f45rDU83NbTce0Pg==", "0981774461160", true, "a9298604-c65d-4086-84d8-f6cc4065aa6c", false, "B18099160" },
                    { new Guid("69d14ccd-458e-45c3-88eb-cfce2a0afa59"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "525d127e-6b1b-4b3c-a195-7c58d97ff777", "B18099159@student.ctu.edu.vn", true, "Đỗ Trúc", false, null, "B18099159@STUDENT.CTU.EDU.VN", "B18099159", "AQAAAAEAACcQAAAAEH3rFerDzMHzd9mLDkve9iCyzsm86kLmSNQMo1cj4eVxAbQUxH/mgybf454iJdhr8Q==", "0981774461159", true, "a95d9ff3-0cd0-445c-84ed-4612b5b45e36", false, "B18099159" },
                    { new Guid("3d91b138-a5c4-4ab1-9ca9-ffed7b92f910"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "c938bd07-c620-4358-ae44-623f2d03deb7", "B18099158@student.ctu.edu.vn", true, "Lê Hảo", false, null, "B18099158@STUDENT.CTU.EDU.VN", "B18099158", "AQAAAAEAACcQAAAAEGpBrXm5YYm0KJwFJTPWyrqGnopJCS6GtdsKaIAl4psGaiTkMVnjVwMyZq4CYjeC9g==", "0981774461158", true, "cd075906-5c14-4c8e-9c77-a76c8c47b390", false, "B18099158" },
                    { new Guid("cc571974-7fc5-43f9-ab15-8f17111cd6f7"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "137bc81e-ed58-4fe9-bc37-2704f2467a28", "B18099157@student.ctu.edu.vn", true, "Đỗ Lâm", false, null, "B18099157@STUDENT.CTU.EDU.VN", "B18099157", "AQAAAAEAACcQAAAAEEPqQhYxyMYiFkRrZ5p3yfR2R2B+kmfpKED5hzb4wRJY2FXiCoZrW+nbhM7eNoBYlw==", "0981774461157", true, "77d772b3-c109-4917-8361-f6a5397c0781", false, "B18099157" },
                    { new Guid("2a867f04-0fca-4dce-9ab2-27f49d9c7613"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "b52d7c94-b15c-4210-8903-745e8c024f73", "B18099156@student.ctu.edu.vn", true, "Đỗ Trung", false, null, "B18099156@STUDENT.CTU.EDU.VN", "B18099156", "AQAAAAEAACcQAAAAEMLpKT1qYifKVTjjCycrLgOU+tIxBaoYz4VI4duk5Cgf8zN/bUN2hbv5FrK3YJSTNg==", "0981774461156", true, "f394eb86-8029-450f-b1d9-1114964543d4", false, "B18099156" },
                    { new Guid("baa097d4-56d1-4741-8c47-9744c1e178a0"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "16927ee2-5fff-4c5e-be35-57a50e223985", "B18099155@student.ctu.edu.vn", true, "Trần Văn Lộc", false, null, "B18099155@STUDENT.CTU.EDU.VN", "B18099155", "AQAAAAEAACcQAAAAEH+eYtLqNP51H1wsNzNp/SrXPVFWs8yoVX05vVFmcu9aFCCWXqga0h1+wlJbMCZDgw==", "0981774461155", true, "8dbb54bd-f42a-4131-8502-5a28e3d4f047", false, "B18099155" },
                    { new Guid("81161214-bbb5-4fae-bce4-7613dc84bb3f"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "56e738e7-1176-4b18-99f4-6bc464d92a2c", "B18099154@student.ctu.edu.vn", true, "Lê Văn Nhựt", false, null, "B18099154@STUDENT.CTU.EDU.VN", "B18099154", "AQAAAAEAACcQAAAAEDCvv/Urre9uzjQi/X23iAbfPPGrf+wfAmU335hdT8W3ZbHx1xD4FeRA++jelzMWng==", "0981774461154", true, "fab7ed93-da07-4c00-90cd-569ea380df85", false, "B18099154" },
                    { new Guid("70ec207a-97db-415d-bbe3-cafcb81b9b8a"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "0532fd99-655d-4b13-9693-41a9e3fad50d", "B18099153@student.ctu.edu.vn", true, "Thái Trung", false, null, "B18099153@STUDENT.CTU.EDU.VN", "B18099153", "AQAAAAEAACcQAAAAEIsBrJv7jLbp5uw5TLzVmxfolzhuPVaCesCO9SElpbDrbcBJAMwbfgNAAYaanphN2g==", "0981774461153", true, "0cbb6545-f44a-41b6-a515-668b3849ffde", false, "B18099153" },
                    { new Guid("503e2155-7fc9-4f96-8bb2-04fe277cdb31"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ad4d7311-07a6-4deb-b4bb-9cb3af9ded4f", "B18099152@student.ctu.edu.vn", true, "Lê Văn Lộc", false, null, "B18099152@STUDENT.CTU.EDU.VN", "B18099152", "AQAAAAEAACcQAAAAEGZl9SOQY2gYLMMFItyE8p1Z1rSsN3oNhZn6upRicn8ivS9P9yN8Hhf6XZIX/V/D3Q==", "0981774461152", true, "3d68bace-7b9c-406c-83b3-b79c49c310a2", false, "B18099152" },
                    { new Guid("b99c7b85-53ee-4067-a41e-403545cdef54"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "a020bdca-71d2-437c-9cbc-37355e797750", "B18099151@student.ctu.edu.vn", true, "Trần Thịnh", false, null, "B18099151@STUDENT.CTU.EDU.VN", "B18099151", "AQAAAAEAACcQAAAAEDjKMbXKvYxVx5pyyfP40uCdTT44RIcvIW67V7emAfz2F1jM177x6qY4pAOch42/IQ==", "0981774461151", true, "464b7bfd-ee52-4dd8-b339-a6d874a94a1c", false, "B18099151" },
                    { new Guid("990c62b6-8d6c-47fb-bcb6-7c68aa272587"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ffecaa34-3858-4d6c-b576-937b30d8f709", "B18099150@student.ctu.edu.vn", true, "Trương Văn Khánh", false, null, "B18099150@STUDENT.CTU.EDU.VN", "B18099150", "AQAAAAEAACcQAAAAEErfsu1/JOM+o6EXiIovC/mShnnXyAksLJN8ahF8vOb8VNA7B1HvsOh/9v1qI93XhQ==", "0981774461150", true, "b4aaf032-ad39-43d3-8306-e023f365755d", false, "B18099150" },
                    { new Guid("538aadc3-d225-4d2b-ae9e-2369f0b2cd1b"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ae812696-7b76-49a8-b78e-3e8d46dc2d67", "B18099166@student.ctu.edu.vn", true, "Nguyễn Hoàng Khánh", false, null, "B18099166@STUDENT.CTU.EDU.VN", "B18099166", "AQAAAAEAACcQAAAAEGMDDFZJIhn+3qVpC6io7ZhiomlDcEl2jWKxsum9gFJlNGMXBWged1PngPUaPNztOg==", "0981774461166", true, "2b35e40e-9046-496d-8acb-420aab6b873d", false, "B18099166" },
                    { new Guid("13b3e888-a382-4658-a846-80f55bc6fb37"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "935e9197-3748-4d9c-af62-a1a657f12d95", "B18099223@student.ctu.edu.vn", true, "Lê Khánh", false, null, "B18099223@STUDENT.CTU.EDU.VN", "B18099223", "AQAAAAEAACcQAAAAEJ06BLygL7SmMZQH3W+jSx/Xu0xYXs0sZEwtx5ebBqd+PSxzGENeA6yl1AXDSJz6ng==", "0981774461223", true, "caecc79a-f184-4993-9b01-443bdb56aebc", false, "B18099223" },
                    { new Guid("c1400430-6785-4c37-9bde-3bc2cea7b75e"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "9ac2118b-883a-4dff-a820-86464ebf18ea", "B18099167@student.ctu.edu.vn", true, "Lê Hảo", false, null, "B18099167@STUDENT.CTU.EDU.VN", "B18099167", "AQAAAAEAACcQAAAAEDNUNSUNn492mcOuYA9UyJZ4xqfoHupsqhXlJQIdH5H7bsbHcFYUZR+itAsY/Q0IPA==", "0981774461167", true, "e8ca33e5-fa08-4274-b96f-5c63b90082a7", false, "B18099167" },
                    { new Guid("03b705af-6b55-4152-83fd-acbaa5423071"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "85ab6595-ab79-44a9-a26a-6c9449af4f87", "B18099169@student.ctu.edu.vn", true, "Trương Văn Nhựt", false, null, "B18099169@STUDENT.CTU.EDU.VN", "B18099169", "AQAAAAEAACcQAAAAEP7uMY9iqLSwJPxyo1dLfKADV1u7D9h5AwVkF/WI06aIL/ZHOelPQNeiecgTK5Li7g==", "0981774461169", true, "02582308-8472-4c9c-ab23-fe667199e409", false, "B18099169" },
                    { new Guid("50521053-b9d9-464d-b5e8-00c48fc4995c"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "289b4797-6f1a-4697-9db4-cf7bbf732488", "B18099184@student.ctu.edu.vn", true, "Phạm Thị Trúc", false, null, "B18099184@STUDENT.CTU.EDU.VN", "B18099184", "AQAAAAEAACcQAAAAEO42nJLZsnVQl02Opf+T3XggYE38L5dDRPcFY1oS2Y5iExEJn7nXuRgs1LgkSY20jA==", "0981774461184", true, "458d615e-16eb-4a66-a9de-5987ae264d86", false, "B18099184" },
                    { new Guid("f21b5736-4e1b-4a01-b665-7fdaeab5e985"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "1d54a386-cee2-46cd-ad3c-71f88b8bd54f", "B18099183@student.ctu.edu.vn", true, "Trương Văn Nhựt", false, null, "B18099183@STUDENT.CTU.EDU.VN", "B18099183", "AQAAAAEAACcQAAAAEEdljSEzkPULz7MtV6RvVwan9OVyju2d1Bebw0FeAZfuwkS5tcurBfPoJ5wENefvtQ==", "0981774461183", true, "ab15de94-7c24-478a-8eb3-cd94559ab211", false, "B18099183" },
                    { new Guid("611dfe3b-6099-4dc5-81ac-59f0bea04757"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "7cc3acdc-f47e-43b3-a3b9-b53e10197e2f", "B18099182@student.ctu.edu.vn", true, "Lê Văn Trung", false, null, "B18099182@STUDENT.CTU.EDU.VN", "B18099182", "AQAAAAEAACcQAAAAEA3LbNWSteRQZWgQdsclxVz9ybBH7bxiDR48WELg1bgCu1p/lufAfVeeLJko7No8oA==", "0981774461182", true, "628e307d-adce-4fd1-82a0-0778fb89b8fc", false, "B18099182" },
                    { new Guid("7099201c-bc51-4f0e-a888-e68190a878ee"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "c01bb746-12da-47e7-a222-cb7a6f987f20", "B18099181@student.ctu.edu.vn", true, "Nguyễn Toàn", false, null, "B18099181@STUDENT.CTU.EDU.VN", "B18099181", "AQAAAAEAACcQAAAAEMj2hEvLu8hIIaMutCq3z0PoPTD4G0NemvdE/9BfsO4bru0bmTqQ1N4ZUr/46s9S8A==", "0981774461181", true, "7d4e4510-8d26-4081-a722-fb8c6726a435", false, "B18099181" },
                    { new Guid("6538c877-4478-470d-a0a4-59d091813ba4"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "78d6cb5a-0e48-47cd-a7cf-68d15af57dc4", "B18099180@student.ctu.edu.vn", true, "Trần Văn Khánh", false, null, "B18099180@STUDENT.CTU.EDU.VN", "B18099180", "AQAAAAEAACcQAAAAEOsTGXRPa710GXozNEpAuZU4bHyQZF6z9DgLQFgyciycoDOBVz2rq+lIlPrbYRmV4A==", "0981774461180", true, "e037da18-3170-40ae-a799-46bdb1ec1146", false, "B18099180" },
                    { new Guid("6675c38c-b749-4aa4-bbe5-fee86ca4616b"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "2bc45706-7ea7-4ff6-a3f4-5bbb703f8d7f", "B18099179@student.ctu.edu.vn", true, "Trương Văn Trúc", false, null, "B18099179@STUDENT.CTU.EDU.VN", "B18099179", "AQAAAAEAACcQAAAAEO46gf8I4Ts2KZkVU1E539q60VSIeaSyRUVBFe+oiz3kGDsRkk/NaDUky1djBnix/A==", "0981774461179", true, "f01d914f-298c-4f4d-a4d8-3c72c3333429", false, "B18099179" },
                    { new Guid("f6d29461-dbc7-4501-be7d-00debc77915a"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "7ded84e4-5229-4586-901e-90ed2b91e632", "B18099178@student.ctu.edu.vn", true, "Nguyễn Văn Lâm", false, null, "B18099178@STUDENT.CTU.EDU.VN", "B18099178", "AQAAAAEAACcQAAAAEJnPRV4/q67WAoJakbaY+Tx0A5+NvgDApx3oaLmoAZzkysqCqbKtJhmjOqB39+sJIQ==", "0981774461178", true, "7806fb6a-8e8f-4a3d-8fb8-f0ce28f84e55", false, "B18099178" },
                    { new Guid("d6d6d1be-7cea-4f90-8fc8-de96f56550f6"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "3f14d455-4fdb-43f4-8866-f7e53a5a6da4", "B18099177@student.ctu.edu.vn", true, "Nguyễn Khánh", false, null, "B18099177@STUDENT.CTU.EDU.VN", "B18099177", "AQAAAAEAACcQAAAAEEvkAZ5ruRdRjjKezeXrMABSDjYIgNQFDwNp+H9vWsdlV7bpT1n7oYJquJ6/xhHVBg==", "0981774461177", true, "84f781c8-ed29-4e43-9ec3-224e28aea44a", false, "B18099177" },
                    { new Guid("dd60dbb4-2ca7-4ce3-b6bc-b0d17ffb300b"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "da66cc00-f169-4fec-9277-fbde35dd7d3c", "B18099176@student.ctu.edu.vn", true, "Thái Nhẫn", false, null, "B18099176@STUDENT.CTU.EDU.VN", "B18099176", "AQAAAAEAACcQAAAAEDYEfhfJWSif16zPyH+xevZVKCcJymcz3Jk8AwaUD293gbN5TsDF2dBfV+IHG+/iww==", "0981774461176", true, "e8017fae-a14f-4e42-bb7f-25b1292dd9b8", false, "B18099176" },
                    { new Guid("16299704-9d26-455d-94da-1302a25c42b6"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "f87d3ca9-8a1d-47f2-8be5-aa4aedf090cc", "B18099175@student.ctu.edu.vn", true, "Phạm Thị Khánh", false, null, "B18099175@STUDENT.CTU.EDU.VN", "B18099175", "AQAAAAEAACcQAAAAEOXAc0YL5Ea15cVzk1yiFcZkm6/04ZG9lnLArC1I73DWdR9lcRaQANGoI8dw/jnIjw==", "0981774461175", true, "389342a4-281d-4a3a-930a-55aca20a3328", false, "B18099175" },
                    { new Guid("de70013a-cf70-4665-9f64-6407039827da"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "58c2cde4-d6cf-40b6-9d52-036b7730bba1", "B18099174@student.ctu.edu.vn", true, "Trần Nghĩa", false, null, "B18099174@STUDENT.CTU.EDU.VN", "B18099174", "AQAAAAEAACcQAAAAENxkA5sEGzWh+meoRQIhud0qdHrm4fzpKxBwDeqkyryuFZS5591RoEWXFV6fiqwyMQ==", "0981774461174", true, "a1dd02e3-b893-4f6e-ba47-3f530afa452f", false, "B18099174" },
                    { new Guid("6838d7c4-66e5-4de7-a1b6-aa49064874fa"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "a32ea5f8-20ff-45b2-8479-31b3ff7f9085", "B18099173@student.ctu.edu.vn", true, "Trương Văn Khánh", false, null, "B18099173@STUDENT.CTU.EDU.VN", "B18099173", "AQAAAAEAACcQAAAAEGLMHlUX9oGwnG0EOLhIqOKsURqpcRePw5y/IMrg8JsDdzMn9gBc4v6Jt+3t4P4G4g==", "0981774461173", true, "6c8228a3-b3c1-4ba9-835b-f9de89059cd0", false, "B18099173" },
                    { new Guid("b1a6e79d-33b5-4be8-9aa7-60f6ebb15f75"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "fc26b0b4-79ba-4c5a-8bf1-cf7c3c549054", "B18099172@student.ctu.edu.vn", true, "Nguyễn Hoàng Khánh", false, null, "B18099172@STUDENT.CTU.EDU.VN", "B18099172", "AQAAAAEAACcQAAAAEM23nSvesgRPkA02etSg2YY62LFhl36ii8Iroeg56of/FBaduLGZDtTIbsgNj+3U7A==", "0981774461172", true, "9e260455-09aa-4f9f-9aef-6cca05dd107b", false, "B18099172" },
                    { new Guid("98abd83b-2b91-45c9-97f0-cbead87b40a2"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "50fcd242-52ac-44a5-a5df-53dc8e27b0d3", "B18099171@student.ctu.edu.vn", true, "Lê Toàn", false, null, "B18099171@STUDENT.CTU.EDU.VN", "B18099171", "AQAAAAEAACcQAAAAEPEx96rlm2Gl9lNt62+icHMZN6XuSRpFmHCRxSRw8uWWcixIHtDUIM+uVgQ+VhUG+g==", "0981774461171", true, "e4b9d077-87b9-430f-a46d-29f5e11a3732", false, "B18099171" },
                    { new Guid("d4cbee19-5748-44c4-a61d-dc2ddd2ac53c"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "b85f44f1-9dce-4c85-b726-6df5fe1896f4", "B18099170@student.ctu.edu.vn", true, "Phạm Thị Khánh", false, null, "B18099170@STUDENT.CTU.EDU.VN", "B18099170", "AQAAAAEAACcQAAAAEMmU4hR5guRSobhkxUQ5N1XID5cFDY2BGVchzqlpVAUjzSV+RuNxwPKqIJ//R7RSsg==", "0981774461170", true, "68d2b4da-227c-4989-bdc2-a833e64de6ae", false, "B18099170" },
                    { new Guid("dad2543e-6ce6-4db3-be0e-42361aae6382"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "b87b3730-f0ee-47a3-ad36-70a622a703f9", "B18099168@student.ctu.edu.vn", true, "Trần Thịnh", false, null, "B18099168@STUDENT.CTU.EDU.VN", "B18099168", "AQAAAAEAACcQAAAAEAISFuajRoR2+VV351eGDRD0Fs3oLPpQrbDSB7TRfIJx24FPKosjkuGPPRF5wNKeqA==", "0981774461168", true, "9cb534d4-d0f9-43d0-b0f2-28e23eb51f42", false, "B18099168" },
                    { new Guid("3a69e6e1-c0fb-44f1-aafc-61fccc441229"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "db92a367-3753-42c9-8366-4c5f684e74c1", "B18099224@student.ctu.edu.vn", true, "Thái Nhựt", false, null, "B18099224@STUDENT.CTU.EDU.VN", "B18099224", "AQAAAAEAACcQAAAAECyOvZ7UITwcR7mIGvvqPj+oFvbiFcRXRwDnaLHl7AHda8BO/gVEBjz0UKUlZjiXnA==", "0981774461224", true, "a3cd5180-2325-4c94-a922-58562daf5f61", false, "B18099224" },
                    { new Guid("559fae44-8558-4b2e-ae62-c76f0ca4b65d"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "fd5933bf-4126-4ecd-87f7-cf3a79c2ccc6", "B18099226@student.ctu.edu.vn", true, "Thái Lâm", false, null, "B18099226@STUDENT.CTU.EDU.VN", "B18099226", "AQAAAAEAACcQAAAAEBaiVKzdj5tFv1Pxb3Xl27vq1TU8X7FtZnR4htOXL8pyQbVw5jdtZha6ZWQdFXa5Fw==", "0981774461226", true, "348da7a3-1984-4508-bdeb-9b1ff73e2ed9", false, "B18099226" },
                    { new Guid("e6d20114-5812-4bd7-8690-0b1dd547b13b"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "a3c7ed26-a2f8-4197-9359-3616028995b7", "B18099149@student.ctu.edu.vn", true, "Lê Khánh", false, null, "B18099149@STUDENT.CTU.EDU.VN", "B18099149", "AQAAAAEAACcQAAAAEAtAhEO11t5Lt6YtQy+2ccJ89kxQZJw+oXm3uTKRMQ5niHKm7W63XqAOQPdh1xbXrw==", "0981774461149", true, "73da283e-e94c-4f47-9f45-6d1d5b84ed07", false, "B18099149" },
                    { new Guid("9ac029c2-60a9-43b7-aaff-2a8440035f39"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "255b7cc2-2090-4873-a009-7a9df0c92f43", "B18099280@student.ctu.edu.vn", true, "Nguyễn Lộc", false, null, "B18099280@STUDENT.CTU.EDU.VN", "B18099280", "AQAAAAEAACcQAAAAEDYYH9/v0OsPWbCwIx6lm9rZB1Y5sdTH7jyJ5enMTRMJljxWpQMGbZ4nBoxw58G/QA==", "0981774461280", true, "def9f2af-e94e-4f2b-ac3b-e502b387ddf6", false, "B18099280" },
                    { new Guid("43c0f9e8-a21f-43b2-949e-850d9ecf40f5"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "9506866d-b141-4868-b5ee-47234382f50f", "B18099279@student.ctu.edu.vn", true, "Lê Vy", false, null, "B18099279@STUDENT.CTU.EDU.VN", "B18099279", "AQAAAAEAACcQAAAAEIVvaUdZXgZEf475iASlMtEePqqMkRCM4nqJZIb1LYiWWMzWwU5d2so4omBdtCFgcA==", "0981774461279", true, "489c8c0e-9042-4bd4-a0bf-3b1a3bbba1d6", false, "B18099279" },
                    { new Guid("bbd850cb-3ea8-47b7-8e67-4799b79dd4b4"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "e83851e1-3a6a-4c05-8c2d-0134c78c2f02", "B18099278@student.ctu.edu.vn", true, "Thái Nhựt", false, null, "B18099278@STUDENT.CTU.EDU.VN", "B18099278", "AQAAAAEAACcQAAAAEPKz1YI1u/IOw34SPaOq6JjTBQY2PELkgfzottZmotP1TMbbl4VIQzO0OxpXAceYHw==", "0981774461278", true, "14c74bdb-847f-440e-be18-338074f3b022", false, "B18099278" },
                    { new Guid("45675f17-ed01-4627-b320-550b81d1895c"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "891b6be9-395f-4c00-bb82-f253a972a9e1", "B18099277@student.ctu.edu.vn", true, "Lê Văn Lâm", false, null, "B18099277@STUDENT.CTU.EDU.VN", "B18099277", "AQAAAAEAACcQAAAAEOB6/iLXySvUhwLf5YLAphKF8eoyBJUpwnSNxMq65UeuFhvA1fWNwy56S7XGTLfVfw==", "0981774461277", true, "925b17bd-368c-4dc6-9069-8df42cf57840", false, "B18099277" },
                    { new Guid("854a1de0-42f0-4c80-9570-298a2ea4c1f0"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "281b966f-5824-4e8c-b841-2d91371a3cdd", "B18099276@student.ctu.edu.vn", true, "Lê Hảo", false, null, "B18099276@STUDENT.CTU.EDU.VN", "B18099276", "AQAAAAEAACcQAAAAEAIqW3nVbpN02YxpQJOzioclxJp0LS4MhhQoqRY8lj6PoTx+F1m+xRVkoZ+tpC6jNA==", "0981774461276", true, "7e73cd83-1200-4dc5-8e4a-0e83247d1bf4", false, "B18099276" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avatar", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("4d9d2c15-bdf6-4211-8dda-cc80b669755c"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "6c11f75c-34eb-4789-989f-66274d24fe6e", "B18099275@student.ctu.edu.vn", true, "Thái Hảo", false, null, "B18099275@STUDENT.CTU.EDU.VN", "B18099275", "AQAAAAEAACcQAAAAEOIHTH01WBJsDAaJEQrNMU+z0V9U68EGZFrJzuLep1XmaQC0OtLM5hJEgT0j0/70gA==", "0981774461275", true, "4793616a-0cf6-47eb-a933-5979b741dc54", false, "B18099275" },
                    { new Guid("696fcae1-07d7-48bb-aeb6-f5a3567a19c0"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "6114f078-04bf-4ee3-b616-440473b83383", "B18099274@student.ctu.edu.vn", true, "Phạm Thị Lâm", false, null, "B18099274@STUDENT.CTU.EDU.VN", "B18099274", "AQAAAAEAACcQAAAAEJNwgkc2o/uaTjIgi8mTOqQiuLPwh4a+DeDhz/2rEbSobnXZkAtnhdx81bFx+lfdgA==", "0981774461274", true, "567ceced-2151-4d29-b827-b9177f44ec97", false, "B18099274" },
                    { new Guid("8d051f8e-9d84-4cc9-90b8-bf58ee39a34e"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "e6093788-f2ff-4f45-9fe1-2c5c99673718", "B18099273@student.ctu.edu.vn", true, "Trần Khánh", false, null, "B18099273@STUDENT.CTU.EDU.VN", "B18099273", "AQAAAAEAACcQAAAAEPq8yeIc6t7ZNx+LUiHEVb+pC2k1LrSR2JMnqJpTXrzhMOib99Vxfc7idTFHJC6KHw==", "0981774461273", true, "50297b28-7137-4863-aca0-5392c8b28c57", false, "B18099273" },
                    { new Guid("f0fb7d04-d4b1-4e52-b072-0e99de40a3e5"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "3e7baded-516f-4bc7-b129-db3214f5c3ea", "B18099272@student.ctu.edu.vn", true, "Trương Văn Khánh", false, null, "B18099272@STUDENT.CTU.EDU.VN", "B18099272", "AQAAAAEAACcQAAAAECMvlwAUStOJ9ONOQOOGR2CiMPkCFphKg0hlbWpBBKI3/4PwaLn10kyvfXI+LMBmOw==", "0981774461272", true, "3818a6cd-737c-45d5-89eb-b79208cc07fc", false, "B18099272" },
                    { new Guid("496b8668-9b42-4344-bf6b-3a59b5fc5359"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "206e990f-c7c5-4287-83c4-f26ce012f9f4", "B18099271@student.ctu.edu.vn", true, "Trương Văn Lâm", false, null, "B18099271@STUDENT.CTU.EDU.VN", "B18099271", "AQAAAAEAACcQAAAAEF2c7heYVereYvT6UIjvoyn+m21E+8CJ/Fyhnm+iDj+J58J6UAEPxJHX3hcLFM8UrA==", "0981774461271", true, "2f735206-c353-4885-981f-cecf28a48a94", false, "B18099271" },
                    { new Guid("57677f45-f195-4462-8271-501207360e58"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ab61f649-3023-4c83-bad1-da1bb97c8c90", "B18099270@student.ctu.edu.vn", true, "Trần Trúc", false, null, "B18099270@STUDENT.CTU.EDU.VN", "B18099270", "AQAAAAEAACcQAAAAEPET/Oe5MCL3r7WOiGhWvN49B2+penltQ4/0g025PejMaH9KA+dWd50EwjeVyItZPQ==", "0981774461270", true, "b4309bd8-9876-4b06-ad94-519610afb8ba", false, "B18099270" },
                    { new Guid("a2da14ec-3748-4d93-a0e8-702738386d40"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "9e65e417-f4c2-4b4b-8bff-62d2ddc77314", "B18099269@student.ctu.edu.vn", true, "Nguyễn Hoàng Nhẫn", false, null, "B18099269@STUDENT.CTU.EDU.VN", "B18099269", "AQAAAAEAACcQAAAAEP8BHI4gtBV3mhly3XPYn83rMaz4vvjG3HweCVKU3m9vResLRnKJXUWXsQX4AQ+3Ag==", "0981774461269", true, "d1496434-6986-498c-9c2e-865736039f16", false, "B18099269" },
                    { new Guid("a48602b9-1f8a-4240-b394-0a19a01a0cd0"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "11b5ef4c-acda-4495-9b7b-563932655c5f", "B18099268@student.ctu.edu.vn", true, "Trần Toàn", false, null, "B18099268@STUDENT.CTU.EDU.VN", "B18099268", "AQAAAAEAACcQAAAAEMGXqw7HAqySV+vtcCfkXccKPEOkY+g7E/4IGOR3gKQAvU2rPFV8bZ/kgcGU1YVUUg==", "0981774461268", true, "573ed6b4-79ad-478b-a60d-2caeeebe9353", false, "B18099268" },
                    { new Guid("22992e67-305a-466d-a1be-707fa8b37b08"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "b6307a81-3452-47a0-92b8-4f33e672fb6d", "B18099267@student.ctu.edu.vn", true, "Thái Hảo", false, null, "B18099267@STUDENT.CTU.EDU.VN", "B18099267", "AQAAAAEAACcQAAAAEM/D8rrwGwuzw+8lIT95e7A6G7ipLOc2SUNs5rtjegwCGuuEtyu4tc8eg76+k2uEyA==", "0981774461267", true, "6aef423e-6f41-472e-bb27-01225fbad7d8", false, "B18099267" },
                    { new Guid("b112a17e-e7ad-49f8-a9ee-b206b13ce2ee"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "aea50336-01fd-4eb8-ad38-3cb16016e66d", "B18099266@student.ctu.edu.vn", true, "Phạm Thị Lâm", false, null, "B18099266@STUDENT.CTU.EDU.VN", "B18099266", "AQAAAAEAACcQAAAAEJjmjmRtOBDxz09XLHWo1pTtYcrm/hWosmuN+pPOQiLN4+feyfexJGX2W/wIRdhj5Q==", "0981774461266", true, "e59c78d4-e653-49d6-804e-c7d8174f21e3", false, "B18099266" },
                    { new Guid("0395246e-3cab-4e29-9711-092650e643ac"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "c8fa9cfa-1996-4f5e-bca0-6b35a34e602e", "B18099281@student.ctu.edu.vn", true, "Nguyễn Văn Khánh", false, null, "B18099281@STUDENT.CTU.EDU.VN", "B18099281", "AQAAAAEAACcQAAAAEGAjHmB+r1lKa9HG3ULoEqX0Z4K65yBnMrB35XflR4wOJHaBFO0ul9U6lk2Kapy7rA==", "0981774461281", true, "f20aabd6-0003-44f2-86a2-97ed8e109ffb", false, "B18099281" },
                    { new Guid("c75efa30-51e7-465b-abd0-0d39e869587f"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "681f0bc7-2ce2-4fbe-b448-e25b2926231d", "B18099265@student.ctu.edu.vn", true, "Trần Văn Toàn", false, null, "B18099265@STUDENT.CTU.EDU.VN", "B18099265", "AQAAAAEAACcQAAAAEPHU19PFwWB1SeBNp1JgQJBLzB0PYmcTXZSCCrYbaA1+q9wCkHY1QgWbH85zLN/3qQ==", "0981774461265", true, "160eeb5d-7fee-4106-9460-71331cc768b1", false, "B18099265" },
                    { new Guid("98df4859-492b-400e-9bff-9c106ac355fd"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "c20d30b9-5c1d-4f89-9baf-4b4bd1e91d75", "B18099282@student.ctu.edu.vn", true, "Thái Hảo", false, null, "B18099282@STUDENT.CTU.EDU.VN", "B18099282", "AQAAAAEAACcQAAAAEAeEJgVh5rsHVTZwbKF92Xc69Z1S6g3AyWwHtTYqGKFARpiESkfoUsEsiBnCjgy2jg==", "0981774461282", true, "40216fd2-a099-413b-bc58-1a0825f341e7", false, "B18099282" },
                    { new Guid("c2b58604-3210-456d-ae23-df85644b555c"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "3e91147f-8b1c-434a-b621-53aa499cdc68", "B18099284@student.ctu.edu.vn", true, "Trần Văn Vy", false, null, "B18099284@STUDENT.CTU.EDU.VN", "B18099284", "AQAAAAEAACcQAAAAEC4MRAjJ2PPIk6UmF6KwzWljFaX3khq11tbH7R98EMHrI+Zw1N6IG81rAGnQ/jKlEg==", "0981774461284", true, "08dc18a4-e918-4718-924b-e7bf2fb5762c", false, "B18099284" },
                    { new Guid("e91a793c-9caa-48ff-a09c-1de8bd093fb2"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "008ed52d-cb4a-483c-8bd5-525d0fa691d1", "B18099299@student.ctu.edu.vn", true, "Lê Nghĩa", false, null, "B18099299@STUDENT.CTU.EDU.VN", "B18099299", "AQAAAAEAACcQAAAAEE7mq0055cAzhUVYSTziOQhgcIoa0wnCGuDxD7JATr9kFAneQj2OD8Kdariy+wIkHg==", "0981774461299", true, "a980f606-22e3-422e-8725-dcf0907802a1", false, "B18099299" },
                    { new Guid("976fe0c7-9396-4458-9e29-d8baa2d2d89f"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "586a8b6a-85cf-4ca1-873d-c3c690dbda94", "B18099298@student.ctu.edu.vn", true, "Thái Lộc", false, null, "B18099298@STUDENT.CTU.EDU.VN", "B18099298", "AQAAAAEAACcQAAAAEI0UdSE7ODo/01vOuI0awXyophvJgUOBsg8GR3A0xuPSHl7B6TsYSvrZa48vk3Mi3g==", "0981774461298", true, "c0793ad6-2066-44a2-845b-9f5c56762a4e", false, "B18099298" },
                    { new Guid("ce967a78-4b40-4382-9fe7-05d0b36829d0"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "80393000-cff6-4f9d-ba2b-7adff63fa84a", "B18099297@student.ctu.edu.vn", true, "Lê Văn Toàn", false, null, "B18099297@STUDENT.CTU.EDU.VN", "B18099297", "AQAAAAEAACcQAAAAEHcIf2Z1QwAJH/oNuv95Ub6cpP2MVMdUAokaMgJpeJI3A1sGxFpd3AP+1YKRVrXIKA==", "0981774461297", true, "0e53d1a1-68a8-4c6b-bc76-4edeb16e77be", false, "B18099297" },
                    { new Guid("71e479af-3f35-4b06-bce1-a3bd1f4b89f6"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "7549891f-68d9-4122-92c0-f572792a9f8d", "B18099296@student.ctu.edu.vn", true, "Trương Văn Khánh", false, null, "B18099296@STUDENT.CTU.EDU.VN", "B18099296", "AQAAAAEAACcQAAAAELUfcW0Fc3q/IGGNA0Y/L3NW7NWdCHw0UB8p5qufW74Mm1+Y77QSUEzTivx2dNjIlQ==", "0981774461296", true, "372b7bb6-63ea-49ab-aa35-b33a4430c027", false, "B18099296" },
                    { new Guid("d7032b13-1712-4afa-a15a-316dcd84b37a"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "b0554c1e-0d7f-434a-8101-a33f694e558a", "B18099295@student.ctu.edu.vn", true, "Lê Văn Lâm", false, null, "B18099295@STUDENT.CTU.EDU.VN", "B18099295", "AQAAAAEAACcQAAAAEPWrDNnvoqgXT/4EE9uWy9cC8FCT6b4ezzWnB/xQIfxPvFoIWHPTIYm6BeI5fGLx/A==", "0981774461295", true, "ccf2f8ec-5ef7-48e7-8138-cfe531f9115d", false, "B18099295" },
                    { new Guid("087afe30-2643-46e6-9e33-b296b5608b6b"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "d5ad8012-bc52-40b1-95f1-28b80080799c", "B18099294@student.ctu.edu.vn", true, "Thái Nhẫn", false, null, "B18099294@STUDENT.CTU.EDU.VN", "B18099294", "AQAAAAEAACcQAAAAEMM52RQNN480OTsK+/ocmb0pLxdAljiJdMDnNgRj8IDZij7WJRFjb+KuubBYTQjA5w==", "0981774461294", true, "31814944-c909-4df0-bcd8-d2d12f9c8934", false, "B18099294" },
                    { new Guid("c837618c-dc3f-468b-b237-36f91fe28c89"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "95f4945f-1a4a-4267-ae38-de18e72bd500", "B18099293@student.ctu.edu.vn", true, "Nguyễn Thịnh", false, null, "B18099293@STUDENT.CTU.EDU.VN", "B18099293", "AQAAAAEAACcQAAAAEGK/IJ9bQrP2ODjHCSfuA+AQq63kMIegJeXqypejgKnm9Tl5IOwifjxdMvMTUmWB7A==", "0981774461293", true, "8b04517b-9e3f-4d50-9e69-8140bb94ed52", false, "B18099293" },
                    { new Guid("8a6be835-409f-4308-918d-3f395efd9dfd"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "bd566766-79bb-426d-9a5f-43b91da9538a", "B18099292@student.ctu.edu.vn", true, "Trần Thịnh", false, null, "B18099292@STUDENT.CTU.EDU.VN", "B18099292", "AQAAAAEAACcQAAAAEF6cLIXBy1nOZU2Ucy9D3CslTbPpC4kSKPE91ezAZ+Uu+4qH7cACV0Al9Vmnkqwn7Q==", "0981774461292", true, "d06416b2-0954-4a4d-82bc-12497218c980", false, "B18099292" },
                    { new Guid("f4a99026-6133-4da8-a597-633c700b8588"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "7b4bd07d-2141-4b0e-ac19-6dec60ab0bd1", "B18099291@student.ctu.edu.vn", true, "Nguyễn Thịnh", false, null, "B18099291@STUDENT.CTU.EDU.VN", "B18099291", "AQAAAAEAACcQAAAAENM6Ls2MgKFDOKKS8PHerV6xK9C3VRC18K8jJ7MGMWvEblEglZIZAqrVUsTHq7VBjQ==", "0981774461291", true, "c7e86377-2e7e-4fd2-b0ef-c6fa153422ac", false, "B18099291" },
                    { new Guid("dd0160a4-501c-4f69-a41a-45b2d93969be"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "33af303e-7eb6-4d93-a020-b27b982bb880", "B18099290@student.ctu.edu.vn", true, "Lê Khánh", false, null, "B18099290@STUDENT.CTU.EDU.VN", "B18099290", "AQAAAAEAACcQAAAAEFiZbESf3tOlfl9UM/tXj/2cLH3pRnfgeYWIpoUAlH/lsBknOx/EItb5e0juvA4AYg==", "0981774461290", true, "57e1eb2c-115e-457f-a387-5560b49bf414", false, "B18099290" },
                    { new Guid("ff8c4b26-5b08-4375-923a-22a4aa54a897"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "15cce8ae-5625-4164-8e18-15d387c307f3", "B18099289@student.ctu.edu.vn", true, "Lê Nghĩa", false, null, "B18099289@STUDENT.CTU.EDU.VN", "B18099289", "AQAAAAEAACcQAAAAEEZGGgZoXGmrR9unSz/e/0nHpuwmBX7U4f+SlRcawDfl7rqcun4xC9g7iyodJYmRiw==", "0981774461289", true, "b05f12a6-aea5-430d-b39f-7ea8461cf7d0", false, "B18099289" },
                    { new Guid("7ad19b1e-fd5e-4aee-ad80-d206e07ee20c"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "4b369487-49dd-4bf6-bacd-e22ad1b5d608", "B18099288@student.ctu.edu.vn", true, "Thái Vy", false, null, "B18099288@STUDENT.CTU.EDU.VN", "B18099288", "AQAAAAEAACcQAAAAEOmHVFsyVLIb/6ZZ4tRQkyBb6XguGc+d0HJWbjfTxx0EFkzQIV03EaaPnP+JImFqIw==", "0981774461288", true, "af30bb9e-9f56-468b-b53d-efe3c13dea73", false, "B18099288" },
                    { new Guid("687c621b-7490-41ac-b133-586cb7bf93f0"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "5b5286d4-b334-409c-ab0e-1c6d0c465950", "B18099287@student.ctu.edu.vn", true, "Nguyễn Hoàng Khánh", false, null, "B18099287@STUDENT.CTU.EDU.VN", "B18099287", "AQAAAAEAACcQAAAAEBkmpgXAZLQ5VM1RTJ5udH83xWYYpLRvBx1F/X6geNtMkfR9V+oLtlVpstsb2lDFTQ==", "0981774461287", true, "c9f47e82-68de-4622-abb6-cb344f26fbab", false, "B18099287" },
                    { new Guid("f16d9e63-f743-41d3-a2ba-787186a8b719"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "03b4b17a-7fa5-4786-a19d-b06cad6fd49c", "B18099286@student.ctu.edu.vn", true, "Lê Vy", false, null, "B18099286@STUDENT.CTU.EDU.VN", "B18099286", "AQAAAAEAACcQAAAAEN2LHoiiHHPawlgvJdBByKGgBxhDSq/md5cnJR8jMJnBX6VP46k+0f+Cx95Q+0JLCA==", "0981774461286", true, "03fe9765-0288-4cb5-a7dd-d6934d4adb4c", false, "B18099286" },
                    { new Guid("aae9d43f-8ed3-4d2a-8d76-72b0d837efb3"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "f7e83965-d0f0-45e9-858a-637e73590194", "B18099285@student.ctu.edu.vn", true, "Nguyễn Vy", false, null, "B18099285@STUDENT.CTU.EDU.VN", "B18099285", "AQAAAAEAACcQAAAAECIq5PEWVFiGFMVgLetS0XeWu6UyEoyIyd0l5z9/+0Pn4310H3uGbAS4Ix6RDRl52A==", "0981774461285", true, "8dd1d422-278a-4260-917e-c8529e469306", false, "B18099285" },
                    { new Guid("b943af61-6212-46b7-b5f0-ad7412e6d600"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "a0d6135c-f90b-4e80-9bcf-3938d97580aa", "B18099283@student.ctu.edu.vn", true, "Trần Văn Khánh", false, null, "B18099283@STUDENT.CTU.EDU.VN", "B18099283", "AQAAAAEAACcQAAAAEEQA5Li92OmS0iqDHRvvAIYmskDLsRZP+v4Nc1FWPnQEf7uLisTe5dOKfji9pHePag==", "0981774461283", true, "917f2692-620d-40b6-8ae6-f2af4d07c1f4", false, "B18099283" },
                    { new Guid("bd342e77-34b4-4c9b-b723-f7c184129b8c"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "f3dd0ee2-7763-41f3-8164-9d25f4ace8e1", "B18099264@student.ctu.edu.vn", true, "Nguyễn Hoàng Lộc", false, null, "B18099264@STUDENT.CTU.EDU.VN", "B18099264", "AQAAAAEAACcQAAAAEAN7E81Lb7JsPc3Xug44WlsgGYLyG+v5qExCECFpK2g0/fzrXJ8gVh9p91+b6HhqNw==", "0981774461264", true, "e63ad5ed-f618-47b2-8385-18f5dfd9130e", false, "B18099264" },
                    { new Guid("37f49058-2255-418c-8024-57d6b84bdc1e"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "74bd5f7c-fdb6-4596-ba8d-9f292060a2c3", "B18099263@student.ctu.edu.vn", true, "Lê Văn Khánh", false, null, "B18099263@STUDENT.CTU.EDU.VN", "B18099263", "AQAAAAEAACcQAAAAEOSlRbjwHtzvYZ8xBeHcgot5pZpxu7niKA74huqeIrOxtlhthPqVWR5KaFkjjcrW2A==", "0981774461263", true, "31d2d8e2-13da-45a2-b39a-c0fa2fe211ba", false, "B18099263" },
                    { new Guid("765974e9-db14-4a38-993f-c541da5d5996"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "fe5e9d22-4bec-4001-a4f0-43e023481007", "B18099262@student.ctu.edu.vn", true, "Trần Văn Lâm", false, null, "B18099262@STUDENT.CTU.EDU.VN", "B18099262", "AQAAAAEAACcQAAAAEOZl7O9se87ylu6cLsCWZUIRi03vwlbuwb1X05r81Uhs5Ix8+4YbZCdilwXYFJSLQg==", "0981774461262", true, "01e1d784-7320-45b7-96f2-5453289a63c6", false, "B18099262" },
                    { new Guid("9324178a-f398-4e69-bab0-23897f36bb24"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "58793d03-0744-4817-b251-1f511336b4c9", "B18099241@student.ctu.edu.vn", true, "Phạm Thị Toàn", false, null, "B18099241@STUDENT.CTU.EDU.VN", "B18099241", "AQAAAAEAACcQAAAAENr0Vaj85ZnykJKvsSas0Ov26Q2BgJvwVBoNJ1EsTlbCCEecvQWmHA0xZ50GzcwK0A==", "0981774461241", true, "73a92d73-8be7-484e-8b35-5b54aae8dfe7", false, "B18099241" },
                    { new Guid("69e735a5-1326-4932-acf0-331b42e0d58e"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "9797c970-7274-490d-8214-ad52dcabfbfd", "B18099240@student.ctu.edu.vn", true, "Thái Trúc", false, null, "B18099240@STUDENT.CTU.EDU.VN", "B18099240", "AQAAAAEAACcQAAAAEM7hLxLbR5G8zqSrDjdw+l1pbhMRvdCofzghLzg+d8WM4NL8x6M/YITcSaczzo+fdw==", "0981774461240", true, "e3c68670-f859-4d7c-bff1-64cdb9966bc2", false, "B18099240" },
                    { new Guid("cb17cf1a-6b63-4585-a8b5-d02f80d2fe4a"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "5821af83-b1fe-4e90-853c-f54b784ccc69", "B18099239@student.ctu.edu.vn", true, "Nguyễn Khánh", false, null, "B18099239@STUDENT.CTU.EDU.VN", "B18099239", "AQAAAAEAACcQAAAAEBRAUyAoN3szKRcK2dou7qaxpY8Ukl3v4DHIb6SQ2XNV0oJ10M6eoMlvzE7xFl/MNA==", "0981774461239", true, "357c1acf-8dfb-46c1-84d7-e62df2d590d3", false, "B18099239" },
                    { new Guid("ed80b63f-3476-4ecb-8b72-90c81251d3be"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ef3fc7d4-5869-4f45-99ab-fd33ca52986a", "B18099238@student.ctu.edu.vn", true, "Lê Văn Toàn", false, null, "B18099238@STUDENT.CTU.EDU.VN", "B18099238", "AQAAAAEAACcQAAAAEMjtI7PbWpumoNAK/Ce03bj1EQvoNTRLMPAbnWzdEVrKL5RndZtJuYgMk6/YXgP1bw==", "0981774461238", true, "b9f6f555-9d4f-4cf9-be44-e87d949b3527", false, "B18099238" },
                    { new Guid("920ba2d9-efae-4528-ba2b-b28e9c0c362c"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "7f294cfe-c575-4393-90ef-f9e247a8316c", "B18099237@student.ctu.edu.vn", true, "Nguyễn Thịnh", false, null, "B18099237@STUDENT.CTU.EDU.VN", "B18099237", "AQAAAAEAACcQAAAAEF+BFIQrkxzzzDltC5wnpgzD+rHFkJZPIMCMKzHc5iwBRUp36LY8xUpTedMCNY30Og==", "0981774461237", true, "ce69fc0e-d4ad-44e0-908f-f01d82ec40cc", false, "B18099237" },
                    { new Guid("290053b1-5997-4822-9dc4-8e318761d6aa"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "937ac6ef-baf1-4f5a-9be4-5d55209c0ad4", "B18099236@student.ctu.edu.vn", true, "Lê Trúc", false, null, "B18099236@STUDENT.CTU.EDU.VN", "B18099236", "AQAAAAEAACcQAAAAEK4jHms9KUEBHI2/dDGTKqlguAUdS1AMpthlNknSAHcDj83SpbxJPTMlEndZtBUPqg==", "0981774461236", true, "1eecaa67-6ab6-47d5-9603-5d92e2570222", false, "B18099236" },
                    { new Guid("90022be0-2de5-4ea3-afc7-9d93d2fe56c0"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "4a0f94d9-914a-48ec-a0e7-7eba6ab9d441", "B18099235@student.ctu.edu.vn", true, "Trần Văn Nhẫn", false, null, "B18099235@STUDENT.CTU.EDU.VN", "B18099235", "AQAAAAEAACcQAAAAEPtrNqWWjei8MKsH5vNlAN1eaROODSKi0B+270AyXHxqqbOYZREzeQl9iXtjKMbgKw==", "0981774461235", true, "1b90f374-9b26-4698-840e-5153e71bf774", false, "B18099235" },
                    { new Guid("b7b8e098-07c8-4f93-a4da-216f21c92980"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "f092b21f-e352-4b75-bb4f-c5ecee3e40d7", "B18099234@student.ctu.edu.vn", true, "Trần Văn Nhựt", false, null, "B18099234@STUDENT.CTU.EDU.VN", "B18099234", "AQAAAAEAACcQAAAAEHd/P4XLf/xnYV1/Y84FanuBY9iP2HZ4apexzMKXDVinOYgCy0E4FIXJUX32nH3jAw==", "0981774461234", true, "2844d8aa-94dd-4af9-b226-6432a6cb0eb0", false, "B18099234" },
                    { new Guid("eb2ad632-a9df-4617-a0af-24b1cbecaf7a"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "3c082cce-031f-438d-88e5-99c6799cb774", "B18099233@student.ctu.edu.vn", true, "Trần Văn Thịnh", false, null, "B18099233@STUDENT.CTU.EDU.VN", "B18099233", "AQAAAAEAACcQAAAAEKgP6UsCHYnFxqToJXGPQIoF+R/naf2r1kqq6cJtmeex0Own9OuFeTb+dMaCk7nzhQ==", "0981774461233", true, "7be2ade3-9c4d-4aa6-be33-8e63de71f2bf", false, "B18099233" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avatar", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("2efca73d-089c-433a-a62d-3eb8fe224980"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "12baed25-d7d6-420b-b9c9-b9ce9a1803b2", "B18099232@student.ctu.edu.vn", true, "Nguyễn Khánh", false, null, "B18099232@STUDENT.CTU.EDU.VN", "B18099232", "AQAAAAEAACcQAAAAEMuaBT8boUHnmiHKPPq7tRzYfy2YdqwA9vEAdVtMH841B6vqr08+TDEzRSz693ozrw==", "0981774461232", true, "1ebc33b9-ea8b-40ae-9cea-4c4a5d2e8d2f", false, "B18099232" },
                    { new Guid("15c42bb2-37a3-49f9-859f-119ca3b42c20"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "1128bdc8-af50-4b5c-a5b6-d0f48d74aea2", "B18099231@student.ctu.edu.vn", true, "Trần Toàn", false, null, "B18099231@STUDENT.CTU.EDU.VN", "B18099231", "AQAAAAEAACcQAAAAEC61OBwxesb3MF2mrAPjNozkXqdlR0fix+E2s0hESUOTGZbMzc4Xppb8qqgzLQ9z1Q==", "0981774461231", true, "08d8b2ad-ce81-4e3a-a6e6-57a7b3d0de78", false, "B18099231" },
                    { new Guid("b5fe3cd8-1256-463f-9062-e26d905f640d"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "4f8029ae-f4f2-470a-8ab2-9842c14c17ae", "B18099230@student.ctu.edu.vn", true, "Phạm Thị Khánh", false, null, "B18099230@STUDENT.CTU.EDU.VN", "B18099230", "AQAAAAEAACcQAAAAEKhhku+tLvYxzAxPWMRlSVtIWhazKqYnpI/tLdRkXOcHUH4dhPIv4ILLE15hU6cZfQ==", "0981774461230", true, "23e71693-2330-48d5-afa4-5ac2af0be756", false, "B18099230" },
                    { new Guid("1074b04d-e70a-4e15-b789-a210b8fc64d6"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "277e381e-1df1-450d-b640-146a9538be1e", "B18099229@student.ctu.edu.vn", true, "Thái Vy", false, null, "B18099229@STUDENT.CTU.EDU.VN", "B18099229", "AQAAAAEAACcQAAAAEEX7PB9a/ZRqmrNu4KI9cZZxs3xF2p4vo8616GBN2nYSz5lKhab9VU7iqJ0jittg+g==", "0981774461229", true, "7bdb4646-e045-4e7c-aedb-346472559ef7", false, "B18099229" },
                    { new Guid("a1cc5915-f635-4813-a91f-2998de193566"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "6d68b32c-b445-4acd-b6e9-6f12630fd71a", "B18099228@student.ctu.edu.vn", true, "Phạm Thị Lâm", false, null, "B18099228@STUDENT.CTU.EDU.VN", "B18099228", "AQAAAAEAACcQAAAAEMxZ7AnrNKNUynb70pNFRCJ2TVSzZz+H0ni10TzNR3GLS++b68xxuG2yPJca1V94eQ==", "0981774461228", true, "75adbba8-9ed9-41f4-95df-2fe2f4a4bcea", false, "B18099228" },
                    { new Guid("717e7689-05f3-4c31-a82a-174ae6453cc6"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "fc9455c1-3668-4154-9e20-632607d0c2b0", "B18099227@student.ctu.edu.vn", true, "Nguyễn Vy", false, null, "B18099227@STUDENT.CTU.EDU.VN", "B18099227", "AQAAAAEAACcQAAAAEGmUgA73w6+HxYIdq3H+h/88FOAJDAdrdOEbTPlyNgTeIZH8oKVgds0ldG6flbegKw==", "0981774461227", true, "0de66383-10eb-4843-89e9-cf62796cd14e", false, "B18099227" },
                    { new Guid("2af57213-22fa-4fcc-9c18-fa424d54371f"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "a5ebe826-6e8f-43a0-90f5-bb2ba4991f5e", "B18099242@student.ctu.edu.vn", true, "Thái Lộc", false, null, "B18099242@STUDENT.CTU.EDU.VN", "B18099242", "AQAAAAEAACcQAAAAECC69ScuGwWIMQAfc00lnVH1eFNROVyTUKRRvzdxF2koW6wdhhRPbZGGl5fzZk93jQ==", "0981774461242", true, "925eca3b-40f1-4b91-babd-dbdb59657211", false, "B18099242" },
                    { new Guid("25c59a1f-d9d0-4f6c-a391-3467bd68b36a"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "cecff2b7-5524-4567-b347-202d071580ac", "B18099243@student.ctu.edu.vn", true, "Trương Văn Nghĩa", false, null, "B18099243@STUDENT.CTU.EDU.VN", "B18099243", "AQAAAAEAACcQAAAAEFya8yKm6F3U+b6Th0tC7bSkisw4hnkmPYQrvZ9gEqJGfajaZskeh5DCyuPLYFBHbQ==", "0981774461243", true, "85e73331-616d-45bd-9733-c5e7ddae42ac", false, "B18099243" },
                    { new Guid("0c3ebc2a-cfde-4471-919c-d56c61db0473"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ab9b10c9-666d-4a3e-93d9-e481ebfe52fd", "B18099244@student.ctu.edu.vn", true, "Lê Văn Nghĩa", false, null, "B18099244@STUDENT.CTU.EDU.VN", "B18099244", "AQAAAAEAACcQAAAAENvfauiuJsUtpFkM4Xs4Oy0VjUvE84ZJ8BfV/NS/GngyPB+P3qEbMW9Ucbx6KDCKmA==", "0981774461244", true, "e639a56a-ed7a-44e2-8f54-e48809184b13", false, "B18099244" },
                    { new Guid("30fdfbac-9093-4fa1-8404-a4d5e30b3b47"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "e21aae1d-a58e-401e-9590-5b713421ff38", "B18099245@student.ctu.edu.vn", true, "Trần Khánh", false, null, "B18099245@STUDENT.CTU.EDU.VN", "B18099245", "AQAAAAEAACcQAAAAEM0uSzA3MEw4oMahnWFHD/PjkfcEtWrNfBDyFiqajTBpkdX+6emZCtl+Nrco9kifBA==", "0981774461245", true, "8c95471f-7c74-44e7-86ef-85b125c35949", false, "B18099245" },
                    { new Guid("ed67b0c8-b211-48f8-ae85-34564f4629f8"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "91d37c3b-5132-4c48-a4e6-e446aa818ebe", "B18099261@student.ctu.edu.vn", true, "Trương Văn Khánh", false, null, "B18099261@STUDENT.CTU.EDU.VN", "B18099261", "AQAAAAEAACcQAAAAEHza6PyW30tUoGwicHjybOT9Lv9TRsY4GksdAbfS5CJH0DLK9UY6nGTrX/UI0OIzYQ==", "0981774461261", true, "44e80e0e-3bc6-419c-b466-6dd7e6507111", false, "B18099261" },
                    { new Guid("1ea0c3c4-900e-40d9-99d2-2eb8f240a744"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "3009e4ad-a264-47e0-a762-17c257e1ee46", "B18099260@student.ctu.edu.vn", true, "Lê Văn Nhẫn", false, null, "B18099260@STUDENT.CTU.EDU.VN", "B18099260", "AQAAAAEAACcQAAAAEFl4I2x8biCvay+qSAKp/BdJB7CwZ59OZ+2uJ0sMCah9xNb3SyHWFi+uCuLCQ+aXxg==", "0981774461260", true, "ae011e95-36ef-4fbb-b216-84ea66602cc6", false, "B18099260" },
                    { new Guid("aae82d33-8d1b-4634-90a2-169e74800e2e"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "f23a55f4-4d1c-4698-8c1f-885b92571f0c", "B18099259@student.ctu.edu.vn", true, "Lê Thịnh", false, null, "B18099259@STUDENT.CTU.EDU.VN", "B18099259", "AQAAAAEAACcQAAAAELBAqRhQTTowNEmw+PPqIyMA9a7TYEhRU/XLTU0HeH9g/5G1QyClDmYkqtEcGAhCKw==", "0981774461259", true, "615aaf57-bd77-49de-8f43-16b65a690963", false, "B18099259" },
                    { new Guid("8005ba7b-d4b8-4706-86bd-618758b211c0"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "b249c7a3-7f9b-49b6-9518-f730abdf81ab", "B18099258@student.ctu.edu.vn", true, "Nguyễn Hoàng Lộc", false, null, "B18099258@STUDENT.CTU.EDU.VN", "B18099258", "AQAAAAEAACcQAAAAECgPin5/8C/tIm02YYwxRwDal3enE5sdhK0dwfyPk7vYQZgS/9hXEs33RKr63NOCow==", "0981774461258", true, "cd0484c7-182a-4096-a392-6918fce20785", false, "B18099258" },
                    { new Guid("23343a5b-3e9c-42ba-8d98-bf4413ffb0d1"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "a3d23331-d364-4bd5-96db-c7dd56145207", "B18099257@student.ctu.edu.vn", true, "Nguyễn Vy", false, null, "B18099257@STUDENT.CTU.EDU.VN", "B18099257", "AQAAAAEAACcQAAAAEGyKdNwqu0xyK1UArJW2RumWbI5J8FKMPa+K2AjTt45PffXEyRkTJKLWF6Xn/WlHQw==", "0981774461257", true, "c442354d-2886-4cf4-b549-321547940ff9", false, "B18099257" },
                    { new Guid("d2ab768b-d650-4b06-a57d-2d7d0bc63813"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "09e1b2da-3989-4e13-838b-89a14c550a5a", "B18099256@student.ctu.edu.vn", true, "Nguyễn Hảo", false, null, "B18099256@STUDENT.CTU.EDU.VN", "B18099256", "AQAAAAEAACcQAAAAELvpBtOshdEF7oJi8o9wJnWKAXNMpbYrUWkxCt0mICHqQ+NakpxV6iTgndlXviQgSg==", "0981774461256", true, "6aad3d66-a776-41f7-9a01-28ab2594289b", false, "B18099256" },
                    { new Guid("129126ed-fc1f-4217-aa40-eefc4c8652d0"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "6bf02957-04f1-4bc6-952f-ae83ce143473", "B18099255@student.ctu.edu.vn", true, "Lê Văn Khánh", false, null, "B18099255@STUDENT.CTU.EDU.VN", "B18099255", "AQAAAAEAACcQAAAAEJ/GUZ++CWVrdRlhAJbWmsmKVS3qs4LoChSKYLREjxiqwbKKvQCFXd+oBi/9oWYw9A==", "0981774461255", true, "82851360-09c0-4928-9ca2-7f0f5e38bdab", false, "B18099255" },
                    { new Guid("e6316e92-49ce-45df-b25c-2b6a9792f261"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "f92dbbc5-1979-41f5-8221-e5c7e923b90e", "B18099225@student.ctu.edu.vn", true, "Đỗ Lộc", false, null, "B18099225@STUDENT.CTU.EDU.VN", "B18099225", "AQAAAAEAACcQAAAAEELvKNrjgR6/BLfi2MJF+fmQnOPsaeujP0p5ly3cICSCrw1lpb81tcQ2STeo3Tpzyw==", "0981774461225", true, "b2ae6c41-60af-4dc7-83a6-a4b092e33446", false, "B18099225" },
                    { new Guid("0fa1e14d-4011-40af-b3db-d6dd90089a01"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "0381ba43-3c53-4fc4-9b69-e6f76e3c2d95", "B18099254@student.ctu.edu.vn", true, "Lê Nhẫn", false, null, "B18099254@STUDENT.CTU.EDU.VN", "B18099254", "AQAAAAEAACcQAAAAEILSmodMLYy1rSIJXm1pWklu+EM3kNu0c2IKLXrcAJpk/7sSXaZMonScEYYg+wpjTw==", "0981774461254", true, "e39b2b1e-382e-405d-b6f8-2286d1cb0965", false, "B18099254" },
                    { new Guid("d89edb22-9f86-4a86-91cc-953fe5dc1612"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "51659191-2fc7-4858-9072-695c9ccac569", "B18099252@student.ctu.edu.vn", true, "Phạm Thị Hảo", false, null, "B18099252@STUDENT.CTU.EDU.VN", "B18099252", "AQAAAAEAACcQAAAAEDeyb26I2coTsQT1g+ZeF1css7TEqgPZTDyQSkRG5VHlGULAUO0zfMZvq2wbtNggGQ==", "0981774461252", true, "4ef2eb27-cff5-4d3d-9042-3a55a75cca92", false, "B18099252" },
                    { new Guid("27f47fff-2190-418e-a5ea-8ea5878af3ae"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "d7208830-3598-4b53-9fb9-242979af9d1c", "B18099251@student.ctu.edu.vn", true, "Trương Văn Khánh", false, null, "B18099251@STUDENT.CTU.EDU.VN", "B18099251", "AQAAAAEAACcQAAAAEFaD58UYOtde1nq4CjUMKOqi3QExAlrIMaogw4CqX61PP+F8q3ILj1+NChwIj+zTsw==", "0981774461251", true, "1451124c-8c25-4e5a-9f80-435affba0b5a", false, "B18099251" },
                    { new Guid("2307dd86-70b5-42d4-848d-d8a9f619236c"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "7e753f11-1a79-4240-8e2a-87f7b0a177fe", "B18099250@student.ctu.edu.vn", true, "Nguyễn Văn Nhựt", false, null, "B18099250@STUDENT.CTU.EDU.VN", "B18099250", "AQAAAAEAACcQAAAAEHNoR7QDFnqcXfuhOLcLqbR2z/b+GruBilbh84LxBRjsHl1fyosgC+ZFjqzO3KwxuA==", "0981774461250", true, "616b85a8-f668-4161-9b2d-6bd49a56e556", false, "B18099250" },
                    { new Guid("30b25c79-dbc5-41f6-8934-69f4f71b3598"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "a78c90dd-e7df-4362-bbfb-ebe142377531", "B18099249@student.ctu.edu.vn", true, "Thái Trung", false, null, "B18099249@STUDENT.CTU.EDU.VN", "B18099249", "AQAAAAEAACcQAAAAEBH6JkHSCikrS/+D5ynnNdcLWnokvLYsfhb1fEPSV9BGG+raNvvxOEmfY+ZMWPO9Jw==", "0981774461249", true, "6ea8c8cc-cd3b-4016-89a5-67a186dc9768", false, "B18099249" },
                    { new Guid("d9b7128e-5c58-499a-9843-c527a16745c5"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "26fa48f2-5649-4e63-a060-951daecb34a1", "B18099248@student.ctu.edu.vn", true, "Lê Văn Lâm", false, null, "B18099248@STUDENT.CTU.EDU.VN", "B18099248", "AQAAAAEAACcQAAAAEFISCsr3yHF+Tyw9Zz/VTPAPkxWtfTdiITDNtllB3DJnOWH6S54lcK5V+xRvB/CQqA==", "0981774461248", true, "36a68046-d4bb-444f-b057-33e9ed768b86", false, "B18099248" },
                    { new Guid("23fa2d22-5c26-42bd-991b-82ef19a66060"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ec594f46-c5e3-4d6a-9d6f-5c39a01cc3b7", "B18099247@student.ctu.edu.vn", true, "Nguyễn Văn Trung", false, null, "B18099247@STUDENT.CTU.EDU.VN", "B18099247", "AQAAAAEAACcQAAAAEJnnRwez7A1fCCoCSvqwAkmpQnhy1d/dbklLt/YVMyBFWSe6bNcwVEANLsAlS3rQsA==", "0981774461247", true, "905c7186-28a9-46de-bba2-d386fd133f24", false, "B18099247" },
                    { new Guid("8a80c189-c866-4a48-b887-cd772d106aa0"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "0bc0be85-cd3d-4951-b544-260fd686e4ff", "B18099246@student.ctu.edu.vn", true, "Trương Văn Nhựt", false, null, "B18099246@STUDENT.CTU.EDU.VN", "B18099246", "AQAAAAEAACcQAAAAEG/UidLIKvTjZQ1phwby4MEfzyftV4s03bwkbFohnpAvTZGZeviP+RcWv1DFJFq2Jg==", "0981774461246", true, "383206e8-3ba8-4607-af14-bdf3701d35c5", false, "B18099246" },
                    { new Guid("95bea5b6-a046-41db-ac2c-e1139a592332"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "041beb80-a2d4-4ba0-9556-3542f0786c3a", "B18099253@student.ctu.edu.vn", true, "Lê Văn Trúc", false, null, "B18099253@STUDENT.CTU.EDU.VN", "B18099253", "AQAAAAEAACcQAAAAEB9XF84ESegnFgo3E6Q3Q0RN6YsDLIaeHq71MBh2X3kzJvRnZsoppu9FXS2pf3ALSA==", "0981774461253", true, "687eaeb8-da6c-44de-9d3d-d18c4227c064", false, "B18099253" },
                    { new Guid("4683d299-85ee-4b6b-a4ad-bb1ab2ee0d91"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "3e66aac3-eda3-4d53-ba80-43f626ca9bf5", "B18099148@student.ctu.edu.vn", true, "Lê Văn Nghĩa", false, null, "B18099148@STUDENT.CTU.EDU.VN", "B18099148", "AQAAAAEAACcQAAAAEM2eAGPT20ybWVQ5WiDQdDH5Vtyijniz4Gw/tMRrBveh8Xk42OnYAcNgw2dNaWDo/w==", "0981774461148", true, "84063dd8-dd93-4d99-9df2-b667de33b0f6", false, "B18099148" },
                    { new Guid("c86a5fb6-07df-4994-8f29-028964372568"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "b8294ece-2c4d-4e27-a11c-0557ee7df927", "B18099165@student.ctu.edu.vn", true, "Trần Văn Nhẫn", false, null, "B18099165@STUDENT.CTU.EDU.VN", "B18099165", "AQAAAAEAACcQAAAAEOAVED/D2wZVqh5BkctDZSDtM/dknke3A59JsbDL8MiBcEPpD0ybL/DAoRQjSheG3g==", "0981774461165", true, "43c561ec-4eeb-41a2-8b94-0728e6ae24b8", false, "B18099165" },
                    { new Guid("a1b8fe37-e767-4a4b-8172-7cf8605393a8"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "f7cc46c4-3631-40e6-95f7-2c125cba9968", "B18099146@student.ctu.edu.vn", true, "Lê Văn Nhẫn", false, null, "B18099146@STUDENT.CTU.EDU.VN", "B18099146", "AQAAAAEAACcQAAAAECyXoqGhbKjU93rfNzNovDrYjjThCtlDt/hLvnVKU/x1MPhapkQ8NXlCN/Mvg8zFMA==", "0981774461146", true, "f7b62657-7d21-4719-b05d-507c7442e1d0", false, "B18099146" },
                    { new Guid("4d2b4f64-2d07-4d55-b46e-eb4a54774e70"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "7fb67a1d-aaad-4b89-a70d-3cdd01b12ed5", "B1809950@student.ctu.edu.vn", true, "Nguyễn Trúc", false, null, "B1809950@STUDENT.CTU.EDU.VN", "B1809950", "AQAAAAEAACcQAAAAEHnn6XUPxpSvdvH4ci98h3eZnaCPYrk8iAYpVghDH+pJIpbwG0LLpkSg1mOzNggqFA==", "098177446150", true, "926aa790-80ea-45f5-a5bc-7c8c6a320770", false, "B1809950" },
                    { new Guid("c1dc4885-f7eb-4b8d-930f-7344db72b5f7"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "2adac114-4fbd-48ee-aa6e-f74fb4a59819", "B1809949@student.ctu.edu.vn", true, "Nguyễn Văn Nghĩa", false, null, "B1809949@STUDENT.CTU.EDU.VN", "B1809949", "AQAAAAEAACcQAAAAEJuIamm/TnCdvfQkOp9by0Dzhte1D1jbdDyvb0BBWNdhcolXha1QbPs9B6iCi9lHFg==", "098177446149", true, "ee54ace6-7b30-4042-95d2-b97d03297f32", false, "B1809949" },
                    { new Guid("f3205131-ae39-4762-a936-f8cfed27d96b"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "0981679a-f6dd-4cfb-be10-3d9ce0bc6b27", "B1809948@student.ctu.edu.vn", true, "Lê Văn Toàn", false, null, "B1809948@STUDENT.CTU.EDU.VN", "B1809948", "AQAAAAEAACcQAAAAELxWnrRb65TeUxHzweD5VGPbf21BpL4AJXUIozKKhLVsRn+Kd131N8lcH7IXP/ZpvQ==", "098177446148", true, "9637b394-455a-4b60-a957-d50ee6999bbe", false, "B1809948" },
                    { new Guid("ec7919a8-a3c2-470d-bf29-e5c186a4ac14"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "c98bf4f2-b9f5-4abc-adf0-648171c0f46c", "B1809947@student.ctu.edu.vn", true, "Lê Khánh", false, null, "B1809947@STUDENT.CTU.EDU.VN", "B1809947", "AQAAAAEAACcQAAAAEKl72+YqlL0Gmv616pYaRoQ3rI4YnRPytjvEf3tNURinVjea6AZwamhSJwDEoS98WA==", "098177446147", true, "2ee26251-c621-42ab-907c-f795ce53dcc5", false, "B1809947" },
                    { new Guid("480bd134-5225-4e70-958d-bd7e5824fea7"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "d2e68b91-333d-4a63-9be6-689400d85676", "B1809946@student.ctu.edu.vn", true, "Trần Nhựt", false, null, "B1809946@STUDENT.CTU.EDU.VN", "B1809946", "AQAAAAEAACcQAAAAEEf/smzc9GaUihTCiq0QHHzZAVVYANtpCyRC6F7dKFXVJjpsnT/apGKggB+SX7SnVQ==", "098177446146", true, "44575c89-d6c0-4b51-a3bf-a994b159606b", false, "B1809946" },
                    { new Guid("3abcd768-4197-4229-8273-befb3436932c"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "3a8b1a46-4e94-4c29-a0e4-8952ea189c19", "B1809945@student.ctu.edu.vn", true, "Trần Văn Nhựt", false, null, "B1809945@STUDENT.CTU.EDU.VN", "B1809945", "AQAAAAEAACcQAAAAEAy6AUPN3VLw7CVhuYhcRBEW4pdIbDqn2Nl1fiZlyJeREqUisnS8/+79d4jjLSOWXg==", "098177446145", true, "cea29f9b-7676-4548-bf16-2818ed1563fd", false, "B1809945" },
                    { new Guid("43f0f2dc-ed06-488e-b8ff-33e5fedce4b8"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "b25f35a2-c36b-4d77-8a75-3e3d4ef86e75", "B1809944@student.ctu.edu.vn", true, "Phạm Thị Khánh", false, null, "B1809944@STUDENT.CTU.EDU.VN", "B1809944", "AQAAAAEAACcQAAAAEOSoIm6ACck34+dtdjUQ7iNt3nPrbZq3oCfiiEaQhhglDVJwW5y+w4LgVDpeVz64uQ==", "098177446144", true, "693046ba-4454-48a7-b8af-e11e57f732a7", false, "B1809944" },
                    { new Guid("aa14e86a-6f2c-4200-850c-7dd7360a08c9"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "530a5109-dc1e-4398-808a-93e63846611d", "B1809943@student.ctu.edu.vn", true, "Lê Thịnh", false, null, "B1809943@STUDENT.CTU.EDU.VN", "B1809943", "AQAAAAEAACcQAAAAENg2hYK7tE4fQdvskS+E7nSUp1GqiS98Gj24nH26H+cWXJgY5daRuDdYudvCnfFIJw==", "098177446143", true, "d8352e50-299a-4ebe-aa1c-2a3cd1bcc72b", false, "B1809943" },
                    { new Guid("429f7cdd-fa29-4112-b667-7479b8f2aa15"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ec8f5cb9-c248-4d0c-bfaa-58cc12a09e51", "B1809942@student.ctu.edu.vn", true, "Nguyễn Hoàng Hảo", false, null, "B1809942@STUDENT.CTU.EDU.VN", "B1809942", "AQAAAAEAACcQAAAAENbk4qtWMFfkuRi3eE0WbMJ19fOFcx34O8Qe5tE09uHzUpQ5yWXd164zp5sMfQL0mg==", "098177446142", true, "5219c757-0eaa-47f1-a2b5-540ec0f79b3e", false, "B1809942" },
                    { new Guid("80f66855-695e-42bd-86df-adfcc096a6fa"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "93fb936b-3019-47db-be0f-7178343014bc", "B1809941@student.ctu.edu.vn", true, "Thái Vy", false, null, "B1809941@STUDENT.CTU.EDU.VN", "B1809941", "AQAAAAEAACcQAAAAEFL2Bvvik3fIVGP4CD8JegXFgKI+C1Pgl3ewZhzj3hLi1g7h/Y0ToW+INk9jE3LGOA==", "098177446141", true, "18f230ca-6ffd-4b2c-96de-7ab8468cdaab", false, "B1809941" },
                    { new Guid("8a966b22-74b4-4fdf-b587-4d9f7365e7e9"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "f2391eed-9b96-4486-8d34-384f7e47a346", "B1809940@student.ctu.edu.vn", true, "Nguyễn Hoàng Nghĩa", false, null, "B1809940@STUDENT.CTU.EDU.VN", "B1809940", "AQAAAAEAACcQAAAAEFGz0d3IEI7xgjbc74uBCKfipqGooQ2n0dHSs1OGx9fk0FHsUsHQmsYm8YX29dJguA==", "098177446140", true, "73d0c854-291e-48c9-9b93-b603a4bb284b", false, "B1809940" },
                    { new Guid("95d89305-f31b-4c24-bd30-eda39134f9cd"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ef190b20-ad28-4372-a73f-8942fd6ad2ad", "B1809939@student.ctu.edu.vn", true, "Thái Nghĩa", false, null, "B1809939@STUDENT.CTU.EDU.VN", "B1809939", "AQAAAAEAACcQAAAAECcBQ93Ey7WEMOR8Xx6bdDRIJd1MmGLtdWbZKjYIr2emq0sEVo7nInMMyczQtg//tA==", "098177446139", true, "2c5fd951-7441-40ee-950b-5f0e8b0dfed2", false, "B1809939" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avatar", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("e9a35a9e-b65b-406d-af8c-69d1fc2184f3"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "c620bdfe-022f-4d83-8efb-79296de257ee", "B1809938@student.ctu.edu.vn", true, "Lê Văn Khánh", false, null, "B1809938@STUDENT.CTU.EDU.VN", "B1809938", "AQAAAAEAACcQAAAAEBvWV4IEUFtLqjRpheuZ905Wsl54qXYTY8FX51QfXfUCKCG3M6O+ghO9IrBwqUFSLQ==", "098177446138", true, "947bed6f-ca92-4125-ad48-e690e11f4fb0", false, "B1809938" },
                    { new Guid("3fd80720-04a1-4c86-954e-41377a8a2f4e"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "c0f77d77-d1c1-4a38-9caa-50f6a3b5a016", "B1809937@student.ctu.edu.vn", true, "Phạm Thị Vy", false, null, "B1809937@STUDENT.CTU.EDU.VN", "B1809937", "AQAAAAEAACcQAAAAEEFmmeyEDHGp0MkQ8vSluB6v+UBbp3+OPdEsgkC3Vi5doFWjIp0U63hvPMpJbLC4og==", "098177446137", true, "6959a641-76a9-4a5f-88df-0fe765355e79", false, "B1809937" },
                    { new Guid("118893c0-ddbf-40f2-8a14-9d432dd1b22e"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "c3c29c54-bdb5-4d3b-90d5-33e1a33cb57a", "B1809936@student.ctu.edu.vn", true, "Nguyễn Nghĩa", false, null, "B1809936@STUDENT.CTU.EDU.VN", "B1809936", "AQAAAAEAACcQAAAAEInVf5XLOqvfmmCzFsAE02QDdaFX/edmIv/lsMebRYiIKw25g+rYdunkWMzQaSQubg==", "098177446136", true, "eca08e4d-23ee-4389-a828-4be367f70bfe", false, "B1809936" },
                    { new Guid("3d44ceab-8216-47bf-90c1-b1ac5607ebc4"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "1536cbe8-9382-415a-ac39-ad5217d0f777", "B1809951@student.ctu.edu.vn", true, "Phạm Thị Lộc", false, null, "B1809951@STUDENT.CTU.EDU.VN", "B1809951", "AQAAAAEAACcQAAAAEItI+BQ6509rLsm6xE//da4g/GVAOXlxRJXcaK2bo2bSP2UrzG6OpsJhLirSirGhag==", "098177446151", true, "ed7ae504-7882-4f43-ad8b-6e5485bd0816", false, "B1809951" },
                    { new Guid("faee1ffe-8a33-4b18-8088-b8c285c2119b"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ad797202-a531-486c-b879-a16a2217a5da", "B1809935@student.ctu.edu.vn", true, "Nguyễn Văn Nghĩa", false, null, "B1809935@STUDENT.CTU.EDU.VN", "B1809935", "AQAAAAEAACcQAAAAEIx/E3fXhnzvhv1WNkzthrbHVd5hUZx6G9BZikK9OzIVvuzRhgFBuntq0F8UbnbWHA==", "098177446135", true, "d0f86dee-fab6-46dd-8f3f-56c50bbb1e3b", false, "B1809935" },
                    { new Guid("abc87ddc-4d6f-4bab-8673-1b72f6ecec91"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "be2f9a86-82f3-4825-9d4e-bc381452fe91", "B1809952@student.ctu.edu.vn", true, "Phạm Thị Toàn", false, null, "B1809952@STUDENT.CTU.EDU.VN", "B1809952", "AQAAAAEAACcQAAAAEDeXTFkM/l9pnp4dCEqfQfBz2Wzq5nrdXcew4aIIjMWzD/T6M8N8DXLJG2fJ1V9AdQ==", "098177446152", true, "aaa823ea-28a1-4fcd-9154-cd3cb50f23c9", false, "B1809952" },
                    { new Guid("e7ce9ae0-5879-48d2-a52c-e933b77f1f1a"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "1eb19efe-dad3-4478-ba50-58fd1a5acd6b", "B18099147@student.ctu.edu.vn", true, "Thái Toàn", false, null, "B18099147@STUDENT.CTU.EDU.VN", "B18099147", "AQAAAAEAACcQAAAAEMC/7h6J+triP8mUrkCx2+7pJFDi/vaw+3a0FI19y3CCIuPfuEIJEsNZDL3RRHvRyQ==", "0981774461147", true, "1acb1a1e-2bbd-4253-acea-ab1e03b5fdb4", false, "B18099147" },
                    { new Guid("4f267353-b003-4b0c-90ff-d20f881da99a"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "8e657961-5df8-4043-906c-fb76ba127a38", "B1809969@student.ctu.edu.vn", true, "Trần Thịnh", false, null, "B1809969@STUDENT.CTU.EDU.VN", "B1809969", "AQAAAAEAACcQAAAAEDQx9FK9JWDEw1sD6fFsKvyaiFZH4PsM5qNzO4gkr+eGeHHexcqMZfA2comNsjay0Q==", "098177446169", true, "da437226-3e79-441f-bfac-74abe0cde696", false, "B1809969" },
                    { new Guid("bb8fad11-9838-42f7-97b0-99e56ff1dced"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "c5d5eb6d-2292-48b9-ade3-aa535f8f3fc8", "B1809968@student.ctu.edu.vn", true, "Thái Toàn", false, null, "B1809968@STUDENT.CTU.EDU.VN", "B1809968", "AQAAAAEAACcQAAAAEN4AYfpRzcMiz6IHwuIFGwPtcuJbVZ0AoE3SSW8wDAHf8roYCXcsZtB6u6VlWQKA4w==", "098177446168", true, "6b3492c8-f926-4fd6-855d-7b975435111b", false, "B1809968" },
                    { new Guid("fe4c6c23-0cfc-4b25-aeb0-d4c160c48306"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "bbee6ae1-f3fb-4d34-a8f1-ca2bf5bdc121", "B1809967@student.ctu.edu.vn", true, "Phạm Thị Thịnh", false, null, "B1809967@STUDENT.CTU.EDU.VN", "B1809967", "AQAAAAEAACcQAAAAEGXNH6EiTzRpcH0/no2I4YD1oqb9DrwkanzSENQeX5Kl1pVJWULa+Bx0SA91r0paYg==", "098177446167", true, "7d0e79d8-245f-4f80-9e15-70b032564c1f", false, "B1809967" },
                    { new Guid("86596b57-de69-4576-a2f0-f6896bea0601"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "442a3470-6692-4f2f-b727-683fd5480f6c", "B1809966@student.ctu.edu.vn", true, "Nguyễn Văn Khánh", false, null, "B1809966@STUDENT.CTU.EDU.VN", "B1809966", "AQAAAAEAACcQAAAAEJFas0RGEK6s4/9FsHOsZBemVLzLxt+WBGpctyj31xYpUFi/mwF5AAxXc6uFM2vvqg==", "098177446166", true, "1478a889-da82-49af-8757-8f545156a774", false, "B1809966" },
                    { new Guid("882dc940-9666-4e52-82b1-83f4b2bb603f"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "d2668696-80a6-45e6-9cb4-5d2e6e4b9cb5", "B1809965@student.ctu.edu.vn", true, "Lê Văn Nhẫn", false, null, "B1809965@STUDENT.CTU.EDU.VN", "B1809965", "AQAAAAEAACcQAAAAEHjey+2cacgtybMWJSXd1K4nZefLP90hAwHN7cqSTwNwY1hTIOWSAgWd7lgzjoDuTg==", "098177446165", true, "87e75b3e-45c7-4b02-a691-c9ef4927b193", false, "B1809965" },
                    { new Guid("9a645d43-0bc2-4008-a790-1a6d3b996543"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "71fa6f7e-1371-445b-a345-aa197a40e39f", "B1809964@student.ctu.edu.vn", true, "Nguyễn Văn Nghĩa", false, null, "B1809964@STUDENT.CTU.EDU.VN", "B1809964", "AQAAAAEAACcQAAAAEHHAv4u35oXHtDzFQjo4HfBwKQ7wEey4TqhbdH5LFUePHRQElww8trUjv+8roTNeaw==", "098177446164", true, "7d758e1b-3c11-459b-a4fd-00a22f571e1e", false, "B1809964" },
                    { new Guid("528fde9f-b7e9-41a3-867a-a23bcf1c9b21"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "7c8b28d3-cb18-4e39-b976-8f1d048f5fb3", "B1809963@student.ctu.edu.vn", true, "Lê Văn Lâm", false, null, "B1809963@STUDENT.CTU.EDU.VN", "B1809963", "AQAAAAEAACcQAAAAEIFnylw5jzYeYu+8SbZBMobnspcv8wuCV61Ecvg6e89NO3dzxyd6p4SyfNAA4rCoNA==", "098177446163", true, "fd799305-c952-4bb5-b6f4-c8f57c0f25bd", false, "B1809963" },
                    { new Guid("257a18c5-d271-43f1-b209-730e310cffce"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "29b25480-d028-401e-9ada-54bc755a897b", "B1809962@student.ctu.edu.vn", true, "Nguyễn Thịnh", false, null, "B1809962@STUDENT.CTU.EDU.VN", "B1809962", "AQAAAAEAACcQAAAAEOF21BICznqmo/R0cqh+Gr+ULKnX66G5qFcCKWSOxnyO9MBk6gRAlZptCOHvrkq8oA==", "098177446162", true, "4aaf2e31-f33c-4d3c-833b-9bd583608f67", false, "B1809962" },
                    { new Guid("4aa94747-b592-4fea-a74d-df048dace220"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "05c6b0dc-a4e9-431e-aae0-071d0ed6404e", "B1809961@student.ctu.edu.vn", true, "Nguyễn Nhựt", false, null, "B1809961@STUDENT.CTU.EDU.VN", "B1809961", "AQAAAAEAACcQAAAAEKlEgHDEn6xQ8sAOXC1cZRNhml0YIWvWR/OED3/8AsTFU9JE6Zs4mJYIpPgBhNbJpw==", "098177446161", true, "ff1087be-f35b-44f2-985b-00de1484be28", false, "B1809961" },
                    { new Guid("25711150-b78e-4046-a858-1f526eae5443"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "5ab319d6-eeec-4bba-9bb1-68eef878d6d1", "B1809960@student.ctu.edu.vn", true, "Lê Văn Vy", false, null, "B1809960@STUDENT.CTU.EDU.VN", "B1809960", "AQAAAAEAACcQAAAAEPutnKmD9o32BmkgkoJQRUxVhau3fRhmNuIr0KYf+yY6H6gyO9eqSNp46yDJPMFxyA==", "098177446160", true, "d1ac081a-eef1-45ae-bd62-0a3385010b9a", false, "B1809960" },
                    { new Guid("e0ee13a6-a833-40a6-b8a4-a7a021ba3338"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "efefcd1e-5fa4-41d3-ad9a-a7dd4fb4f2f2", "B1809959@student.ctu.edu.vn", true, "Lê Hảo", false, null, "B1809959@STUDENT.CTU.EDU.VN", "B1809959", "AQAAAAEAACcQAAAAEFbwEUGHuqow0NN0qcB/fcJaSov/Qe0Bmdcg/u3Wp+rp5Q5+On+qoA9ivEv7+dmRkQ==", "098177446159", true, "143cc7e5-22a7-4d08-aa4c-aae89424afe0", false, "B1809959" },
                    { new Guid("2f930c21-4d2b-48e6-9410-493e7200a868"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "dbc3e846-d9a9-42b0-bafb-011bc91fe6dd", "B1809958@student.ctu.edu.vn", true, "Phạm Thị Nhẫn", false, null, "B1809958@STUDENT.CTU.EDU.VN", "B1809958", "AQAAAAEAACcQAAAAEIv6oAMvbeEf2fg4wyKRrrKFQ7+5gaLOmOgWcKA2HEFQlum0HC6Mh7uw1J1RCKxH6w==", "098177446158", true, "b9440de7-80b4-48b2-ab35-66131b6a9fe3", false, "B1809958" },
                    { new Guid("a0efc4f1-e304-4c3d-ac7c-8ea7912c3500"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "e12d98ef-15f7-425f-a3d9-38fcbbbc30cb", "B1809957@student.ctu.edu.vn", true, "Trần Văn Nghĩa", false, null, "B1809957@STUDENT.CTU.EDU.VN", "B1809957", "AQAAAAEAACcQAAAAEDVvTMOIy1/OQ2I+WNTpEaZG+r/W1NE+0ODcXoyvfgz//mVYwUY+z9CgPwAt1U40/g==", "098177446157", true, "0d0a6d6e-cc88-4670-9709-55cb53ea3123", false, "B1809957" },
                    { new Guid("bd1f6efa-1629-48fe-9ec9-9f03e81d6117"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ea185389-c3b6-42d3-8ba5-4b02eda6273a", "B1809956@student.ctu.edu.vn", true, "Trần Văn Khánh", false, null, "B1809956@STUDENT.CTU.EDU.VN", "B1809956", "AQAAAAEAACcQAAAAEKuqF4JKMzIaWZ9wqOo9qqnjZJvyQW0x/0Cs3/UmLpqMSP4igk1Qvo2DhCFIFKeHpw==", "098177446156", true, "a9e2bb30-0dd3-4797-ba59-80e45cd63a24", false, "B1809956" },
                    { new Guid("723fb475-8c5f-45a6-8049-b1a34ba36bf0"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "21b3e92e-1ec0-4f54-9b78-e8c54baaad99", "B1809955@student.ctu.edu.vn", true, "Phạm Thị Lộc", false, null, "B1809955@STUDENT.CTU.EDU.VN", "B1809955", "AQAAAAEAACcQAAAAEB1u2kvrpTL0POHlko9O6Z715Wf7Vl0PWHGFVy4DKzlgyHnqGoBpyDWpOvTJ6WIHtA==", "098177446155", true, "b2c59a12-f643-494e-8821-435dedba77c8", false, "B1809955" },
                    { new Guid("5c327df4-b6f0-4b22-bfab-2a37b914127a"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "d2e2d884-db73-4ebd-b38f-5efc527ba7c5", "B1809953@student.ctu.edu.vn", true, "Nguyễn Hảo", false, null, "B1809953@STUDENT.CTU.EDU.VN", "B1809953", "AQAAAAEAACcQAAAAEDpvpN1EfblP3tEo3jVQVjZ564972R7BPMcs2WFKQqtaOVPZBSrS1PrhB830ZUT3Eg==", "098177446153", true, "aa96979b-5405-4624-a3ef-43b6fe5d9e89", false, "B1809953" },
                    { new Guid("f7833a56-4305-4e12-b4ed-5673277653f3"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "710f21d5-4467-435f-97b1-8e6f67ccfa7e", "B1809934@student.ctu.edu.vn", true, "Phạm Thị Thịnh", false, null, "B1809934@STUDENT.CTU.EDU.VN", "B1809934", "AQAAAAEAACcQAAAAEPuiDZE8duJS5aibdYfN9vi7m0zpnWAeOjpPFYzs2oMZGhTXE7MyYRIoFtbNmwMdTA==", "098177446134", true, "7b8377c2-79d5-4e53-ae1a-a9860b11c493", false, "B1809934" },
                    { new Guid("83534383-3514-42b9-910c-cb0d47f19b56"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "cffc8cc8-d51d-432b-87ef-74823f49db7d", "B1809933@student.ctu.edu.vn", true, "Trần Trung", false, null, "B1809933@STUDENT.CTU.EDU.VN", "B1809933", "AQAAAAEAACcQAAAAEK7gmCFG3s65u45pV+Qf/5BVq7/0yor1EeXsECfiJIPRG2CheWvbXAz6uCZB+ZR4BA==", "098177446133", true, "ed5d87af-6d2e-41c3-a4b7-a7b363c980e7", false, "B1809933" },
                    { new Guid("5dd9a5d7-c2ca-40c7-a066-f626a8f2d2d2"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "3be6bf02-b96b-4de7-98f8-1494c8916986", "B1809932@student.ctu.edu.vn", true, "Phạm Thị Nghĩa", false, null, "B1809932@STUDENT.CTU.EDU.VN", "B1809932", "AQAAAAEAACcQAAAAEFmwuXmSaMkE2PEW3YU0AMwXtB1N2g1+/Z9XQyjki5wEaq3h3a346daNxx2YL2NO/g==", "098177446132", true, "9c01e340-dbfd-4675-b194-8dbba28a1bf6", false, "B1809932" },
                    { new Guid("d623f5be-a2b6-4db3-9b6c-9f2e62175c88"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "0406cc0e-02f6-4c57-b4d1-2a98eccb9f29", "B1809911@student.ctu.edu.vn", true, "Trần Văn Nhẫn", false, null, "B1809911@STUDENT.CTU.EDU.VN", "B1809911", "AQAAAAEAACcQAAAAEF5Hr1q5Su1OqSiwOIZvC3jvdoBbfn0YmnmR3RRTeYrmnb5wxk/Yi298E4X72rHm3g==", "098177446111", true, "6c80ddfb-901e-402b-84ba-7f090e26048f", false, "B1809911" },
                    { new Guid("51cf2a94-9f64-4e0a-bd42-60ba518f6f06"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "5a1cd717-0ce5-441b-bc41-645ae94aebbe", "B1809910@student.ctu.edu.vn", true, "Lê Nghĩa", false, null, "B1809910@STUDENT.CTU.EDU.VN", "B1809910", "AQAAAAEAACcQAAAAELrFyy11ilSjk9gb+I+/WPzD29Ysr34kvIABsA3whpu2lkwHJA/Fed1uYy8B29VPTw==", "098177446110", true, "dd222547-6e41-4b1d-8de4-a4671371b1e3", false, "B1809910" },
                    { new Guid("6ee1ee30-2953-4c3e-8ff8-0007b12bc8b9"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ff58705d-b9e3-4bb8-9d71-430b89aed6da", "B180999@student.ctu.edu.vn", true, "Trương Văn Toàn", false, null, "B180999@STUDENT.CTU.EDU.VN", "B180999", "AQAAAAEAACcQAAAAEKk4Znk/ooMpqBd6c0yQJLFkt3Rh+3db7KG8Lh/7KV7SWs5htr1rPxC4QYImhz4acA==", "09817744619", true, "9970bb28-d5b1-424e-bd7f-ad830f7ddc73", false, "B180999" },
                    { new Guid("22f56273-134d-440f-8404-c93cb419f931"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "44344622-c1a9-4553-b2c7-14c867303654", "B180998@student.ctu.edu.vn", true, "Nguyễn Hoàng Nhẫn", false, null, "B180998@STUDENT.CTU.EDU.VN", "B180998", "AQAAAAEAACcQAAAAEKErcm1019+WpOiYU4AexVGq6X8/xVc/oMYHz2CvuXWtNcQHK78yHvrfM6DzgPe83g==", "09817744618", true, "339fdb7d-c7e3-4995-bb32-6b425a12a5cd", false, "B180998" },
                    { new Guid("afca891b-c143-4bd1-b2d0-d26cc8775e17"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "42713724-01af-4ac1-abba-4832ad1eadd7", "B180997@student.ctu.edu.vn", true, "Thái Khánh", false, null, "B180997@STUDENT.CTU.EDU.VN", "B180997", "AQAAAAEAACcQAAAAEG0mU7jOCBwfiitdVqV9UCVsL5SuwebJW1u8WyJbovjAACmsPcXSKK0Pnmqe2cuzjA==", "09817744617", true, "39008eea-6fd7-4da7-ab8b-8a2db8e218dd", false, "B180997" },
                    { new Guid("1b352943-8a5e-49e7-bd20-73f36b33debe"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "c16f11cc-fa97-4b3b-9930-c257dad0bbc0", "B180996@student.ctu.edu.vn", true, "Trần Văn Nhựt", false, null, "B180996@STUDENT.CTU.EDU.VN", "B180996", "AQAAAAEAACcQAAAAEKhj1IiWT1c+0TZZ9dFlulA4k7ISnARzth9bNKk5ChfrUXibYPlpZ+m5lS/xrj87+Q==", "09817744616", true, "4fb7501c-79c8-4f7a-8922-446185b702c4", false, "B180996" },
                    { new Guid("18cad4e4-4937-4559-981d-d6e8144a76bf"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "7f06e5d2-7b97-4604-94cb-e3765b9a3f09", "B180995@student.ctu.edu.vn", true, "Nguyễn Hoàng Hảo", false, null, "B180995@STUDENT.CTU.EDU.VN", "B180995", "AQAAAAEAACcQAAAAEG1FQAy4TjXAJi7ZfXkmUf+4sLH1pvtQkklLj7a7lxJUo4KqCkeekk5rNbOqGWYusQ==", "09817744615", true, "0e758c9d-758a-4f76-9ecb-78e01808f203", false, "B180995" },
                    { new Guid("b4704ffc-5b52-4b1f-8bab-9316d2f523ea"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "cfc1a4a2-8637-443d-a221-30d7208271d8", "B180994@student.ctu.edu.vn", true, "Trần Văn Vy", false, null, "B180994@STUDENT.CTU.EDU.VN", "B180994", "AQAAAAEAACcQAAAAEI4lySVvAO3MULycsocrv1v2jWfDwHtE4F+tEBhZg89IcGS4rOm3s48rzt4UJx0LEw==", "09817744614", true, "556bb241-c01b-486c-9c00-3ce1027f4237", false, "B180994" },
                    { new Guid("5af29074-61c8-4718-9389-53e98d3572df"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "768b6788-cda8-4311-ab39-7472158400ae", "B180993@student.ctu.edu.vn", true, "Nguyễn Lâm", false, null, "B180993@STUDENT.CTU.EDU.VN", "B180993", "AQAAAAEAACcQAAAAEHeGQ7IYP/ZzYNme1OrnQAM0a9lewdi55oWXaUM4w+9e5vu5mkXL0syjUUXuPNGx9w==", "09817744613", true, "0c61eeef-91df-416d-a7ab-0b0f950a78d5", false, "B180993" },
                    { new Guid("bfefbec5-c208-42d7-9883-75ac611aa69f"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "311902b3-5474-48a0-825c-6e27f6e5556d", "B180992@student.ctu.edu.vn", true, "Trần Trúc", false, null, "B180992@STUDENT.CTU.EDU.VN", "B180992", "AQAAAAEAACcQAAAAEAz92ML+6QQC3McB3qm1i4cxFz83kRIGoXk6VJjdwa1tsB8u2SmOtM2paBRwRVyBvA==", "09817744612", true, "f7354bd0-14d3-4f3e-8875-272247ef21bd", false, "B180992" },
                    { new Guid("4ee8867c-feff-42a8-989f-803fb3421351"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "dfb335a2-5e85-4162-824d-439d8eed5c9c", "B180991@student.ctu.edu.vn", true, "Đỗ Trung", false, null, "B180991@STUDENT.CTU.EDU.VN", "B180991", "AQAAAAEAACcQAAAAEC3WXn2FaDGas52rQOcy9MSTalc2GHZL5F1wbF/QforGG59IQiXBtU43D3V7eoOoVg==", "09817744611", true, "d80a195d-b0a2-47cb-a14d-3152ab2b2d50", false, "B180991" },
                    { new Guid("85ba1fde-b003-4dbd-a026-d56831b6bbf8"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "f7c3c844-2957-4a8b-8617-aab7497a1f42", "B180990@student.ctu.edu.vn", true, "Nguyễn Lâm", false, null, "B180990@STUDENT.CTU.EDU.VN", "B180990", "AQAAAAEAACcQAAAAEN/2RVkz10lN0l/wAf04deF3sC6ieN1Ye+99owJtfLJi2Oirf/3+mWFybg6KcU9+pQ==", "09817744610", true, "e321b40f-49ce-458c-8e14-2ef4951d27cd", false, "B180990" },
                    { new Guid("bff91065-dc92-421e-a233-d1080f630928"), 0, "Hưng Lợi, Ninh Kiều, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "c9ae03b1-c2ac-4533-9622-b31ffef0a4b6", "haob1809323@student.ctu.edu.vn", false, "Vương Như Hảo", false, null, "haob1809323@student.ctu.edu.vn", "HaoVN", "AQAAAAEAACcQAAAAEHwMQPpKXAq9DESBkTABpH1uHc8VPsRtt/DeNAFW/5YGEQbDJvsv9Uh+kiW0qrZR4w==", null, false, "", false, "HaoVN" },
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, "Hưng Lợi, Ninh Kiều, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "d3980a6b-0a1b-4b18-a675-0990ffd0343c", "trucb1809323@student.ctu.edu.vn", false, "Võ Thị Thanh Trúc", false, null, "trucb1809323@student.ctu.edu.vn", "TrucVTT", "AQAAAAEAACcQAAAAEK57B1kA6P388jd2NJAaDq5Mf2FM5sae7re9Gzv/b5prjaI/kSjOtl8euNuGTt2DSQ==", null, false, "", false, "TrucVTT" },
                    { new Guid("bff91064-dc92-421e-a233-d1080f630928"), 0, "Hưng Lợi, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "70f12fc6-dd39-421f-852c-423fbe23c30c", "yenb1809323@student.ctu.edu.vn", false, "Đỗ Xuân Yên", false, null, "yenb1809323@student.ctu.edu.vn", "YenDX", "AQAAAAEAACcQAAAAEJFe1VaFZ8Dvj9w0wN9RXaWKEGAostmWyn33MZG+YCYYw1RPitjhM4l0jr9iD6xiUg==", null, false, "", false, "YenDX" },
                    { new Guid("882ccd9e-36cf-4940-88e5-ea7fbd477c37"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "acd29645-4cdc-4a49-b12a-8e4c0f2ac86b", "B1809912@student.ctu.edu.vn", true, "Nguyễn Hảo", false, null, "B1809912@STUDENT.CTU.EDU.VN", "B1809912", "AQAAAAEAACcQAAAAEMo2pLSBoKW2s6J2N32mMQeIjO4iSMeDUvHx0DOOHUWv8W2YWmPWuO2Js9wP4/jSIw==", "098177446112", true, "c662f1ea-5e46-45e6-bccf-3aa32e8fc6d7", false, "B1809912" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avatar", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("a55e3e12-6287-4c86-a86f-89f004f332ed"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "72168dc2-3831-4485-b311-bf3f18d126fc", "B1809913@student.ctu.edu.vn", true, "Đỗ Lâm", false, null, "B1809913@STUDENT.CTU.EDU.VN", "B1809913", "AQAAAAEAACcQAAAAEOgHvYeJyH0fHuaDOBK5fk3/kBMvvTNWrKWubFy0wUHVjCMnrQT2V+QG15MbceilQg==", "098177446113", true, "5897bfc2-1d2e-4e01-80ab-f86cd4876c87", false, "B1809913" },
                    { new Guid("eef44e4d-8de7-4675-8949-84bf629809b9"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "b2600fc4-8bbe-48d3-9535-9b4f23aeab1a", "B1809914@student.ctu.edu.vn", true, "Thái Nghĩa", false, null, "B1809914@STUDENT.CTU.EDU.VN", "B1809914", "AQAAAAEAACcQAAAAEOJaH1VJmEM1mY3phyw/QRpNi5656SbNAId5SAzk32tNPGp1btJD17DlZ9uQLL1KvQ==", "098177446114", true, "92abc99c-0605-4d58-b90c-40ad3ca2af34", false, "B1809914" },
                    { new Guid("05ef55e7-1566-4e42-a955-020e90a69802"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "73fa487a-9977-4834-aa77-e4de9092c177", "B1809915@student.ctu.edu.vn", true, "Trương Văn Trung", false, null, "B1809915@STUDENT.CTU.EDU.VN", "B1809915", "AQAAAAEAACcQAAAAEHFO7Bsq5vQMaMWMYNmaU5zUFU65vYNHe7RxfwRibaeAffpIUWE3OTaRwBDLxXLIyA==", "098177446115", true, "a4202a41-0cdb-4507-b1f9-8fe8b0b47b61", false, "B1809915" },
                    { new Guid("6a5c4b2e-5a17-4300-8eb3-dc048436c2ab"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "6023ac9e-a985-4f3e-aeb1-85ba4d9327e2", "B1809931@student.ctu.edu.vn", true, "Trần Toàn", false, null, "B1809931@STUDENT.CTU.EDU.VN", "B1809931", "AQAAAAEAACcQAAAAEGj5FpdRxN2VlR+ZFv37iMHgRed8LJDiOS6nNsCYhfFAkIf04Q3jOpvfoLtYNPgHlw==", "098177446131", true, "00604584-4de0-4fb2-816e-9daac59a98ba", false, "B1809931" },
                    { new Guid("f08e285e-7df6-4718-974e-48129e6e9715"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "94c23a6e-9518-4b82-981e-f63a5b6303a2", "B1809930@student.ctu.edu.vn", true, "Trương Văn Khánh", false, null, "B1809930@STUDENT.CTU.EDU.VN", "B1809930", "AQAAAAEAACcQAAAAENoElyCZ/UBl7waZR4+t0cSDDkOm4vVM3gwBCJIJ05Ut1EIxPwINc3zpG0ZzWC4eiA==", "098177446130", true, "f1f96a67-0b6e-4a4c-9428-eb1e8857f232", false, "B1809930" },
                    { new Guid("f829d5ff-00be-4368-b49a-0588c291c448"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "427b9ed7-76e0-4b2f-b3fd-453b55df4315", "B1809929@student.ctu.edu.vn", true, "Nguyễn Văn Toàn", false, null, "B1809929@STUDENT.CTU.EDU.VN", "B1809929", "AQAAAAEAACcQAAAAEPSsMroj/jLNDrKhKxnIoFkLFFWURH7KuR9rRug/6wtSSt1+t+ADNtty4uuT2usviA==", "098177446129", true, "69634f47-6e75-4c89-a588-cb4aa09d0eef", false, "B1809929" },
                    { new Guid("5f869759-4f5f-4c17-9e3e-2cacd27a6919"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "5b7bc263-68e0-4af9-bd5e-793e929f4b87", "B1809928@student.ctu.edu.vn", true, "Trần Văn Hảo", false, null, "B1809928@STUDENT.CTU.EDU.VN", "B1809928", "AQAAAAEAACcQAAAAEJnNxCOhcEC1GsdGCOLZ6kjIgKkql0L5Z29EcD/WHOHlymoXmbfc3l+lSAWRTpodrg==", "098177446128", true, "57eafafb-4c2f-4cb7-a452-a6c2c979e2be", false, "B1809928" },
                    { new Guid("c5754a1f-458c-4f1f-8cfe-34446401d826"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "81fb1ed8-f7aa-44fb-8763-beafbfc03007", "B1809927@student.ctu.edu.vn", true, "Đỗ Nhựt", false, null, "B1809927@STUDENT.CTU.EDU.VN", "B1809927", "AQAAAAEAACcQAAAAEJWYDaPSNBcuUTduONdBC/ed522aN4C9kCpZwiUpzUUPM6aSci5k7hTSBZ9Mm0REyg==", "098177446127", true, "dbb29c45-60be-4142-99ec-4336902540c6", false, "B1809927" },
                    { new Guid("c5a4ac50-9fdc-4715-bc0c-ba0645587b9d"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "69e4382f-6bb8-4304-922a-5d83a2e9fd43", "B1809926@student.ctu.edu.vn", true, "Trần Văn Vy", false, null, "B1809926@STUDENT.CTU.EDU.VN", "B1809926", "AQAAAAEAACcQAAAAEDHjZxa7G6RPsqbzkuOAMl0kSThB1tLtKY0EPhjhjMcz5FlzlVfC/ELfeGgVmBsgPQ==", "098177446126", true, "70ffac47-c238-46a9-a930-87840a720e58", false, "B1809926" },
                    { new Guid("b2ad653d-3048-49e7-b3ee-f07076a294f9"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "6f87f60f-e8d2-41f2-bfb2-d657cc99b948", "B1809925@student.ctu.edu.vn", true, "Nguyễn Văn Trúc", false, null, "B1809925@STUDENT.CTU.EDU.VN", "B1809925", "AQAAAAEAACcQAAAAEGapAhThfhE8lx5m2cxW/E75bFPuW0hcEXjK8xI6dJ0TKJfW1ZgpVw9kgdRuLBzo9w==", "098177446125", true, "cb75db1d-0c6a-4323-8693-42bcca664f8a", false, "B1809925" },
                    { new Guid("09a1b152-971e-4a25-b550-85439e305fe5"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "5afef087-f75c-47d8-b76a-5e769ec5e524", "B1809970@student.ctu.edu.vn", true, "Nguyễn Văn Trung", false, null, "B1809970@STUDENT.CTU.EDU.VN", "B1809970", "AQAAAAEAACcQAAAAEAjspVWCrCvdKa8ErnKV4UqHSTnwPTtu3/7QB4/tYkRMABRuwbjMGAR6mXZYiA/atw==", "098177446170", true, "5601e83e-6245-4897-9627-115bc9235984", false, "B1809970" },
                    { new Guid("82c2022c-79a4-4424-92c2-e5b8bbbc02bd"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "71313525-68c1-4e9a-9bb1-8072c8daf48f", "B1809924@student.ctu.edu.vn", true, "Đỗ Thịnh", false, null, "B1809924@STUDENT.CTU.EDU.VN", "B1809924", "AQAAAAEAACcQAAAAEN0CBoMB2pi+JWaFEaV5zSWmMV0g1TDyyOiBqLpk+//9LAW5HT6xh3eSBqW4GKMjCg==", "098177446124", true, "838db171-3a0a-487c-b589-f01612d793fd", false, "B1809924" },
                    { new Guid("71e75106-5a1c-4962-812a-d240e1a887cd"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "22535cbd-1290-4210-847a-e0bfb2edb436", "B1809922@student.ctu.edu.vn", true, "Lê Trung", false, null, "B1809922@STUDENT.CTU.EDU.VN", "B1809922", "AQAAAAEAACcQAAAAEJD3CbCL1UB90Cs23/YSh7i5Z67+fqjkmTtjz4gVzmcPsPXqanSsida5eDfuIfCIHg==", "098177446122", true, "310b599e-3e7a-4272-aa62-0a06aa3757c2", false, "B1809922" },
                    { new Guid("089b2abf-11f1-41db-b40a-04711e05e078"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "a2197c2d-d1f8-42e2-abb9-249fcdffb1b6", "B1809921@student.ctu.edu.vn", true, "Nguyễn Khánh", false, null, "B1809921@STUDENT.CTU.EDU.VN", "B1809921", "AQAAAAEAACcQAAAAEK0ddljgKzWeEhQapxDQNe9FE7UkBrrZPZ6HQV1nvrd//yMB/HGNRAuArKekZn4sZA==", "098177446121", true, "d48d85f9-08c7-4c5a-894a-8620c68824ef", false, "B1809921" },
                    { new Guid("15607863-96fb-4e17-bc19-8f85ee9eb85e"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "21bf2edc-e809-4b30-a36b-66c9fe13675b", "B1809920@student.ctu.edu.vn", true, "Trương Văn Thịnh", false, null, "B1809920@STUDENT.CTU.EDU.VN", "B1809920", "AQAAAAEAACcQAAAAEK6mtAJqpi+/Gv2fIYkC/7AK+oGBilrnZz92yANbdlUzTp8C899YzMD07naRfc7Dwg==", "098177446120", true, "e44ab4f0-1591-461f-be05-96370c6413f5", false, "B1809920" },
                    { new Guid("dcffb626-b7a0-4204-9a5c-9361e5a9cd5b"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "fedeb61c-7bc3-428a-bec7-f1d87b5dc58d", "B1809919@student.ctu.edu.vn", true, "Nguyễn Hoàng Khánh", false, null, "B1809919@STUDENT.CTU.EDU.VN", "B1809919", "AQAAAAEAACcQAAAAEDNuQAwPo0jv2ww2rLsu2FdUbRLVgga9bBZXhOumyahPMRjijbjRdqjlsRT53RI0OA==", "098177446119", true, "b03a5741-ef92-481c-80ad-61e8741278c7", false, "B1809919" },
                    { new Guid("d8a24afc-ea59-4553-80f8-538d2787faae"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "352e3043-1ea8-4ca2-96d6-63cc0cac2c70", "B1809918@student.ctu.edu.vn", true, "Trần Vy", false, null, "B1809918@STUDENT.CTU.EDU.VN", "B1809918", "AQAAAAEAACcQAAAAEK7nxaxAjb4zK85aeqLtjBo7U3nJmkQ9sVOHdhX9ZtF5l8B7Ze5hlFPQhD5A4wHaBA==", "098177446118", true, "16aff3a9-764c-4939-ae69-bc0ac81ac898", false, "B1809918" },
                    { new Guid("894ae027-a595-4891-ac27-bcc42b7e8db0"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "bb8483ed-1d83-4f3f-9c6a-e349d1021bcd", "B1809917@student.ctu.edu.vn", true, "Lê Nhẫn", false, null, "B1809917@STUDENT.CTU.EDU.VN", "B1809917", "AQAAAAEAACcQAAAAEEVPviF7V0WjCJ4RInKjPyYu6YKd0QlGeYt95dT8Vs3hAUf/uVt2fGWqFWtabR26qA==", "098177446117", true, "02314f63-f686-4a2d-b272-2a734bcfda46", false, "B1809917" },
                    { new Guid("68fd5fb8-eb1e-491b-a1f3-eb1798bb2f84"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "fc681869-371c-475f-8488-7b915e158983", "B1809916@student.ctu.edu.vn", true, "Nguyễn Văn Trúc", false, null, "B1809916@STUDENT.CTU.EDU.VN", "B1809916", "AQAAAAEAACcQAAAAEEYVTNQI3EnahgNxhKCWTEAHNOj0O4g/2ux4v+ohWVRkomBIAqnI8f9gQBA2vN7CWA==", "098177446116", true, "885eaf13-df68-4d25-a61b-fc0de98b9136", false, "B1809916" },
                    { new Guid("6f71bdc6-4bbd-428a-9c11-f436d37c7737"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "490de114-b520-4f36-9776-5600c0a87869", "B1809923@student.ctu.edu.vn", true, "Đỗ Trung", false, null, "B1809923@STUDENT.CTU.EDU.VN", "B1809923", "AQAAAAEAACcQAAAAEGkZzdepGNoAgW0MKXOdigAz1TIPZQ7p0Dj7t3e3fYDXCYZUc/eUUh928QPdjjp//g==", "098177446123", true, "7de9c111-79fc-42a6-9bae-e04a8ce82c8f", false, "B1809923" },
                    { new Guid("0afc92af-e16b-4086-bbb1-a7bb3fb0a254"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "1c6b0a0a-85c4-42d2-b054-df41ce3f0255", "B1809971@student.ctu.edu.vn", true, "Đỗ Khánh", false, null, "B1809971@STUDENT.CTU.EDU.VN", "B1809971", "AQAAAAEAACcQAAAAEMQFsRsT8eiXtUlB6SiIWEdFYX96dbbKDMD4Y0WCsEpmmAPXH3YGE1JyCG/Bt6YUOQ==", "098177446171", true, "93f15c8d-c095-4501-88a4-d6b2e45b4634", false, "B1809971" },
                    { new Guid("bd94c7d1-68d8-4447-9654-0d820a8ccc69"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "17a74006-f0ad-4c4f-8939-8581bf7aaf05", "B1809954@student.ctu.edu.vn", true, "Lê Văn Nhựt", false, null, "B1809954@STUDENT.CTU.EDU.VN", "B1809954", "AQAAAAEAACcQAAAAEAvUrhQn75Wkicaj2KVzykbJnBnhQnubcHJ+Sc42/g2hgrYd8e00dM136x1tEbUD0w==", "098177446154", true, "bac2bf1c-3a1f-4983-a0e0-fa98defcd35a", false, "B1809954" },
                    { new Guid("522e0e93-008f-4d45-8ec8-1e370538edf4"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "80859b91-1154-4342-9bea-9c2befdf5307", "B1809973@student.ctu.edu.vn", true, "Lê Khánh", false, null, "B1809973@STUDENT.CTU.EDU.VN", "B1809973", "AQAAAAEAACcQAAAAECDBALdIV++cyYQmfj94WQvgwko46d4uNNNSvpPCT4L6jVcTH5mjHuf+5EapybK9aA==", "098177446173", true, "50f6203d-cc1f-47c4-ac51-ee67ec2a2812", false, "B1809973" },
                    { new Guid("dbcb0cce-a5e9-436a-8f58-4b848e229a2e"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "c04413ba-8389-4a14-aa59-c740c43b0fef", "B18099126@student.ctu.edu.vn", true, "Phạm Thị Trung", false, null, "B18099126@STUDENT.CTU.EDU.VN", "B18099126", "AQAAAAEAACcQAAAAEAkSvssk20Q9UBEs150DzIHU1eORj3ykwH6SCoM1EIUpmOZwm5VZBLzhl+C7DoOSCw==", "0981774461126", true, "1c6d5afb-3f44-4074-8349-a542625fdf8f", false, "B18099126" },
                    { new Guid("2ef30f4d-89a3-47ec-ada1-64795e191e1c"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "a04691e2-00d7-434c-99bf-b1427081e19e", "B18099125@student.ctu.edu.vn", true, "Thái Vy", false, null, "B18099125@STUDENT.CTU.EDU.VN", "B18099125", "AQAAAAEAACcQAAAAEHMl8q+XZUd1wxc4WnXZCw+rvZLix0EK/Fya/aw69AvJpJeIXqUFT7juPkFxFvsp/w==", "0981774461125", true, "f8b064b0-e844-4a93-98ca-0a5b7c34ea13", false, "B18099125" },
                    { new Guid("1372ffda-c440-4a5e-8987-8856aefdec6f"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "3489c62d-2076-43fa-b9d0-3b10f9b86af3", "B18099124@student.ctu.edu.vn", true, "Nguyễn Khánh", false, null, "B18099124@STUDENT.CTU.EDU.VN", "B18099124", "AQAAAAEAACcQAAAAEHRs0cIi5B7tTw86i+L3PiUevgy2KCl9MJfxtu9gqQlfoksr5eirqMcuqhILprAYVg==", "0981774461124", true, "36105bc5-6109-4c38-be11-f67139bdfbf3", false, "B18099124" },
                    { new Guid("0e6c1b93-0b8a-45e0-bd03-9f25595c4906"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "9e179bbe-666a-4631-a885-890f0defd980", "B18099123@student.ctu.edu.vn", true, "Thái Trung", false, null, "B18099123@STUDENT.CTU.EDU.VN", "B18099123", "AQAAAAEAACcQAAAAEKmYlkQkBKnG/gbdRyykSOs6Q3gpakf7L0pfBXBt+4Oi5t53wjk3ywuCIRIAwHQcew==", "0981774461123", true, "d2e62cf1-ee8a-44e0-87ce-d02d293331fd", false, "B18099123" },
                    { new Guid("db77656b-6e0a-49ea-95d1-44d2cfc58558"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "54c1e9d0-9f9a-40e1-b58b-524136cd4714", "B18099122@student.ctu.edu.vn", true, "Trần Văn Nghĩa", false, null, "B18099122@STUDENT.CTU.EDU.VN", "B18099122", "AQAAAAEAACcQAAAAEOk4CUqZUZo/80n8aRsLkMiJLezCmBPovyXPVIVG/0JS7GZmLTvSl4irh7FeT1EUVA==", "0981774461122", true, "d1910b96-a1e0-4c94-b5ca-6ec86f33012b", false, "B18099122" },
                    { new Guid("d0f5a293-eb2c-4df5-8a58-a3134fb8be19"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "88817816-a412-4aeb-b9bd-a515f2525072", "B18099121@student.ctu.edu.vn", true, "Lê Văn Nghĩa", false, null, "B18099121@STUDENT.CTU.EDU.VN", "B18099121", "AQAAAAEAACcQAAAAEGoeFNihkcpq1aDLY2pfnXSpr2DG6XXXJded2+2l12ur/BFiiFfhfp6qHzUTU1q6UA==", "0981774461121", true, "23fcc2b4-8773-40ed-947e-bf9f75c8d6d9", false, "B18099121" },
                    { new Guid("50a3a8dc-d512-4f52-981b-b3942710e174"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "4507e3ae-a609-4675-9d71-afb6c50c775b", "B18099120@student.ctu.edu.vn", true, "Trần Nhựt", false, null, "B18099120@STUDENT.CTU.EDU.VN", "B18099120", "AQAAAAEAACcQAAAAEO1HnKpcy3DEzO86mE+ApcVD5aGJAO5FESKCFyKJQGDkCMCAp6lWeB/ysiCjAnUE+g==", "0981774461120", true, "57f45491-5bd4-44af-b4df-034399f38454", false, "B18099120" },
                    { new Guid("e6a497f9-2895-40ab-96a4-1a17c52655a0"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "06d00104-cbbb-435b-a88b-425314fa96d4", "B18099119@student.ctu.edu.vn", true, "Nguyễn Văn Hảo", false, null, "B18099119@STUDENT.CTU.EDU.VN", "B18099119", "AQAAAAEAACcQAAAAECsLWlmKHach3mpSi/Fd6xNh1Q0WAdw/WvS1zdkVZJD/mV4ndhDeIgQBaRNIAnT0Mg==", "0981774461119", true, "3d913e94-a462-4968-97da-ecff249862d3", false, "B18099119" },
                    { new Guid("e6d2c7ba-035a-4d54-8bb9-00db7e5c6173"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "d2110474-b26f-46fc-8788-7cf2af2f58c4", "B18099118@student.ctu.edu.vn", true, "Phạm Thị Lâm", false, null, "B18099118@STUDENT.CTU.EDU.VN", "B18099118", "AQAAAAEAACcQAAAAEM/CvrPYgVdgk2izPdOP9ZFDXU1UDbtIU5P+8Xw7sG9ut4UrCC5WSg3sIeo1mc2HCw==", "0981774461118", true, "2cbfc43b-e018-4ec3-94ba-67a6d82bc0ca", false, "B18099118" },
                    { new Guid("32f88a33-e861-4dc3-af21-213ed3ac8a80"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "69d91c08-77e4-42db-becb-856cbaeed96f", "B18099117@student.ctu.edu.vn", true, "Lê Khánh", false, null, "B18099117@STUDENT.CTU.EDU.VN", "B18099117", "AQAAAAEAACcQAAAAENDmISOLjV+ubbxmQfeBOVjT/e43FrfxMII78YBL9jPrBhlutkCpGVTWhujjQIB/pw==", "0981774461117", true, "ad99f82a-62ad-4504-bf61-c2def80a92c8", false, "B18099117" },
                    { new Guid("90a694d2-d5e1-4c8e-a9d4-113f775ccd03"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "bf3fe59c-bd75-4a92-a3f6-1e1b0a8e480d", "B18099116@student.ctu.edu.vn", true, "Phạm Thị Thịnh", false, null, "B18099116@STUDENT.CTU.EDU.VN", "B18099116", "AQAAAAEAACcQAAAAEA+v+3d2IUxcDUzuTFhpAZg01sPC5ehuEPbnArZvJsblq2nR3IPlgvct6LO6TA/GrA==", "0981774461116", true, "5aae7e60-d323-4bd0-93f2-abc522605da8", false, "B18099116" },
                    { new Guid("4fd9dcca-dda8-444c-b2ba-2772d60cac6c"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "12871880-bfd1-49f8-b723-b50f590c6a3f", "B18099115@student.ctu.edu.vn", true, "Thái Nghĩa", false, null, "B18099115@STUDENT.CTU.EDU.VN", "B18099115", "AQAAAAEAACcQAAAAEEfa7EyKxho8bSt8x5iAIS5Fl7K6IAbhqlMU7gcwqaRpHiBEkOKV9RMfJ7Ggc7X8tg==", "0981774461115", true, "d23c8ac7-f430-4273-a790-a4c2e4c785bc", false, "B18099115" },
                    { new Guid("1b3baea5-cd59-4166-9ed6-feb23a451b82"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "dad0a777-c1d5-4176-9dbf-c59dea809a49", "B18099114@student.ctu.edu.vn", true, "Thái Lâm", false, null, "B18099114@STUDENT.CTU.EDU.VN", "B18099114", "AQAAAAEAACcQAAAAEMx5QjSCDL/148orIma64ELuoNErkJv5QAdH24yMj3pEKD8aSQAcQHvkfpY7RPiIZw==", "0981774461114", true, "eaa2114a-66c7-44db-82bb-7d208c35dc6c", false, "B18099114" },
                    { new Guid("05ac7a0c-1055-492f-8731-b5e0a5f434d9"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "d1927bf0-f353-4666-930a-712321eea567", "B18099113@student.ctu.edu.vn", true, "Nguyễn Nhựt", false, null, "B18099113@STUDENT.CTU.EDU.VN", "B18099113", "AQAAAAEAACcQAAAAEOl79T0KZdmDlfjiXhoK5Dw4zi6Ly1r2lmcHDfkaqkTxuJKCkDhOEuJ/YXrJdfX+Qw==", "0981774461113", true, "df81bd5c-196b-43e5-a1a8-99fcffdd70d3", false, "B18099113" },
                    { new Guid("f7fb10b0-6c53-4beb-9318-97de7108bc13"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "6d86e335-5bfd-4850-a0fb-19fe6c18cc4d", "B18099112@student.ctu.edu.vn", true, "Nguyễn Hoàng Nghĩa", false, null, "B18099112@STUDENT.CTU.EDU.VN", "B18099112", "AQAAAAEAACcQAAAAENUm3xQypY6wabK+SSFe/yT1u6Kah0xsWzQQDYoayBrm+/bbMJ/xGCllciKfop4J+A==", "0981774461112", true, "116be113-28da-484b-bb39-bc98bf334197", false, "B18099112" },
                    { new Guid("b8f94450-c787-45f5-9d62-6cdcad553fef"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "becd9a28-6534-45dd-a13b-ac2bc03c5d0e", "B18099127@student.ctu.edu.vn", true, "Lê Lâm", false, null, "B18099127@STUDENT.CTU.EDU.VN", "B18099127", "AQAAAAEAACcQAAAAEHdCNM6CDNxjmX8MyoPaV14kpDhTW7fUhPbfZVRDqiV5ALGOENcTHis4EEE1Zcr6sA==", "0981774461127", true, "5bc3d6cb-393a-46af-8f09-2819e8a0c5ae", false, "B18099127" },
                    { new Guid("4757251e-a13e-4c5a-9a22-02394e7fee19"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "58c48d58-b094-49bf-b3de-e2a6aeac7f7c", "B18099111@student.ctu.edu.vn", true, "Phạm Thị Khánh", false, null, "B18099111@STUDENT.CTU.EDU.VN", "B18099111", "AQAAAAEAACcQAAAAEEoMA1eIcYM8c/rDUIcBNCvc+tOAcwklHExiWINFDpX6K0YVlfk7stdcjxKU/UYOTA==", "0981774461111", true, "9e646d54-bc5a-4f2c-bc98-8c9c18f5e991", false, "B18099111" },
                    { new Guid("4187d623-6d50-4db8-8075-7cb978d0cddf"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "461cc53f-1f67-4a80-9e22-7babacec4dbf", "B1809972@student.ctu.edu.vn", true, "Thái Nhẫn", false, null, "B1809972@STUDENT.CTU.EDU.VN", "B1809972", "AQAAAAEAACcQAAAAEDM3ImoFK9xMo/jTCqxmYXfTqXXw1ONjf/a+IQKDkHU65jLaDECIIDmXmBOgapleDA==", "098177446172", true, "b578ab1b-d3da-4d0d-8247-f48c4dd51f95", false, "B1809972" },
                    { new Guid("462617dd-e276-4066-946a-79736c9f4d91"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "a56cb9ee-1f0f-421a-8ee5-ca403b173937", "B18099130@student.ctu.edu.vn", true, "Nguyễn Khánh", false, null, "B18099130@STUDENT.CTU.EDU.VN", "B18099130", "AQAAAAEAACcQAAAAECpD7mmivdQm9pvqJNvmSs0jDT5OtmLBRSOaOD3K4e4a9zm0ExOuYVYHJpOIWkAYxw==", "0981774461130", true, "4a195730-6832-4297-a19a-142194069f9f", false, "B18099130" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avatar", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("e920a5a4-3415-4a1d-8e2a-8982c4386ea6"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "e3a883d6-a593-473f-a64f-b12b3fef783e", "B18099145@student.ctu.edu.vn", true, "Đỗ Nghĩa", false, null, "B18099145@STUDENT.CTU.EDU.VN", "B18099145", "AQAAAAEAACcQAAAAENpZiQB8iehzI4MGZMGJeMucxql8wbMIEuVi2FWlh7m3MsPbPt8uv6+W22TNKlxuqA==", "0981774461145", true, "8672af78-34fc-4efb-ba32-47c1aef110ac", false, "B18099145" },
                    { new Guid("98c56511-afa2-4f6e-b110-4d44836299e8"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "e8606b51-e6ca-4d33-a2f2-5cb172a73572", "B18099144@student.ctu.edu.vn", true, "Trương Văn Nghĩa", false, null, "B18099144@STUDENT.CTU.EDU.VN", "B18099144", "AQAAAAEAACcQAAAAEJweUAZXf8kn2FxsbxkHAwdtL5puPY0MvBu/THRY04R9kwMcJqMkaH80wyVJyZnhEA==", "0981774461144", true, "ee77f6a4-44cd-4161-bb44-859c735c3a9f", false, "B18099144" },
                    { new Guid("9a493d2d-3671-4c4b-9dd2-492095e5ab56"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "edb3cc8d-ad04-4bdd-b0f2-118e62321d49", "B18099143@student.ctu.edu.vn", true, "Nguyễn Văn Khánh", false, null, "B18099143@STUDENT.CTU.EDU.VN", "B18099143", "AQAAAAEAACcQAAAAEFLBwd3VyWmZTausFeGj4w4mnLDtiIQHzghz2noZv7MSK4EwVif0s/tO+pn7qjt6gQ==", "0981774461143", true, "b1309517-84f8-4516-891f-447e924e2874", false, "B18099143" },
                    { new Guid("b15b1095-202d-49e2-92ad-5c47be931877"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "f5275f0d-d931-4ef1-86b3-c6b933e771a5", "B18099142@student.ctu.edu.vn", true, "Trương Văn Khánh", false, null, "B18099142@STUDENT.CTU.EDU.VN", "B18099142", "AQAAAAEAACcQAAAAEGlUreNMn7lrMSubrA4ymSxlmH9tjuafH2T8NCuKFvRRdJGT1i7CbUdMDRACaXfRPQ==", "0981774461142", true, "0141b581-9be6-4854-a4b1-35647a65b08f", false, "B18099142" },
                    { new Guid("eb767016-9e06-4c56-9903-ef9ac85cf402"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "81f451f1-f6f1-403f-b092-3a9fef52662d", "B18099141@student.ctu.edu.vn", true, "Trần Khánh", false, null, "B18099141@STUDENT.CTU.EDU.VN", "B18099141", "AQAAAAEAACcQAAAAEP4JYgeMkId8C2IVf2Pj6sQpznAJoQ+OK/IVoXfo83c1MGzxshtdA02mfrG1ShlqGg==", "0981774461141", true, "4426dbd6-d75d-45fb-9872-3700f160f10f", false, "B18099141" },
                    { new Guid("64e720d4-9d05-485a-bd34-8ad675af5d95"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "664aafd0-40a9-4a4f-bf36-1f617bc4f360", "B18099140@student.ctu.edu.vn", true, "Nguyễn Hoàng Toàn", false, null, "B18099140@STUDENT.CTU.EDU.VN", "B18099140", "AQAAAAEAACcQAAAAEAmvYUCFMsv8B0OXaCrFxhtgiKBbJs8zFZxDrL13tx1/fEjX+KWv+4tD8cDMnqaHZg==", "0981774461140", true, "78807d8b-c808-4f99-aa8b-cce677b59e42", false, "B18099140" },
                    { new Guid("84fdf487-ca09-4e9f-901f-55d988398187"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "100f4c4c-8ab7-4b47-aea2-454b42f843da", "B18099139@student.ctu.edu.vn", true, "Đỗ Toàn", false, null, "B18099139@STUDENT.CTU.EDU.VN", "B18099139", "AQAAAAEAACcQAAAAEIsbI/jAyQvUDCiqFBEjs41NHWGoc51onRTGEPSm53iJIYr8jkiU86XwosdUkwfwZw==", "0981774461139", true, "9a3df32f-9e62-4d5a-904d-10854510466a", false, "B18099139" },
                    { new Guid("9b02b0f2-8394-4397-9e09-a1ddd0084960"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "7b3826c6-9627-4236-89bb-03cf61a45109", "B18099138@student.ctu.edu.vn", true, "Phạm Thị Hảo", false, null, "B18099138@STUDENT.CTU.EDU.VN", "B18099138", "AQAAAAEAACcQAAAAEEGnGvpAOFALIyM03nkjLZjIw0Qe+hJr2WEiga+Z6gPalJWNX/RvvkFgd0JmRlonbw==", "0981774461138", true, "fa13426b-81f6-4f6b-8f36-661493210ce7", false, "B18099138" },
                    { new Guid("83eaaa1e-d4ef-49ed-ae42-ef89a4bc7373"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "c9d51f24-e5a7-4a98-9eda-9645bfbe1643", "B18099137@student.ctu.edu.vn", true, "Lê Văn Thịnh", false, null, "B18099137@STUDENT.CTU.EDU.VN", "B18099137", "AQAAAAEAACcQAAAAEIqU64CZeE5tW9m6YN8P3yqsCiY+QkNVr2ON1eXEqEH2qn/7ZZ3s1gYhraw3ela3Pw==", "0981774461137", true, "ec92c143-25bd-4caa-96e5-7bb576969ba9", false, "B18099137" },
                    { new Guid("1adf1cbf-0441-4824-b5e9-b72cc702c640"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ebeadcef-e19c-41bb-b92c-3641279206ea", "B18099136@student.ctu.edu.vn", true, "Trần Lâm", false, null, "B18099136@STUDENT.CTU.EDU.VN", "B18099136", "AQAAAAEAACcQAAAAECG/s7I071i5iOlVuBWFgm/xhg31ZJYA6BjT9MjXHPO9mqr2j8WRBWM9iNPHCYQGPQ==", "0981774461136", true, "23202d41-1833-4df3-8a58-e8a09b2e8a82", false, "B18099136" },
                    { new Guid("a01af778-d757-4022-8673-44baab055929"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "4a281174-2604-4283-b9a4-c1ebce5a5a79", "B18099135@student.ctu.edu.vn", true, "Lê Toàn", false, null, "B18099135@STUDENT.CTU.EDU.VN", "B18099135", "AQAAAAEAACcQAAAAEKhuR/16+ciqIl28Fl+Dnep15rc9HFA16cva7nrWrtJJzq3teUI1OaJi5mMrQXyNkA==", "0981774461135", true, "4c56e93a-6063-4c9b-97bc-c96d28f61503", false, "B18099135" },
                    { new Guid("b33dc930-4046-41ce-a309-1a41c7dec7a2"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "fed7acd8-b690-4928-96ea-f7fce0946c44", "B18099134@student.ctu.edu.vn", true, "Thái Lộc", false, null, "B18099134@STUDENT.CTU.EDU.VN", "B18099134", "AQAAAAEAACcQAAAAELTXwvD8zT8PMslQ2ZCb9f5DrOH0TiwpDYZHcyjrwC+wzHh4uwXILnOn5L036aGzNg==", "0981774461134", true, "81188d5d-c8c2-48d8-8297-b1f3f891dd2a", false, "B18099134" },
                    { new Guid("0aef8b94-022a-4d3c-96cf-7b7ea3687a04"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "f6f33af9-4a90-4fd5-859b-24aed735acd2", "B18099133@student.ctu.edu.vn", true, "Lê Văn Khánh", false, null, "B18099133@STUDENT.CTU.EDU.VN", "B18099133", "AQAAAAEAACcQAAAAEPgMmyrHQvbmbI/s5ndf7HJYsz8HWzCrH/YZi65VQT3Dqi0ZYf1ont/dAUoURD62zg==", "0981774461133", true, "0d7ba893-0493-4562-8de4-d29049b845e2", false, "B18099133" },
                    { new Guid("60cb9f88-1b3c-4567-8e6c-d0cdc9017283"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "9bab3e4d-b00e-422f-b0a0-c7c9a3cadb43", "B18099132@student.ctu.edu.vn", true, "Trần Trung", false, null, "B18099132@STUDENT.CTU.EDU.VN", "B18099132", "AQAAAAEAACcQAAAAEFwnguaVzVbtUoIw9uoDmUVAy3k9Wh+23gdV4w5PzRFTYo9ULe7EbnJxOMkALyHWpA==", "0981774461132", true, "9bfa00eb-7c9b-411a-98fa-2bbb466bbc0d", false, "B18099132" },
                    { new Guid("1ce197a9-51ad-4e32-89cf-ccf1d414c087"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "5632349d-19ce-43bd-ac9f-35567226ed65", "B18099131@student.ctu.edu.vn", true, "Nguyễn Hoàng Trúc", false, null, "B18099131@STUDENT.CTU.EDU.VN", "B18099131", "AQAAAAEAACcQAAAAEI63aANs+xBqcWlfFJjW0X9yR3LKCGVliw7us82VAPZXYSL6aR6IdNTf4i5hkYF/SQ==", "0981774461131", true, "e86b5db0-6994-40af-b79e-f5f25ec6a34f", false, "B18099131" },
                    { new Guid("fce48743-13ce-4072-8ab3-9924d2af4717"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "00309789-2fd6-4e44-a9ba-e4f381595245", "B18099129@student.ctu.edu.vn", true, "Nguyễn Hoàng Vy", false, null, "B18099129@STUDENT.CTU.EDU.VN", "B18099129", "AQAAAAEAACcQAAAAECauL62TwPLlDvcL0cymc3c/ZspNVYsqXOe+DSXIpilC6KNyx8FImurzK9fDXAjlPQ==", "0981774461129", true, "bb86be61-df72-4746-a4b4-ec13dc0ab895", false, "B18099129" },
                    { new Guid("ac11fb96-9e15-4493-85bd-c6a14a615e33"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "b2877904-8637-465c-92cf-131acb7e4fb2", "B18099110@student.ctu.edu.vn", true, "Lê Văn Trung", false, null, "B18099110@STUDENT.CTU.EDU.VN", "B18099110", "AQAAAAEAACcQAAAAEFCO0HwvKI+rcFY2QdogeMBr5Gqboqw6xj+jlVgYY4cqVMIK+OygE1lJkXTdysoqvg==", "0981774461110", true, "5fe08803-4480-4300-9bc3-4f126d22755b", false, "B18099110" },
                    { new Guid("4bdf10e6-4aa1-4bbe-8de5-b58a909a3f3b"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "eea90c38-51c3-4059-acb5-57814804e106", "B18099128@student.ctu.edu.vn", true, "Phạm Thị Trúc", false, null, "B18099128@STUDENT.CTU.EDU.VN", "B18099128", "AQAAAAEAACcQAAAAEOdrbqXcG5HHsfTF6TDhQFKnqLn2B5hknjfmiIWU7Y2x9n2i2YJp/K20S+ZvG+AmLA==", "0981774461128", true, "8ff4e470-560a-41b3-9324-0aa84917b740", false, "B18099128" },
                    { new Guid("3e727ea2-c051-4eec-8823-830ad7188b3a"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "62f98aaf-a15f-445e-9b17-e6d103b1e645", "B18099108@student.ctu.edu.vn", true, "Phạm Thị Trung", false, null, "B18099108@STUDENT.CTU.EDU.VN", "B18099108", "AQAAAAEAACcQAAAAELu6EoVmsCnk6xlsADNqLTFFHaixoItvjjT02jZctfrWO6IGB7HdlCFVPvghG7SaUA==", "0981774461108", true, "802c9b41-2763-455e-aa1a-eb4feab19731", false, "B18099108" },
                    { new Guid("f344eec1-c963-47fa-9dbb-496cc6931ef6"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "9f87300a-0397-473c-a36b-5f6f55b3e3d4", "B1809988@student.ctu.edu.vn", true, "Nguyễn Văn Nhẫn", false, null, "B1809988@STUDENT.CTU.EDU.VN", "B1809988", "AQAAAAEAACcQAAAAEBXkwxHg4AUYqEV1Rhp26LXhS6nRVl5/R0jHuPx0Vt+VlVndo1qLXHjWCvV3Zva8eg==", "098177446188", true, "a7436f6f-76c9-4087-b434-aab93ecd1d47", false, "B1809988" },
                    { new Guid("8ac6839e-3dc9-447e-ac60-675f2ceb7b92"), 0, "Rạch Giá, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "7c23797e-f49c-413e-9b53-4946b9dad17c", "B1809987@student.ctu.edu.vn", true, "Trần Lâm", false, null, "B1809987@STUDENT.CTU.EDU.VN", "B1809987", "AQAAAAEAACcQAAAAELIBFYAdcECFCBlUtpgdLWr6iD0Phg9KLsEJMSueeO5jq7nTRLXDwNFZ4De+Ounv4g==", "098177446187", true, "46c07ff0-a3ce-4276-850d-31085062c3f4", false, "B1809987" },
                    { new Guid("214abb3d-1d2c-4f84-8d1d-3f4710891cdd"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "caa5d8ef-0084-4ff3-baa4-6ab6f2e2847e", "B1809986@student.ctu.edu.vn", true, "Phạm Thị Lộc", false, null, "B1809986@STUDENT.CTU.EDU.VN", "B1809986", "AQAAAAEAACcQAAAAECP/hzBQLtPwPqHDVuzPWbVNExoKg3vK/cV95PKO+hT8TZ5smGN2axydcgyZqzjFAQ==", "098177446186", true, "b7725288-0c63-4b12-a78c-26fe3f1efaf3", false, "B1809986" },
                    { new Guid("d08adf6b-297c-414b-bedb-c1a3886fd99d"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ea9cab7c-f9ca-4ae5-a160-d055c2174456", "B1809985@student.ctu.edu.vn", true, "Lê Văn Trung", false, null, "B1809985@STUDENT.CTU.EDU.VN", "B1809985", "AQAAAAEAACcQAAAAEBPGG42uQxL/CTm2rU9f/7rSWv7qmRHuFsz/ljJpGo6dnsXosxBuXW2+3CHRuclqSQ==", "098177446185", true, "e30be272-ea82-4852-8d62-52495afa044a", false, "B1809985" },
                    { new Guid("e4dc4f3b-a64e-48a2-858b-6ddeea64d0bb"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "2b27d153-49ea-460d-bdd5-2f0b5cac5655", "B1809984@student.ctu.edu.vn", true, "Lê Trúc", false, null, "B1809984@STUDENT.CTU.EDU.VN", "B1809984", "AQAAAAEAACcQAAAAEKtq/K1qWBBemEsq7MXs5Zoixtzj5m9Z29FLKjTE7Bqtq5B3t2orTBTerznUvkYGJQ==", "098177446184", true, "30d4171a-97b2-4a13-98fb-7587b64344eb", false, "B1809984" },
                    { new Guid("0803dc46-770f-461c-9e73-94deffbc55d7"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ac30a888-09e7-4228-a9d6-b0f601933758", "B1809983@student.ctu.edu.vn", true, "Lê Nghĩa", false, null, "B1809983@STUDENT.CTU.EDU.VN", "B1809983", "AQAAAAEAACcQAAAAEFqVMFMAPjdC7AaGTiUqvGU53fx7spK+CB8mkvl+pqy0lbyYgbCAz4KRI5adUO3t2w==", "098177446183", true, "a5d4c373-370f-4a9c-bc09-023417063276", false, "B1809983" },
                    { new Guid("9cdce684-615e-47be-a1bb-1992bb1a63a5"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "14301a96-88f0-4c42-8667-1492ece99aae", "B1809982@student.ctu.edu.vn", true, "Trần Văn Lộc", false, null, "B1809982@STUDENT.CTU.EDU.VN", "B1809982", "AQAAAAEAACcQAAAAED1z/Yop4BYrdZmhwF97fvG1gBqT5NEO3u/kCM8tVeLNfA3u3eVe/Z3lpVcbTvSamw==", "098177446182", true, "40f13b36-9958-4e90-98f3-f9e200fedc83", false, "B1809982" },
                    { new Guid("6794e692-75be-4592-a787-03eb61a336a8"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "dd6176dc-bc2b-4f20-a646-10d316b260bf", "B1809981@student.ctu.edu.vn", true, "Trần Vy", false, null, "B1809981@STUDENT.CTU.EDU.VN", "B1809981", "AQAAAAEAACcQAAAAEIzLJk7DyGxE6/rIzv3+/qupEIL2+8QCHBEA7C4aq9VVlTfRqPN5VBRhprX7KZ668g==", "098177446181", true, "0ceead2a-3261-4bdf-b91b-769b02199dd0", false, "B1809981" },
                    { new Guid("e1d51102-e29f-4ce2-9a9a-523ededa0f9d"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "5c3c986f-121a-4fde-a373-03054f50318f", "B1809980@student.ctu.edu.vn", true, "Thái Vy", false, null, "B1809980@STUDENT.CTU.EDU.VN", "B1809980", "AQAAAAEAACcQAAAAENi5PSwmvrMgHKxEBg83CKAfnVYctVUm3+mJswEPuuYC6hL45z21nZI6CI0QM7iCXw==", "098177446180", true, "ae7b6571-d0dc-4b96-b7e9-ebc1f5654dd0", false, "B1809980" },
                    { new Guid("29d46f1f-212a-4bc6-848a-ef55c142d330"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "bbbcb67b-9928-47dc-87ed-b0016a94e39f", "B1809979@student.ctu.edu.vn", true, "Trần Văn Lộc", false, null, "B1809979@STUDENT.CTU.EDU.VN", "B1809979", "AQAAAAEAACcQAAAAECnmn0u7byy5TZ2ZdBrEQ3yRHTQx7cJrQhf7GZ/yw+u57+vWC5g9fHQp6inTw6tzvw==", "098177446179", true, "aaad842f-a548-4ee7-9551-18d1955b601b", false, "B1809979" },
                    { new Guid("59640aa2-4d97-46a9-b27e-aabc7d0c8574"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "0b4b9f3a-8498-47d0-9153-569d7418364a", "B1809978@student.ctu.edu.vn", true, "Nguyễn Hoàng Trung", false, null, "B1809978@STUDENT.CTU.EDU.VN", "B1809978", "AQAAAAEAACcQAAAAEGIWhxJ9yST97Gae+ySurXECyg/HMXaj26YoOf0kB7x4tBYQ0Q5zTBjUp+tYPnMVbw==", "098177446178", true, "33068933-4fa1-4b3c-b2a6-f34378191aec", false, "B1809978" },
                    { new Guid("285acc3e-34be-48c4-b4ed-1c5135197cd2"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "346b642d-0e4c-474b-9b4e-f64473252932", "B1809977@student.ctu.edu.vn", true, "Đỗ Lâm", false, null, "B1809977@STUDENT.CTU.EDU.VN", "B1809977", "AQAAAAEAACcQAAAAENPpLNqhbI59eqqs+fwsPf0+W8FXkqSKRoCi60Ps04fh1peOcYAbLK/gP69dKo1iUA==", "098177446177", true, "fac64388-7756-4299-946f-4cf635a2ff4b", false, "B1809977" },
                    { new Guid("05b854a7-dc47-4391-a239-f08becee68b2"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "57559a47-c589-4430-8332-005cd398428c", "B1809976@student.ctu.edu.vn", true, "Trương Văn Nhựt", false, null, "B1809976@STUDENT.CTU.EDU.VN", "B1809976", "AQAAAAEAACcQAAAAEGfwt8N/iUEMCG/ENbSseAjInZ430UN/8kULFXuq9sPUuxrxvvJWovxYPOyMxaDqyg==", "098177446176", true, "46475b81-de5e-49ab-92df-30d346f73526", false, "B1809976" },
                    { new Guid("6713249c-06ec-42af-9003-e1e9f684cb7e"), 0, "Tam Bình, Vĩnh Long", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "01b0ec2d-e59f-41d0-9549-d153dc03101e", "B1809975@student.ctu.edu.vn", true, "Lê Văn Lâm", false, null, "B1809975@STUDENT.CTU.EDU.VN", "B1809975", "AQAAAAEAACcQAAAAEP0MDIsQRTMVn/4wSzc/t0VqhAVXRdFtXrVXR+l9Ht4kvB+t1xl2+O1V5pMOwlNrYQ==", "098177446175", true, "f88a85fa-0ae4-4faf-9505-c6189a37f30e", false, "B1809975" },
                    { new Guid("ae14c8c6-f241-493d-8a7f-ef9a3b35894c"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "13b69436-9ed1-4862-93fc-04b4c6a461d3", "B1809974@student.ctu.edu.vn", true, "Nguyễn Hảo", false, null, "B1809974@STUDENT.CTU.EDU.VN", "B1809974", "AQAAAAEAACcQAAAAEA/u9TQ9yOm1bfsQmzUERbma377e743dw8wr5ljVEIUq5pIJL5A6jruFFwQcSfvBqA==", "098177446174", true, "0256625d-9bae-41dd-b3ef-c62be1cdbecc", false, "B1809974" },
                    { new Guid("a2424871-33a7-4936-9bec-e893532661d0"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "01d1d59f-72f7-4be0-a6d4-4ca90134c688", "B1809989@student.ctu.edu.vn", true, "Trương Văn Thịnh", false, null, "B1809989@STUDENT.CTU.EDU.VN", "B1809989", "AQAAAAEAACcQAAAAEDFii+SKmDJ0kQDX5/F/RPRP8rryXsWzbsKPROFQJqnC+5lb2ODe1CX7g9NnWYhgww==", "098177446189", true, "792c88f5-cd79-4a8e-adbd-daa35d49b609", false, "B1809989" },
                    { new Guid("e91e9822-dc84-46a3-baac-b57f3a3c7679"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "74b4a5f9-7d55-4642-b794-3108618d1226", "B18099109@student.ctu.edu.vn", true, "Trần Văn Nghĩa", false, null, "B18099109@STUDENT.CTU.EDU.VN", "B18099109", "AQAAAAEAACcQAAAAEHMwpoT8vim59W1OAE/CyBsqlAEsPasFpzFt0DOTWI6KoZVlq2cWkJyC4K76y0DOVA==", "0981774461109", true, "e7743f06-55d8-4880-9ffb-3a4645b15923", false, "B18099109" },
                    { new Guid("8139add9-3d31-412c-9aea-02c27e18e3a5"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "570cdc05-f65b-4124-9b95-67c6d60e047c", "B1809990@student.ctu.edu.vn", true, "Đỗ Nghĩa", false, null, "B1809990@STUDENT.CTU.EDU.VN", "B1809990", "AQAAAAEAACcQAAAAEB4mnQMh9cv4qc3oQT9MU1nWNu+bVqshAd81C6gHHt0BIJfnqjaEpCOZO4aaLCrG8g==", "098177446190", true, "f7df5e40-8ced-4b04-8842-ff6ba76c870b", false, "B1809990" },
                    { new Guid("8c9abf69-7fd0-41ee-adda-afc80d39c024"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "fabf67d0-2b6b-48a9-a2fa-c5e7ca31efa3", "B1809992@student.ctu.edu.vn", true, "Nguyễn Trung", false, null, "B1809992@STUDENT.CTU.EDU.VN", "B1809992", "AQAAAAEAACcQAAAAEEQbNIL73j6OhLrGHNwDzZEgck/gve7qizHMq9+wTi8v3a1b8KvIxDB4566OJxR80w==", "098177446192", true, "c0944218-252e-4e46-a220-e80ceab668b6", false, "B1809992" },
                    { new Guid("78bcc23e-c49f-47ba-a5c0-2bb504be62e1"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "7e7471ee-5f9d-4c1f-be28-ed35790b9690", "B18099107@student.ctu.edu.vn", true, "Nguyễn Hoàng Nghĩa", false, null, "B18099107@STUDENT.CTU.EDU.VN", "B18099107", "AQAAAAEAACcQAAAAEF5a4P/WdGoqGkaruDbehiIyPnBcxaTx0mBqmBopJUu/izz/uAwvQu6OAujJGFVNmg==", "0981774461107", true, "4f6b54d0-cb5b-4c74-b63c-b00cbfa5cf0a", false, "B18099107" },
                    { new Guid("c0dbe0c0-f0c3-4843-9d17-295d90644139"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "94be1044-000b-44db-90e3-c5a5576e4800", "B18099106@student.ctu.edu.vn", true, "Trần Lộc", false, null, "B18099106@STUDENT.CTU.EDU.VN", "B18099106", "AQAAAAEAACcQAAAAEC/bajwpCOCIKTAxQ4oLVNnXXN9/WtFdpDf6iysu+t8kjS55aJ7zBMWg0i0tsq7+fg==", "0981774461106", true, "2c5e50b9-995b-4e10-b635-5475fafccbfa", false, "B18099106" },
                    { new Guid("fee5c108-c51b-48a8-b65b-32bf20c05d2f"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "b20db30d-b796-4447-ad17-34fa2f57b3d0", "B18099105@student.ctu.edu.vn", true, "Lê Nhẫn", false, null, "B18099105@STUDENT.CTU.EDU.VN", "B18099105", "AQAAAAEAACcQAAAAEPq/cKMQhm/A/5OmVxS7d35KRY4p6yKn1b6GYOufHcG6iVzeiUyIx+uWb8xpyAoZvg==", "0981774461105", true, "1d0661b6-3c64-4152-8d3d-81ec9e779faf", false, "B18099105" },
                    { new Guid("bd406a97-75b7-4ce6-8177-c813372358a9"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "2037db2b-c41c-4917-ac47-d7cc8a72f87b", "B18099104@student.ctu.edu.vn", true, "Nguyễn Thịnh", false, null, "B18099104@STUDENT.CTU.EDU.VN", "B18099104", "AQAAAAEAACcQAAAAEPgM/wb3369vQ2CUpCEaJUuzkc9Sx7o1UqYEr1MggHM67lgJUlVZmS4lRUpEinPyKA==", "0981774461104", true, "4a639ff2-5c76-4ecc-9058-5bac192ce27a", false, "B18099104" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avatar", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("3ad8c1bf-c652-4ae4-97b1-47fd81de44ce"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "6ae273bd-e21a-4127-8879-0875098ef910", "B18099103@student.ctu.edu.vn", true, "Thái Nhẫn", false, null, "B18099103@STUDENT.CTU.EDU.VN", "B18099103", "AQAAAAEAACcQAAAAEEe2CQkkxSS1MkL2PSvZ5nNcJ9QZOBdpwWUec8OCBnISH4RJy5ThzCQl8duR7rQFvg==", "0981774461103", true, "949af9e0-4a17-43b6-a7c7-67a0ff162ac1", false, "B18099103" },
                    { new Guid("e85534cd-6c64-4c66-ab46-10aa135105b0"), 0, "Hà Tiên, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "659308fc-2790-4118-b14b-497d1e74cca6", "B18099102@student.ctu.edu.vn", true, "Thái Nghĩa", false, null, "B18099102@STUDENT.CTU.EDU.VN", "B18099102", "AQAAAAEAACcQAAAAEPmIpamXXEWK5m1Hr/wjnliQ9ShtV55xAaxxwe1pJFXNav6m1sunIfVWyG6twt9jrg==", "0981774461102", true, "159bf080-f025-4f9b-bd42-7653180d6eb2", false, "B18099102" },
                    { new Guid("b10e29d4-af91-4ef5-a7ca-76bad4515fb3"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "77e7f37e-6b6c-437e-8652-d33b2f8bfadb", "B18099101@student.ctu.edu.vn", true, "Phạm Thị Toàn", false, null, "B18099101@STUDENT.CTU.EDU.VN", "B18099101", "AQAAAAEAACcQAAAAEFNPdaKTdggfDrHE80yuZSFNKraK+IpSAcYcW2Y8WLKTiIk487ecdmPbyUvL1d/n8A==", "0981774461101", true, "3cd78e4e-df93-4e7c-b1e5-163654ada8b3", false, "B18099101" },
                    { new Guid("9279047b-0319-4c2e-a13b-65e247f027a8"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "35984fdc-dd3f-4221-82c1-7ddfd8bd886d", "B1809991@student.ctu.edu.vn", true, "Phạm Thị Khánh", false, null, "B1809991@STUDENT.CTU.EDU.VN", "B1809991", "AQAAAAEAACcQAAAAECIHcrwanEqnUL2UBstGSVYvRuSdVOy1RdxFGh9RUCyCNTdVl8CV1c+EWMpQnYyCVQ==", "098177446191", true, "ea373929-6e40-48b3-9fda-0ee3b66bf4f6", false, "B1809991" },
                    { new Guid("4b85d614-ed82-43da-a408-86ddbfa12e19"), 0, "Tháp Mười, Đồng Tháp", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "66af964d-a582-4b6a-9c9f-44924962cf5c", "B18099100@student.ctu.edu.vn", true, "Phạm Thị Toàn", false, null, "B18099100@STUDENT.CTU.EDU.VN", "B18099100", "AQAAAAEAACcQAAAAEC1VxXSRb2kiRkfU0FBxzxLHRlLS5N6XX2LU6SzxRNStGezse+e+cF1j9M4eiVPZ1w==", "0981774461100", true, "b69b9af6-727c-479c-a3df-4db7b8b2fb53", false, "B18099100" },
                    { new Guid("e90ecdae-8445-47dc-be63-18ca9abac388"), 0, "Ninh Kiêu, Cần Thơ", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "61e1e63b-c60d-4daf-9aee-53def91c34a1", "B1809998@student.ctu.edu.vn", true, "Nguyễn Văn Lâm", false, null, "B1809998@STUDENT.CTU.EDU.VN", "B1809998", "AQAAAAEAACcQAAAAEEOXr9KOQGeffTmlY1Qvn+8zRfL5PAnr5zMO8fiHENBYbDr6CLYVTZ0O17CZAcB5wg==", "098177446198", true, "842ffd03-4797-4902-addd-e6701d137a5b", false, "B1809998" },
                    { new Guid("ef18dd97-1744-4260-9ee4-2a6eadfb36b9"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "d4dc3582-c9a7-4277-9f88-69cf6c6ec37a", "B1809997@student.ctu.edu.vn", true, "Lê Văn Lộc", false, null, "B1809997@STUDENT.CTU.EDU.VN", "B1809997", "AQAAAAEAACcQAAAAEFU0P668FGELdqWVw9VrJ+AYpMfg+Lv6Rg9QkOLQTN5iBSUJbEcd9h8gT3VBsmZyXA==", "098177446197", true, "f80d4e51-4c42-4c3a-8043-5bf899fa6bba", false, "B1809997" },
                    { new Guid("b157360a-7d09-4864-8ca6-9a9c85c7eb2b"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "2272af61-28eb-4f20-b25f-51e750d1608b", "B1809996@student.ctu.edu.vn", true, "Thái Toàn", false, null, "B1809996@STUDENT.CTU.EDU.VN", "B1809996", "AQAAAAEAACcQAAAAEP8atWRnKgzJ+UxZqj3gc9zDPYSJ3xxnRilpzn0hUSpid2bOIwzWNN5yUv2sHAov9g==", "098177446196", true, "3bd1c275-1714-4533-92e5-46e602366633", false, "B1809996" },
                    { new Guid("fa043aa7-470a-4337-9398-9e2801455cb2"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "20f3fe3b-7e5b-4601-b1b5-b573f49cee0e", "B1809995@student.ctu.edu.vn", true, "Lê Vy", false, null, "B1809995@STUDENT.CTU.EDU.VN", "B1809995", "AQAAAAEAACcQAAAAECD++S4EX7Ar+EtyIc6KeGsfpzom7yarKI3o+HPr1b7Hf4EPjNUxJ4I0cbgjXEOwww==", "098177446195", true, "caa983f4-b2bc-4153-90f6-cff8d58f3a7f", false, "B1809995" },
                    { new Guid("0f799f73-41e5-400c-905b-4fa2f680ba95"), 0, "Giồng Riềng, Kiên Giang", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "2827aa18-8017-46a7-b67a-1600a55c0bb5", "B1809994@student.ctu.edu.vn", true, "Nguyễn Trúc", false, null, "B1809994@STUDENT.CTU.EDU.VN", "B1809994", "AQAAAAEAACcQAAAAEFRrcaiWzpPhI3vWYfBpRstm84nIXrHIGivFWyzyOYaMMoUS5gjdiyvUDArB6D9bTQ==", "098177446194", true, "3f594f5e-87a8-424d-9d9d-4e05411a20b2", false, "B1809994" },
                    { new Guid("7c124e41-d330-4985-86ca-d52f16926e35"), 0, "Phong Điền, Cần Thơ", null, new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "b6b9fd09-f7a7-40d2-9a38-f61d877a693f", "B1809993@student.ctu.edu.vn", true, "Đỗ Lộc", false, null, "B1809993@STUDENT.CTU.EDU.VN", "B1809993", "AQAAAAEAACcQAAAAEM0jOzENZjgTWeRcxXe7QyTHwSBMzXeBf87C0RmAdX9oX4Xo2B4/iQeeM4jdVmFECQ==", "098177446193", true, "69a33e3d-6215-4919-9313-14ca492b3f18", false, "B1809993" },
                    { new Guid("df1a75f0-b38e-40fd-be92-d7dacf942841"), 0, "Phú Quốc, Kiên Giang", null, new DateTime(2001, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "7e0dff5c-b5c9-4c1a-a7eb-ade774acf53b", "B1809999@student.ctu.edu.vn", true, "Trương Văn Hảo", false, null, "B1809999@STUDENT.CTU.EDU.VN", "B1809999", "AQAAAAEAACcQAAAAELgj+hxmjSZZ8QuDroguZeiI++jGkkp/Vieu/6ddAXG1yZH0b1VMi8hIlNsn2HmbJQ==", "098177446199", true, "90897949-6c97-4ec5-9da3-ec9fe52cbad7", false, "B1809999" }
                });

            migrationBuilder.InsertData(
                table: "Application",
                columns: new[] { "IdApplication", "Description", "NameApplication" },
                values: new object[,]
                {
                    { 11, "Không có", "Đơn xin miễn học phần Ngoại ngữ, Tin học, GDQP, GDTC (SV in đơn và nộp tại thư viện Khoa CNTT&TT)" },
                    { 12, "Không có", "Đơn xác nhận (sử dụng  ngoài trường - không cần ghi lý do)-SV chỉ chọn 'Nộp đơn' không cần phải in" },
                    { 14, "Không có", "Đơn đề nghị xét miễn và công nhận điểm HP do đã tham gia học tập ở nước ngoài" },
                    { 10, "Không có", "Đơn xin bảo lưu học phần (SV in đơn và nộp tại thư viện khoa CNTT&TT)" },
                    { 13, "Không có", "Đơn xin vắng thi (Điểm I)" },
                    { 9, "Không có", "Đơn xin trợ cấp khó khăn đột xuất" },
                    { 2, "Không có", "Đơn xin xác nhận (sử dụng trong trường)-(SV chỉ chọn 'Nộp đơn' không cần phải in đơn này)" },
                    { 7, "Không có", "Đơn xin thôi học (SV in đơn cho phụ huynh ký và nộp tại VPK, Khoa ký xong SV nộp tại PCTSV)" },
                    { 6, "Không có", "Đơn xin tạm nghỉ học (Để điều trị bệnh: PH ký; GVCV ký; SV nộp tại VPK, Khoa ký xong SV nộp PCTSV)" },
                    { 5, "Không có", "Đơn xin tạm nghỉ học: SV in đơn cho PH ký, GVCV xác nhận, SV nộp tại VPK, Khoa ký xong SV nộp PCTSV" },
                    { 4, "Không có", "Đơn xin xác nhận (sử dụng ngoài trường - mẫu đơn này không dùng để vay vốn theo diện chính sách được)" },
                    { 8, "Không có", "Đơn xét trợ cấp khó khăn đột xuất (SV in đơn, gởi BCS và GVCV xác nhận, sau đó nộp tại VPK)" }
                });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "ClassId", "NameClass", "teacher" },
                values: new object[,]
                {
                    { 1, "Công nghệ thông tin 1", "Lâm Nhựt Khang" },
                    { 2, "Công nghệ thông tin 2", "Trần Cao Đệ" },
                    { 3, "Công nghệ thông tin 3", "Lâm Nhựt Khang" },
                    { 4, "Công nghệ thông tin 4", "Thái Minh Tuấn" },
                    { 5, "Công nghệ thông tin 5", "Thái Minh Tuấn" }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "IdCourse", "NameCourse" },
                values: new object[,]
                {
                    { "K47", "Khóa 47" },
                    { "K46", "Khóa 46" },
                    { "K48", "Khóa 48" },
                    { "K44", "Khóa 44" },
                    { "K45", "Khóa 45" }
                });

            migrationBuilder.InsertData(
                table: "Semester",
                columns: new[] { "IdSemester", "NameSemester" },
                values: new object[,]
                {
                    { 1, "Học kỳ I" },
                    { 2, "Học kỳ II" },
                    { 3, "Học kỳ hè" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "Đã nhận" },
                    { 5, "Đã in" },
                    { 4, "Lưu đơn" },
                    { 2, "Hủy đăng ký" },
                    { 1, "Đăng ký" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Xác nhận yêu cầu" });

            migrationBuilder.InsertData(
                table: "Year",
                columns: new[] { "IdYear", "Year" },
                values: new object[,]
                {
                    { 5, 2022 },
                    { 1, 2018 },
                    { 2, 2019 },
                    { 3, 2020 },
                    { 4, 2021 },
                    { 6, 2023 }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("4ee8867c-feff-42a8-989f-803fb3421351") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("1074b04d-e70a-4e15-b789-a210b8fc64d6") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("a1cc5915-f635-4813-a91f-2998de193566") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("7860d176-cd9b-4fe6-9cdc-c6829bff2304") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("b7fa6ab5-f298-4577-9c95-bb613ed53280") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("a8502205-a79d-47dc-b8f9-8b8df983fe3f") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("e1607665-0b43-4b68-8132-86554a0e5f07") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("4e76012a-7b95-4513-9d46-91cd17741a2c") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("049d0711-2893-4e0c-9830-79fcb87006ed") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("3f87e1c7-be78-484f-8f0f-6789984920b2") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("c9d49df6-86d3-4eed-b145-83f7a89d4e28") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("634bcaf6-f0fb-4057-83c2-c4429a871287") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("d418469e-cfe0-4f78-82e8-c28b3e15c819") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("dabff61d-e067-4c3d-b0ba-834d4c466f97") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("8b12049b-7bb8-4573-b67a-03ffa91995a7") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("9ccd656b-8be9-4cd9-a456-4a4446c7a5e5") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("f21b5736-4e1b-4a01-b665-7fdaeab5e985") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("d6d6d1be-7cea-4f90-8fc8-de96f56550f6") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("de70013a-cf70-4665-9f64-6407039827da") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("b1a6e79d-33b5-4be8-9aa7-60f6ebb15f75") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("b5fe3cd8-1256-463f-9062-e26d905f640d") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("03b705af-6b55-4152-83fd-acbaa5423071") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("2efca73d-089c-433a-a62d-3eb8fe224980") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("25c59a1f-d9d0-4f6c-a391-3467bd68b36a") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("976fe0c7-9396-4458-9e29-d8baa2d2d89f") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("71e479af-3f35-4b06-bce1-a3bd1f4b89f6") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("d7032b13-1712-4afa-a15a-316dcd84b37a") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("087afe30-2643-46e6-9e33-b296b5608b6b") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("f16d9e63-f743-41d3-a2ba-787186a8b719") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("aae9d43f-8ed3-4d2a-8d76-72b0d837efb3") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("c2b58604-3210-456d-ae23-df85644b555c") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("45675f17-ed01-4627-b320-550b81d1895c") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("8d051f8e-9d84-4cc9-90b8-bf58ee39a34e") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("c75efa30-51e7-465b-abd0-0d39e869587f") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("ed67b0c8-b211-48f8-ae85-34564f4629f8") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("8005ba7b-d4b8-4706-86bd-618758b211c0") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("d2ab768b-d650-4b06-a57d-2d7d0bc63813") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("0fa1e14d-4011-40af-b3db-d6dd90089a01") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("95bea5b6-a046-41db-ac2c-e1139a592332") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("27f47fff-2190-418e-a5ea-8ea5878af3ae") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("d9b7128e-5c58-499a-9843-c527a16745c5") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("8a80c189-c866-4a48-b887-cd772d106aa0") }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("0c3ebc2a-cfde-4471-919c-d56c61db0473") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("2af57213-22fa-4fcc-9c18-fa424d54371f") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("17557f2a-be60-49b2-9cab-1bea6fe0fa01") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("9324178a-f398-4e69-bab0-23897f36bb24") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("2a867f04-0fca-4dce-9ab2-27f49d9c7613") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("0afc92af-e16b-4086-bbb1-a7bb3fb0a254") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("4f267353-b003-4b0c-90ff-d20f881da99a") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("528fde9f-b7e9-41a3-867a-a23bcf1c9b21") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("e0ee13a6-a833-40a6-b8a4-a7a021ba3338") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("bd1f6efa-1629-48fe-9ec9-9f03e81d6117") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("abc87ddc-4d6f-4bab-8673-1b72f6ecec91") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("3d44ceab-8216-47bf-90c1-b1ac5607ebc4") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("4d2b4f64-2d07-4d55-b46e-eb4a54774e70") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("f7833a56-4305-4e12-b4ed-5673277653f3") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("f08e285e-7df6-4718-974e-48129e6e9715") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("b2ad653d-3048-49e7-b3ee-f07076a294f9") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("6f71bdc6-4bbd-428a-9c11-f436d37c7737") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("089b2abf-11f1-41db-b40a-04711e05e078") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("dcffb626-b7a0-4204-9a5c-9361e5a9cd5b") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("894ae027-a595-4891-ac27-bcc42b7e8db0") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("68fd5fb8-eb1e-491b-a1f3-eb1798bb2f84") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("1b352943-8a5e-49e7-bd20-73f36b33debe") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("b4704ffc-5b52-4b1f-8bab-9316d2f523ea") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("bed10234-220c-4521-865f-92d9cc2b6f23") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("ae14c8c6-f241-493d-8a7f-ef9a3b35894c") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("29d46f1f-212a-4bc6-848a-ef55c142d330") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("95d89305-f31b-4c24-bd30-eda39134f9cd") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("8139add9-3d31-412c-9aea-02c27e18e3a5") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("baa097d4-56d1-4741-8c47-9744c1e178a0") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("81161214-bbb5-4fae-bce4-7613dc84bb3f") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("503e2155-7fc9-4f96-8bb2-04fe277cdb31") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("b99c7b85-53ee-4067-a41e-403545cdef54") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("eb767016-9e06-4c56-9903-ef9ac85cf402") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("1ce197a9-51ad-4e32-89cf-ccf1d414c087") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("4bdf10e6-4aa1-4bbe-8de5-b58a909a3f3b") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("dbcb0cce-a5e9-436a-8f58-4b848e229a2e") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("2ef30f4d-89a3-47ec-ada1-64795e191e1c") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("1372ffda-c440-4a5e-8987-8856aefdec6f") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("462617dd-e276-4066-946a-79736c9f4d91") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("db77656b-6e0a-49ea-95d1-44d2cfc58558") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("d0f5a293-eb2c-4df5-8a58-a3134fb8be19") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("90a694d2-d5e1-4c8e-a9d4-113f775ccd03") }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("c0dbe0c0-f0c3-4843-9d17-295d90644139") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("e85534cd-6c64-4c66-ab46-10aa135105b0") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("e90ecdae-8445-47dc-be63-18ca9abac388") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("ef18dd97-1744-4260-9ee4-2a6eadfb36b9") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("0f799f73-41e5-400c-905b-4fa2f680ba95") },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), new Guid("9279047b-0319-4c2e-a13b-65e247f027a8") }
                });

            migrationBuilder.InsertData(
                table: "RegisterScoreboard",
                columns: new[] { "IdRegisterScoreboard", "DateReceived", "DateRegister", "IdStatus" },
                values: new object[,]
                {
                    { 140, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8823), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8822), 2 },
                    { 142, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8864), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8863), 2 },
                    { 144, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8905), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8904), 2 },
                    { 152, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9070), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9069), 2 },
                    { 161, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9264), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9263), 2 },
                    { 157, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9175), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9172), 2 },
                    { 162, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9284), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9283), 2 },
                    { 129, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8584), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8583), 2 },
                    { 155, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9132), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9130), 2 },
                    { 128, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8563), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8562), 2 },
                    { 94, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7728), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7726), 2 },
                    { 121, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8414), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8412), 2 },
                    { 120, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8393), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8391), 2 },
                    { 119, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8371), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8370), 2 },
                    { 112, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8224), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8223), 2 },
                    { 105, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8063), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8061), 2 },
                    { 104, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8042), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8040), 2 },
                    { 102, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7999), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7998), 2 },
                    { 98, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7914), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7913), 2 },
                    { 89, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7610), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7609), 2 },
                    { 163, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9305), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9304), 2 },
                    { 125, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8496), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8495), 2 },
                    { 185, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9772), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9770), 2 },
                    { 91, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7660), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7658), 3 },
                    { 191, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9898), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9896), 2 },
                    { 86, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7544), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7542), 2 },
                    { 95, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7851), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7849), 3 },
                    { 88, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7587), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7586), 3 },
                    { 75, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7218), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7217), 3 },
                    { 61, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6916), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6914), 3 },
                    { 60, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6893), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6892), 3 },
                    { 59, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6860), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6858), 3 },
                    { 53, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6731), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6730), 3 },
                    { 52, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6711), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6710), 3 },
                    { 47, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6604), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6603), 3 },
                    { 35, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6341), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6340), 3 }
                });

            migrationBuilder.InsertData(
                table: "RegisterScoreboard",
                columns: new[] { "IdRegisterScoreboard", "DateReceived", "DateRegister", "IdStatus" },
                values: new object[,]
                {
                    { 27, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6164), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6162), 3 },
                    { 26, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6139), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6138), 3 },
                    { 24, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6098), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6097), 3 },
                    { 20, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6013), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6012), 3 },
                    { 18, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5971), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5970), 3 },
                    { 11, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5814), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5813), 3 },
                    { 2, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5552), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5543), 3 },
                    { 1, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(3368), new DateTime(2022, 11, 17, 17, 54, 59, 654, DateTimeKind.Local).AddTicks(6408), 3 },
                    { 200, new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(89), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(88), 2 },
                    { 199, new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(69), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(68), 2 },
                    { 188, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9836), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9835), 2 },
                    { 84, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7501), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7500), 2 },
                    { 44, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6539), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6538), 1 },
                    { 68, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7067), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7066), 2 },
                    { 147, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8967), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8965), 1 },
                    { 146, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8947), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8945), 1 },
                    { 145, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8926), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8925), 1 },
                    { 135, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8713), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8712), 1 },
                    { 131, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8631), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8630), 1 },
                    { 117, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8329), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8328), 1 },
                    { 110, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8176), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8174), 1 },
                    { 103, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8021), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8019), 1 },
                    { 85, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7523), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7521), 1 },
                    { 83, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7481), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7479), 1 },
                    { 77, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7358), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7357), 1 },
                    { 76, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7335), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7238), 1 },
                    { 72, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7151), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7150), 1 },
                    { 66, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7024), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7022), 1 },
                    { 62, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6937), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6936), 1 },
                    { 55, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6774), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6773), 1 },
                    { 49, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6648), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6646), 1 },
                    { 99, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7935), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7933), 3 },
                    { 38, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6406), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6405), 1 },
                    { 29, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6207), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6205), 1 },
                    { 28, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6185), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6184), 1 },
                    { 153, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9091), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9089), 1 },
                    { 71, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7130), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7129), 2 },
                    { 154, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9111), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9109), 1 },
                    { 158, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9202), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9200), 1 },
                    { 64, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6980), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6978), 2 },
                    { 58, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6839), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6838), 2 },
                    { 57, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6817), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6815), 2 }
                });

            migrationBuilder.InsertData(
                table: "RegisterScoreboard",
                columns: new[] { "IdRegisterScoreboard", "DateReceived", "DateRegister", "IdStatus" },
                values: new object[,]
                {
                    { 54, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6753), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6751), 2 },
                    { 46, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6582), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6581), 2 },
                    { 34, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6319), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6317), 2 },
                    { 32, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6272), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6271), 2 },
                    { 17, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5948), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5946), 2 },
                    { 16, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5927), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5925), 2 },
                    { 14, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5876), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5875), 2 },
                    { 10, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5791), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5790), 2 },
                    { 9, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5740), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5738), 2 },
                    { 7, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5695), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5694), 2 },
                    { 4, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5617), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5616), 2 },
                    { 196, new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6), 1 },
                    { 195, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9986), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9984), 1 },
                    { 194, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9964), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9962), 1 },
                    { 190, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9877), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9876), 1 },
                    { 180, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9667), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9666), 1 },
                    { 176, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9583), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9582), 1 },
                    { 170, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9451), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9450), 1 },
                    { 156, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9153), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9151), 1 },
                    { 101, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7978), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7976), 3 },
                    { 143, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8885), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8883), 4 },
                    { 116, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8308), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8307), 3 },
                    { 70, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7109), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7108), 5 },
                    { 67, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7045), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7043), 5 },
                    { 63, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6959), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6957), 5 },
                    { 51, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6689), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6688), 5 },
                    { 45, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6561), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6559), 5 },
                    { 42, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6493), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6491), 5 },
                    { 41, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6471), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6469), 5 },
                    { 40, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6450), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6448), 5 },
                    { 39, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6429), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6427), 5 },
                    { 37, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6385), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6384), 5 },
                    { 36, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6363), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6362), 5 },
                    { 33, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6295), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6293), 5 },
                    { 30, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6229), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6228), 5 },
                    { 25, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6119), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6118), 5 },
                    { 21, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6035), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6034), 5 },
                    { 8, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5717), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5715), 5 },
                    { 6, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5673), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5671), 5 },
                    { 5, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5638), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5637), 5 },
                    { 192, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9922), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9921), 4 },
                    { 183, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9730), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9728), 4 }
                });

            migrationBuilder.InsertData(
                table: "RegisterScoreboard",
                columns: new[] { "IdRegisterScoreboard", "DateReceived", "DateRegister", "IdStatus" },
                values: new object[,]
                {
                    { 181, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9689), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9688), 4 },
                    { 74, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7193), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7192), 5 },
                    { 179, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9646), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9645), 4 },
                    { 78, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7378), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7377), 5 },
                    { 82, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7461), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7459), 5 },
                    { 193, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9943), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9941), 5 },
                    { 186, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9795), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9793), 5 },
                    { 175, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9562), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9561), 5 },
                    { 174, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9537), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9536), 5 },
                    { 173, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9515), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9514), 5 },
                    { 167, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9389), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9388), 5 },
                    { 166, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9368), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9367), 5 },
                    { 165, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9347), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9346), 5 },
                    { 164, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9327), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9325), 5 },
                    { 159, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9223), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9221), 5 },
                    { 150, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9027), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9026), 5 },
                    { 148, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8987), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8985), 5 },
                    { 139, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8798), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8796), 5 },
                    { 137, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8756), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8754), 5 },
                    { 134, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8693), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8692), 5 },
                    { 130, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8610), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8608), 5 },
                    { 124, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8476), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8475), 5 },
                    { 123, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8456), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8455), 5 },
                    { 114, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8267), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8266), 5 },
                    { 97, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7893), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7892), 5 },
                    { 87, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7565), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7564), 5 },
                    { 81, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7440), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7438), 5 },
                    { 178, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9625), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9624), 4 },
                    { 177, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9604), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9603), 4 },
                    { 171, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9472), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9471), 4 },
                    { 56, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6795), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6794), 4 },
                    { 50, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6669), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6667), 4 },
                    { 48, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6626), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6624), 4 },
                    { 43, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6518), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6517), 4 },
                    { 31, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6251), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6250), 4 },
                    { 22, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6056), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6055), 4 },
                    { 19, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5992), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5991), 4 },
                    { 15, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5905), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5896), 4 },
                    { 13, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5855), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5854), 4 },
                    { 12, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5835), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5833), 4 },
                    { 3, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5594), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(5592), 4 },
                    { 189, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9856), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9855), 3 }
                });

            migrationBuilder.InsertData(
                table: "RegisterScoreboard",
                columns: new[] { "IdRegisterScoreboard", "DateReceived", "DateRegister", "IdStatus" },
                values: new object[,]
                {
                    { 187, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9816), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9814), 3 },
                    { 184, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9750), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9749), 3 },
                    { 182, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9710), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9708), 3 },
                    { 172, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9493), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9491), 3 },
                    { 151, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9050), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9047), 3 },
                    { 141, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8843), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8842), 3 },
                    { 133, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8673), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8671), 3 },
                    { 127, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8542), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8541), 3 },
                    { 122, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8435), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8432), 3 },
                    { 65, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7000), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6999), 4 },
                    { 69, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7089), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7087), 4 },
                    { 73, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7172), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7170), 4 },
                    { 79, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7398), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7396), 4 },
                    { 169, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9431), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9429), 4 },
                    { 168, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9410), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9409), 4 },
                    { 160, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9243), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9242), 4 },
                    { 149, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9007), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(9006), 4 },
                    { 23, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6077), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(6076), 1 },
                    { 138, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8777), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8775), 4 },
                    { 136, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8735), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8734), 4 },
                    { 132, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8653), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8651), 4 },
                    { 126, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8517), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8516), 4 },
                    { 118, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8351), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8350), 4 },
                    { 108, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8128), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8127), 3 },
                    { 115, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8288), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8287), 4 },
                    { 111, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8198), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8196), 4 },
                    { 109, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8150), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8149), 4 },
                    { 107, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8104), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8102), 4 },
                    { 106, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8083), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8081), 4 },
                    { 100, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7956), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7954), 4 },
                    { 96, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7873), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7871), 4 },
                    { 93, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7708), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7706), 4 },
                    { 92, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7682), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7681), 4 },
                    { 90, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7639), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7637), 4 },
                    { 80, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7418), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(7417), 4 },
                    { 113, new DateTime(2022, 11, 19, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8246), new DateTime(2022, 11, 17, 17, 54, 59, 667, DateTimeKind.Local).AddTicks(8245), 4 },
                    { 197, new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(27), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(26), 5 },
                    { 198, new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(49), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(47), 5 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "ClassId", "IdCourse", "UserId", "YearEnd", "YearStart" },
                values: new object[,]
                {
                    { 142, 2, "K47", new Guid("dbcb0cce-a5e9-436a-8f58-4b848e229a2e"), 2024, 2021 },
                    { 166, 3, "K45", new Guid("c837618c-dc3f-468b-b237-36f91fe28c89"), 2023, 2020 },
                    { 176, 3, "K45", new Guid("df1a75f0-b38e-40fd-be92-d7dacf942841"), 2023, 2020 },
                    { 194, 4, "K45", new Guid("6794e692-75be-4592-a787-03eb61a336a8"), 2023, 2021 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "ClassId", "IdCourse", "UserId", "YearEnd", "YearStart" },
                values: new object[,]
                {
                    { 203, 4, "K45", new Guid("baa097d4-56d1-4741-8c47-9744c1e178a0"), 2025, 2021 },
                    { 208, 4, "K45", new Guid("8a966b22-74b4-4fdf-b587-4d9f7365e7e9"), 2025, 2020 },
                    { 209, 3, "K45", new Guid("ec7919a8-a3c2-470d-bf29-e5c186a4ac14"), 2023, 2018 },
                    { 165, 1, "K45", new Guid("0e6c1b93-0b8a-45e0-bd03-9f25595c4906"), 2023, 2020 },
                    { 210, 4, "K45", new Guid("c5754a1f-458c-4f1f-8cfe-34446401d826"), 2023, 2019 },
                    { 215, 2, "K45", new Guid("8a6be835-409f-4308-918d-3f395efd9dfd"), 2022, 2018 },
                    { 218, 2, "K45", new Guid("3e727ea2-c051-4eec-8823-830ad7188b3a"), 2023, 2021 },
                    { 226, 2, "K45", new Guid("687c621b-7490-41ac-b133-586cb7bf93f0"), 2022, 2019 },
                    { 228, 2, "K45", new Guid("7e898cd0-2d72-4ac3-b1e6-601e3edfad00"), 2024, 2018 },
                    { 229, 2, "K45", new Guid("7099201c-bc51-4f0e-a888-e68190a878ee"), 2022, 2021 },
                    { 233, 3, "K45", new Guid("a1cc5915-f635-4813-a91f-2998de193566"), 2022, 2018 },
                    { 212, 2, "K45", new Guid("dd0160a4-501c-4f69-a41a-45b2d93969be"), 2025, 2018 },
                    { 163, 1, "K45", new Guid("95bea5b6-a046-41db-ac2c-e1139a592332"), 2023, 2018 },
                    { 155, 3, "K45", new Guid("90a694d2-d5e1-4c8e-a9d4-113f775ccd03"), 2024, 2021 },
                    { 151, 4, "K45", new Guid("503e2155-7fc9-4f96-8bb2-04fe277cdb31"), 2025, 2019 },
                    { 94, 2, "K45", new Guid("522e0e93-008f-4d45-8ec8-1e370538edf4"), 2023, 2020 },
                    { 95, 3, "K45", new Guid("37f49058-2255-418c-8024-57d6b84bdc1e"), 2022, 2020 },
                    { 96, 3, "K45", new Guid("e7ce9ae0-5879-48d2-a52c-e933b77f1f1a"), 2025, 2021 },
                    { 98, 1, "K45", new Guid("d4cbee19-5748-44c4-a61d-dc2ddd2ac53c"), 2022, 2021 },
                    { 102, 2, "K45", new Guid("3e727ea2-c051-4eec-8823-830ad7188b3a"), 2024, 2020 },
                    { 104, 2, "K45", new Guid("98abd83b-2b91-45c9-97f0-cbead87b40a2"), 2025, 2020 },
                    { 105, 2, "K45", new Guid("f16d9e63-f743-41d3-a2ba-787186a8b719"), 2025, 2020 },
                    { 106, 2, "K45", new Guid("6a5c4b2e-5a17-4300-8eb3-dc048436c2ab"), 2022, 2019 },
                    { 110, 2, "K45", new Guid("6eecb6b8-67d5-420c-a111-933ca97a495c"), 2024, 2019 },
                    { 115, 2, "K45", new Guid("50521053-b9d9-464d-b5e8-00c48fc4995c"), 2022, 2019 },
                    { 118, 3, "K45", new Guid("eb2ad632-a9df-4617-a0af-24b1cbecaf7a"), 2022, 2021 },
                    { 119, 2, "K45", new Guid("a0efc4f1-e304-4c3d-ac7c-8ea7912c3500"), 2024, 2018 },
                    { 131, 1, "K45", new Guid("a01af778-d757-4022-8673-44baab055929"), 2024, 2020 },
                    { 137, 1, "K45", new Guid("e6316e92-49ce-45df-b25c-2b6a9792f261"), 2023, 2018 },
                    { 141, 4, "K45", new Guid("522e0e93-008f-4d45-8ec8-1e370538edf4"), 2022, 2018 },
                    { 235, 1, "K45", new Guid("dd60dbb4-2ca7-4ce3-b6bc-b0d17ffb300b"), 2025, 2019 },
                    { 237, 4, "K45", new Guid("c0dbe0c0-f0c3-4843-9d17-295d90644139"), 2023, 2019 },
                    { 241, 3, "K45", new Guid("bfefbec5-c208-42d7-9883-75ac611aa69f"), 2025, 2021 },
                    { 250, 2, "K45", new Guid("30b25c79-dbc5-41f6-8934-69f4f71b3598"), 2023, 2019 },
                    { 56, 1, "K46", new Guid("5dd9a5d7-c2ca-40c7-a066-f626a8f2d2d2"), 2023, 2018 },
                    { 68, 1, "K46", new Guid("ed80b63f-3476-4ecb-8b72-90c81251d3be"), 2022, 2020 },
                    { 83, 2, "K46", new Guid("7c3810f4-46c5-4fe6-9641-71f4c7c646b4"), 2022, 2019 },
                    { 87, 1, "K46", new Guid("86cdf93f-7053-493d-a389-191383b73a9b"), 2024, 2019 },
                    { 100, 2, "K46", new Guid("81161214-bbb5-4fae-bce4-7613dc84bb3f"), 2022, 2018 },
                    { 103, 3, "K46", new Guid("6838d7c4-66e5-4de7-a1b6-aa49064874fa"), 2023, 2019 },
                    { 112, 3, "K46", new Guid("c9d49df6-86d3-4eed-b145-83f7a89d4e28"), 2025, 2021 },
                    { 116, 4, "K46", new Guid("a55e3e12-6287-4c86-a86f-89f004f332ed"), 2024, 2021 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "ClassId", "IdCourse", "UserId", "YearEnd", "YearStart" },
                values: new object[,]
                {
                    { 123, 4, "K46", new Guid("8a966b22-74b4-4fdf-b587-4d9f7365e7e9"), 2025, 2018 },
                    { 129, 3, "K46", new Guid("5af29074-61c8-4718-9389-53e98d3572df"), 2022, 2021 },
                    { 130, 2, "K46", new Guid("24d83dd1-5d54-4226-ba5d-ae95b87dbc39"), 2024, 2019 },
                    { 134, 1, "K46", new Guid("83eaaa1e-d4ef-49ed-ae42-ef89a4bc7373"), 2022, 2021 },
                    { 136, 4, "K46", new Guid("3a69e6e1-c0fb-44f1-aafc-61fccc441229"), 2025, 2020 },
                    { 138, 4, "K46", new Guid("e6d20114-5812-4bd7-8690-0b1dd547b13b"), 2025, 2019 },
                    { 145, 2, "K46", new Guid("ed67b0c8-b211-48f8-ae85-34564f4629f8"), 2024, 2021 },
                    { 54, 4, "K46", new Guid("c86a5fb6-07df-4994-8f29-028964372568"), 2024, 2021 },
                    { 90, 4, "K45", new Guid("257a18c5-d271-43f1-b209-730e310cffce"), 2022, 2019 },
                    { 53, 3, "K46", new Guid("84fdf487-ca09-4e9f-901f-55d988398187"), 2025, 2019 },
                    { 42, 2, "K46", new Guid("98c56511-afa2-4f6e-b110-4d44836299e8"), 2022, 2020 },
                    { 255, 1, "K45", new Guid("d87f20ae-a7ca-4ea1-8fe3-9259e62e34db"), 2024, 2019 },
                    { 272, 1, "K45", new Guid("95d89305-f31b-4c24-bd30-eda39134f9cd"), 2024, 2019 },
                    { 275, 1, "K45", new Guid("98dccdd4-d8ae-4d50-bf78-709f0aaa21d5"), 2024, 2018 },
                    { 276, 1, "K45", new Guid("6838d7c4-66e5-4de7-a1b6-aa49064874fa"), 2024, 2018 },
                    { 277, 4, "K45", new Guid("7e898cd0-2d72-4ac3-b1e6-601e3edfad00"), 2023, 2021 },
                    { 283, 2, "K45", new Guid("22992e67-305a-466d-a1be-707fa8b37b08"), 2022, 2021 },
                    { 291, 3, "K45", new Guid("c2b58604-3210-456d-ae23-df85644b555c"), 2023, 2018 },
                    { 292, 1, "K45", new Guid("32f88a33-e861-4dc3-af21-213ed3ac8a80"), 2025, 2019 },
                    { 295, 3, "K45", new Guid("03b705af-6b55-4152-83fd-acbaa5423071"), 2025, 2018 },
                    { 297, 4, "K45", new Guid("4ee8867c-feff-42a8-989f-803fb3421351"), 2023, 2021 },
                    { 1, 3, "K46", new Guid("ed67b0c8-b211-48f8-ae85-34564f4629f8"), 2022, 2021 },
                    { 14, 1, "K46", new Guid("afca891b-c143-4bd1-b2d0-d26cc8775e17"), 2024, 2019 },
                    { 22, 4, "K46", new Guid("d9b7128e-5c58-499a-9843-c527a16745c5"), 2024, 2021 },
                    { 36, 2, "K46", new Guid("e1607665-0b43-4b68-8132-86554a0e5f07"), 2024, 2020 },
                    { 39, 3, "K46", new Guid("dad2543e-6ce6-4db3-be0e-42361aae6382"), 2022, 2018 },
                    { 51, 2, "K46", new Guid("2a867f04-0fca-4dce-9ab2-27f49d9c7613"), 2025, 2019 },
                    { 146, 3, "K46", new Guid("882dc940-9666-4e52-82b1-83f4b2bb603f"), 2024, 2020 },
                    { 88, 4, "K45", new Guid("3fd80720-04a1-4c86-954e-41377a8a2f4e"), 2022, 2021 },
                    { 82, 3, "K45", new Guid("cc571974-7fc5-43f9-ab15-8f17111cd6f7"), 2023, 2019 },
                    { 111, 3, "K44", new Guid("05b854a7-dc47-4391-a239-f08becee68b2"), 2024, 2019 },
                    { 117, 1, "K44", new Guid("0fa1e14d-4011-40af-b3db-d6dd90089a01"), 2023, 2021 },
                    { 120, 4, "K44", new Guid("214abb3d-1d2c-4f84-8d1d-3f4710891cdd"), 2024, 2019 },
                    { 125, 1, "K44", new Guid("9a645d43-0bc2-4008-a790-1a6d3b996543"), 2025, 2021 },
                    { 128, 4, "K44", new Guid("98df4859-492b-400e-9bff-9c106ac355fd"), 2024, 2020 },
                    { 135, 4, "K44", new Guid("7ad19b1e-fd5e-4aee-ad80-d206e07ee20c"), 2025, 2020 },
                    { 107, 3, "K44", new Guid("4d9d2c15-bdf6-4211-8dda-cc80b669755c"), 2023, 2020 },
                    { 149, 3, "K44", new Guid("37f49058-2255-418c-8024-57d6b84bdc1e"), 2024, 2020 },
                    { 153, 3, "K44", new Guid("45675f17-ed01-4627-b320-550b81d1895c"), 2024, 2019 },
                    { 154, 1, "K44", new Guid("6794e692-75be-4592-a787-03eb61a336a8"), 2022, 2020 },
                    { 169, 4, "K44", new Guid("c837618c-dc3f-468b-b237-36f91fe28c89"), 2025, 2020 },
                    { 170, 1, "K44", new Guid("05ef55e7-1566-4e42-a955-020e90a69802"), 2023, 2019 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "ClassId", "IdCourse", "UserId", "YearEnd", "YearStart" },
                values: new object[,]
                {
                    { 173, 1, "K44", new Guid("9ac029c2-60a9-43b7-aaff-2a8440035f39"), 2024, 2019 },
                    { 175, 1, "K44", new Guid("cc571974-7fc5-43f9-ab15-8f17111cd6f7"), 2025, 2021 },
                    { 152, 1, "K44", new Guid("7c3810f4-46c5-4fe6-9641-71f4c7c646b4"), 2022, 2020 },
                    { 97, 3, "K44", new Guid("98abd83b-2b91-45c9-97f0-cbead87b40a2"), 2022, 2018 },
                    { 91, 1, "K44", new Guid("7099201c-bc51-4f0e-a888-e68190a878ee"), 2024, 2021 },
                    { 84, 2, "K44", new Guid("29d46f1f-212a-4bc6-848a-ef55c142d330"), 2023, 2021 },
                    { 10, 1, "K44", new Guid("611dfe3b-6099-4dc5-81ac-59f0bea04757"), 2023, 2019 },
                    { 11, 4, "K44", new Guid("1074b04d-e70a-4e15-b789-a210b8fc64d6"), 2025, 2018 },
                    { 16, 2, "K44", new Guid("8be85bd5-1095-46dd-98de-f158021c9f12"), 2023, 2021 },
                    { 18, 3, "K44", new Guid("882dc940-9666-4e52-82b1-83f4b2bb603f"), 2025, 2019 },
                    { 32, 4, "K44", new Guid("c0dbe0c0-f0c3-4843-9d17-295d90644139"), 2023, 2019 },
                    { 37, 2, "K44", new Guid("db77656b-6e0a-49ea-95d1-44d2cfc58558"), 2023, 2019 },
                    { 41, 2, "K44", new Guid("9cdce684-615e-47be-a1bb-1992bb1a63a5"), 2022, 2019 },
                    { 46, 1, "K44", new Guid("bd94c7d1-68d8-4447-9654-0d820a8ccc69"), 2022, 2021 },
                    { 50, 3, "K44", new Guid("d2ab768b-d650-4b06-a57d-2d7d0bc63813"), 2023, 2020 },
                    { 59, 2, "K44", new Guid("f7833a56-4305-4e12-b4ed-5673277653f3"), 2024, 2021 },
                    { 63, 4, "K44", new Guid("9324178a-f398-4e69-bab0-23897f36bb24"), 2023, 2020 },
                    { 67, 2, "K44", new Guid("a01af778-d757-4022-8673-44baab055929"), 2023, 2021 },
                    { 70, 1, "K44", new Guid("eef44e4d-8de7-4675-8949-84bf629809b9"), 2025, 2019 },
                    { 72, 3, "K44", new Guid("c5a4ac50-9fdc-4715-bc0c-ba0645587b9d"), 2022, 2021 },
                    { 73, 2, "K44", new Guid("bed10234-220c-4521-865f-92d9cc2b6f23"), 2023, 2019 },
                    { 177, 2, "K44", new Guid("90022be0-2de5-4ea3-afc7-9d93d2fe56c0"), 2023, 2018 },
                    { 192, 4, "K44", new Guid("50a3a8dc-d512-4f52-981b-b3942710e174"), 2023, 2021 },
                    { 199, 4, "K44", new Guid("b10e29d4-af91-4ef5-a7ca-76bad4515fb3"), 2025, 2019 },
                    { 204, 3, "K44", new Guid("ae14c8c6-f241-493d-8a7f-ef9a3b35894c"), 2022, 2021 },
                    { 23, 1, "K45", new Guid("765974e9-db14-4a38-993f-c541da5d5996"), 2025, 2019 },
                    { 28, 1, "K45", new Guid("aff5e306-75cb-4779-b1ab-3d6cf23de72f"), 2024, 2019 },
                    { 29, 2, "K45", new Guid("3f87e1c7-be78-484f-8f0f-6789984920b2"), 2022, 2020 },
                    { 44, 1, "K45", new Guid("05ef55e7-1566-4e42-a955-020e90a69802"), 2025, 2021 },
                    { 47, 1, "K45", new Guid("d7032b13-1712-4afa-a15a-316dcd84b37a"), 2025, 2020 },
                    { 49, 2, "K45", new Guid("25711150-b78e-4046-a858-1f526eae5443"), 2024, 2019 },
                    { 52, 3, "K45", new Guid("1b3baea5-cd59-4166-9ed6-feb23a451b82"), 2024, 2021 },
                    { 57, 4, "K45", new Guid("5af29074-61c8-4718-9389-53e98d3572df"), 2023, 2020 },
                    { 61, 4, "K45", new Guid("8ac6839e-3dc9-447e-ac60-675f2ceb7b92"), 2025, 2021 },
                    { 65, 1, "K45", new Guid("98dccdd4-d8ae-4d50-bf78-709f0aaa21d5"), 2022, 2020 },
                    { 66, 3, "K45", new Guid("4d2b4f64-2d07-4d55-b46e-eb4a54774e70"), 2023, 2018 },
                    { 76, 3, "K45", new Guid("d623f5be-a2b6-4db3-9b6c-9f2e62175c88"), 2023, 2018 },
                    { 77, 1, "K45", new Guid("8a6be835-409f-4308-918d-3f395efd9dfd"), 2023, 2019 },
                    { 78, 2, "K45", new Guid("87dbd58a-08be-4527-9f0b-a5637720c6bd"), 2023, 2021 },
                    { 80, 4, "K45", new Guid("dabff61d-e067-4c3d-b0ba-834d4c466f97"), 2025, 2018 },
                    { 9, 4, "K45", new Guid("15c42bb2-37a3-49f9-859f-119ca3b42c20"), 2023, 2021 },
                    { 85, 4, "K45", new Guid("0803dc46-770f-461c-9e73-94deffbc55d7"), 2023, 2020 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "ClassId", "IdCourse", "UserId", "YearEnd", "YearStart" },
                values: new object[,]
                {
                    { 290, 2, "K44", new Guid("4ee8867c-feff-42a8-989f-803fb3421351"), 2022, 2021 },
                    { 288, 2, "K44", new Guid("a8502205-a79d-47dc-b8f9-8b8df983fe3f"), 2022, 2020 },
                    { 206, 1, "K44", new Guid("c837618c-dc3f-468b-b237-36f91fe28c89"), 2022, 2018 },
                    { 211, 3, "K44", new Guid("9279047b-0319-4c2e-a13b-65e247f027a8"), 2022, 2019 },
                    { 216, 1, "K44", new Guid("f7833a56-4305-4e12-b4ed-5673277653f3"), 2022, 2021 },
                    { 217, 4, "K44", new Guid("1074b04d-e70a-4e15-b789-a210b8fc64d6"), 2025, 2021 },
                    { 219, 4, "K44", new Guid("95bea5b6-a046-41db-ac2c-e1139a592332"), 2025, 2021 },
                    { 221, 4, "K44", new Guid("59640aa2-4d97-46a9-b27e-aabc7d0c8574"), 2024, 2021 },
                    { 223, 2, "K44", new Guid("9ac029c2-60a9-43b7-aaff-2a8440035f39"), 2024, 2021 },
                    { 236, 1, "K44", new Guid("e91a793c-9caa-48ff-a09c-1de8bd093fb2"), 2023, 2021 },
                    { 246, 2, "K44", new Guid("7ad19b1e-fd5e-4aee-ad80-d206e07ee20c"), 2022, 2019 },
                    { 247, 1, "K44", new Guid("0afc92af-e16b-4086-bbb1-a7bb3fb0a254"), 2022, 2020 },
                    { 253, 3, "K44", new Guid("3d44ceab-8216-47bf-90c1-b1ac5607ebc4"), 2022, 2020 },
                    { 260, 3, "K44", new Guid("71e479af-3f35-4b06-bce1-a3bd1f4b89f6"), 2023, 2021 },
                    { 267, 3, "K44", new Guid("cc571974-7fc5-43f9-ab15-8f17111cd6f7"), 2023, 2018 },
                    { 274, 3, "K44", new Guid("90022be0-2de5-4ea3-afc7-9d93d2fe56c0"), 2023, 2020 },
                    { 287, 4, "K44", new Guid("b7fa6ab5-f298-4577-9c95-bb613ed53280"), 2025, 2019 },
                    { 289, 2, "K44", new Guid("611dfe3b-6099-4dc5-81ac-59f0bea04757"), 2025, 2021 },
                    { 140, 4, "K47", new Guid("480bd134-5225-4e70-958d-bd7e5824fea7"), 2025, 2018 },
                    { 148, 2, "K46", new Guid("c0dbe0c0-f0c3-4843-9d17-295d90644139"), 2022, 2018 },
                    { 159, 1, "K46", new Guid("b157360a-7d09-4864-8ca6-9a9c85c7eb2b"), 2023, 2021 },
                    { 108, 1, "K48", new Guid("634bcaf6-f0fb-4057-83c2-c4429a871287"), 2023, 2018 },
                    { 101, 1, "K48", new Guid("bbd850cb-3ea8-47b7-8e67-4799b79dd4b4"), 2025, 2021 },
                    { 93, 1, "K48", new Guid("7e898cd0-2d72-4ac3-b1e6-601e3edfad00"), 2023, 2021 },
                    { 92, 3, "K48", new Guid("f0fb7d04-d4b1-4e52-b072-0e99de40a3e5"), 2025, 2018 },
                    { 86, 2, "K48", new Guid("43c0f9e8-a21f-43b2-949e-850d9ecf40f5"), 2023, 2019 },
                    { 81, 4, "K48", new Guid("ae14c8c6-f241-493d-8a7f-ef9a3b35894c"), 2023, 2019 },
                    { 109, 3, "K48", new Guid("a0efc4f1-e304-4c3d-ac7c-8ea7912c3500"), 2025, 2018 },
                    { 58, 2, "K48", new Guid("462617dd-e276-4066-946a-79736c9f4d91"), 2023, 2021 },
                    { 34, 4, "K48", new Guid("09a1b152-971e-4a25-b550-85439e305fe5"), 2022, 2018 },
                    { 31, 4, "K48", new Guid("25711150-b78e-4046-a858-1f526eae5443"), 2025, 2019 },
                    { 30, 3, "K48", new Guid("e0ee13a6-a833-40a6-b8a4-a7a021ba3338"), 2022, 2019 },
                    { 25, 4, "K48", new Guid("087afe30-2643-46e6-9e33-b296b5608b6b"), 2023, 2020 },
                    { 21, 2, "K48", new Guid("ec7919a8-a3c2-470d-bf29-e5c186a4ac14"), 2022, 2021 },
                    { 20, 2, "K48", new Guid("71e479af-3f35-4b06-bce1-a3bd1f4b89f6"), 2025, 2020 },
                    { 45, 3, "K48", new Guid("e920a5a4-3415-4a1d-8e2a-8982c4386ea6"), 2023, 2021 },
                    { 113, 4, "K48", new Guid("d623f5be-a2b6-4db3-9b6c-9f2e62175c88"), 2024, 2020 },
                    { 114, 2, "K48", new Guid("17557f2a-be60-49b2-9cab-1bea6fe0fa01"), 2024, 2021 },
                    { 121, 4, "K48", new Guid("8a80c189-c866-4a48-b887-cd772d106aa0"), 2022, 2021 },
                    { 186, 1, "K48", new Guid("f4a99026-6133-4da8-a597-633c700b8588"), 2022, 2020 },
                    { 184, 2, "K48", new Guid("cb17cf1a-6b63-4585-a8b5-d02f80d2fe4a"), 2024, 2018 },
                    { 182, 3, "K48", new Guid("1074b04d-e70a-4e15-b789-a210b8fc64d6"), 2022, 2019 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "ClassId", "IdCourse", "UserId", "YearEnd", "YearStart" },
                values: new object[,]
                {
                    { 180, 4, "K48", new Guid("95bea5b6-a046-41db-ac2c-e1139a592332"), 2025, 2018 },
                    { 174, 4, "K48", new Guid("37f49058-2255-418c-8024-57d6b84bdc1e"), 2023, 2018 },
                    { 171, 2, "K48", new Guid("687c621b-7490-41ac-b133-586cb7bf93f0"), 2024, 2018 },
                    { 167, 2, "K48", new Guid("80f66855-695e-42bd-86df-adfcc096a6fa"), 2025, 2020 },
                    { 164, 3, "K48", new Guid("c2b58604-3210-456d-ae23-df85644b555c"), 2025, 2021 },
                    { 158, 4, "K48", new Guid("c9d49df6-86d3-4eed-b145-83f7a89d4e28"), 2022, 2021 },
                    { 157, 2, "K48", new Guid("dc2c4ceb-be0b-4342-888b-c4a40c3d52a3"), 2023, 2021 },
                    { 156, 4, "K48", new Guid("0d5327a5-6b00-4c5b-8983-3ec8d6e965fc"), 2024, 2018 },
                    { 147, 3, "K48", new Guid("6ee1ee30-2953-4c3e-8ff8-0007b12bc8b9"), 2024, 2021 },
                    { 143, 1, "K48", new Guid("f7833a56-4305-4e12-b4ed-5673277653f3"), 2022, 2019 },
                    { 133, 4, "K48", new Guid("a2424871-33a7-4936-9bec-e893532661d0"), 2024, 2019 },
                    { 124, 4, "K48", new Guid("5af29074-61c8-4718-9389-53e98d3572df"), 2025, 2018 },
                    { 19, 2, "K48", new Guid("dd60dbb4-2ca7-4ce3-b6bc-b0d17ffb300b"), 2022, 2019 },
                    { 15, 2, "K48", new Guid("9a645d43-0bc2-4008-a790-1a6d3b996543"), 2022, 2021 },
                    { 7, 2, "K48", new Guid("fe4c6c23-0cfc-4b25-aeb0-d4c160c48306"), 2024, 2018 },
                    { 6, 1, "K48", new Guid("d89edb22-9f86-4a86-91cc-953fe5dc1612"), 2023, 2021 },
                    { 239, 2, "K47", new Guid("e1607665-0b43-4b68-8132-86554a0e5f07"), 2025, 2021 },
                    { 238, 2, "K47", new Guid("0747e4f7-b6cd-473d-b17a-d0c8e3066f2f"), 2025, 2021 },
                    { 234, 2, "K47", new Guid("f829d5ff-00be-4368-b49a-0588c291c448"), 2022, 2019 },
                    { 231, 1, "K47", new Guid("0cdaa3a4-1d98-470a-82c6-e4f5f52e7606"), 2024, 2020 },
                    { 230, 4, "K47", new Guid("cb17cf1a-6b63-4585-a8b5-d02f80d2fe4a"), 2025, 2018 },
                    { 222, 4, "K47", new Guid("15607863-96fb-4e17-bc19-8f85ee9eb85e"), 2022, 2019 },
                    { 220, 1, "K47", new Guid("b99c7b85-53ee-4067-a41e-403545cdef54"), 2023, 2021 },
                    { 213, 3, "K47", new Guid("22f56273-134d-440f-8404-c93cb419f931"), 2022, 2021 },
                    { 205, 3, "K47", new Guid("1ce197a9-51ad-4e32-89cf-ccf1d414c087"), 2023, 2018 },
                    { 197, 4, "K47", new Guid("d8a24afc-ea59-4553-80f8-538d2787faae"), 2023, 2021 },
                    { 185, 2, "K47", new Guid("59640aa2-4d97-46a9-b27e-aabc7d0c8574"), 2022, 2018 },
                    { 139, 3, "K47", new Guid("bd1f6efa-1629-48fe-9ec9-9f03e81d6117"), 2025, 2021 },
                    { 178, 2, "K47", new Guid("aa14e86a-6f2c-4200-850c-7dd7360a08c9"), 2025, 2021 },
                    { 162, 4, "K47", new Guid("bd1f6efa-1629-48fe-9ec9-9f03e81d6117"), 2023, 2020 },
                    { 144, 2, "K47", new Guid("9ac029c2-60a9-43b7-aaff-2a8440035f39"), 2025, 2018 },
                    { 240, 1, "K47", new Guid("e1d51102-e29f-4ce2-9a9a-523ededa0f9d"), 2023, 2020 },
                    { 188, 4, "K48", new Guid("78bcc23e-c49f-47ba-a5c0-2bb504be62e1"), 2022, 2020 },
                    { 242, 1, "K47", new Guid("214abb3d-1d2c-4f84-8d1d-3f4710891cdd"), 2025, 2020 },
                    { 249, 4, "K47", new Guid("e9a35a9e-b65b-406d-af8c-69d1fc2184f3"), 2024, 2021 },
                    { 5, 4, "K48", new Guid("290053b1-5997-4822-9dc4-8e318761d6aa"), 2022, 2019 },
                    { 3, 4, "K48", new Guid("30b25c79-dbc5-41f6-8934-69f4f71b3598"), 2025, 2018 },
                    { 2, 2, "K48", new Guid("c1400430-6785-4c37-9bde-3bc2cea7b75e"), 2025, 2021 },
                    { 298, 3, "K47", new Guid("b10e29d4-af91-4ef5-a7ca-76bad4515fb3"), 2025, 2018 },
                    { 293, 1, "K47", new Guid("4757251e-a13e-4c5a-9a22-02394e7fee19"), 2022, 2019 },
                    { 286, 1, "K47", new Guid("3fd80720-04a1-4c86-954e-41377a8a2f4e"), 2023, 2018 },
                    { 284, 2, "K47", new Guid("50521053-b9d9-464d-b5e8-00c48fc4995c"), 2024, 2019 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "ClassId", "IdCourse", "UserId", "YearEnd", "YearStart" },
                values: new object[,]
                {
                    { 273, 3, "K47", new Guid("4d9d2c15-bdf6-4211-8dda-cc80b669755c"), 2023, 2020 },
                    { 268, 2, "K47", new Guid("b7b8e098-07c8-4f93-a4da-216f21c92980"), 2022, 2019 },
                    { 266, 2, "K47", new Guid("3fd80720-04a1-4c86-954e-41377a8a2f4e"), 2024, 2020 },
                    { 264, 1, "K47", new Guid("64e720d4-9d05-485a-bd34-8ad675af5d95"), 2023, 2019 },
                    { 261, 4, "K47", new Guid("5dd9a5d7-c2ca-40c7-a066-f626a8f2d2d2"), 2024, 2019 },
                    { 257, 3, "K47", new Guid("b1a6e79d-33b5-4be8-9aa7-60f6ebb15f75"), 2023, 2018 },
                    { 256, 1, "K47", new Guid("dc2c4ceb-be0b-4342-888b-c4a40c3d52a3"), 2023, 2020 },
                    { 254, 3, "K47", new Guid("538aadc3-d225-4d2b-ae9e-2369f0b2cd1b"), 2022, 2019 },
                    { 248, 1, "K47", new Guid("bfefbec5-c208-42d7-9883-75ac611aa69f"), 2023, 2020 },
                    { 150, 3, "K46", new Guid("ef18dd97-1744-4260-9ee4-2a6eadfb36b9"), 2025, 2020 },
                    { 189, 4, "K48", new Guid("bb8fad11-9838-42f7-97b0-99e56ff1dced"), 2022, 2020 },
                    { 193, 1, "K48", new Guid("bd342e77-34b4-4c9b-b723-f7c184129b8c"), 2022, 2018 },
                    { 4, 2, "K47", new Guid("43c0f9e8-a21f-43b2-949e-850d9ecf40f5"), 2023, 2021 },
                    { 8, 3, "K47", new Guid("0803dc46-770f-461c-9e73-94deffbc55d7"), 2022, 2020 },
                    { 12, 3, "K47", new Guid("f16d9e63-f743-41d3-a2ba-787186a8b719"), 2023, 2020 },
                    { 13, 2, "K47", new Guid("0cdaa3a4-1d98-470a-82c6-e4f5f52e7606"), 2022, 2019 },
                    { 17, 4, "K47", new Guid("87dbd58a-08be-4527-9f0b-a5637720c6bd"), 2024, 2020 },
                    { 24, 1, "K47", new Guid("c837618c-dc3f-468b-b237-36f91fe28c89"), 2023, 2020 },
                    { 296, 4, "K46", new Guid("d623f5be-a2b6-4db3-9b6c-9f2e62175c88"), 2022, 2020 },
                    { 26, 3, "K47", new Guid("0afc92af-e16b-4086-bbb1-a7bb3fb0a254"), 2024, 2020 },
                    { 33, 3, "K47", new Guid("f3205131-ae39-4762-a936-f8cfed27d96b"), 2023, 2019 },
                    { 35, 2, "K47", new Guid("4e76012a-7b95-4513-9d46-91cd17741a2c"), 2024, 2018 },
                    { 38, 1, "K47", new Guid("0d5327a5-6b00-4c5b-8983-3ec8d6e965fc"), 2022, 2019 },
                    { 40, 2, "K47", new Guid("496b8668-9b42-4344-bf6b-3a59b5fc5359"), 2025, 2019 },
                    { 43, 2, "K47", new Guid("8a80c189-c866-4a48-b887-cd772d106aa0"), 2024, 2020 },
                    { 48, 4, "K47", new Guid("e6d2c7ba-035a-4d54-8bb9-00db7e5c6173"), 2022, 2019 },
                    { 27, 2, "K47", new Guid("50521053-b9d9-464d-b5e8-00c48fc4995c"), 2023, 2018 },
                    { 294, 4, "K46", new Guid("717e7689-05f3-4c31-a82a-174ae6453cc6"), 2023, 2018 },
                    { 279, 3, "K46", new Guid("1b3baea5-cd59-4166-9ed6-feb23a451b82"), 2022, 2021 },
                    { 278, 2, "K46", new Guid("c86a5fb6-07df-4994-8f29-028964372568"), 2022, 2018 },
                    { 160, 4, "K46", new Guid("290053b1-5997-4822-9dc4-8e318761d6aa"), 2024, 2018 },
                    { 161, 3, "K46", new Guid("8a966b22-74b4-4fdf-b587-4d9f7365e7e9"), 2023, 2019 },
                    { 168, 3, "K46", new Guid("dcffb626-b7a0-4204-9a5c-9361e5a9cd5b"), 2022, 2019 },
                    { 172, 4, "K46", new Guid("bbd850cb-3ea8-47b7-8e67-4799b79dd4b4"), 2022, 2021 },
                    { 179, 2, "K46", new Guid("9ccd656b-8be9-4cd9-a456-4a4446c7a5e5"), 2022, 2019 },
                    { 181, 2, "K46", new Guid("6f71bdc6-4bbd-428a-9c11-f436d37c7737"), 2024, 2018 },
                    { 187, 3, "K46", new Guid("9a493d2d-3671-4c4b-9dd2-492095e5ab56"), 2024, 2020 },
                    { 191, 3, "K46", new Guid("6ee1ee30-2953-4c3e-8ff8-0007b12bc8b9"), 2022, 2019 },
                    { 225, 1, "K46", new Guid("ef18dd97-1744-4260-9ee4-2a6eadfb36b9"), 2022, 2018 },
                    { 244, 4, "K46", new Guid("e6a497f9-2895-40ab-96a4-1a17c52655a0"), 2024, 2021 },
                    { 245, 2, "K46", new Guid("8c9abf69-7fd0-41ee-adda-afc80d39c024"), 2024, 2019 },
                    { 258, 3, "K46", new Guid("e4dc4f3b-a64e-48a2-858b-6ddeea64d0bb"), 2023, 2019 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "ClassId", "IdCourse", "UserId", "YearEnd", "YearStart" },
                values: new object[,]
                {
                    { 259, 3, "K46", new Guid("95d89305-f31b-4c24-bd30-eda39134f9cd"), 2025, 2018 },
                    { 269, 3, "K46", new Guid("e85534cd-6c64-4c66-ab46-10aa135105b0"), 2025, 2018 },
                    { 270, 2, "K46", new Guid("8ac6839e-3dc9-447e-ac60-675f2ceb7b92"), 2025, 2019 },
                    { 55, 4, "K47", new Guid("78bcc23e-c49f-47ba-a5c0-2bb504be62e1"), 2024, 2021 },
                    { 60, 2, "K47", new Guid("90022be0-2de5-4ea3-afc7-9d93d2fe56c0"), 2022, 2019 },
                    { 62, 1, "K47", new Guid("a48602b9-1f8a-4240-b394-0a19a01a0cd0"), 2023, 2021 },
                    { 64, 4, "K47", new Guid("3d44ceab-8216-47bf-90c1-b1ac5607ebc4"), 2025, 2018 },
                    { 262, 4, "K48", new Guid("c1400430-6785-4c37-9bde-3bc2cea7b75e"), 2023, 2018 },
                    { 252, 1, "K48", new Guid("bed10234-220c-4521-865f-92d9cc2b6f23"), 2023, 2019 },
                    { 251, 3, "K48", new Guid("30fdfbac-9093-4fa1-8404-a4d5e30b3b47"), 2022, 2021 },
                    { 243, 1, "K48", new Guid("86cdf93f-7053-493d-a389-191383b73a9b"), 2023, 2019 },
                    { 232, 3, "K48", new Guid("b5fe3cd8-1256-463f-9062-e26d905f640d"), 2023, 2021 },
                    { 227, 2, "K48", new Guid("9a493d2d-3671-4c4b-9dd2-492095e5ab56"), 2024, 2019 },
                    { 224, 4, "K48", new Guid("23343a5b-3e9c-42ba-8d98-bf4413ffb0d1"), 2023, 2021 },
                    { 214, 1, "K48", new Guid("98abd83b-2b91-45c9-97f0-cbead87b40a2"), 2023, 2019 },
                    { 207, 2, "K48", new Guid("b691565f-72fb-4c5d-8451-63ff137f79ac"), 2024, 2021 },
                    { 202, 3, "K48", new Guid("3abcd768-4197-4229-8273-befb3436932c"), 2022, 2021 },
                    { 201, 2, "K48", new Guid("611dfe3b-6099-4dc5-81ac-59f0bea04757"), 2023, 2019 },
                    { 200, 4, "K48", new Guid("1b3baea5-cd59-4166-9ed6-feb23a451b82"), 2023, 2019 },
                    { 198, 3, "K48", new Guid("d7032b13-1712-4afa-a15a-316dcd84b37a"), 2024, 2019 },
                    { 196, 4, "K48", new Guid("3e727ea2-c051-4eec-8823-830ad7188b3a"), 2025, 2018 },
                    { 195, 3, "K48", new Guid("976fe0c7-9396-4458-9e29-d8baa2d2d89f"), 2023, 2021 },
                    { 263, 1, "K48", new Guid("496b8668-9b42-4344-bf6b-3a59b5fc5359"), 2025, 2018 },
                    { 190, 1, "K48", new Guid("0fa1e14d-4011-40af-b3db-d6dd90089a01"), 2024, 2020 },
                    { 265, 2, "K48", new Guid("5dd9a5d7-c2ca-40c7-a066-f626a8f2d2d2"), 2025, 2021 },
                    { 280, 1, "K48", new Guid("5c5839b0-ed68-4539-8729-074e1bd0715a"), 2025, 2021 },
                    { 69, 4, "K47", new Guid("15c42bb2-37a3-49f9-859f-119ca3b42c20"), 2023, 2019 },
                    { 71, 4, "K47", new Guid("aa14e86a-6f2c-4200-850c-7dd7360a08c9"), 2022, 2019 },
                    { 74, 2, "K47", new Guid("86cdf93f-7053-493d-a389-191383b73a9b"), 2025, 2018 },
                    { 75, 2, "K47", new Guid("6ce9d59b-0a62-4a94-b515-39084e7da946"), 2022, 2018 },
                    { 79, 3, "K47", new Guid("87dbd58a-08be-4527-9f0b-a5637720c6bd"), 2025, 2019 },
                    { 89, 1, "K47", new Guid("e6d2c7ba-035a-4d54-8bb9-00db7e5c6173"), 2025, 2020 },
                    { 99, 4, "K47", new Guid("95d89305-f31b-4c24-bd30-eda39134f9cd"), 2023, 2021 },
                    { 122, 4, "K47", new Guid("22f56273-134d-440f-8404-c93cb419f931"), 2022, 2019 },
                    { 126, 4, "K47", new Guid("9cdce684-615e-47be-a1bb-1992bb1a63a5"), 2025, 2020 },
                    { 127, 1, "K47", new Guid("22992e67-305a-466d-a1be-707fa8b37b08"), 2023, 2018 },
                    { 132, 2, "K47", new Guid("47024bc0-76fc-49dd-9560-5577b470e180"), 2025, 2018 },
                    { 299, 4, "K48", new Guid("98c56511-afa2-4f6e-b110-4d44836299e8"), 2024, 2021 },
                    { 285, 3, "K48", new Guid("882dc940-9666-4e52-82b1-83f4b2bb603f"), 2025, 2020 },
                    { 282, 2, "K48", new Guid("882ccd9e-36cf-4940-88e5-ea7fbd477c37"), 2023, 2020 },
                    { 281, 2, "K48", new Guid("e0ee13a6-a833-40a6-b8a4-a7a021ba3338"), 2022, 2018 },
                    { 271, 3, "K48", new Guid("e91e9822-dc84-46a3-baac-b57f3a3c7679"), 2022, 2019 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "ClassId", "IdCourse", "UserId", "YearEnd", "YearStart" },
                values: new object[] { 183, 3, "K47", new Guid("24d83dd1-5d54-4226-ba5d-ae95b87dbc39"), 2024, 2020 });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "IdFeedback", "ContentFeedback", "StudentId", "TitleFeedback" },
                values: new object[,]
                {
                    { 21, "Nội dung của phản hồi do sinh viên gửi21", 15, "Sinh Viên Gửi Phản Hồi 21" },
                    { 22, "Nội dung của phản hồi do sinh viên gửi22", 64, "Sinh Viên Gửi Phản Hồi 22" },
                    { 6, "Nội dung của phản hồi do sinh viên gửi6", 174, "Sinh Viên Gửi Phản Hồi 6" },
                    { 11, "Nội dung của phản hồi do sinh viên gửi11", 89, "Sinh Viên Gửi Phản Hồi 11" },
                    { 25, "Nội dung của phản hồi do sinh viên gửi25", 23, "Sinh Viên Gửi Phản Hồi 25" },
                    { 7, "Nội dung của phản hồi do sinh viên gửi7", 122, "Sinh Viên Gửi Phản Hồi 7" },
                    { 16, "Nội dung của phản hồi do sinh viên gửi16", 53, "Sinh Viên Gửi Phản Hồi 16" },
                    { 28, "Nội dung của phản hồi do sinh viên gửi28", 42, "Sinh Viên Gửi Phản Hồi 28" },
                    { 24, "Nội dung của phản hồi do sinh viên gửi24", 230, "Sinh Viên Gửi Phản Hồi 24" },
                    { 5, "Nội dung của phản hồi do sinh viên gửi5", 64, "Sinh Viên Gửi Phản Hồi 5" },
                    { 20, "Nội dung của phản hồi do sinh viên gửi20", 105, "Sinh Viên Gửi Phản Hồi 20" },
                    { 18, "Nội dung của phản hồi do sinh viên gửi18", 275, "Sinh Viên Gửi Phản Hồi 18" },
                    { 19, "Nội dung của phản hồi do sinh viên gửi19", 118, "Sinh Viên Gửi Phản Hồi 19" },
                    { 3, "Nội dung của phản hồi do sinh viên gửi3", 257, "Sinh Viên Gửi Phản Hồi 3" },
                    { 17, "Nội dung của phản hồi do sinh viên gửi17", 257, "Sinh Viên Gửi Phản Hồi 17" },
                    { 12, "Nội dung của phản hồi do sinh viên gửi12", 209, "Sinh Viên Gửi Phản Hồi 12" },
                    { 30, "Nội dung của phản hồi do sinh viên gửi30", 296, "Sinh Viên Gửi Phản Hồi 30" },
                    { 14, "Nội dung của phản hồi do sinh viên gửi14", 237, "Sinh Viên Gửi Phản Hồi 14" },
                    { 29, "Nội dung của phản hồi do sinh viên gửi29", 235, "Sinh Viên Gửi Phản Hồi 29" },
                    { 9, "Nội dung của phản hồi do sinh viên gửi9", 106, "Sinh Viên Gửi Phản Hồi 9" },
                    { 8, "Nội dung của phản hồi do sinh viên gửi8", 175, "Sinh Viên Gửi Phản Hồi 8" },
                    { 27, "Nội dung của phản hồi do sinh viên gửi27", 284, "Sinh Viên Gửi Phản Hồi 27" },
                    { 26, "Nội dung của phản hồi do sinh viên gửi26", 70, "Sinh Viên Gửi Phản Hồi 26" },
                    { 2, "Nội dung của phản hồi do sinh viên gửi2", 184, "Sinh Viên Gửi Phản Hồi 2" },
                    { 15, "Nội dung của phản hồi do sinh viên gửi15", 270, "Sinh Viên Gửi Phản Hồi 15" },
                    { 1, "Nội dung của phản hồi do sinh viên gửi1", 195, "Sinh Viên Gửi Phản Hồi 1" },
                    { 13, "Nội dung của phản hồi do sinh viên gửi13", 168, "Sinh Viên Gửi Phản Hồi 13" },
                    { 23, "Nội dung của phản hồi do sinh viên gửi23", 8, "Sinh Viên Gửi Phản Hồi 23" },
                    { 10, "Nội dung của phản hồi do sinh viên gửi10", 24, "Sinh Viên Gửi Phản Hồi 10" },
                    { 4, "Nội dung của phản hồi do sinh viên gửi4", 24, "Sinh Viên Gửi Phản Hồi 4" }
                });

            migrationBuilder.InsertData(
                table: "RegisterApplication",
                columns: new[] { "Id", "ApplicationId", "Content", "DateReceived", "DateRegister", "Dear", "IdStatus", "StudentId" },
                values: new object[,]
                {
                    { 24, 5, "Lý do xin xác nhận: 24", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5817), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5816), "Kính gửi: 24", 2, 240 },
                    { 171, 2, "Lý do xin xác nhận: 171", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9999), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9998), "Kính gửi: 171", 1, 248 },
                    { 2, 5, "Lý do xin xác nhận: 2", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5121), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5117), "Kính gửi: 2", 1, 26 },
                    { 105, 5, "Lý do xin xác nhận: 105", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8119), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8118), "Kính gửi: 105", 4, 24 },
                    { 155, 2, "Lý do xin xác nhận: 155", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9568), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9566), "Kính gửi: 155", 3, 254 },
                    { 179, 5, "Lý do xin xác nhận: 179", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(219), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(218), "Kính gửi: 179", 4, 8 },
                    { 194, 5, "Lý do xin xác nhận: 194", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(623), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(622), "Kính gửi: 194", 3, 238 },
                    { 6, 5, "Lý do xin xác nhận: 6", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5259), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5257), "Kính gửi: 6", 4, 257 },
                    { 161, 5, "Lý do xin xác nhận: 161", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9736), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9734), "Kính gửi: 161", 1, 257 },
                    { 97, 5, "Lý do xin xác nhận: 97", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7906), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7905), "Kính gửi: 97", 5, 264 },
                    { 182, 5, "Lý do xin xác nhận: 182", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(298), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(297), "Kính gửi: 182", 5, 4 },
                    { 108, 5, "Lý do xin xác nhận: 108", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8202), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8200), "Kính gửi: 108", 3, 266 }
                });

            migrationBuilder.InsertData(
                table: "RegisterApplication",
                columns: new[] { "Id", "ApplicationId", "Content", "DateReceived", "DateRegister", "Dear", "IdStatus", "StudentId" },
                values: new object[,]
                {
                    { 104, 5, "Lý do xin xác nhận: 104", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8092), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8091), "Kính gửi: 104", 5, 4 },
                    { 16, 5, "Lý do xin xác nhận: 16", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5598), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5596), "Kính gửi: 16", 2, 13 },
                    { 19, 2, "Lý do xin xác nhận: 19", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5682), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5681), "Kính gửi: 19", 3, 48 },
                    { 90, 2, "Lý do xin xác nhận: 90", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7719), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7718), "Kính gửi: 90", 5, 222 },
                    { 45, 4, "Lý do xin xác nhận: 45", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6398), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6397), "Kính gửi: 45", 2, 43 },
                    { 169, 2, "Lý do xin xác nhận: 169", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9945), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9944), "Kính gửi: 169", 3, 40 },
                    { 115, 5, "Lý do xin xác nhận: 115", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8388), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8386), "Kính gửi: 115", 5, 40 },
                    { 160, 5, "Lý do xin xác nhận: 160", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9709), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9708), "Kính gửi: 160", 4, 75 },
                    { 109, 5, "Lý do xin xác nhận: 109", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8228), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8227), "Kính gửi: 109", 2, 79 },
                    { 151, 2, "Lý do xin xác nhận: 151", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9397), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9395), "Kính gửi: 151", 2, 35 },
                    { 12, 4, "Lý do xin xác nhận: 12", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5434), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5433), "Kính gửi: 12", 1, 89 },
                    { 116, 5, "Lý do xin xác nhận: 116", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8421), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8419), "Kính gửi: 116", 3, 89 },
                    { 133, 4, "Lý do xin xác nhận: 133", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8890), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8889), "Kính gửi: 133", 5, 273 },
                    { 75, 4, "Lý do xin xác nhận: 75", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7312), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7310), "Kính gửi: 75", 5, 33 },
                    { 196, 5, "Lý do xin xác nhận: 196", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(675), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(674), "Kính gửi: 196", 5, 99 },
                    { 193, 4, "Lý do xin xác nhận: 193", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(595), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(594), "Kính gửi: 193", 3, 27 },
                    { 147, 2, "Lý do xin xác nhận: 147", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9289), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9288), "Kính gửi: 147", 2, 126 },
                    { 22, 4, "Lý do xin xác nhận: 22", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5764), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5763), "Kính gửi: 22", 1, 140 },
                    { 158, 4, "Lý do xin xác nhận: 158", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9655), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9654), "Kính gửi: 158", 1, 142 },
                    { 30, 4, "Lý do xin xác nhận: 30", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5987), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5986), "Kính gửi: 30", 2, 183 },
                    { 141, 5, "Lý do xin xác nhận: 141", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9126), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9125), "Kính gửi: 141", 4, 26 },
                    { 32, 2, "Lý do xin xác nhận: 32", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6042), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6040), "Kính gửi: 32", 5, 197 },
                    { 112, 5, "Lý do xin xác nhận: 112", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8307), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8306), "Kính gửi: 112", 2, 238 },
                    { 46, 2, "Lý do xin xác nhận: 46", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6426), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6424), "Kính gửi: 46", 2, 99 },
                    { 122, 2, "Lý do xin xác nhận: 122", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8590), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8588), "Kính gửi: 122", 5, 11 },
                    { 142, 4, "Lý do xin xác nhận: 142", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9151), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9150), "Kính gửi: 142", 5, 298 },
                    { 126, 5, "Lý do xin xác nhận: 126", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8697), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8695), "Kính gửi: 126", 5, 167 },
                    { 157, 5, "Lý do xin xác nhận: 157", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9622), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9621), "Kính gửi: 157", 1, 171 },
                    { 106, 4, "Lý do xin xác nhận: 106", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8145), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8144), "Kính gửi: 106", 3, 180 },
                    { 145, 4, "Lý do xin xác nhận: 145", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9235), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9233), "Kính gửi: 145", 4, 180 },
                    { 166, 5, "Lý do xin xác nhận: 166", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9868), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9867), "Kính gửi: 166", 1, 180 },
                    { 143, 5, "Lý do xin xác nhận: 143", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9178), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9177), "Kính gửi: 143", 4, 182 },
                    { 159, 5, "Lý do xin xác nhận: 159", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9682), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9681), "Kính gửi: 159", 3, 182 },
                    { 57, 5, "Lý do xin xác nhận: 57", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6818), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6817), "Kính gửi: 57", 2, 186 },
                    { 9, 5, "Lý do xin xác nhận: 9", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5344), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5342), "Kính gửi: 9", 1, 189 },
                    { 27, 5, "Lý do xin xác nhận: 27", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5895), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5893), "Kính gửi: 27", 5, 198 },
                    { 146, 5, "Lý do xin xác nhận: 146", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9262), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9261), "Kính gửi: 146", 5, 198 },
                    { 178, 2, "Lý do xin xác nhận: 178", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(192), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(191), "Kính gửi: 178", 1, 164 },
                    { 121, 4, "Lý do xin xác nhận: 121", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8563), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8562), "Kính gửi: 121", 5, 200 },
                    { 102, 4, "Lý do xin xác nhận: 102", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8040), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8039), "Kính gửi: 102", 4, 224 },
                    { 181, 2, "Lý do xin xác nhận: 181", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(271), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(270), "Kính gửi: 181", 2, 224 },
                    { 73, 4, "Lý do xin xác nhận: 73", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7259), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7258), "Kính gửi: 73", 1, 227 }
                });

            migrationBuilder.InsertData(
                table: "RegisterApplication",
                columns: new[] { "Id", "ApplicationId", "Content", "DateReceived", "DateRegister", "Dear", "IdStatus", "StudentId" },
                values: new object[,]
                {
                    { 189, 2, "Lý do xin xác nhận: 189", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(489), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(488), "Kính gửi: 189", 1, 252 },
                    { 156, 5, "Lý do xin xác nhận: 156", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9595), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9594), "Kính gửi: 156", 1, 262 },
                    { 35, 4, "Lý do xin xác nhận: 35", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6123), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6122), "Kính gửi: 35", 2, 263 },
                    { 60, 2, "Lý do xin xác nhận: 60", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6898), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6897), "Kính gửi: 60", 2, 265 },
                    { 168, 2, "Lý do xin xác nhận: 168", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9919), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9918), "Kính gửi: 168", 5, 265 },
                    { 50, 5, "Lý do xin xác nhận: 50", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6627), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6626), "Kính gửi: 50", 4, 280 },
                    { 55, 4, "Lý do xin xác nhận: 55", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6760), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6759), "Kính gửi: 55", 2, 280 },
                    { 86, 5, "Lý do xin xác nhận: 86", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7613), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7611), "Kính gửi: 86", 4, 281 },
                    { 192, 2, "Lý do xin xác nhận: 192", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(569), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(567), "Kính gửi: 192", 4, 214 },
                    { 89, 5, "Lý do xin xác nhận: 89", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7691), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7690), "Kính gửi: 89", 2, 293 },
                    { 8, 5, "Lý do xin xác nhận: 8", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5315), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5314), "Kính gửi: 8", 1, 164 },
                    { 4, 2, "Lý do xin xác nhận: 4", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5201), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5200), "Kính gửi: 4", 2, 158 },
                    { 64, 2, "Lý do xin xác nhận: 64", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7009), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7008), "Kính gửi: 64", 1, 2 },
                    { 36, 4, "Lý do xin xác nhận: 36", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6149), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6148), "Kính gửi: 36", 3, 5 },
                    { 165, 4, "Lý do xin xác nhận: 165", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9841), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9840), "Kính gửi: 165", 4, 7 },
                    { 67, 4, "Lý do xin xác nhận: 67", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7093), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7091), "Kính gửi: 67", 2, 15 },
                    { 149, 5, "Lý do xin xác nhận: 149", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9343), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9342), "Kính gửi: 149", 4, 19 },
                    { 20, 4, "Lý do xin xác nhận: 20", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5709), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5707), "Kính gửi: 20", 1, 30 },
                    { 107, 4, "Lý do xin xác nhận: 107", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8173), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8171), "Kính gửi: 107", 2, 30 },
                    { 5, 2, "Lý do xin xác nhận: 5", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5228), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5227), "Kính gửi: 5", 4, 31 },
                    { 110, 2, "Lý do xin xác nhận: 110", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8254), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8252), "Kính gửi: 110", 2, 31 },
                    { 54, 2, "Lý do xin xác nhận: 54", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6734), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6732), "Kính gửi: 54", 4, 34 },
                    { 140, 2, "Lý do xin xác nhận: 140", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9098), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9097), "Kính gửi: 140", 4, 34 },
                    { 99, 4, "Lý do xin xác nhận: 99", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7960), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7959), "Kính gửi: 99", 2, 158 },
                    { 40, 5, "Lý do xin xác nhận: 40", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6258), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6257), "Kính gửi: 40", 2, 45 },
                    { 185, 2, "Lý do xin xác nhận: 185", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(382), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(381), "Kính gửi: 185", 5, 45 },
                    { 7, 4, "Lý do xin xác nhận: 7", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5288), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5286), "Kính gửi: 7", 1, 81 },
                    { 183, 4, "Lý do xin xác nhận: 183", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(324), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(322), "Kính gửi: 183", 2, 93 },
                    { 92, 5, "Lý do xin xác nhận: 92", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7774), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7773), "Kính gửi: 92", 2, 101 },
                    { 77, 5, "Lý do xin xác nhận: 77", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7366), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7364), "Kính gửi: 77", 2, 108 },
                    { 187, 5, "Lý do xin xác nhận: 187", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(436), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(435), "Kính gửi: 187", 1, 124 },
                    { 128, 5, "Lý do xin xác nhận: 128", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8749), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8748), "Kính gửi: 128", 5, 133 },
                    { 43, 5, "Lý do xin xác nhận: 43", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6344), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6343), "Kính gửi: 43", 3, 143 },
                    { 164, 5, "Lý do xin xác nhận: 164", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9816), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9815), "Kính gửi: 164", 1, 143 },
                    { 56, 4, "Lý do xin xác nhận: 56", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6790), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6789), "Kính gửi: 56", 4, 157 },
                    { 98, 2, "Lý do xin xác nhận: 98", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7932), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7931), "Kính gửi: 98", 5, 157 },
                    { 139, 5, "Lý do xin xác nhận: 139", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9071), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9070), "Kính gửi: 139", 3, 45 },
                    { 71, 4, "Lý do xin xác nhận: 71", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7206), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7204), "Kính gửi: 71", 4, 4 },
                    { 170, 4, "Lý do xin xác nhận: 170", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9972), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9971), "Kính gửi: 170", 1, 187 },
                    { 200, 4, "Lý do xin xác nhận: 200", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(787), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(786), "Kính gửi: 200", 4, 270 },
                    { 198, 2, "Lý do xin xác nhận: 198", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(728), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(727), "Kính gửi: 198", 1, 216 },
                    { 78, 2, "Lý do xin xác nhận: 78", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7392), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7391), "Kính gửi: 78", 5, 253 }
                });

            migrationBuilder.InsertData(
                table: "RegisterApplication",
                columns: new[] { "Id", "ApplicationId", "Content", "DateReceived", "DateRegister", "Dear", "IdStatus", "StudentId" },
                values: new object[,]
                {
                    { 186, 2, "Lý do xin xác nhận: 186", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(409), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(408), "Kính gửi: 186", 4, 290 },
                    { 70, 2, "Lý do xin xác nhận: 70", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7179), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7178), "Kính gửi: 70", 2, 23 },
                    { 52, 2, "Lý do xin xác nhận: 52", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6680), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6679), "Kính gửi: 52", 3, 29 },
                    { 129, 4, "Lý do xin xác nhận: 129", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8776), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8775), "Kính gửi: 129", 5, 44 },
                    { 114, 5, "Lý do xin xác nhận: 114", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8361), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8359), "Kính gửi: 114", 1, 47 },
                    { 83, 5, "Lý do xin xác nhận: 83", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7529), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7528), "Kính gửi: 83", 1, 49 },
                    { 132, 5, "Lý do xin xác nhận: 132", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8864), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8863), "Kính gửi: 132", 2, 52 },
                    { 162, 5, "Lý do xin xác nhận: 162", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9764), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9763), "Kính gửi: 162", 1, 57 },
                    { 96, 4, "Lý do xin xác nhận: 96", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7880), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7879), "Kính gửi: 96", 2, 61 },
                    { 125, 4, "Lý do xin xác nhận: 125", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8669), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8668), "Kính gửi: 125", 5, 66 },
                    { 93, 2, "Lý do xin xác nhận: 93", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7799), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7798), "Kính gửi: 93", 4, 78 },
                    { 13, 4, "Lý do xin xác nhận: 13", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5462), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5461), "Kính gửi: 13", 5, 80 },
                    { 123, 4, "Lý do xin xác nhận: 123", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8616), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8615), "Kính gửi: 123", 4, 82 },
                    { 153, 5, "Lý do xin xác nhận: 153", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9514), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9513), "Kính gửi: 153", 3, 88 },
                    { 48, 4, "Lý do xin xác nhận: 48", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6479), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6478), "Kính gửi: 48", 5, 94 },
                    { 174, 4, "Lý do xin xác nhận: 174", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(84), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(82), "Kính gửi: 174", 5, 94 },
                    { 135, 2, "Lý do xin xác nhận: 135", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8942), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8941), "Kính gửi: 135", 1, 106 },
                    { 119, 2, "Lý do xin xác nhận: 119", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8506), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8505), "Kính gửi: 119", 4, 110 },
                    { 173, 5, "Lý do xin xác nhận: 173", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(57), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(56), "Kính gửi: 173", 2, 155 },
                    { 53, 5, "Lý do xin xác nhận: 53", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6707), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6706), "Kính gửi: 53", 2, 176 },
                    { 42, 2, "Lý do xin xác nhận: 42", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6311), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6310), "Kính gửi: 42", 4, 203 },
                    { 23, 2, "Lý do xin xác nhận: 23", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5791), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5790), "Kính gửi: 23", 5, 211 },
                    { 61, 5, "Lý do xin xác nhận: 61", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6925), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6924), "Kính gửi: 61", 1, 209 },
                    { 10, 4, "Lý do xin xác nhận: 10", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5379), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5378), "Kính gửi: 10", 5, 206 },
                    { 117, 4, "Lý do xin xác nhận: 117", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8453), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8452), "Kính gửi: 117", 5, 204 },
                    { 51, 4, "Lý do xin xác nhận: 51", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6654), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6653), "Kính gửi: 51", 5, 18 },
                    { 94, 5, "Lý do xin xác nhận: 94", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7825), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7823), "Kính gửi: 94", 4, 18 },
                    { 38, 4, "Lý do xin xác nhận: 38", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6203), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6202), "Kính gửi: 38", 5, 32 },
                    { 18, 2, "Lý do xin xác nhận: 18", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5656), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5654), "Kính gửi: 18", 2, 37 },
                    { 188, 5, "Lý do xin xác nhận: 188", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(463), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(461), "Kính gửi: 188", 1, 37 },
                    { 1, 2, "Lý do xin xác nhận: 1", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(3418), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(3143), "Kính gửi: 1", 2, 59 },
                    { 74, 5, "Lý do xin xác nhận: 74", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7285), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7284), "Kính gửi: 74", 2, 59 },
                    { 33, 5, "Lý do xin xác nhận: 33", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6067), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6066), "Kính gửi: 33", 3, 63 },
                    { 79, 5, "Lý do xin xác nhận: 79", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7418), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7417), "Kính gửi: 79", 3, 63 },
                    { 172, 2, "Lý do xin xác nhận: 172", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(29), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(28), "Kính gửi: 172", 3, 63 },
                    { 103, 2, "Lý do xin xác nhận: 103", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8066), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8065), "Kính gửi: 103", 1, 72 },
                    { 3, 4, "Lý do xin xác nhận: 3", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5162), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5161), "Kính gửi: 3", 2, 84 },
                    { 44, 2, "Lý do xin xác nhận: 44", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6371), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6369), "Kính gửi: 44", 1, 84 },
                    { 176, 2, "Lý do xin xác nhận: 176", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(137), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(136), "Kính gửi: 176", 1, 120 },
                    { 21, 4, "Lý do xin xác nhận: 21", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5736), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5735), "Kính gửi: 21", 4, 135 },
                    { 68, 2, "Lý do xin xác nhận: 68", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7125), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7124), "Kính gửi: 68", 5, 135 },
                    { 167, 4, "Lý do xin xác nhận: 167", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9893), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9892), "Kính gửi: 167", 1, 135 }
                });

            migrationBuilder.InsertData(
                table: "RegisterApplication",
                columns: new[] { "Id", "ApplicationId", "Content", "DateReceived", "DateRegister", "Dear", "IdStatus", "StudentId" },
                values: new object[,]
                {
                    { 34, 4, "Lý do xin xác nhận: 34", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6097), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6095), "Kính gửi: 34", 4, 149 },
                    { 124, 2, "Lý do xin xác nhận: 124", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8642), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8641), "Kính gửi: 124", 3, 149 },
                    { 41, 5, "Lý do xin xác nhận: 41", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6285), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6284), "Kính gửi: 41", 4, 152 },
                    { 28, 4, "Lý do xin xác nhận: 28", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5923), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5922), "Kính gửi: 28", 3, 173 },
                    { 152, 5, "Lý do xin xác nhận: 152", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9486), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9484), "Kính gửi: 152", 2, 192 },
                    { 76, 4, "Lý do xin xác nhận: 76", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7339), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7338), "Kính gửi: 76", 1, 204 },
                    { 190, 2, "Lý do xin xác nhận: 190", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(516), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(514), "Kính gửi: 190", 2, 204 },
                    { 88, 2, "Lý do xin xác nhận: 88", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7664), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7662), "Kính gửi: 88", 2, 296 },
                    { 72, 5, "Lý do xin xác nhận: 72", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7233), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7231), "Kính gửi: 72", 2, 209 },
                    { 150, 5, "Lý do xin xác nhận: 150", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9370), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9369), "Kính gửi: 150", 5, 212 },
                    { 100, 2, "Lý do xin xác nhận: 100", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7986), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7985), "Kính gửi: 100", 1, 103 },
                    { 82, 5, "Lý do xin xác nhận: 82", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7503), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7501), "Kính gửi: 82", 4, 112 },
                    { 148, 2, "Lý do xin xác nhận: 148", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9316), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9315), "Kính gửi: 148", 1, 112 },
                    { 120, 2, "Lý do xin xác nhận: 120", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8532), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8531), "Kính gửi: 120", 3, 129 },
                    { 17, 2, "Lý do xin xác nhận: 17", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5628), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5627), "Kính gửi: 17", 2, 134 },
                    { 47, 5, "Lý do xin xác nhận: 47", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6452), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6451), "Kính gửi: 47", 3, 134 },
                    { 95, 4, "Lý do xin xác nhận: 95", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7854), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7852), "Kính gửi: 95", 4, 136 },
                    { 163, 5, "Lý do xin xác nhận: 163", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9790), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9789), "Kính gửi: 163", 5, 136 },
                    { 11, 2, "Lý do xin xác nhận: 11", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5408), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5406), "Kính gửi: 11", 5, 148 },
                    { 180, 5, "Lý do xin xác nhận: 180", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(245), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(244), "Kính gửi: 180", 4, 148 },
                    { 177, 4, "Lý do xin xác nhận: 177", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(165), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(163), "Kính gửi: 177", 5, 150 },
                    { 131, 4, "Lý do xin xác nhận: 131", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8836), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8835), "Kính gửi: 131", 3, 159 },
                    { 87, 4, "Lý do xin xác nhận: 87", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7638), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7637), "Kính gửi: 87", 4, 160 },
                    { 111, 5, "Lý do xin xác nhận: 111", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8281), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8279), "Kính gửi: 111", 5, 160 },
                    { 29, 2, "Lý do xin xác nhận: 29", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5950), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5949), "Kính gửi: 29", 5, 168 },
                    { 191, 2, "Lý do xin xác nhận: 191", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(542), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(541), "Kính gửi: 191", 5, 168 },
                    { 138, 5, "Lý do xin xác nhận: 138", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9034), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9032), "Kính gửi: 138", 3, 172 },
                    { 66, 2, "Lý do xin xác nhận: 66", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7064), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7063), "Kính gửi: 66", 1, 187 },
                    { 127, 5, "Lý do xin xác nhận: 127", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8723), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8722), "Kính gửi: 127", 5, 187 },
                    { 63, 2, "Lý do xin xác nhận: 63", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6981), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6979), "Kính gửi: 63", 3, 285 },
                    { 37, 4, "Lý do xin xác nhận: 37", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6176), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6175), "Kính gửi: 37", 1, 225 },
                    { 15, 2, "Lý do xin xác nhận: 15", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5514), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5513), "Kính gửi: 15", 2, 244 },
                    { 26, 5, "Lý do xin xác nhận: 26", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5868), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5867), "Kính gửi: 26", 4, 244 },
                    { 14, 2, "Lý do xin xác nhận: 14", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5488), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5487), "Kính gửi: 14", 3, 87 },
                    { 59, 5, "Lý do xin xác nhận: 59", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6871), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6870), "Kính gửi: 59", 2, 210 },
                    { 81, 4, "Lý do xin xác nhận: 81", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7476), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7475), "Kính gửi: 81", 5, 56 },
                    { 62, 4, "Lý do xin xác nhận: 62", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6953), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6952), "Kính gửi: 62", 3, 53 },
                    { 154, 4, "Lý do xin xác nhận: 154", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9540), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9539), "Kính gửi: 154", 2, 212 },
                    { 25, 4, "Lý do xin xác nhận: 25", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5843), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(5841), "Kính gửi: 25", 2, 215 },
                    { 130, 5, "Lý do xin xác nhận: 130", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8805), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8804), "Kính gửi: 130", 4, 215 },
                    { 58, 5, "Lý do xin xác nhận: 58", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6845), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6844), "Kính gửi: 58", 1, 226 },
                    { 184, 5, "Lý do xin xác nhận: 184", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(351), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(350), "Kính gửi: 184", 5, 226 }
                });

            migrationBuilder.InsertData(
                table: "RegisterApplication",
                columns: new[] { "Id", "ApplicationId", "Content", "DateReceived", "DateRegister", "Dear", "IdStatus", "StudentId" },
                values: new object[,]
                {
                    { 91, 4, "Lý do xin xác nhận: 91", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7747), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7746), "Kính gửi: 91", 1, 233 },
                    { 69, 2, "Lý do xin xác nhận: 69", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7152), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7151), "Kính gửi: 69", 4, 237 },
                    { 49, 5, "Lý do xin xác nhận: 49", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6592), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6591), "Kính gửi: 49", 4, 241 },
                    { 118, 5, "Lý do xin xác nhận: 118", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8480), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8479), "Kính gửi: 118", 4, 241 },
                    { 137, 4, "Lý do xin xác nhận: 137", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8996), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8995), "Kính gửi: 137", 2, 241 },
                    { 65, 5, "Lý do xin xác nhận: 65", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7035), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7034), "Kính gửi: 65", 3, 250 },
                    { 134, 2, "Lý do xin xác nhận: 134", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8915), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8914), "Kính gửi: 134", 2, 250 },
                    { 136, 2, "Lý do xin xác nhận: 136", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8970), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8968), "Kính gửi: 136", 3, 250 },
                    { 31, 2, "Lý do xin xác nhận: 31", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6014), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6012), "Kính gửi: 31", 4, 276 },
                    { 175, 4, "Lý do xin xác nhận: 175", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(110), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(109), "Kính gửi: 175", 1, 291 },
                    { 197, 4, "Lý do xin xác nhận: 197", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(701), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(700), "Kính gửi: 197", 4, 292 },
                    { 144, 2, "Lý do xin xác nhận: 144", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9204), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(9203), "Kính gửi: 144", 3, 295 },
                    { 84, 2, "Lý do xin xác nhận: 84", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7557), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7556), "Kính gửi: 84", 5, 1 },
                    { 199, 2, "Lý do xin xác nhận: 199", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(760), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(759), "Kính gửi: 199", 2, 14 },
                    { 195, 2, "Lý do xin xác nhận: 195", new DateTime(2022, 11, 19, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(650), new DateTime(2022, 11, 17, 17, 54, 59, 669, DateTimeKind.Local).AddTicks(649), "Kính gửi: 195", 4, 36 },
                    { 85, 5, "Lý do xin xác nhận: 85", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7586), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7584), "Kính gửi: 85", 4, 42 },
                    { 113, 5, "Lý do xin xác nhận: 113", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8333), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8332), "Kính gửi: 113", 1, 42 },
                    { 39, 4, "Lý do xin xác nhận: 39", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6229), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(6228), "Kính gửi: 39", 5, 53 },
                    { 101, 4, "Lý do xin xác nhận: 101", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8013), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(8012), "Kính gửi: 101", 5, 53 },
                    { 80, 2, "Lý do xin xác nhận: 80", new DateTime(2022, 11, 19, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7446), new DateTime(2022, 11, 17, 17, 54, 59, 668, DateTimeKind.Local).AddTicks(7444), "Kính gửi: 80", 2, 285 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppRoleClaims_RoleId",
                table: "AppRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AppRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserClaims_UserId",
                table: "AppUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_RoleId",
                table: "AppUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AppUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AppUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DetailRegisterScoreboard_StudentId",
                table: "DetailRegisterScoreboard",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailRegisterScoreboard_YearSemesterIdEnd",
                table: "DetailRegisterScoreboard",
                column: "YearSemesterIdEnd");

            migrationBuilder.CreateIndex(
                name: "IX_DetailRegisterScoreboard_YearSemesterIdStart",
                table: "DetailRegisterScoreboard",
                column: "YearSemesterIdStart");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_StudentId",
                table: "Feedbacks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_MinusPoints_StudentId",
                table: "MinusPoints",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterApplication_ApplicationId",
                table: "RegisterApplication",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterApplication_IdStatus",
                table: "RegisterApplication",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterApplication_StudentId",
                table: "RegisterApplication",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterScoreboard_IdStatus",
                table: "RegisterScoreboard",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_IdCourse",
                table: "Students",
                column: "IdCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_YearSemester_IdSemester",
                table: "YearSemester",
                column: "IdSemester");

            migrationBuilder.CreateIndex(
                name: "IX_YearSemester_IdYear",
                table: "YearSemester",
                column: "IdYear");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "DetailRegisterScoreboard");

            migrationBuilder.DropTable(
                name: "EmailAdmin");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "MinusPoints");

            migrationBuilder.DropTable(
                name: "RegisterApplication");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "YearSemester");

            migrationBuilder.DropTable(
                name: "RegisterScoreboard");

            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.DropTable(
                name: "Year");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
