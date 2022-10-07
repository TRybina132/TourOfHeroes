using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class seedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "dog", "admin", "ADMIN" },
                    { 2, "goat", "user", "USER" },
                    { 4, "lizard", "reptiloid", "REPTILOID" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58428bd7-7195-4837-b5c8-c2fb2ea9d59f", "AQAAAAEAACcQAAAAEJ/PPG+ggIx0GvrxXYbWLmwb13NNLBRapOon+mJLajTWPoMYZU+nU+grCwnFEsXCGg==", "1a543090-4518-404c-9d8e-431e7d7909de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5308df83-4ef0-46d5-8d60-3e80f64f8b19", "AQAAAAEAACcQAAAAEOODt6rXrlPrQG0Ew4PAembI2lpThTl5zlU9YOMy1C1+FDHHHTqedVv8Q0idPUmBDw==", "4a9be33d-1422-4553-92e7-18c693d2fbd1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff7547e5-a181-4d1a-9b6a-fc3d82d8401d", "AQAAAAEAACcQAAAAEBZU9FwlFvjgdWn+Ao3i4BBXtOCbFVitSI8eIAsfLpwbD80qJ44PHsYAl7h1djjpSA==", "069cb3d4-7a20-496c-868f-c049ab9aba79" });

            migrationBuilder.InsertData(
                table: "Heroes",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[,]
                {
                    { 200, "Andromeda", null },
                    { 244, "Lilith", null },
                    { 400, "Mercury", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d6e92aa-7666-4ff1-8031-210982af415e", "AQAAAAEAACcQAAAAEO/es3WXcZop0yMOhP95NaY+3At7+bupy90Dt3wevR7tU0kuM8ceKhJViphvak/+wg==", "fd62d504-d70d-4805-b2fa-dde6419ae7fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d75e15a8-9e12-4803-a957-4b9ad35dd626", "AQAAAAEAACcQAAAAED7MNVu9CLmVm4hDhLjIVNtIHegtKEXpdtEKpU3ToRxiSLq4Vqzsz3P3j8USih6MQg==", "f03e7199-0249-4c88-94e3-7cc869608a99" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c76f658-bf88-4d04-b27d-d1670b3f561d", "AQAAAAEAACcQAAAAEPBqGeeD0ccm1lrTUDR2UAlUjM8L+naPe+uCUpfPj88221FgA9yN1JBi4AHU7bDVeQ==", "977f3e67-5171-4d3c-8a59-daebff8243eb" });
        }
    }
}
