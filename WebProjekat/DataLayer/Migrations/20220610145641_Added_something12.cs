using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Added_something12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admini",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PunoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admini", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dostavljaci",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PunoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dostavljaci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Lozinka = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PunoIme = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodi",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeProizvoda = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cena = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    Sastojci = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Porudzbine",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Komentar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cena = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    DostavljacId = table.Column<long>(type: "bigint", nullable: true),
                    KorisnikId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porudzbine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Porudzbine_Dostavljaci_DostavljacId",
                        column: x => x.DostavljacId,
                        principalTable: "Dostavljaci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Porudzbine_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kolicina",
                columns: table => new
                {
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    KolicinaProizvoda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kolicina", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_Kolicina_Porudzbine_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Porudzbine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kolicina_Proizvodi_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Proizvodi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kolicina_OrderId",
                table: "Kolicina",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_KorisnickoIme",
                table: "Korisnici",
                column: "KorisnickoIme",
                unique: true,
                filter: "[KorisnickoIme] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Porudzbine_DostavljacId",
                table: "Porudzbine",
                column: "DostavljacId");

            migrationBuilder.CreateIndex(
                name: "IX_Porudzbine_KorisnikId",
                table: "Porudzbine",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodi_ImeProizvoda",
                table: "Proizvodi",
                column: "ImeProizvoda",
                unique: true,
                filter: "[ImeProizvoda] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admini");

            migrationBuilder.DropTable(
                name: "Kolicina");

            migrationBuilder.DropTable(
                name: "Porudzbine");

            migrationBuilder.DropTable(
                name: "Proizvodi");

            migrationBuilder.DropTable(
                name: "Dostavljaci");

            migrationBuilder.DropTable(
                name: "Korisnici");
        }
    }
}
