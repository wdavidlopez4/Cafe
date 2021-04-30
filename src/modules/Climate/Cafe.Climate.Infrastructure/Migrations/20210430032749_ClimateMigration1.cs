using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cafe.Climate.Infrastructure.Migrations
{
    public partial class ClimateMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClimateCrop",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CoffeeGrowerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClimateCrop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClimateMonitoring",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CropId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClimateMonitoring", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClimateMonitoring_ClimateCrop_CropId",
                        column: x => x.CropId,
                        principalTable: "ClimateCrop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Arduinos",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MonitoringId = table.Column<string>(nullable: true),
                    Occupied = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arduinos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arduinos_ClimateMonitoring_MonitoringId",
                        column: x => x.MonitoringId,
                        principalTable: "ClimateMonitoring",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClimaticFactor",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MonitoringId = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    OptimalStateDevelopmentThreshold = table.Column<string>(nullable: true),
                    OptimalTemperatureDevelopmentThreshold = table.Column<double>(nullable: true),
                    MaximunDevelopmentThreshold = table.Column<double>(nullable: true),
                    MinimunDevelopmentThreshold = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClimaticFactor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClimaticFactor_ClimateMonitoring_MonitoringId",
                        column: x => x.MonitoringId,
                        principalTable: "ClimateMonitoring",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArduinoDatas",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Temperature = table.Column<double>(nullable: false),
                    Humididy = table.Column<double>(nullable: false),
                    Altitude = table.Column<double>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    ArduinoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArduinoDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArduinoDatas_Arduinos_ArduinoId",
                        column: x => x.ArduinoId,
                        principalTable: "Arduinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArduinoDatas_ArduinoId",
                table: "ArduinoDatas",
                column: "ArduinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Arduinos_MonitoringId",
                table: "Arduinos",
                column: "MonitoringId",
                unique: true,
                filter: "[MonitoringId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClimateMonitoring_CropId",
                table: "ClimateMonitoring",
                column: "CropId",
                unique: true,
                filter: "[CropId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ClimaticFactor_MonitoringId",
                table: "ClimaticFactor",
                column: "MonitoringId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArduinoDatas");

            migrationBuilder.DropTable(
                name: "ClimaticFactor");

            migrationBuilder.DropTable(
                name: "Arduinos");

            migrationBuilder.DropTable(
                name: "ClimateMonitoring");

            migrationBuilder.DropTable(
                name: "ClimateCrop");
        }
    }
}
