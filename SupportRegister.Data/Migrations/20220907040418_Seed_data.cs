using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SupportRegister.Data.Migrations
{
    public partial class Seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "8bb2fa17-18a7-4d04-a909-fa3d8b63cf65", "Administrator role", "admin", "admin" },
                    { new Guid("bff91064-dc92-421e-a233-d1080f630928"), "193c58c4-2e36-422f-b5ea-edb05822c1e5", "Staff role", "staff", "staff" },
                    { new Guid("bff91054-dc92-421e-a233-d1080f630928"), "38281943-5bdf-49d8-a6b2-6b382c233d00", "Student role", "student", "student" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Avatar", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("bff91064-dc92-421e-a233-d1080f630928"), 0, "Hưng Lợi, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "da410ce5-1ae5-4ef1-ac7a-b0907c234498", "yenb1809323@student.ctu.edu.vn", false, "Đỗ Xuân Yên", false, null, "yenb1809323@student.ctu.edu.vn", "YenDX", "AQAAAAEAACcQAAAAECt2LzKBe6RjbBfQWWrcwu8TGwCj7d96CFv4Cqn8e/STNO+suIRbQPqyPta7QgWiLw==", null, false, "", false, "YenDX" },
                    { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, "Hưng Lợi, Ninh Kiều, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "001ddcb5-6fa5-4688-a942-bb31f836e080", "trucb1809323@student.ctu.edu.vn", false, "Võ Thị Thanh Trúc", false, null, "trucb1809323@student.ctu.edu.vn", "TrucVTT", "AQAAAAEAACcQAAAAEKQ4QZS3smC6IVTrgzMTx9PcEnnZjshWr9u54S7dgkRC7pgV25OQIO5xPq/DFiW3iQ==", null, false, "", false, "TrucVTT" },
                    { new Guid("bff91064-dc92-421e-a233-d1080f630929"), 0, "Hưng Lợi, Ninh Kiều, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "f56387cc-9423-4d5c-8aad-3cf741467c26", "haob1809323@student.ctu.edu.vn", false, "Vương Như Hảo", false, null, "haob1809323@student.ctu.edu.vn", "HaoVN", "AQAAAAEAACcQAAAAENYA2jSpuzUXeGrspMJm9b6GkJ0xSawn7QzAgPWyZhgznAiy+2l+f4l5A9BODDYEWA==", null, false, "", false, "HaoVN" },
                    { new Guid("bff91065-dc92-421e-a233-d1080f630928"), 0, "Hưng Lợi, Ninh Kiều, Cần Thơ", null, new DateTime(2000, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "bc168440-16a1-488b-9e11-3ea5078fc480", "haob1809323@student.ctu.edu.vn", false, "Vương Như Hảo", false, null, "haob1809323@student.ctu.edu.vn", "HaoVN", "AQAAAAEAACcQAAAAEHxwVX/GK0sIVxXpxlRi1aON15sJumKwUmb3o1V4juOlOxhLKpQVke1wNvDIf0zVwA==", null, false, "", false, "HaoVN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("bff91054-dc92-421e-a233-d1080f630928"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("bff91064-dc92-421e-a233-d1080f630928"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("bff91064-dc92-421e-a233-d1080f630928"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("bff91064-dc92-421e-a233-d1080f630929"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("bff91065-dc92-421e-a233-d1080f630928"));
        }
    }
}
