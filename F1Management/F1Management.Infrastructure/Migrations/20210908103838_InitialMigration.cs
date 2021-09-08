using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace F1Management.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrandPrix",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CircuitName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrandPrix", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaceCars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Strategy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceCars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEmailVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chassis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Wear = table.Column<double>(type: "float", nullable: false),
                    FrontWing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RearWing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaceCarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chassis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chassis_RaceCars_RaceCarId",
                        column: x => x.RaceCarId,
                        principalTable: "RaceCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Wear = table.Column<double>(type: "float", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorsePower = table.Column<int>(type: "int", nullable: false),
                    RaceCarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Engines_RaceCars_RaceCarId",
                        column: x => x.RaceCarId,
                        principalTable: "RaceCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gearboxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Wear = table.Column<double>(type: "float", nullable: false),
                    GearCount = table.Column<int>(type: "int", nullable: false),
                    RaceCarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gearboxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gearboxes_RaceCars_RaceCarId",
                        column: x => x.RaceCarId,
                        principalTable: "RaceCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrandPrixId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RaceCarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    SessionType = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FastestLap = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_GrandPrix_GrandPrixId",
                        column: x => x.GrandPrixId,
                        principalTable: "GrandPrix",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessions_RaceCars_RaceCarId",
                        column: x => x.RaceCarId,
                        principalTable: "RaceCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TireSets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrontLeftWear = table.Column<int>(type: "int", nullable: false),
                    FrontRightWear = table.Column<int>(type: "int", nullable: false),
                    RearLeftWear = table.Column<int>(type: "int", nullable: false),
                    RearRightWear = table.Column<int>(type: "int", nullable: false),
                    RaceCarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TireSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TireSets_RaceCars_RaceCarId",
                        column: x => x.RaceCarId,
                        principalTable: "RaceCars",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PitStopCrews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PitStopCrews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PitStopCrews_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PitStops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OldTiresId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NewTiresId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StationaryTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CarSessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PitStops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PitStops_Sessions_CarSessionId",
                        column: x => x.CarSessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PitStops_TireSets_NewTiresId",
                        column: x => x.NewTiresId,
                        principalTable: "TireSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PitStops_TireSets_OldTiresId",
                        column: x => x.OldTiresId,
                        principalTable: "TireSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarMechanic_TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: true),
                    RaceCarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PitStopCrewId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RaceEngineer_TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_Member_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Member",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Member_PitStopCrews_PitStopCrewId",
                        column: x => x.PitStopCrewId,
                        principalTable: "PitStopCrews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Member_RaceCars_RaceCarId",
                        column: x => x.RaceCarId,
                        principalTable: "RaceCars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Member_Teams_CarMechanic_TeamId",
                        column: x => x.CarMechanic_TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Member_Teams_RaceEngineer_TeamId",
                        column: x => x.RaceEngineer_TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Member_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Member_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chassis_RaceCarId",
                table: "Chassis",
                column: "RaceCarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Engines_RaceCarId",
                table: "Engines",
                column: "RaceCarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gearboxes_RaceCarId",
                table: "Gearboxes",
                column: "RaceCarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_CarMechanic_TeamId",
                table: "Member",
                column: "CarMechanic_TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_DriverId",
                table: "Member",
                column: "DriverId",
                unique: true,
                filter: "[DriverId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Member_PitStopCrewId",
                table: "Member",
                column: "PitStopCrewId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_RaceCarId",
                table: "Member",
                column: "RaceCarId",
                unique: true,
                filter: "[RaceCarId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Member_RaceEngineer_TeamId",
                table: "Member",
                column: "RaceEngineer_TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_TeamId",
                table: "Member",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_UserId",
                table: "Member",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PitStopCrews_TeamId",
                table: "PitStopCrews",
                column: "TeamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PitStops_CarSessionId",
                table: "PitStops",
                column: "CarSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_PitStops_NewTiresId",
                table: "PitStops",
                column: "NewTiresId");

            migrationBuilder.CreateIndex(
                name: "IX_PitStops_OldTiresId",
                table: "PitStops",
                column: "OldTiresId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_GrandPrixId",
                table: "Sessions",
                column: "GrandPrixId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_RaceCarId",
                table: "Sessions",
                column: "RaceCarId");

            migrationBuilder.CreateIndex(
                name: "IX_TireSets_RaceCarId",
                table: "TireSets",
                column: "RaceCarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chassis");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "Gearboxes");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "PitStops");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "PitStopCrews");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "TireSets");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "GrandPrix");

            migrationBuilder.DropTable(
                name: "RaceCars");
        }
    }
}
