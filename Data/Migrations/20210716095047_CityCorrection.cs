using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CityCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cities_ZipCode",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cities_ZipCode",
                table: "Users",
                column: "ZipCode",
                principalTable: "Cities",
                principalColumn: "ZipCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cities_ZipCode",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cities_ZipCode",
                table: "Users",
                column: "ZipCode",
                principalTable: "Cities",
                principalColumn: "ZipCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
