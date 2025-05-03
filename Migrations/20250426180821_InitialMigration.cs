using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ZR_Banka.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    id_korisnik = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ime = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    prezime = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    username = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    password = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    mail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    uloga = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Korisnik_pkey", x => x.id_korisnik);
                });

            migrationBuilder.CreateTable(
                name: "Uplata",
                columns: table => new
                {
                    id_uplate = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_kredit = table.Column<int>(type: "integer", nullable: true),
                    uplata = table.Column<decimal>(type: "numeric(6,2)", precision: 6, scale: 2, nullable: false),
                    datum_uplate = table.Column<DateOnly>(type: "date", nullable: false),
                    preostali_dug = table.Column<decimal>(type: "numeric(7,2)", precision: 7, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Uplata_pkey", x => x.id_uplate);
                });

            migrationBuilder.CreateTable(
                name: "Kredit",
                columns: table => new
                {
                    id_kredit = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_korisnik = table.Column<int>(type: "integer", nullable: true),
                    vrsta_kredita = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    datum_pozajmice = table.Column<DateOnly>(type: "date", nullable: false),
                    kamatna_stopa = table.Column<decimal>(type: "numeric(4,2)", precision: 4, scale: 2, nullable: false),
                    vrijeme_otplate = table.Column<int>(type: "integer", nullable: false),
                    glavnica = table.Column<decimal>(type: "numeric", nullable: false),
                    status_kredita = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Kredit_pkey", x => x.id_kredit);
                    table.ForeignKey(
                        name: "id_korisnik",
                        column: x => x.id_korisnik,
                        principalTable: "Korisnik",
                        principalColumn: "id_korisnik");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kredit_id_korisnik",
                table: "Kredit",
                column: "id_korisnik");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kredit");

            migrationBuilder.DropTable(
                name: "Uplata");

            migrationBuilder.DropTable(
                name: "Korisnik");
        }
    }
}
