using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Versao01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Desconto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desconto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bilhete",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    DataRegisto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilmeId = table.Column<int>(type: "int", nullable: false),
                    DescontoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilhete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bilhete_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bilhete_Desconto_DescontoId",
                        column: x => x.DescontoId,
                        principalTable: "Desconto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bilhete_Filme_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Ana" },
                    { 2, "Bruno" },
                    { 3, "Rui" }
                });

            migrationBuilder.InsertData(
                table: "Desconto",
                columns: new[] { "Id", "Descricao", "Preco" },
                values: new object[,]
                {
                    { 1, "Adulto", 8.0 },
                    { 2, "Estudante", 6.0 },
                    { 3, "Criança", 4.0 }
                });

            migrationBuilder.InsertData(
                table: "Filme",
                columns: new[] { "Id", "Genero", "Nome" },
                values: new object[,]
                {
                    { 1, "Ficçao", "Alien" },
                    { 2, "Corrida", "Carros" },
                    { 3, "Romance", "Vida" }
                });

            migrationBuilder.InsertData(
                table: "Bilhete",
                columns: new[] { "Id", "ClienteId", "DataRegisto", "DescontoId", "FilmeId", "Stock" },
                values: new object[] { 1, 1, new DateTime(2022, 11, 25, 18, 9, 3, 192, DateTimeKind.Local).AddTicks(453), 2, 3, 35 });

            migrationBuilder.InsertData(
                table: "Bilhete",
                columns: new[] { "Id", "ClienteId", "DataRegisto", "DescontoId", "FilmeId", "Stock" },
                values: new object[] { 2, 2, new DateTime(2022, 11, 25, 18, 9, 3, 192, DateTimeKind.Local).AddTicks(558), 1, 1, 35 });

            migrationBuilder.InsertData(
                table: "Bilhete",
                columns: new[] { "Id", "ClienteId", "DataRegisto", "DescontoId", "FilmeId", "Stock" },
                values: new object[] { 3, 3, new DateTime(2022, 11, 25, 18, 9, 3, 192, DateTimeKind.Local).AddTicks(560), 3, 2, 35 });

            migrationBuilder.CreateIndex(
                name: "IX_Bilhete_ClienteId",
                table: "Bilhete",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Bilhete_DescontoId",
                table: "Bilhete",
                column: "DescontoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bilhete_FilmeId",
                table: "Bilhete",
                column: "FilmeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bilhete");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Desconto");

            migrationBuilder.DropTable(
                name: "Filme");
        }
    }
}
