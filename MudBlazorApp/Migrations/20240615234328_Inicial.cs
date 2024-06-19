using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MudBlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.DepartamentoId);
                });

            migrationBuilder.CreateTable(
                name: "DespesaMensais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MesReferencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DespesaMensais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DespesaMensais_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "DepartamentoId", "Nome" },
                values: new object[,]
                {
                    { 1, "Gestão" },
                    { 2, "Desenvolvimento" },
                    { 3, "Infraestrutura" },
                    { 4, "Qualidade" },
                    { 5, "Suporte" }
                });

            migrationBuilder.InsertData(
                table: "DespesaMensais",
                columns: new[] { "Id", "DepartamentoId", "MesReferencia", "Valor" },
                values: new object[,]
                {
                    { 1, 1, 1, 150000m },
                    { 2, 1, 2, 145000m },
                    { 3, 1, 3, 155000m },
                    { 4, 1, 4, 160000m },
                    { 5, 1, 5, 165000m },
                    { 6, 1, 6, 170000m },
                    { 7, 1, 7, 175000m },
                    { 8, 1, 8, 180000m },
                    { 9, 1, 9, 185000m },
                    { 10, 1, 10, 190000m },
                    { 11, 1, 11, 195000m },
                    { 12, 1, 12, 200000m },
                    { 13, 2, 1, 120000m },
                    { 14, 2, 2, 118000m },
                    { 15, 2, 3, 122000m },
                    { 16, 2, 4, 125000m },
                    { 17, 2, 5, 128000m },
                    { 18, 2, 6, 130000m },
                    { 19, 2, 7, 132000m },
                    { 20, 2, 8, 135000m },
                    { 21, 2, 9, 138000m },
                    { 22, 2, 10, 140000m },
                    { 23, 2, 11, 142000m },
                    { 24, 2, 12, 145000m },
                    { 25, 3, 1, 90000m },
                    { 26, 3, 2, 88000m },
                    { 27, 3, 3, 91000m },
                    { 28, 3, 4, 93000m },
                    { 29, 3, 5, 95000m },
                    { 30, 3, 6, 97000m },
                    { 31, 3, 7, 99000m },
                    { 32, 3, 8, 100000m },
                    { 33, 3, 9, 102000m },
                    { 34, 3, 10, 104000m },
                    { 35, 3, 11, 106000m },
                    { 36, 3, 12, 108000m },
                    { 37, 4, 1, 60000m },
                    { 38, 4, 2, 59000m },
                    { 39, 4, 3, 61000m },
                    { 40, 4, 4, 62000m },
                    { 41, 4, 5, 63000m },
                    { 42, 4, 6, 64000m },
                    { 43, 4, 7, 65000m },
                    { 44, 4, 8, 66000m },
                    { 45, 4, 9, 67000m },
                    { 46, 4, 10, 68000m },
                    { 47, 4, 11, 69000m },
                    { 48, 4, 12, 70000m },
                    { 49, 5, 1, 75000m },
                    { 50, 5, 2, 74000m },
                    { 51, 5, 3, 76000m },
                    { 52, 5, 4, 77000m },
                    { 53, 5, 5, 78000m },
                    { 54, 5, 6, 79000m },
                    { 55, 5, 7, 80000m },
                    { 56, 5, 8, 81000m },
                    { 57, 5, 9, 82000m },
                    { 58, 5, 10, 83000m },
                    { 59, 5, 11, 84000m },
                    { 60, 5, 12, 85000m }
                });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "FuncionarioId", "Cargo", "DataAdmissao", "DepartamentoId", "Nome", "Salario" },
                values: new object[,]
                {
                    { 1, "Gerente", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "José", 7000m },
                    { 2, "Coordenadora", new DateTime(2018, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Maria", 6500m },
                    { 3, "Assistente Administrativo", new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ricardo", 2200m },
                    { 4, "Desenvolvedor Sênior", new DateTime(2019, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Carlos", 3500m },
                    { 5, "Desenvolvedora Pleno", new DateTime(2021, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Ana", 4200m },
                    { 6, "Desenvolvedor Júnior", new DateTime(2023, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Pedro", 2500m },
                    { 7, "Estagiário de Desenvolvimento", new DateTime(2023, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Gabriel", 1200m },
                    { 8, "Analista de Infraestrutura", new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Rafael", 4500m },
                    { 9, "Suporte Técnico", new DateTime(2020, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Fernanda", 3200m },
                    { 10, "Estagiária de Infraestrutura", new DateTime(2019, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Bruna", 1200m },
                    { 11, "Analista de Qualidade", new DateTime(2021, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Carla", 4000m },
                    { 12, "Técnico de Qualidade", new DateTime(2020, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Paulo", 3200m },
                    { 13, "Analista de Suporte", new DateTime(2019, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "João", 3800m },
                    { 14, "Técnica de Suporte", new DateTime(2018, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Mariana", 3000m },
                    { 15, "Assistente de Suporte", new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Lucas", 2500m },
                    { 16, "Analista Financeiro", new DateTime(2018, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Eduardo", 6000m },
                    { 17, "Desenvolvedora Júnior", new DateTime(2018, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Amanda", 2800m },
                    { 18, "Analista de Marketing", new DateTime(2019, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Carolina", 5000m },
                    { 19, "Assistente Administrativo", new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Roberto", 2300m },
                    { 20, "Suporte Técnico", new DateTime(2021, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Rodrigo", 3100m },
                    { 21, "Analista de Vendas", new DateTime(2022, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Isabela", 4800m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DespesaMensais_DepartamentoId",
                table: "DespesaMensais",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_DepartamentoId",
                table: "Funcionarios",
                column: "DepartamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DespesaMensais");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
