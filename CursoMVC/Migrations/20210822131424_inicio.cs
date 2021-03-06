using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoMVC.Migrations
{
    public partial class inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    AlumnoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlumnoDNI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlumnoApellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlumnoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.AlumnoID);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    CursoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creditos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.CursoID);
                });

            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    NotaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    calificacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => x.NotaID);
                });

            migrationBuilder.CreateTable(
                name: "Docente",
                columns: table => new
                {
                    DocenteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocenteDNI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CursoID = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docente", x => x.DocenteID);
                    table.ForeignKey(
                        name: "FK_Docente_Curso_CursoID",
                        column: x => x.CursoID,
                        principalTable: "Curso",
                        principalColumn: "CursoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscripcion",
                columns: table => new
                {
                    InscripcionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaDeInscripcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CursoID = table.Column<int>(type: "int", nullable: false),
                    AlumnoID = table.Column<int>(type: "int", nullable: false),
                    NotaID = table.Column<int>(type: "int", nullable: false),
                    AlumnoApellidos = table.Column<int>(type: "int", nullable: false),
                    AlumnoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    calificacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripcion", x => x.InscripcionID);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Alumno_AlumnoID",
                        column: x => x.AlumnoID,
                        principalTable: "Alumno",
                        principalColumn: "AlumnoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Curso_CursoID",
                        column: x => x.CursoID,
                        principalTable: "Curso",
                        principalColumn: "CursoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Nota_NotaID",
                        column: x => x.NotaID,
                        principalTable: "Nota",
                        principalColumn: "NotaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Docente_CursoID",
                table: "Docente",
                column: "CursoID");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_AlumnoID",
                table: "Inscripcion",
                column: "AlumnoID");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_CursoID",
                table: "Inscripcion",
                column: "CursoID");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_NotaID",
                table: "Inscripcion",
                column: "NotaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Docente");

            migrationBuilder.DropTable(
                name: "Inscripcion");

            migrationBuilder.DropTable(
                name: "Alumno");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Nota");
        }
    }
}
