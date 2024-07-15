using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RailwayScheduler.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTrainModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Source = table.Column<string>(type: "TEXT", nullable: false),
                    Destination = table.Column<string>(type: "TEXT", nullable: false),
                    TimeSource = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeDestination = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trains", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Trains",
                columns: new[] { "Id", "Destination", "Source", "TimeDestination", "TimeSource" },
                values: new object[,]
                {
                    { 1, "Station B", "Station A", 1000, 800 },
                    { 2, "Station D", "Station C", 1100, 900 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trains");
        }
    }
}
