using Microsoft.EntityFrameworkCore.Migrations;

namespace Cafe.Configuration.Infrastructure.Migrations
{
    public partial class CofeeMigration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Climate_ConfigurationCrops_ConfigurationCropId",
                table: "Climate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Climate",
                table: "Climate");

            migrationBuilder.DropColumn(
                name: "ClimateId",
                table: "ConfigurationCrops");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Climate");

            migrationBuilder.RenameTable(
                name: "Climate",
                newName: "Temperatures");

            migrationBuilder.AddColumn<string>(
                name: "TemperatureId",
                table: "ConfigurationCrops",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "MinimumThresholdInsectDevelopment",
                table: "Temperatures",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "MinimumEffectiveGrade",
                table: "Temperatures",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "MaximunThresholdInsectDevelioment",
                table: "Temperatures",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temperatures",
                table: "Temperatures",
                column: "ConfigurationCropId");

            migrationBuilder.AddForeignKey(
                name: "FK_Temperatures_ConfigurationCrops_ConfigurationCropId",
                table: "Temperatures",
                column: "ConfigurationCropId",
                principalTable: "ConfigurationCrops",
                principalColumn: "CropId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Temperatures_ConfigurationCrops_ConfigurationCropId",
                table: "Temperatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temperatures",
                table: "Temperatures");

            migrationBuilder.DropColumn(
                name: "TemperatureId",
                table: "ConfigurationCrops");

            migrationBuilder.RenameTable(
                name: "Temperatures",
                newName: "Climate");

            migrationBuilder.AddColumn<string>(
                name: "ClimateId",
                table: "ConfigurationCrops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "MinimumThresholdInsectDevelopment",
                table: "Climate",
                type: "float",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "MinimumEffectiveGrade",
                table: "Climate",
                type: "float",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<double>(
                name: "MaximunThresholdInsectDevelioment",
                table: "Climate",
                type: "float",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Climate",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Climate",
                table: "Climate",
                column: "ConfigurationCropId");

            migrationBuilder.AddForeignKey(
                name: "FK_Climate_ConfigurationCrops_ConfigurationCropId",
                table: "Climate",
                column: "ConfigurationCropId",
                principalTable: "ConfigurationCrops",
                principalColumn: "CropId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
