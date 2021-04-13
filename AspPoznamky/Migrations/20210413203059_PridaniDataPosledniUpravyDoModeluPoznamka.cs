using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspPoznamky.Migrations
{
    public partial class PridaniDataPosledniUpravyDoModeluPoznamka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatumPosledniUpravy",
                table: "Poznamky",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatumPosledniUpravy",
                table: "Poznamky");
        }
    }
}
