using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ZR_Banka.Migrations
{
    /// <inheritdoc />
    public partial class TB_Zahtjev : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zahtjev",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_korisnik = table.Column<int>(type: "integer", nullable: false),
                    vrsta_kredita = table.Column<string>(type: "text", nullable: false),
                    iznos = table.Column<decimal>(type: "numeric", nullable: false),
                    datum_zahtjeva = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status_zahtjeva = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zahtjev", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zahtjev");
        }
    }
}
