using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto.Migrations
{
    public partial class Migracion6entidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Academia",
                columns: table => new
                {
                    ID_academia = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Academia", x => x.ID_academia);
                });

            migrationBuilder.CreateTable(
                name: "Permiso_Docente",
                columns: table => new
                {
                    Numero = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Permiso = table.Column<int>(type: "INTEGER", nullable: false),
                    Docente = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso_Docente", x => x.Numero);
                });

            migrationBuilder.CreateTable(
                name: "Plantel",
                columns: table => new
                {
                    ID_lantel = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plantel", x => x.ID_lantel);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Permiso",
                columns: table => new
                {
                    ID_permiso = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Permiso", x => x.ID_permiso);
                });

            migrationBuilder.CreateTable(
                name: "Docente",
                columns: table => new
                {
                    Nomina = table.Column<int>(type: "INTEGER", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Apellido_Paterno = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Apellido_Materno = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Fecha_Nacimiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Coordinador = table.Column<bool>(type: "INTEGER", nullable: false),
                    Contraseña = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Fecha_Ingreso = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Id_Academia = table.Column<int>(type: "INTEGER", nullable: false),
                    Id_Docente = table.Column<int>(type: "INTEGER", nullable: false),
                    Id_Plantel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docente", x => x.Nomina);
                    table.ForeignKey(
                        name: "FK_Docente_Academia_Id_Academia",
                        column: x => x.Id_Academia,
                        principalTable: "Academia",
                        principalColumn: "ID_academia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Docente_Permiso_Docente_Nomina",
                        column: x => x.Nomina,
                        principalTable: "Permiso_Docente",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Docente_Plantel_Id_Docente",
                        column: x => x.Id_Docente,
                        principalTable: "Plantel",
                        principalColumn: "ID_lantel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permiso",
                columns: table => new
                {
                    Id_Permiso = table.Column<int>(type: "INTEGER", nullable: false),
                    Valido = table.Column<bool>(type: "INTEGER", nullable: false),
                    Inicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Termino = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Motivo = table.Column<string>(type: "TEXT", nullable: true),
                    Id_Tipo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso", x => x.Id_Permiso);
                    table.ForeignKey(
                        name: "FK_Permiso_Permiso_Docente_Id_Permiso",
                        column: x => x.Id_Permiso,
                        principalTable: "Permiso_Docente",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permiso_Tipo_Permiso_Id_Tipo",
                        column: x => x.Id_Tipo,
                        principalTable: "Tipo_Permiso",
                        principalColumn: "ID_permiso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Docente_Id_Academia",
                table: "Docente",
                column: "Id_Academia");

            migrationBuilder.CreateIndex(
                name: "IX_Docente_Id_Docente",
                table: "Docente",
                column: "Id_Docente");

            migrationBuilder.CreateIndex(
                name: "IX_Permiso_Id_Tipo",
                table: "Permiso",
                column: "Id_Tipo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Docente");

            migrationBuilder.DropTable(
                name: "Permiso");

            migrationBuilder.DropTable(
                name: "Academia");

            migrationBuilder.DropTable(
                name: "Plantel");

            migrationBuilder.DropTable(
                name: "Permiso_Docente");

            migrationBuilder.DropTable(
                name: "Tipo_Permiso");
        }
    }
}
