using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAssemblyTest.Server.Migrations
{
    public partial class AdjustDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVehicle_User_UserId",
                table: "UserVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVehicle_Vehicle_VehicleId",
                table: "UserVehicle");

            migrationBuilder.DropTable(
                name: "UserStarship");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserVehicle",
                table: "UserVehicle");

            migrationBuilder.DropIndex(
                name: "IX_UserVehicle_UserId",
                table: "UserVehicle");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserVehicle");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "UserVehicle",
                newName: "VehiclesId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserVehicle",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_UserVehicle_VehicleId",
                table: "UserVehicle",
                newName: "IX_UserVehicle_VehiclesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserVehicle",
                table: "UserVehicle",
                columns: new[] { "UsersId", "VehiclesId" });

            migrationBuilder.CreateTable(
                name: "StarshipUser",
                columns: table => new
                {
                    StarshipsId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarshipUser", x => new { x.StarshipsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_StarshipUser_Starship_StarshipsId",
                        column: x => x.StarshipsId,
                        principalTable: "Starship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StarshipUser_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StarshipUser_UsersId",
                table: "StarshipUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVehicle_User_UsersId",
                table: "UserVehicle",
                column: "UsersId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVehicle_Vehicle_VehiclesId",
                table: "UserVehicle",
                column: "VehiclesId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserVehicle_User_UsersId",
                table: "UserVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVehicle_Vehicle_VehiclesId",
                table: "UserVehicle");

            migrationBuilder.DropTable(
                name: "StarshipUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserVehicle",
                table: "UserVehicle");

            migrationBuilder.RenameColumn(
                name: "VehiclesId",
                table: "UserVehicle",
                newName: "VehicleId");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "UserVehicle",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserVehicle_VehiclesId",
                table: "UserVehicle",
                newName: "IX_UserVehicle_VehicleId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserVehicle",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserVehicle",
                table: "UserVehicle",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserStarship",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StarshipId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_UserVehicle_UserId",
                table: "UserVehicle",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStarship_StarshipId",
                table: "UserStarship",
                column: "StarshipId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStarship_UserId",
                table: "UserStarship",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserVehicle_User_UserId",
                table: "UserVehicle",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVehicle_Vehicle_VehicleId",
                table: "UserVehicle",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
