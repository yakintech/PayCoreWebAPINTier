using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayCore.DAL.Migrations
{
    public partial class WebUserTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Roles",
                table: "WebUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roles",
                table: "WebUsers");
        }
    }
}
