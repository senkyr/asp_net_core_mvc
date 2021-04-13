using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcPoznamky.Migrations
{
    public partial class TakUzSnad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Poznamky_Uzivatele_UzivatelId",
                table: "Poznamky");

            migrationBuilder.RenameColumn(
                name: "UzivatelId",
                table: "Poznamky",
                newName: "AutorId");

            migrationBuilder.RenameIndex(
                name: "IX_Poznamky_UzivatelId",
                table: "Poznamky",
                newName: "IX_Poznamky_AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Poznamky_Uzivatele_AutorId",
                table: "Poznamky",
                column: "AutorId",
                principalTable: "Uzivatele",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Poznamky_Uzivatele_AutorId",
                table: "Poznamky");

            migrationBuilder.RenameColumn(
                name: "AutorId",
                table: "Poznamky",
                newName: "UzivatelId");

            migrationBuilder.RenameIndex(
                name: "IX_Poznamky_AutorId",
                table: "Poznamky",
                newName: "IX_Poznamky_UzivatelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Poznamky_Uzivatele_UzivatelId",
                table: "Poznamky",
                column: "UzivatelId",
                principalTable: "Uzivatele",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
