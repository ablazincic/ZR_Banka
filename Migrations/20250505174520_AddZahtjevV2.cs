using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZR_Banka.Migrations
{
    /// <inheritdoc />
    public partial class AddZahtjevV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "vrijeme_otplate",
                table: "Zahtjev",
                type: "integer",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "vrijeme_otplate",
                table: "Zahtjev",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
