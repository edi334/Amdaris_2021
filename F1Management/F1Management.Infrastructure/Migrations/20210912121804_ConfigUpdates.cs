using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace F1Management.Infrastructure.Migrations
{
    public partial class ConfigUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PitStops_TireSets_NewTiresId",
                table: "PitStops");

            migrationBuilder.DropForeignKey(
                name: "FK_PitStops_TireSets_OldTiresId",
                table: "PitStops");

            migrationBuilder.DropIndex(
                name: "IX_PitStops_NewTiresId",
                table: "PitStops");

            migrationBuilder.DropIndex(
                name: "IX_PitStops_OldTiresId",
                table: "PitStops");

            migrationBuilder.AlterColumn<Guid>(
                name: "OldTiresId",
                table: "PitStops",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "NewTiresId",
                table: "PitStops",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PitStops_NewTiresId",
                table: "PitStops",
                column: "NewTiresId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PitStops_OldTiresId",
                table: "PitStops",
                column: "OldTiresId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PitStops_TireSets_NewTiresId",
                table: "PitStops",
                column: "NewTiresId",
                principalTable: "TireSets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PitStops_TireSets_OldTiresId",
                table: "PitStops",
                column: "OldTiresId",
                principalTable: "TireSets",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PitStops_TireSets_NewTiresId",
                table: "PitStops");

            migrationBuilder.DropForeignKey(
                name: "FK_PitStops_TireSets_OldTiresId",
                table: "PitStops");

            migrationBuilder.DropIndex(
                name: "IX_PitStops_NewTiresId",
                table: "PitStops");

            migrationBuilder.DropIndex(
                name: "IX_PitStops_OldTiresId",
                table: "PitStops");

            migrationBuilder.AlterColumn<Guid>(
                name: "OldTiresId",
                table: "PitStops",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "NewTiresId",
                table: "PitStops",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_PitStops_NewTiresId",
                table: "PitStops",
                column: "NewTiresId");

            migrationBuilder.CreateIndex(
                name: "IX_PitStops_OldTiresId",
                table: "PitStops",
                column: "OldTiresId");

            migrationBuilder.AddForeignKey(
                name: "FK_PitStops_TireSets_NewTiresId",
                table: "PitStops",
                column: "NewTiresId",
                principalTable: "TireSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PitStops_TireSets_OldTiresId",
                table: "PitStops",
                column: "OldTiresId",
                principalTable: "TireSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
