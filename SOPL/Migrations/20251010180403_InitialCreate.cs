using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOPL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lekarze",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specjalizacja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lekarze", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leki",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StanMagazynowy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leki", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacjenci",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacjenci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistorieChorob",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacjentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LekarzId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataWizyty = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diagnoza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zalecenia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorieChorob", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorieChorob_Lekarze_LekarzId",
                        column: x => x.LekarzId,
                        principalTable: "Lekarze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorieChorob_Pacjenci_PacjentId",
                        column: x => x.PacjentId,
                        principalTable: "Pacjenci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wizyty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LekarzId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacjentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataRozpoczecia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataZakonczenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wizyty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wizyty_Lekarze_LekarzId",
                        column: x => x.LekarzId,
                        principalTable: "Lekarze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wizyty_Pacjenci_PacjentId",
                        column: x => x.PacjentId,
                        principalTable: "Pacjenci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recepty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HistoriaChorobyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataWystawienia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Uwagi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recepty_HistorieChorob_HistoriaChorobyId",
                        column: x => x.HistoriaChorobyId,
                        principalTable: "HistorieChorob",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PozycjeRecepty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceptaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LekId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PozycjeRecepty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PozycjeRecepty_Leki_LekId",
                        column: x => x.LekId,
                        principalTable: "Leki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PozycjeRecepty_Recepty_ReceptaId",
                        column: x => x.ReceptaId,
                        principalTable: "Recepty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorieChorob_LekarzId",
                table: "HistorieChorob",
                column: "LekarzId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorieChorob_PacjentId",
                table: "HistorieChorob",
                column: "PacjentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lekarze_Email",
                table: "Lekarze",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacjenci_Email",
                table: "Pacjenci",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacjenci_Pesel",
                table: "Pacjenci",
                column: "Pesel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PozycjeRecepty_LekId",
                table: "PozycjeRecepty",
                column: "LekId");

            migrationBuilder.CreateIndex(
                name: "IX_PozycjeRecepty_ReceptaId",
                table: "PozycjeRecepty",
                column: "ReceptaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recepty_HistoriaChorobyId",
                table: "Recepty",
                column: "HistoriaChorobyId");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_LekarzId",
                table: "Wizyty",
                column: "LekarzId");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_PacjentId",
                table: "Wizyty",
                column: "PacjentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PozycjeRecepty");

            migrationBuilder.DropTable(
                name: "Wizyty");

            migrationBuilder.DropTable(
                name: "Leki");

            migrationBuilder.DropTable(
                name: "Recepty");

            migrationBuilder.DropTable(
                name: "HistorieChorob");

            migrationBuilder.DropTable(
                name: "Lekarze");

            migrationBuilder.DropTable(
                name: "Pacjenci");
        }
    }
}
