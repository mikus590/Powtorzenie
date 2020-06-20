using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class AddedPracownikTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPracownik",
                table: "Zamówienia",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pracownik",
                columns: table => new
                {
                    IdPracownik = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Imie = table.Column<string>(maxLength: 50, nullable: true),
                    Nazwisko = table.Column<int>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracownik", x => x.IdPracownik);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zamówienia_IdPracownik",
                table: "Zamówienia",
                column: "IdPracownik");

            migrationBuilder.AddForeignKey(
                name: "FK_Zamówienia_Pracownik_IdPracownik",
                table: "Zamówienia",
                column: "IdPracownik",
                principalTable: "Pracownik",
                principalColumn: "IdPracownik",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zamówienia_Pracownik_IdPracownik",
                table: "Zamówienia");

            migrationBuilder.DropTable(
                name: "Pracownik");

            migrationBuilder.DropIndex(
                name: "IX_Zamówienia_IdPracownik",
                table: "Zamówienia");

            migrationBuilder.DropColumn(
                name: "IdPracownik",
                table: "Zamówienia");
        }
    }
}
