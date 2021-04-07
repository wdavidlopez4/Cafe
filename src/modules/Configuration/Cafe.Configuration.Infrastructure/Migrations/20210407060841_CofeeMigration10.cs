using Microsoft.EntityFrameworkCore.Migrations;

namespace Cafe.Configuration.Infrastructure.Migrations
{
    public partial class CofeeMigration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Temperatures",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConfigurationCropId",
                table: "Temperatures",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temperatures",
                table: "Temperatures",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Temperatures_ConfigurationCropId",
                table: "Temperatures",
                column: "ConfigurationCropId",
                unique: true,
                filter: "[ConfigurationCropId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Temperatures_ConfigurationCrops_ConfigurationCropId",
                table: "Temperatures",
                column: "ConfigurationCropId",
                principalTable: "ConfigurationCrops",
                principalColumn: "CropId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Temperatures_ConfigurationCrops_ConfigurationCropId",
                table: "Temperatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temperatures",
                table: "Temperatures");

            migrationBuilder.DropIndex(
                name: "IX_Temperatures_ConfigurationCropId",
                table: "Temperatures");

            migrationBuilder.AlterColumn<string>(
                name: "ConfigurationCropId",
                table: "Temperatures",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Temperatures",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "TemperatureId",
                table: "ConfigurationCrops",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
