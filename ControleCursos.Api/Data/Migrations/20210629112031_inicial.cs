using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ControleCursos.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricao = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.codigo);
                });

            migrationBuilder.CreateTable(
                name: "cursos",
                columns: table => new
                {
                    codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descricaoAssunto = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    dataInicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dataTermino = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    qtdAlunosTurma = table.Column<int>(type: "integer", nullable: false),
                    categoriacodigo = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cursos", x => x.codigo);
                    table.ForeignKey(
                        name: "FK_cursos_categoria_categoriacodigo",
                        column: x => x.categoriacodigo,
                        principalTable: "categoria",
                        principalColumn: "codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cursos_categoriacodigo",
                table: "cursos",
                column: "categoriacodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cursos");

            migrationBuilder.DropTable(
                name: "categoria");
        }
    }
}
