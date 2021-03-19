using Microsoft.EntityFrameworkCore.Migrations;

namespace AboCafes.Web.Migrations
{
    public partial class Cafesb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Cafes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "Cafes",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);
        }
    }
}
