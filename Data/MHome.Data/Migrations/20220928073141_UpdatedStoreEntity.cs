using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHome.Data.Migrations
{
    public partial class UpdatedStoreEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Stores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Stores",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Stores");
        }
    }
}
