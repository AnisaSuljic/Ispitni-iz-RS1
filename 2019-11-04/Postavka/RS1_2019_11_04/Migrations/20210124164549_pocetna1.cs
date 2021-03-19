using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_2019_11_04.Migrations
{
    public partial class pocetna1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PopravniIspit",
                columns: table => new
                {
                    PopravniIspitID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    PredmetID = table.Column<int>(nullable: false),
                    SkolaID = table.Column<int>(nullable: false),
                    SkolskaGodinaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopravniIspit", x => x.PopravniIspitID);
                    table.ForeignKey(
                        name: "FK_PopravniIspit_Predmet_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PopravniIspit_Skola_SkolaID",
                        column: x => x.SkolaID,
                        principalTable: "Skola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PopravniIspit_SkolskaGodina_SkolskaGodinaID",
                        column: x => x.SkolskaGodinaID,
                        principalTable: "SkolskaGodina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PopravniIspit_PredmetID",
                table: "PopravniIspit",
                column: "PredmetID");

            migrationBuilder.CreateIndex(
                name: "IX_PopravniIspit_SkolaID",
                table: "PopravniIspit",
                column: "SkolaID");

            migrationBuilder.CreateIndex(
                name: "IX_PopravniIspit_SkolskaGodinaID",
                table: "PopravniIspit",
                column: "SkolskaGodinaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PopravniIspit");
        }
    }
}
