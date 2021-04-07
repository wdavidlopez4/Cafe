using Microsoft.EntityFrameworkCore.Migrations;

namespace Cafe.Configuration.Infrastructure.Migrations
{
    public partial class CofeeMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoffeeGrowers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeGrowers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Crops",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DayFormation = table.Column<int>(nullable: false),
                    CoffeeGrowerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crops_CoffeeGrowers_CoffeeGrowerId",
                        column: x => x.CoffeeGrowerId,
                        principalTable: "CoffeeGrowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationCrops",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CropId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationCrops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfigurationCrops_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Temperatures",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConfigurationCropId = table.Column<string>(nullable: true),
                    MinimumThresholdInsectDevelopment = table.Column<double>(nullable: false),
                    MaximunThresholdInsectDevelioment = table.Column<double>(nullable: false),
                    MinimumEffectiveGrade = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temperatures_ConfigurationCrops_ConfigurationCropId",
                        column: x => x.ConfigurationCropId,
                        principalTable: "ConfigurationCrops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationCrops_CropId",
                table: "ConfigurationCrops",
                column: "CropId",
                unique: true,
                filter: "[CropId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_CoffeeGrowerId",
                table: "Crops",
                column: "CoffeeGrowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Temperatures_ConfigurationCropId",
                table: "Temperatures",
                column: "ConfigurationCropId",
                unique: true,
                filter: "[ConfigurationCropId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Temperatures");

            migrationBuilder.DropTable(
                name: "ConfigurationCrops");

            migrationBuilder.DropTable(
                name: "Crops");

            migrationBuilder.DropTable(
                name: "CoffeeGrowers");
        }
    }
}
