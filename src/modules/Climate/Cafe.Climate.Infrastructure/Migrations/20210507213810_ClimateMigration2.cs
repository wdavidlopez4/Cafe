using Microsoft.EntityFrameworkCore.Migrations;

namespace Cafe.Climate.Infrastructure.Migrations
{
    public partial class ClimateMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaximunDevelopmentThreshold",
                table: "ClimaticFactor");

            migrationBuilder.DropColumn(
                name: "MinimunDevelopmentThreshold",
                table: "ClimaticFactor");

            migrationBuilder.AlterColumn<int>(
                name: "OptimalStateDevelopmentThreshold",
                table: "ClimaticFactor",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ClimateAccumulateds",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccumulatedTemperature = table.Column<double>(nullable: false),
                    AccumulatedHumedity = table.Column<double>(nullable: false),
                    AccumulatedAltitude = table.Column<double>(nullable: false),
                    MonitoringId = table.Column<string>(nullable: true),
                    ContData = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClimateAccumulateds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClimateAccumulateds_ClimateMonitoring_MonitoringId",
                        column: x => x.MonitoringId,
                        principalTable: "ClimateMonitoring",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClimateAccumulateds_MonitoringId",
                table: "ClimateAccumulateds",
                column: "MonitoringId",
                unique: true,
                filter: "[MonitoringId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClimateAccumulateds");

            migrationBuilder.AlterColumn<string>(
                name: "OptimalStateDevelopmentThreshold",
                table: "ClimaticFactor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MaximunDevelopmentThreshold",
                table: "ClimaticFactor",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MinimunDevelopmentThreshold",
                table: "ClimaticFactor",
                type: "float",
                nullable: true);
        }
    }
}
