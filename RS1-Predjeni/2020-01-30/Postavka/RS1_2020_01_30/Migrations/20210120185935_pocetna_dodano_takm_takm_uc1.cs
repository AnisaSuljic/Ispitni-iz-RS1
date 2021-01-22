using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_2020_01_30.Migrations
{
    public partial class pocetna_dodano_takm_takm_uc1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TakmicenjeId",
                table: "TakmicenjeUcesnik",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TakmicenjeUcesnik_TakmicenjeId",
                table: "TakmicenjeUcesnik",
                column: "TakmicenjeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TakmicenjeUcesnik_Takmicenje_TakmicenjeId",
                table: "TakmicenjeUcesnik",
                column: "TakmicenjeId",
                principalTable: "Takmicenje",
                principalColumn: "TakmicenjeID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TakmicenjeUcesnik_Takmicenje_TakmicenjeId",
                table: "TakmicenjeUcesnik");

            migrationBuilder.DropIndex(
                name: "IX_TakmicenjeUcesnik_TakmicenjeId",
                table: "TakmicenjeUcesnik");

            migrationBuilder.DropColumn(
                name: "TakmicenjeId",
                table: "TakmicenjeUcesnik");
        }
    }
}
