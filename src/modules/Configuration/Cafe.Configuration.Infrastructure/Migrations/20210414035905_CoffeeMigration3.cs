using Microsoft.EntityFrameworkCore.Migrations;

namespace Cafe.Configuration.Infrastructure.Migrations
{
    public partial class CoffeeMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monitoring",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CropId = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    ActivateByImage = table.Column<string>(nullable: true),
                    ActivateManually = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitoring", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monitoring_Crops_CropId",
                        column: x => x.CropId,
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monitoring_CropId",
                table: "Monitoring",
                column: "CropId",
                unique: true,
                filter: "[CropId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monitoring");
        }
    }
}
