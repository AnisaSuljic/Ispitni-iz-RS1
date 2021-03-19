using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_2019_06_25.Migrations
{
    public partial class pocetna6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IspitniTerminStavke",
                columns: table => new
                {
                    IspitniTerminStavkeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsPristupio = table.Column<bool>(nullable: false),
                    IspitniTerminID = table.Column<int>(nullable: false),
                    Ocjena = table.Column<int>(nullable: false),
                    StudentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IspitniTerminStavke", x => x.IspitniTerminStavkeID);
                    table.ForeignKey(
                        name: "FK_IspitniTerminStavke_IspitniTermin_IspitniTerminID",
                        column: x => x.IspitniTerminID,
                        principalTable: "IspitniTermin",
                        principalColumn: "IspitniTerminID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IspitniTerminStavke_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IspitniTerminStavke_IspitniTerminID",
                table: "IspitniTerminStavke",
                column: "IspitniTerminID");

            migrationBuilder.CreateIndex(
                name: "IX_IspitniTerminStavke_StudentID",
                table: "IspitniTerminStavke",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IspitniTerminStavke");
        }
    }
}
