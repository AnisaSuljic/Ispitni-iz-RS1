using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_2019_11_04.Migrations
{
    public partial class pocetna3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PopravniIspitStavke",
                columns: table => new
                {
                    PopravniIspitStavkeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bodovi = table.Column<int>(nullable: false),
                    IsPrisutan = table.Column<bool>(nullable: false),
                    OdjeljenjeStavkeID = table.Column<int>(nullable: false),
                    PopravniIspitID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopravniIspitStavke", x => x.PopravniIspitStavkeID);
                    table.ForeignKey(
                        name: "FK_PopravniIspitStavke_OdjeljenjeStavka_OdjeljenjeStavkeID",
                        column: x => x.OdjeljenjeStavkeID,
                        principalTable: "OdjeljenjeStavka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PopravniIspitStavke_PopravniIspit_PopravniIspitID",
                        column: x => x.PopravniIspitID,
                        principalTable: "PopravniIspit",
                        principalColumn: "PopravniIspitID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PopravniIspitStavke_OdjeljenjeStavkeID",
                table: "PopravniIspitStavke",
                column: "OdjeljenjeStavkeID");

            migrationBuilder.CreateIndex(
                name: "IX_PopravniIspitStavke_PopravniIspitID",
                table: "PopravniIspitStavke",
                column: "PopravniIspitID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PopravniIspitStavke");
        }
    }
}
