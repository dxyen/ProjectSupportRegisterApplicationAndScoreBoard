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
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
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
                    Birthday = table.Column<DateTime>(type: "date", nullable: true),
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
                    NameClass = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
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
                name: "Semester",
                columns: table => new
                {
                    IdSemester = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSemester = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
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
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                    table.ForeignKey(
                        name: "FK_STAFFS_USERS",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    YearEnd = table.Column<int>(type: "int", nullable: true)
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
                name: "RegisterApplication",
                columns: table => new
                {
                    IdRegisterApplication = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdStatus = table.Column<int>(type: "int", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "date", nullable: false),
                    DateReceived = table.Column<DateTime>(type: "date", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGISTERAPPLICATION", x => x.IdRegisterApplication);
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
                });

            migrationBuilder.CreateTable(
                name: "RegisterScoreboard",
                columns: table => new
                {
                    IdRegisterScoreboard = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdStatus = table.Column<int>(type: "int", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "date", nullable: false),
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
                name: "Feedbacks",
                columns: table => new
                {
                    IdFeedback = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ContentFeedback = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
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
                name: "DetailRegisterApplication",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    RegisId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetailRe__D170D43024840281", x => new { x.StudentId, x.RegisId });
                    table.ForeignKey(
                        name: "Fk_detailapp_regisapp",
                        column: x => x.RegisId,
                        principalTable: "RegisterApplication",
                        principalColumn: "IdRegisterApplication",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_detailapp_stu",
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
                    SemesterId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    YearId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetailRe__B873A826F6F01A76", x => new { x.RegisId, x.SemesterId, x.StudentId, x.YearId });
                    table.ForeignKey(
                        name: "Fk_detail_semester",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "IdSemester",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_detail_stu",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Fk_detail_year",
                        column: x => x.YearId,
                        principalTable: "Year",
                        principalColumn: "IdYear",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_regis_score",
                        column: x => x.RegisId,
                        principalTable: "RegisterScoreboard",
                        principalColumn: "IdRegisterScoreboard",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "5c1f42e4-a3d0-4630-8e8f-f334675b755c", "Administrator role", "admin", "admin" },
                    { new Guid("bff91064-dc92-421e-a233-d1080f630928"), "5cc64c3b-9efc-42e7-84c3-94559caf8621", "Staff role", "staff", "staff" },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), "a0e2fbf5-9e34-49dc-a268-1444773d81c4", "Student role", "student", "student" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avatar", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("bff91064-dc92-421e-a233-d1080f630928"), 0, "Hưng Lợi, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "73b015ee-67d0-4268-8ae2-5771431c5a91", "yenb1809323@student.ctu.edu.vn", false, "Đỗ Xuân Yên", false, null, "yenb1809323@student.ctu.edu.vn", "YenDX", "AQAAAAEAACcQAAAAEChXIjO+ua6ALnRsS0J7nwZzegmdiCOaeisq/bTGwwCxerPAaZhkPP2+YTMzFhvPGw==", null, false, "", false, "YenDX" },
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, "Hưng Lợi, Ninh Kiều, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "f5776b92-f26f-42c0-b4fb-6c358c2cd166", "trucb1809323@student.ctu.edu.vn", false, "Võ Thị Thanh Trúc", false, null, "trucb1809323@student.ctu.edu.vn", "TrucVTT", "AQAAAAEAACcQAAAAEGUtEc0WkqhVdeVYpd2yj05ZffgOv89Su/sdv6MdHBdHWRjQ8HDsdnfpVh3wqkbbew==", null, false, "", false, "TrucVTT" },
                    { new Guid("bff91065-dc92-421e-a233-d1080f630928"), 0, "Hưng Lợi, Ninh Kiều, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "6870dffd-ba74-4eb7-a7cc-486f11194730", "haob1809323@student.ctu.edu.vn", false, "Vương Như Hảo", false, null, "haob1809323@student.ctu.edu.vn", "HaoVN", "AQAAAAEAACcQAAAAENEmIUfOC7eM0WRVW64vPf58QSpuSwLZjGvlc+dHAFhzQr+Ys+6scG+AoCSdMctkRA==", null, false, "", false, "HaoVN" }
                });

            migrationBuilder.InsertData(
                table: "Semester",
                columns: new[] { "IdSemester", "NameSemester", "Price" },
                values: new object[,]
                {
                    { 1, "Học kỳ I", 0 },
                    { 2, "Học kỳ II", 0 },
                    { 3, "Học kỳ hè", 0 }
                });

            migrationBuilder.InsertData(
                table: "Year",
                columns: new[] { "IdYear", "Year" },
                values: new object[,]
                {
                    { 1, 2018 },
                    { 2, 2019 },
                    { 3, 2020 },
                    { 4, 2021 },
                    { 5, 2022 },
                    { 6, 2023 }
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
                name: "IX_DetailRegisterApplication_RegisId",
                table: "DetailRegisterApplication",
                column: "RegisId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailRegisterScoreboard_SemesterId",
                table: "DetailRegisterScoreboard",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailRegisterScoreboard_StudentId",
                table: "DetailRegisterScoreboard",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailRegisterScoreboard_YearId",
                table: "DetailRegisterScoreboard",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_StudentId",
                table: "Feedbacks",
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
                name: "IX_RegisterScoreboard_IdStatus",
                table: "RegisterScoreboard",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_UserId",
                table: "Staffs",
                column: "UserId");

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
                name: "DetailRegisterApplication");

            migrationBuilder.DropTable(
                name: "DetailRegisterScoreboard");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "RegisterApplication");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.DropTable(
                name: "Year");

            migrationBuilder.DropTable(
                name: "RegisterScoreboard");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Application");

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
