using Microsoft.EntityFrameworkCore.Migrations;

namespace F1Management.Infrastructure.Migrations
{
    public partial class AddedNameToRaceCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RaceCars",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "RaceCars");
        }
    }
}
