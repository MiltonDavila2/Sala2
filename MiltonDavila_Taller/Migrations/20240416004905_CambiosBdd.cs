using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiltonDavila_Taller.Migrations
{
    /// <inheritdoc />
    public partial class CambiosBdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LugarVacunacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaVacunacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LugarVacunacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vacuna",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreVacuna = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paisProcedencia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacuna", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstudianteUDLA",
                columns: table => new
                {
                    BannerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstudiante = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechadeNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LugarVacunacionId = table.Column<int>(type: "int", nullable: false),
                    VacunaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudianteUDLA", x => x.BannerID);
                    table.ForeignKey(
                        name: "FK_EstudianteUDLA_LugarVacunacion_LugarVacunacionId",
                        column: x => x.LugarVacunacionId,
                        principalTable: "LugarVacunacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstudianteUDLA_Vacuna_VacunaId",
                        column: x => x.VacunaId,
                        principalTable: "Vacuna",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstudianteUDLA_LugarVacunacionId",
                table: "EstudianteUDLA",
                column: "LugarVacunacionId");

            migrationBuilder.CreateIndex(
                name: "IX_EstudianteUDLA_VacunaId",
                table: "EstudianteUDLA",
                column: "VacunaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstudianteUDLA");

            migrationBuilder.DropTable(
                name: "LugarVacunacion");

            migrationBuilder.DropTable(
                name: "Vacuna");
        }
    }
}
