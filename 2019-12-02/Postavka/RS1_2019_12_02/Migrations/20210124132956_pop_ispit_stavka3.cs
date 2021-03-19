using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RS1_2019_12_02.Migrations
{
    public partial class pop_ispit_stavka3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Bodovi",
                table: "PopravniIspitStavke",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Bodovi",
                table: "PopravniIspitStavke",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
