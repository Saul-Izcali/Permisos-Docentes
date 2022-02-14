using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto.Migrations
{
    public partial class QuitarEntidad_P_D : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Docente_Permiso_Docente_Nomina",
                table: "Docente");

            migrationBuilder.DropForeignKey(
                name: "FK_Permiso_Permiso_Docente_Id_Permiso",
                table: "Permiso");

            migrationBuilder.DropTable(
                name: "Permiso_Docente");

            migrationBuilder.AlterColumn<int>(
                name: "Id_Permiso",
                table: "Permiso",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "Id_Docente",
                table: "Permiso",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Permiso_Id_Docente",
                table: "Permiso",
                column: "Id_Docente");

            migrationBuilder.AddForeignKey(
                name: "FK_Permiso_Docente_Id_Docente",
                table: "Permiso",
                column: "Id_Docente",
                principalTable: "Docente",
                principalColumn: "Nomina",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permiso_Docente_Id_Docente",
                table: "Permiso");

            migrationBuilder.DropIndex(
                name: "IX_Permiso_Id_Docente",
                table: "Permiso");

            migrationBuilder.DropColumn(
                name: "Id_Docente",
                table: "Permiso");

            migrationBuilder.AlterColumn<int>(
                name: "Id_Permiso",
                table: "Permiso",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "Permiso_Docente",
                columns: table => new
                {
                    Numero = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Docente = table.Column<int>(type: "INTEGER", nullable: false),
                    Permiso = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso_Docente", x => x.Numero);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Docente_Permiso_Docente_Nomina",
                table: "Docente",
                column: "Nomina",
                principalTable: "Permiso_Docente",
                principalColumn: "Numero",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permiso_Permiso_Docente_Id_Permiso",
                table: "Permiso",
                column: "Id_Permiso",
                principalTable: "Permiso_Docente",
                principalColumn: "Numero",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
