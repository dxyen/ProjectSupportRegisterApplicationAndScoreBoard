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
                    Price = table.Column<int>(type: "int", nullable: true)
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
                name: "Scoreboard",
                columns: table => new
                {
                    IdScore = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameScore = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCOREBOARD", x => x.IdScore);
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
                    IdStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameStatus = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATUS", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "Year",
                columns: table => new
                {
                    IdYear = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
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
                    YearStart = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_STUDENTS_USERS",
                        column: x => x.UserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "RegisterApplication",
                columns: table => new
                {
                    IdRegisterApplication = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    IdStatus = table.Column<int>(type: "int", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "date", nullable: true),
                    DateReceived = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGISTERAPPLICATION", x => x.IdRegisterApplication);
                    table.ForeignKey(
                        name: "FK_REGISTER_STATUS",
                        column: x => x.IdStatus,
                        principalTable: "Status",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REGISTERAPPLICATION_STUDENT",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegisterScoreboard",
                columns: table => new
                {
                    IdRegisterScoreboard = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    IdStatus = table.Column<int>(type: "int", nullable: false),
                    DateRegister = table.Column<DateTime>(type: "date", nullable: false),
                    DateReceived = table.Column<DateTime>(type: "date", nullable: true),
                    YearId = table.Column<int>(type: "int", nullable: false),
                    SemesterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGISTERSCOREBOARD", x => x.IdRegisterScoreboard);
                    table.ForeignKey(
                        name: "FK_REGISTERSCOREBOARD_STATUS",
                        column: x => x.IdStatus,
                        principalTable: "Status",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_REGISTERSCOREBOARD_STUDENTS",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Fk_Semeter_RegidterScoreboard",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "IdSemester",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_Year_RegisterScoreboard",
                        column: x => x.YearId,
                        principalTable: "Year",
                        principalColumn: "IdYear",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailRegisterApplication",
                columns: table => new
                {
                    IdApplication = table.Column<int>(type: "int", nullable: false),
                    IdRegisterApplication = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DETAILREGISTERAPPLICATION", x => new { x.IdApplication, x.IdRegisterApplication });
                    table.ForeignKey(
                        name: "FK_DETAILRE_APPLICATION",
                        column: x => x.IdApplication,
                        principalTable: "Application",
                        principalColumn: "IdApplication",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DETAILRE_REGISTERAPPLICATION",
                        column: x => x.IdRegisterApplication,
                        principalTable: "RegisterApplication",
                        principalColumn: "IdRegisterApplication",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetailRegisterScoreboard",
                columns: table => new
                {
                    IdRegisterScoreboard = table.Column<int>(type: "int", nullable: false),
                    IdScore = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DETAILREGISTERSCOREBOARD", x => new { x.IdRegisterScoreboard, x.IdScore });
                    table.ForeignKey(
                        name: "FK_DETAILRE_REGISTERSCOREBOARD",
                        column: x => x.IdRegisterScoreboard,
                        principalTable: "RegisterScoreboard",
                        principalColumn: "IdRegisterScoreboard",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DETAILRE_SCORE",
                        column: x => x.IdScore,
                        principalTable: "Scoreboard",
                        principalColumn: "IdScore",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "9aaff60d-c90f-46cd-8922-8af1ec84b022", "Administrator role", "admin", "admin" },
                    { new Guid("bff91064-dc92-421e-a233-d1080f630928"), "57fac229-f3d6-476b-8e9d-378b230b6eea", "Staff role", "staff", "staff" },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), "a9ed1891-beea-4c43-bb5f-f4dc4e1c43da", "Student role", "student", "student" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avatar", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("bff91064-dc92-421e-a233-d1080f630928"), 0, "Hưng Lợi, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "7c05c63b-62c3-4644-9303-00258536b275", "yenb1809323@student.ctu.edu.vn", false, "Đỗ Xuân Yên", false, null, "yenb1809323@student.ctu.edu.vn", "YenDX", "AQAAAAEAACcQAAAAELnobsFwxdhmeblq+HsPujvhIfmwNmhQTaZwbW7zheRPfMWWUo1E/Bqjj1YvpnJ32w==", null, false, "", false, "YenDX" },
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, "Hưng Lợi, Ninh Kiều, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "4546f16e-1fc5-4081-8153-a1313806acff", "trucb1809323@student.ctu.edu.vn", false, "Võ Thị Thanh Trúc", false, null, "trucb1809323@student.ctu.edu.vn", "TrucVTT", "AQAAAAEAACcQAAAAEDl50yipYvgXv5QLQE223cCBZLts3bRkm98Yv9dSgaLvgz9wDzcWkVO89NZnrJqkfw==", null, false, "", false, "TrucVTT" },
                    { new Guid("bff91065-dc92-421e-a233-d1080f630928"), 0, "Hưng Lợi, Ninh Kiều, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ac7c8387-12d4-47ec-930d-43532c8f438f", "haob1809323@student.ctu.edu.vn", false, "Vương Như Hảo", false, null, "haob1809323@student.ctu.edu.vn", "HaoVN", "AQAAAAEAACcQAAAAEDmQBRIAMzRkns9nwc9p/7wRln5DSxouD0h/g6pIGnqqZYDklMMG8RO3aN43YlUx0g==", null, false, "", false, "HaoVN" }
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
                table: "Year",
                columns: new[] { "IdYear", "Year" },
                values: new object[,]
                {
                    { 1, "2019-2020" },
                    { 2, "2020-2021" },
                    { 3, "2021-2022" },
                    { 4, "2022-2023" },
                    { 5, "2023-2024" }
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
                name: "IX_DetailRegisterApplication_IdRegisterApplication",
                table: "DetailRegisterApplication",
                column: "IdRegisterApplication");

            migrationBuilder.CreateIndex(
                name: "IX_DetailRegisterScoreboard_IdScore",
                table: "DetailRegisterScoreboard",
                column: "IdScore");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_StudentId",
                table: "Feedbacks",
                column: "StudentId");

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
                name: "IX_RegisterScoreboard_SemesterId",
                table: "RegisterScoreboard",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterScoreboard_StudentId",
                table: "RegisterScoreboard",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterScoreboard_YearId",
                table: "RegisterScoreboard",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_UserId",
                table: "Staffs",
                column: "UserId");

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
                name: "Application");

            migrationBuilder.DropTable(
                name: "RegisterApplication");

            migrationBuilder.DropTable(
                name: "RegisterScoreboard");

            migrationBuilder.DropTable(
                name: "Scoreboard");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.DropTable(
                name: "Year");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
