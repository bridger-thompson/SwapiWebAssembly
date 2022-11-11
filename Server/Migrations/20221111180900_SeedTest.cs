using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAssemblyTest.Server.Migrations
{
    public partial class SeedTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Starship",
                columns: new[] { "Id", "Cost_In_Credits", "Crew", "Hyperdrive_Rating", "Length", "Max_Atmosphering_Speed", "Model", "Name", "Passengers", "UserId" },
                values: new object[] { 1, 50000L, "5", "3.0", "12", "400", "Test Model", "Test", "5", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Starship",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
