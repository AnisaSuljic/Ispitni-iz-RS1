using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_2020_01_30.Migrations
{
    public partial class pocetna_takmicenja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Takmicenje",
                columns: table => new
                {
                    TakmicenjeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PredmetID = table.Column<int>(nullable: false),
                    SkolaID = table.Column<int>(nullable: false),
                    Razred = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    BrojKojiNisuPristupili = table.Column<int>(nullable: false),
                    IsZakljucano = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Takmicenje", x => x.TakmicenjeID);
                    table.ForeignKey(
                        name: "FK_Takmicenje_Predmet_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Takmicenje_Skola_SkolaID",
                        column: x => x.SkolaID,
                        principalTable: "Skola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TakmicenjeUcesnik",
                columns: table => new
                {
                    TakmicenjeUcesnikID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TakmicenjeID = table.Column<int>(nullable: false),
                    OdjeljenjeStavkaID = table.Column<int>(nullable: false),
                    IsPristupio = table.Column<bool>(nullable: false),
                    Bodovi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakmicenjeUcesnik", x => x.TakmicenjeUcesnikID);
                    table.ForeignKey(
                        name: "FK_TakmicenjeUcesnik_OdjeljenjeStavka_OdjeljenjeStavkaID",
                        column: x => x.OdjeljenjeStavkaID,
                        principalTable: "OdjeljenjeStavka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TakmicenjeUcesnik_Takmicenje_TakmicenjeID",
                        column: x => x.TakmicenjeID,
                        principalTable: "Takmicenje",
                        principalColumn: "TakmicenjeID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Takmicenje_PredmetID",
                table: "Takmicenje",
                column: "PredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_Takmicenje_SkolaID",
                table: "Takmicenje",
                column: "SkolaID");

            migrationBuilder.CreateIndex(
                name: "IX_TakmicenjeUcesnik_OdjeljenjeStavkaID",
                table: "TakmicenjeUcesnik",
                column: "OdjeljenjeStavkaID");

            migrationBuilder.CreateIndex(
                name: "IX_TakmicenjeUcesnik_TakmicenjeID",
                table: "TakmicenjeUcesnik",
                column: "TakmicenjeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TakmicenjeUcesnik");

            migrationBuilder.DropTable(
                name: "Takmicenje");
        }
    }
}
