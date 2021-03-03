using Microsoft.EntityFrameworkCore.Migrations;

namespace BookApp.Migrations
{
    public partial class AddMarketDescriptionColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MarketDescription",
                table: "Markets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarketDescription",
                table: "Markets");
        }
    }
}
