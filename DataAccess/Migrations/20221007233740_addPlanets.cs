using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addPlanets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlanetId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Population = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38ce565b-722e-4576-817d-cf617d5fb545", "AQAAAAEAACcQAAAAEG8hYNPr20WiGdxOc/y9KQrHSZFEAd/lct8LPG8mfGHfVV3w8c+eVR67JLneJrg08Q==", "986aa2c4-9c23-4679-a78d-0dc1067dfd3c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62af58d7-6573-4396-91de-395f6bcd1302", "AQAAAAEAACcQAAAAEB1jnulrMuacWpyVJu0TkXM0ikMZs92Y/yfBm12Qzt6SIJviYYUYn4PJrhE6suYKFQ==", "26811be1-02c8-4477-a82d-8159cd59715a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f03093ae-f68b-4624-a686-4caf9c7e88e9", "AQAAAAEAACcQAAAAEA/qrErgSg7SJHQJgSELQKO7LD5mzp2M9sCwsH/FCMTDMDpqIBPu3elRbpp1P6rAiA==", "7801f586-1601-49f8-be9d-1a352ec64897" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PlanetId",
                table: "AspNetUsers",
                column: "PlanetId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Planets_PlanetId",
                table: "AspNetUsers",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Planets_PlanetId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PlanetId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PlanetId",
                table: "AspNetUsers");

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
        }
    }
}
