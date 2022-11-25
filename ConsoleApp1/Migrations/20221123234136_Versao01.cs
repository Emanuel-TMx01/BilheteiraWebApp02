using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp1.Migrations
{
    public partial class Versao01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Descontos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descontos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bilhetes",
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
                    table.PrimaryKey("PK_Bilhetes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bilhetes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bilhetes_Descontos_DescontoId",
                        column: x => x.DescontoId,
                        principalTable: "Descontos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bilhetes_Filmes_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Ana" },
                    { 2, "Bruno" },
                    { 3, "Rui" }
                });

            migrationBuilder.InsertData(
                table: "Descontos",
                columns: new[] { "Id", "Descricao", "Preco" },
                values: new object[,]
                {
                    { 1, "Adulto", 8.0 },
                    { 2, "Estudante", 6.0 },
                    { 3, "Criança", 4.0 }
                });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "Id", "Genero", "Nome" },
                values: new object[,]
                {
                    { 1, "Ficçao", "Alien" },
                    { 2, "Corrida", "Carros" },
                    { 3, "Romance", "Vida" }
                });

            migrationBuilder.InsertData(
                table: "Bilhetes",
                columns: new[] { "Id", "ClienteId", "DataRegisto", "DescontoId", "FilmeId", "Stock" },
                values: new object[] { 1, 1, new DateTime(2022, 11, 23, 23, 41, 36, 250, DateTimeKind.Local).AddTicks(6368), 2, 3, 35 });

            migrationBuilder.InsertData(
                table: "Bilhetes",
                columns: new[] { "Id", "ClienteId", "DataRegisto", "DescontoId", "FilmeId", "Stock" },
                values: new object[] { 2, 2, new DateTime(2022, 11, 23, 23, 41, 36, 250, DateTimeKind.Local).AddTicks(6412), 1, 1, 35 });

            migrationBuilder.InsertData(
                table: "Bilhetes",
                columns: new[] { "Id", "ClienteId", "DataRegisto", "DescontoId", "FilmeId", "Stock" },
                values: new object[] { 3, 3, new DateTime(2022, 11, 23, 23, 41, 36, 250, DateTimeKind.Local).AddTicks(6415), 3, 2, 35 });

            migrationBuilder.CreateIndex(
                name: "IX_Bilhetes_ClienteId",
                table: "Bilhetes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Bilhetes_DescontoId",
                table: "Bilhetes",
                column: "DescontoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bilhetes_FilmeId",
                table: "Bilhetes",
                column: "FilmeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bilhetes");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Descontos");

            migrationBuilder.DropTable(
                name: "Filmes");
        }
    }
}
