using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace adsProyecto.Migrations
{
    /// <inheritdoc />
    public partial class Profesor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    IdProfesor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.IdProfesor);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profesor");
        }
    }
}
