using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcPoznamky.Migrations
{
    public partial class PridaniPoznamek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Jmeno",
                table: "Uzivatele",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Poznamky",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutorId = table.Column<int>(type: "int", nullable: false),
                    DatumVytvoreni = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poznamky", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poznamky_Uzivatele_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Uzivatele",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uzivatele_Jmeno",
                table: "Uzivatele",
                column: "Jmeno",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Poznamky_AutorId",
                table: "Poznamky",
                column: "AutorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Poznamky");

            migrationBuilder.DropIndex(
                name: "IX_Uzivatele_Jmeno",
                table: "Uzivatele");

            migrationBuilder.AlterColumn<string>(
                name: "Jmeno",
                table: "Uzivatele",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
