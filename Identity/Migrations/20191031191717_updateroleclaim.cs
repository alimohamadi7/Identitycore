using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.Migrations
{
    public partial class updateroleclaim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "GivenOn",
                table: "RoleClaims",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GivenOn",
                table: "RoleClaims");
        }
    }
}
