using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace F1Management.Infrastructure.Migrations
{
    public partial class AddedSeparateDriversTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_RaceCars_RaceCarId",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_RaceCarId",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "RaceCarId",
                table: "TeamMembers");

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    RaceCarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_RaceCars_RaceCarId",
                        column: x => x.RaceCarId,
                        principalTable: "RaceCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drivers_TeamMembers_Id",
                        column: x => x.Id,
                        principalTable: "TeamMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_RaceCarId",
                table: "Drivers",
                column: "RaceCarId",
                unique: true,
                filter: "[RaceCarId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "TeamMembers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "TeamMembers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "TeamMembers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RaceCarId",
                table: "TeamMembers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_RaceCarId",
                table: "TeamMembers",
                column: "RaceCarId",
                unique: true,
                filter: "[RaceCarId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_RaceCars_RaceCarId",
                table: "TeamMembers",
                column: "RaceCarId",
                principalTable: "RaceCars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
