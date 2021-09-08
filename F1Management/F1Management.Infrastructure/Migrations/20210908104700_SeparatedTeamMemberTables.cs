using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace F1Management.Infrastructure.Migrations
{
    public partial class SeparatedTeamMemberTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Member_Member_DriverId",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_PitStopCrews_PitStopCrewId",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_RaceCars_RaceCarId",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_Teams_CarMechanic_TeamId",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_Teams_RaceEngineer_TeamId",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_Teams_TeamId",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_CarMechanic_TeamId",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_DriverId",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_PitStopCrewId",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_RaceCarId",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_RaceEngineer_TeamId",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Member_TeamId",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "CarMechanic_TeamId",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "PitStopCrewId",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "RaceCarId",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "RaceEngineer_TeamId",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Member");

            migrationBuilder.CreateTable(
                name: "CarMechanics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarMechanics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarMechanics_Member_Id",
                        column: x => x.Id,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarMechanics_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    RaceCarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_Member_Id",
                        column: x => x.Id,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Drivers_RaceCars_RaceCarId",
                        column: x => x.RaceCarId,
                        principalTable: "RaceCars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Drivers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PitStopMechanics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PitStopCrewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PitStopMechanics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PitStopMechanics_Member_Id",
                        column: x => x.Id,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PitStopMechanics_PitStopCrews_PitStopCrewId",
                        column: x => x.PitStopCrewId,
                        principalTable: "PitStopCrews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaceEngineers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceEngineers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceEngineers_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RaceEngineers_Member_Id",
                        column: x => x.Id,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RaceEngineers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarMechanics_TeamId",
                table: "CarMechanics",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_RaceCarId",
                table: "Drivers",
                column: "RaceCarId",
                unique: true,
                filter: "[RaceCarId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_TeamId",
                table: "Drivers",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PitStopMechanics_PitStopCrewId",
                table: "PitStopMechanics",
                column: "PitStopCrewId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceEngineers_DriverId",
                table: "RaceEngineers",
                column: "DriverId",
                unique: true,
                filter: "[DriverId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RaceEngineers_TeamId",
                table: "RaceEngineers",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarMechanics");

            migrationBuilder.DropTable(
                name: "PitStopMechanics");

            migrationBuilder.DropTable(
                name: "RaceEngineers");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.AddColumn<Guid>(
                name: "CarMechanic_TeamId",
                table: "Member",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Member",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "DriverId",
                table: "Member",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Member",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PitStopCrewId",
                table: "Member",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Member",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RaceCarId",
                table: "Member",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RaceEngineer_TeamId",
                table: "Member",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TeamId",
                table: "Member",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Member_DriverId",
                table: "Member",
                column: "DriverId",
                principalTable: "Member",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_PitStopCrews_PitStopCrewId",
                table: "Member",
                column: "PitStopCrewId",
                principalTable: "PitStopCrews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Member_RaceCars_RaceCarId",
                table: "Member",
                column: "RaceCarId",
                principalTable: "RaceCars",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Teams_CarMechanic_TeamId",
                table: "Member",
                column: "CarMechanic_TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Teams_RaceEngineer_TeamId",
                table: "Member",
                column: "RaceEngineer_TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Teams_TeamId",
                table: "Member",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }
    }
}
