using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicle_Rental_System.Migrations
{
    public partial class Inital234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6cd6262 - b32b - 4bf4 - 8e79 - 9f76e595b36f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6cd6215 - b32b - 4bf4 - 4431 - 9f76e595b36f",
                column: "ConcurrencyStamp",
                value: "dc525714-bab1-4886-a57a-7483243ae980");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6cd6215 - b32b - 4bf4 - 8e79 - 9f76e595b36f",
                column: "ConcurrencyStamp",
                value: "229b660d-d8a2-404c-bab5-9203cbe85895");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b6cd6262 - b32b - 4bf4 - 8e79 - 9f76e595b26f", 0, "47d4e844-8fcd-4b23-8bce-a2bdfc7ba1f1", "User", "admin1@gmail.com", false, false, null, null, "ADMIN1@GMAIL.COM", "AQAAAAEAACcQAAAAEDA/ef2d08K8XSO7PoGmMbCvIAk+sNpE8H+SzKCqxBpMOEGT8Bw2sUlxv4PB6UmKCw==", null, false, "3c317f71-0902-4677-aa65-ee3b149c7c19", false, "admin1@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6cd6262 - b32b - 4bf4 - 8e79 - 9f76e595b26f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6cd6215 - b32b - 4bf4 - 4431 - 9f76e595b36f",
                column: "ConcurrencyStamp",
                value: "407d9f11-709e-4c1a-9828-36bc13c1ab7d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6cd6215 - b32b - 4bf4 - 8e79 - 9f76e595b36f",
                column: "ConcurrencyStamp",
                value: "d87d20a6-629e-4ee0-9cb2-8d28c59c16ef");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b6cd6262 - b32b - 4bf4 - 8e79 - 9f76e595b36f", 0, "d6ed3e79-e6fd-469e-8c90-a70821c11155", "User", "adminlogin@gmail.com", false, false, null, null, "ADMINLOGIN@GMAIL.COM", "AQAAAAEAACcQAAAAEPgzuzdUMtRyhPQJdwK4lssUndy/iJkTcMg7z8QnNrI3+/qCUTkqxI00SnRY/NIDzQ==", null, false, "06b82f98-99bc-4b1a-aedb-17df7daccf5a", false, "adminlogin@gmail.com" });
        }
    }
}
