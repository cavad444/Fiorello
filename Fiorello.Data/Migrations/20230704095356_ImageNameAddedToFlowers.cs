using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiorello.Data.Migrations
{
    public partial class ImageNameAddedToFlowers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Flowers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Flowers");
        }
    }
}
