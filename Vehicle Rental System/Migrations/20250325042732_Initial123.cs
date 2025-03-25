using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicle_Rental_System.Migrations
{
    public partial class Initial123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6cd6262 - b32b - 4bf4 - 8e79 - 9f76e595b36f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6ed3e79-e6fd-469e-8c90-a70821c11155", "AQAAAAEAACcQAAAAEPgzuzdUMtRyhPQJdwK4lssUndy/iJkTcMg7z8QnNrI3+/qCUTkqxI00SnRY/NIDzQ==", "06b82f98-99bc-4b1a-aedb-17df7daccf5a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6cd6215 - b32b - 4bf4 - 4431 - 9f76e595b36f",
                column: "ConcurrencyStamp",
                value: "d4be5ce4-8e4f-4f64-8da9-b045abfba2d9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6cd6215 - b32b - 4bf4 - 8e79 - 9f76e595b36f",
                column: "ConcurrencyStamp",
                value: "a72a09c5-c7e0-4154-be2b-08b9f9dcae60");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b6cd6262 - b32b - 4bf4 - 8e79 - 9f76e595b36f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ee0bd92-eb17-437d-a377-54d955462edf", "AQAAAAEAACcQAAAAEA2FTIC5MG5qcC+WeJIMiY1jGrjwW7Ma5fM/aRG61en4T0fLWNsOmPCsXrGriZH//A==", "71fedfa9-8ab6-4323-8c03-57785fe62753" });
        }
    }
}
