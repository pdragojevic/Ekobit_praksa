using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddedCityEntitie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Users",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ZipCode);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_ZipCode",
                table: "Users",
                column: "ZipCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cities_ZipCode",
                table: "Users",
                column: "ZipCode",
                principalTable: "Cities",
                principalColumn: "ZipCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cities_ZipCode",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Users_ZipCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Users");
        }
    }
}
