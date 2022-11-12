using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAssemblyTest.Server.Migrations
{
    public partial class UserCredits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Credits",
                table: "User",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Credits",
                table: "User");
        }
    }
}
