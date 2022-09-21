using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHome.Data.Migrations
{
    public partial class AddPictureUrlClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Clients");
        }
    }
}
