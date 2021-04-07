using Microsoft.EntityFrameworkCore.Migrations;

namespace Cafe.Configuration.Infrastructure.Migrations
{
    public partial class CofeeMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crop_CoffeeGrowers_CoffeeGrowerId",
                table: "Crop");

            migrationBuilder.DropForeignKey(
                name: "FK_Crop_ConfigurationCrop_ConfigurationCropId",
                table: "Crop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crop",
                table: "Crop");

            migrationBuilder.DropIndex(
                name: "IX_Crop_ConfigurationCropId",
                table: "Crop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfigurationCrop",
                table: "ConfigurationCrop");

            migrationBuilder.RenameTable(
                name: "Crop",
                newName: "Crops");

            migrationBuilder.RenameTable(
                name: "ConfigurationCrop",
                newName: "ConfigurationCrops");

            migrationBuilder.RenameIndex(
                name: "IX_Crop_CoffeeGrowerId",
                table: "Crops",
                newName: "IX_Crops_CoffeeGrowerId");

            migrationBuilder.AlterColumn<string>(
                name: "ConfigurationCropId",
                table: "Crops",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClimateId",
                table: "ConfigurationCrops",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "ConfigurationCrops",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crops",
                table: "Crops",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfigurationCrops",
                table: "ConfigurationCrops",
                column: "CropId");

            migrationBuilder.CreateTable(
                name: "Climate",
                columns: table => new
                {
                    ConfigurationCropId = table.Column<string>(nullable: false),
                    Id = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    MinimumThresholdInsectDevelopment = table.Column<double>(nullable: true),
                    MaximunThresholdInsectDevelioment = table.Column<double>(nullable: true),
                    MinimumEffectiveGrade = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Climate", x => x.ConfigurationCropId);
                    table.ForeignKey(
                        name: "FK_Climate_ConfigurationCrops_ConfigurationCropId",
                        column: x => x.ConfigurationCropId,
                        principalTable: "ConfigurationCrops",
                        principalColumn: "CropId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ConfigurationCrops_Crops_CropId",
                table: "ConfigurationCrops",
                column: "CropId",
                principalTable: "Crops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_CoffeeGrowers_CoffeeGrowerId",
                table: "Crops",
                column: "CoffeeGrowerId",
                principalTable: "CoffeeGrowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfigurationCrops_Crops_CropId",
                table: "ConfigurationCrops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_CoffeeGrowers_CoffeeGrowerId",
                table: "Crops");

            migrationBuilder.DropTable(
                name: "Climate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crops",
                table: "Crops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfigurationCrops",
                table: "ConfigurationCrops");

            migrationBuilder.DropColumn(
                name: "ClimateId",
                table: "ConfigurationCrops");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ConfigurationCrops");

            migrationBuilder.RenameTable(
                name: "Crops",
                newName: "Crop");

            migrationBuilder.RenameTable(
                name: "ConfigurationCrops",
                newName: "ConfigurationCrop");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_CoffeeGrowerId",
                table: "Crop",
                newName: "IX_Crop_CoffeeGrowerId");

            migrationBuilder.AlterColumn<string>(
                name: "ConfigurationCropId",
                table: "Crop",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crop",
                table: "Crop",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfigurationCrop",
                table: "ConfigurationCrop",
                column: "CropId");

            migrationBuilder.CreateIndex(
                name: "IX_Crop_ConfigurationCropId",
                table: "Crop",
                column: "ConfigurationCropId",
                unique: true,
                filter: "[ConfigurationCropId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Crop_CoffeeGrowers_CoffeeGrowerId",
                table: "Crop",
                column: "CoffeeGrowerId",
                principalTable: "CoffeeGrowers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Crop_ConfigurationCrop_ConfigurationCropId",
                table: "Crop",
                column: "ConfigurationCropId",
                principalTable: "ConfigurationCrop",
                principalColumn: "CropId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
