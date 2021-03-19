using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_2019_12_02.Migrations
{
    public partial class pocetna_popravni_dodan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PopravniIspit",
                columns: table => new
                {
                    PopravniIspitID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumIspita = table.Column<DateTime>(nullable: false),
                    OdjeljenjeID = table.Column<int>(nullable: false),
                    PredmetID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopravniIspit", x => x.PopravniIspitID);
                    table.ForeignKey(
                        name: "FK_PopravniIspit_Odjeljenje_OdjeljenjeID",
                        column: x => x.OdjeljenjeID,
                        principalTable: "Odjeljenje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PopravniIspit_Predmet_PredmetID",
                        column: x => x.PredmetID,
                        principalTable: "Predmet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PopravniIspit_OdjeljenjeID",
                table: "PopravniIspit",
                column: "OdjeljenjeID");

            migrationBuilder.CreateIndex(
                name: "IX_PopravniIspit_PredmetID",
                table: "PopravniIspit",
                column: "PredmetID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PopravniIspit");
        }
    }
}
