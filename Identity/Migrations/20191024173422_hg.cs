using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.Migrations
{
    public partial class hg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "Users",
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 400,
                oldNullable: true);
        }
    }
}
