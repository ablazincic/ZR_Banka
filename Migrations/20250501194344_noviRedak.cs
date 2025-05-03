using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZR_Banka.Migrations
{
    /// <inheritdoc />
    public partial class noviRedak : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "UkupanIznos",
                table: "Kredit",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UkupanIznos",
                table: "Kredit");
        }
    }
}
