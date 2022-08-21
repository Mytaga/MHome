using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHome.Data.Migrations
{
    public partial class ImageURLAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Furnitures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Accessories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Furnitures");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Accessories");
        }
    }
}
