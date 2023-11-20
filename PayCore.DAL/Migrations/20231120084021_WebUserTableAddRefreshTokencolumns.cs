using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayCore.DAL.Migrations
{
    public partial class WebUserTableAddRefreshTokencolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "WebUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpireDate",
                table: "WebUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "WebUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpireDate",
                table: "WebUsers");
        }
    }
}
