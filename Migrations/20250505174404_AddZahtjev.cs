using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZR_Banka.Migrations
{
    /// <inheritdoc />
    public partial class AddZahtjev : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Zahtjev",
                table: "Zahtjev");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Zahtjev",
                newName: "IdZahtjev");

            migrationBuilder.AddColumn<DateTime>(
                name: "vrijeme_otplate",
                table: "Zahtjev",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "Zahtjev_pkey",
                table: "Zahtjev",
                column: "IdZahtjev");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "Zahtjev_pkey",
                table: "Zahtjev");

            migrationBuilder.DropColumn(
                name: "vrijeme_otplate",
                table: "Zahtjev");

            migrationBuilder.RenameColumn(
                name: "IdZahtjev",
                table: "Zahtjev",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zahtjev",
                table: "Zahtjev",
                column: "Id");
        }
    }
}
