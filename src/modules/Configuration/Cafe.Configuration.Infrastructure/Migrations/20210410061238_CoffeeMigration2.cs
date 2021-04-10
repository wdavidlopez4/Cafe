using Microsoft.EntityFrameworkCore.Migrations;

namespace Cafe.Configuration.Infrastructure.Migrations
{
    public partial class CoffeeMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arduino",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ConfigurationCropId = table.Column<string>(nullable: true),
                    Occupied = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arduino", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arduino_ConfigurationCrops_ConfigurationCropId",
                        column: x => x.ConfigurationCropId,
                        principalTable: "ConfigurationCrops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arduino_ConfigurationCropId",
                table: "Arduino",
                column: "ConfigurationCropId",
                unique: true,
                filter: "[ConfigurationCropId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arduino");
        }
    }
}
