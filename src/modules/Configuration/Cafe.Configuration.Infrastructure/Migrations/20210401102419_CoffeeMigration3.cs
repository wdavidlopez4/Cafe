using Microsoft.EntityFrameworkCore.Migrations;

namespace Cafe.Configuration.Infrastructure.Migrations
{
    public partial class CoffeeMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCoffeeGrower",
                table: "Crop");

            migrationBuilder.AddColumn<string>(
                name: "ConfigurationCropId",
                table: "Crop",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayFormation",
                table: "Crop",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Crop",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ConfigurationCrop",
                columns: table => new
                {
                    CropId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationCrop", x => x.CropId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crop_ConfigurationCropId",
                table: "Crop",
                column: "ConfigurationCropId",
                unique: true,
                filter: "[ConfigurationCropId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Crop_ConfigurationCrop_ConfigurationCropId",
                table: "Crop",
                column: "ConfigurationCropId",
                principalTable: "ConfigurationCrop",
                principalColumn: "CropId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crop_ConfigurationCrop_ConfigurationCropId",
                table: "Crop");

            migrationBuilder.DropTable(
                name: "ConfigurationCrop");

            migrationBuilder.DropIndex(
                name: "IX_Crop_ConfigurationCropId",
                table: "Crop");

            migrationBuilder.DropColumn(
                name: "ConfigurationCropId",
                table: "Crop");

            migrationBuilder.DropColumn(
                name: "DayFormation",
                table: "Crop");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Crop");

            migrationBuilder.AddColumn<string>(
                name: "IdCoffeeGrower",
                table: "Crop",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
