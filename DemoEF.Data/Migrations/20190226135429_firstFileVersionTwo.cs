using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoEF.Data.Migrations
{
    public partial class firstFileVersionTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServerFilePath",
                table: "Files");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServerFilePath",
                table: "Files",
                nullable: true);
        }
    }
}
