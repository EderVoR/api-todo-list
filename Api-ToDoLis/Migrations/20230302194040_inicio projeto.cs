using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_ToDoLis.Migrations
{
    public partial class inicioprojeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoListas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao_tipo = table.Column<string>(type: "TEXT", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoListas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDoLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Observacao = table.Column<string>(type: "TEXT", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Concluido = table.Column<bool>(type: "INTEGER", nullable: false),
                    Tipo_Id = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoLists_TipoListas_Tipo_Id",
                        column: x => x.Tipo_Id,
                        principalTable: "TipoListas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_Tipo_Id",
                table: "ToDoLists",
                column: "Tipo_Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoLists");

            migrationBuilder.DropTable(
                name: "TipoListas");
        }
    }
}
