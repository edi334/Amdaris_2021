using Microsoft.EntityFrameworkCore.Migrations;

namespace F1Management.Infrastructure.Migrations
{
    public partial class ChangedSomeProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsEmailVerified",
                table: "Users",
                newName: "IsInvited");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsInvited",
                table: "Users",
                newName: "IsEmailVerified");
        }
    }
}
