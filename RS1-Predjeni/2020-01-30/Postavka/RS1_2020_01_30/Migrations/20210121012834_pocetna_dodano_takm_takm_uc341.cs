using Microsoft.EntityFrameworkCore.Migrations;

namespace RS1_2020_01_30.Migrations
{
    public partial class pocetna_dodano_takm_takm_uc341 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsZakljucano",
                table: "Takmicenje");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsZakljucano",
                table: "Takmicenje",
                nullable: false,
                defaultValue: false);
        }
    }
}
