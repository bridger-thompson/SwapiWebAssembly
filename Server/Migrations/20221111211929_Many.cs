using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAssemblyTest.Server.Migrations
{
    public partial class Many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Starship_User_UserId",
                table: "Starship");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_User_UserId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_UserId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Starship_UserId",
                table: "Starship");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Starship");

            migrationBuilder.CreateTable(
                name: "UserStarship",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    StarshipId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStarship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserStarship_Starship_StarshipId",
                        column: x => x.StarshipId,
                        principalTable: "Starship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserStarship_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserVehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserVehicle_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserVehicle_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserStarship_StarshipId",
                table: "UserStarship",
                column: "StarshipId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStarship_UserId",
                table: "UserStarship",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVehicle_UserId",
                table: "UserVehicle",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVehicle_VehicleId",
                table: "UserVehicle",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserStarship");

            migrationBuilder.DropTable(
                name: "UserVehicle");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Vehicle",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Starship",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_UserId",
                table: "Vehicle",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Starship_UserId",
                table: "Starship",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Starship_User_UserId",
                table: "Starship",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_User_UserId",
                table: "Vehicle",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
