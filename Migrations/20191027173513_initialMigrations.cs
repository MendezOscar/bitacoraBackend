using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bitacorabackend.Migrations
{
    public partial class initialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Bitacories",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    date = table.Column<DateTime>(nullable: false),
                    Activity = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true),
                    InitialDate = table.Column<DateTime>(nullable: false),
                    FinalDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitacories", x => x.id);
                    table.ForeignKey(
                        name: "FK_Bitacories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bitacories_CategoryId",
                table: "Bitacories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bitacories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
