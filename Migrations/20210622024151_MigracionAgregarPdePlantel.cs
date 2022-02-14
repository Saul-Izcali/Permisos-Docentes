using Microsoft.EntityFrameworkCore.Migrations;

namespace Proyecto.Migrations
{
    public partial class MigracionAgregarPdePlantel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID_lantel",
                table: "Plantel",
                newName: "ID_Plantel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID_Plantel",
                table: "Plantel",
                newName: "ID_lantel");
        }
    }
}
