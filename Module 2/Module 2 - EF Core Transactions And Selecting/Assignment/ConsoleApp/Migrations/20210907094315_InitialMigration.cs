using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capital = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Population = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workshops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workshops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participants_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopParticipants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipantId = table.Column<int>(type: "int", nullable: false),
                    WorkshopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkshopParticipants_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkshopParticipants_Workshops_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "Workshops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Capital", "Name", "Population" },
                values: new object[,]
                {
                    { 1, "Bucharest", "Romania", 20000 },
                    { 2, "Budapest", "Hungary", 10000 },
                    { 3, "Paris", "France", 50000 }
                });

            migrationBuilder.InsertData(
                table: "Workshops",
                columns: new[] { "Id", "Name", "ShortDescription", "Theme" },
                values: new object[,]
                {
                    { 1, "Breakdance Workshop", "We will learn to breakdance!", "Dancing" },
                    { 2, "Painting Workshop", "We will learn to paint!", "Painting" }
                });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "CountryId", "Email", "FirstName", "LastName" },
                values: new object[] { 1, 1, "andrei.popescu@gmail.com", "Andrei", "Popescu" });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "CountryId", "Email", "FirstName", "LastName" },
                values: new object[] { 3, 2, "istvan.seres@gmail.com", "Istvan", "Seres" });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "CountryId", "Email", "FirstName", "LastName" },
                values: new object[] { 2, 3, "jean.monet@gmail.com", "Jean", "Monet" });

            migrationBuilder.InsertData(
                table: "WorkshopParticipants",
                columns: new[] { "Id", "ParticipantId", "WorkshopId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 4, 3, 1 },
                    { 3, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_CountryId",
                table: "Participants",
                column: "CountryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopParticipants_ParticipantId",
                table: "WorkshopParticipants",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopParticipants_WorkshopId",
                table: "WorkshopParticipants",
                column: "WorkshopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkshopParticipants");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Workshops");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
