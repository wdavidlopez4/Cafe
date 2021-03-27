using Microsoft.EntityFrameworkCore.Migrations;

namespace Cafe.Configuration.Infrastructure.Migrations
{
    public partial class CoffeeMigration1 : Migration
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
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeGrowers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Crop",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IdCoffeeGrower = table.Column<string>(nullable: true),
                    CoffeeGrowerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crop_CoffeeGrowers_CoffeeGrowerId",
                        column: x => x.CoffeeGrowerId,
                        principalTable: "CoffeeGrowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crop_CoffeeGrowerId",
                table: "Crop",
                column: "CoffeeGrowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crop");

            migrationBuilder.DropTable(
                name: "CoffeeGrowers");
        }
    }
}
