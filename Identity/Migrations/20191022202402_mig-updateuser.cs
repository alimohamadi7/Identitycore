using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.Migrations
{
    public partial class migupdateuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GeneratedKey",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeneratedKey",
                table: "Users");
        }
    }
}
