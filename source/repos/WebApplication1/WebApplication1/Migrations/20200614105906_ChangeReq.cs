using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class ChangeReq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zamówienia_Pracownik_IdPracownik",
                table: "Zamówienia");


            migrationBuilder.AlterColumn<int>(
                name: "IdPracownik",
                table: "Zamówienia",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Zamówienia_Pracownik_IdPracownik",
                table: "Zamówienia",
                column: "IdPracownik",
                principalTable: "Pracownik",
                principalColumn: "IdPracownik",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zamówienia_Pracownik_IdPracownik",
                table: "Zamówienia");

            migrationBuilder.AlterColumn<int>(
                name: "IdPracownik",
                table: "Zamówienia",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Zamówienia_Pracownik_IdPracownik",
                table: "Zamówienia",
                column: "IdPracownik",
                principalTable: "Pracownik",
                principalColumn: "IdPracownik",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
