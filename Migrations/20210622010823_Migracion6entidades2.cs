using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto.Migrations
{
    public partial class Migracion6entidades2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Docente_Plantel_Id_Docente",
                table: "Docente");

            migrationBuilder.DropIndex(
                name: "IX_Docente_Id_Docente",
                table: "Docente");

            migrationBuilder.DropColumn(
                name: "Id_Docente",
                table: "Docente");

            migrationBuilder.CreateIndex(
                name: "IX_Docente_Id_Plantel",
                table: "Docente",
                column: "Id_Plantel");

            migrationBuilder.AddForeignKey(
                name: "FK_Docente_Plantel_Id_Plantel",
                table: "Docente",
                column: "Id_Plantel",
                principalTable: "Plantel",
                principalColumn: "ID_lantel",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Docente_Plantel_Id_Plantel",
                table: "Docente");

            migrationBuilder.DropIndex(
                name: "IX_Docente_Id_Plantel",
                table: "Docente");

            migrationBuilder.AddColumn<int>(
                name: "Id_Docente",
                table: "Docente",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Docente_Id_Docente",
                table: "Docente",
                column: "Id_Docente");

            migrationBuilder.AddForeignKey(
                name: "FK_Docente_Plantel_Id_Docente",
                table: "Docente",
                column: "Id_Docente",
                principalTable: "Plantel",
                principalColumn: "ID_lantel",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
