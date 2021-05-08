using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cafe.Climate.Infrastructure.Migrations
{
    public partial class ClimateMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DegreesDays",
                table: "ClimaticFactor",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "ClimaticFactor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DegreesDays",
                table: "ClimaticFactor");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "ClimaticFactor");
        }
    }
}
