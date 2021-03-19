using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_2019_06_25.Migrations
{
    public partial class pocetna2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IspitniTermin",
                columns: table => new
                {
                    IspitniTerminID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AngazovanID = table.Column<int>(nullable: false),
                    DatumIspita = table.Column<DateTime>(nullable: false),
                    Napomena = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IspitniTermin", x => x.IspitniTerminID);
                    table.ForeignKey(
                        name: "FK_IspitniTermin_Angazovan_AngazovanID",
                        column: x => x.AngazovanID,
                        principalTable: "Angazovan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IspitniTermin_AngazovanID",
                table: "IspitniTermin",
                column: "AngazovanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IspitniTermin");
        }
    }
}
