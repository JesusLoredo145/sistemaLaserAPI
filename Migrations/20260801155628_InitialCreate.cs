using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaLaserAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    deviceId = table.Column<string>(type: "TEXT", nullable: true),
                    counter = table.Column<int>(type: "INTEGER", nullable: true),
                    signalValue = table.Column<int>(type: "INTEGER", nullable: true),
                    detectionDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    created = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidents");
        }
    }
}
