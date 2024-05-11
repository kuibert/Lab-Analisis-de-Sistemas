using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace adsProyecto.Migrations
{
    /// <inheritdoc />
    public partial class Grupo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grupo",
                columns: table => new
                {
                    IdGrupo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCarrera = table.Column<int>(type: "int", nullable: false),
                    IdMateria = table.Column<int>(type: "int", nullable: false),
                    IdProfesor = table.Column<int>(type: "int", nullable: false),
                    cliclo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    anio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo", x => x.IdGrupo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grupo");
        }
    }
}
