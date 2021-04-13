using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcPoznamky.Migrations
{
    public partial class RefaktorizaceDatabaze : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Poznamky_Uzivatele_AutorId",
                table: "Poznamky");

            migrationBuilder.AlterColumn<int>(
                name: "AutorId",
                table: "Poznamky",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "AutorId",
                table: "Poznamky",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Poznamky_Uzivatele_AutorId",
                table: "Poznamky",
                column: "AutorId",
                principalTable: "Uzivatele",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
