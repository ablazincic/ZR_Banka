using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZR_Banka.Migrations
{
    /// <inheritdoc />
    public partial class AddZahtjevV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdZahtjev",
                table: "Zahtjev",
                newName: "id_zahtjev");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_zahtjev",
                table: "Zahtjev",
                newName: "IdZahtjev");
        }
    }
}
