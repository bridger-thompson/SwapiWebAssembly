using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAssemblyTest.Server.Migrations
{
    public partial class Back : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Height = table.Column<string>(type: "TEXT", nullable: false),
                    Mass = table.Column<string>(type: "TEXT", nullable: false),
                    Hair_Color = table.Column<string>(type: "TEXT", nullable: false),
                    Skin_Color = table.Column<string>(type: "TEXT", nullable: false),
                    Birth_Year = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Starship",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Cost_In_Credits = table.Column<long>(type: "INTEGER", nullable: false),
                    Length = table.Column<string>(type: "TEXT", nullable: false),
                    Max_Atmosphering_Speed = table.Column<string>(type: "TEXT", nullable: false),
                    Crew = table.Column<string>(type: "TEXT", nullable: false),
                    Passengers = table.Column<string>(type: "TEXT", nullable: false),
                    Hyperdrive_Rating = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Starship", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Cost_In_Credits = table.Column<long>(type: "INTEGER", nullable: false),
                    Length = table.Column<string>(type: "TEXT", nullable: false),
                    Max_Atmosphering_Speed = table.Column<string>(type: "TEXT", nullable: false),
                    Passengers = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: true),
                    Credits = table.Column<long>(type: "INTEGER", nullable: false),
                    ClickRate = table.Column<int>(type: "INTEGER", nullable: false),
                    AutoclickRate = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id");
                });

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
                name: "IX_User_PersonId",
                table: "User",
                column: "PersonId");

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

            migrationBuilder.DropTable(
                name: "Starship");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
