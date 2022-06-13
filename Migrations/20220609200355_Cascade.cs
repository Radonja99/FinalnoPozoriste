using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PozoristeProjekat.Migrations
{
    public partial class Cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnikID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImeKorisnika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrezimeKorisnika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LozinkaKorisnika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojRezervacija = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.KorisnikID);
                });

            migrationBuilder.CreateTable(
                name: "Predstava",
                columns: table => new
                {
                    PredstavaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NazivPredstave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zanr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojIzvodjenja = table.Column<int>(type: "int", nullable: false),
                    DatumPremijere = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predstava", x => x.PredstavaID);
                });

            migrationBuilder.CreateTable(
                name: "Urednik",
                columns: table => new
                {
                    UrednikID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImeUrednika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrezimeUrednika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JMBGUrednika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickoImeUrednika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LozinkaUrednika = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urednik", x => x.UrednikID);
                });

            migrationBuilder.CreateTable(
                name: "Pozoriste",
                columns: table => new
                {
                    PozoristeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NazivPozorista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrednikID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pozoriste", x => x.PozoristeID);
                    table.ForeignKey(
                        name: "FK_Pozoriste_Urednik_UrednikID",
                        column: x => x.UrednikID,
                        principalTable: "Urednik",
                        principalColumn: "UrednikID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    SalaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NazivSale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UkupanBrojMesta = table.Column<int>(type: "int", nullable: false),
                    PozoristeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.SalaID);
                    table.ForeignKey(
                        name: "FK_Sala_Pozoriste_PozoristeID",
                        column: x => x.PozoristeID,
                        principalTable: "Pozoriste",
                        principalColumn: "PozoristeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Izvedba",
                columns: table => new
                {
                    IzvedbaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatumPrikazivanja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GostujucaPredstava = table.Column<bool>(type: "bit", nullable: false),
                    BrojSlobodnihMesta = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    SalaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PredstavaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izvedba", x => x.IzvedbaID);
                    table.ForeignKey(
                        name: "FK_Izvedba_Predstava_PredstavaID",
                        column: x => x.PredstavaID,
                        principalTable: "Predstava",
                        principalColumn: "PredstavaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Izvedba_Sala_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Sala",
                        principalColumn: "SalaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sediste",
                columns: table => new
                {
                    SedisteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrojReda = table.Column<int>(type: "int", nullable: false),
                    Sektor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojSedista = table.Column<int>(type: "int", nullable: false),
                    SalaID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sediste", x => x.SedisteID);
                    table.ForeignKey(
                        name: "FK_Sediste_Sala_SalaID",
                        column: x => x.SalaID,
                        principalTable: "Sala",
                        principalColumn: "SalaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    RezervacijaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatumKreiranjaRezervacije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrojMesta = table.Column<int>(type: "int", nullable: false),
                    UkupnaCenaRezervacije = table.Column<int>(type: "int", nullable: false),
                    Placeno = table.Column<bool>(type: "bit", nullable: false),
                    DatumIstekaRezervacije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KorisnikID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IzvedbaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.RezervacijaID);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Izvedba_IzvedbaID",
                        column: x => x.IzvedbaID,
                        principalTable: "Izvedba",
                        principalColumn: "IzvedbaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Izvedba_PredstavaID",
                table: "Izvedba",
                column: "PredstavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Izvedba_SalaID",
                table: "Izvedba",
                column: "SalaID");

            migrationBuilder.CreateIndex(
                name: "IX_Pozoriste_UrednikID",
                table: "Pozoriste",
                column: "UrednikID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_IzvedbaID",
                table: "Rezervacija",
                column: "IzvedbaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KorisnikID",
                table: "Rezervacija",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Sala_PozoristeID",
                table: "Sala",
                column: "PozoristeID");

            migrationBuilder.CreateIndex(
                name: "IX_Sediste_SalaID",
                table: "Sediste",
                column: "SalaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervacija");

            migrationBuilder.DropTable(
                name: "Sediste");

            migrationBuilder.DropTable(
                name: "Izvedba");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Predstava");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "Pozoriste");

            migrationBuilder.DropTable(
                name: "Urednik");
        }
    }
}
