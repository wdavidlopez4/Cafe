using Microsoft.EntityFrameworkCore.Migrations;

namespace Cafe.Configuration.Infrastructure.Migrations
{
    public partial class CofeeMigration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Climate_ConfigurationCrops_ConfigurationCropId",
                table: "Climate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Climate",
                table: "Climate");

            migrationBuilder.DropIndex(
                name: "IX_Climate_ConfigurationCropId",
                table: "Climate");

            migrationBuilder.AlterColumn<string>(
                name: "ConfigurationCropId",
                table: "Climate",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Climate",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Climate_ConfigurationCrops_ConfigurationCropId",
                table: "Climate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Climate",
                table: "Climate");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Climate",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ConfigurationCropId",
                table: "Climate",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Climate",
                table: "Climate",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Climate_ConfigurationCropId",
                table: "Climate",
                column: "ConfigurationCropId");

            migrationBuilder.AddForeignKey(
                name: "FK_Climate_ConfigurationCrops_ConfigurationCropId",
                table: "Climate",
                column: "ConfigurationCropId",
                principalTable: "ConfigurationCrops",
                principalColumn: "CropId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
