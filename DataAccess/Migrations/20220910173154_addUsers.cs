using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class addUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "3d6e92aa-7666-4ff1-8031-210982af415e", null, false, false, null, null, "6_IKAREN", "AQAAAAEAACcQAAAAEO/es3WXcZop0yMOhP95NaY+3At7+bupy90Dt3wevR7tU0kuM8ceKhJViphvak/+wg==", null, false, "fd62d504-d70d-4805-b2fa-dde6419ae7fb", false, "6_Ikaren" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, "d75e15a8-9e12-4803-a957-4b9ad35dd626", null, false, false, null, null, "NANCY_2200", "AQAAAAEAACcQAAAAED7MNVu9CLmVm4hDhLjIVNtIHegtKEXpdtEKpU3ToRxiSLq4Vqzsz3P3j8USih6MQg==", null, false, "f03e7199-0249-4c88-94e3-7cc869608a99", false, "nancy_2200" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 3, 0, "6c76f658-bf88-4d04-b27d-d1670b3f561d", null, false, false, null, null, "MARK222", "AQAAAAEAACcQAAAAEPBqGeeD0ccm1lrTUDR2UAlUjM8L+naPe+uCUpfPj88221FgA9yN1JBi4AHU7bDVeQ==", null, false, "977f3e67-5171-4d3c-8a59-daebff8243eb", false, "Mark222" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
