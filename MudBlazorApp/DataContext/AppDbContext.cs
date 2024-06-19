using Microsoft.EntityFrameworkCore;
using MudBlazorApp.Components.Pages;
using MudBlazorApp.Entities;
using static Azure.Core.HttpHeader;

namespace MudBlazorApp.DataContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<DespesaMensal> DespesaMensais { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>()
            .HasMany(d => d.Funcionarios)
            .WithOne(f => f.Departamento)
            .HasForeignKey(f => f.DepartamentoId);


        modelBuilder.Entity<Departamento>().HasData(
            new Departamento { DepartamentoId = 1, Nome = "Gestão" },
            new Departamento { DepartamentoId = 2, Nome = "Desenvolvimento" },
            new Departamento { DepartamentoId = 3, Nome = "Infraestrutura" },
            new Departamento { DepartamentoId = 4, Nome = "Qualidade" },
            new Departamento { DepartamentoId = 5, Nome = "Suporte" }
        );

        modelBuilder.Entity<Funcionario>().HasData(
            // Funcionários para o departamento 1
            new Funcionario { FuncionarioId = 1, Nome = "José", Cargo = "Gerente", Salario = 7000, DataAdmissao = new DateTime(2023, 1, 15), DepartamentoId = 1 },
            new Funcionario { FuncionarioId = 2, Nome = "Maria", Cargo = "Coordenadora", Salario = 6500, DataAdmissao = new DateTime(2018, 8, 10), DepartamentoId = 1 },
            new Funcionario { FuncionarioId = 3, Nome = "Ricardo", Cargo = "Assistente Administrativo", Salario = 2200, DataAdmissao = new DateTime(2022, 6, 30), DepartamentoId = 1 },

            // Funcionários para o departamento 2
            new Funcionario { FuncionarioId = 4, Nome = "Carlos", Cargo = "Desenvolvedor Sênior", Salario = 3500, DataAdmissao = new DateTime(2019, 4, 5), DepartamentoId = 2 },
            new Funcionario { FuncionarioId = 5, Nome = "Ana", Cargo = "Desenvolvedora Pleno", Salario = 4200, DataAdmissao = new DateTime(2021, 12, 20), DepartamentoId = 2 },
            new Funcionario { FuncionarioId = 6, Nome = "Pedro", Cargo = "Desenvolvedor Júnior", Salario = 2500, DataAdmissao = new DateTime(2023, 3, 8), DepartamentoId = 2 },
            new Funcionario { FuncionarioId = 7, Nome = "Gabriel", Cargo = "Estagiário de Desenvolvimento", Salario = 1200, DataAdmissao = new DateTime(2023, 2, 28), DepartamentoId = 2 },

            // Funcionários para o departamento 3
            new Funcionario { FuncionarioId = 8, Nome = "Rafael", Cargo = "Analista de Infraestrutura", Salario = 4500, DataAdmissao = new DateTime(2021, 9, 1), DepartamentoId = 3 },
            new Funcionario { FuncionarioId = 9, Nome = "Fernanda", Cargo = "Suporte Técnico", Salario = 3200, DataAdmissao = new DateTime(2020, 5, 12), DepartamentoId = 3 },
            new Funcionario { FuncionarioId = 10, Nome = "Bruna", Cargo = "Estagiária de Infraestrutura", Salario = 1200, DataAdmissao = new DateTime(2019, 7, 15), DepartamentoId = 3 },

            // Funcionários para o departamento 4
            new Funcionario { FuncionarioId = 11, Nome = "Carla", Cargo = "Analista de Qualidade", Salario = 4000, DataAdmissao = new DateTime(2021, 3, 15), DepartamentoId = 4 },
            new Funcionario { FuncionarioId = 12, Nome = "Paulo", Cargo = "Técnico de Qualidade", Salario = 3200, DataAdmissao = new DateTime(2020, 8, 20), DepartamentoId = 4 },

            // Funcionários para o departamento 5
            new Funcionario { FuncionarioId = 13, Nome = "João", Cargo = "Analista de Suporte", Salario = 3800, DataAdmissao = new DateTime(2019, 4, 18), DepartamentoId = 5 },
            new Funcionario { FuncionarioId = 14, Nome = "Mariana", Cargo = "Técnica de Suporte", Salario = 3000, DataAdmissao = new DateTime(2018, 11, 5), DepartamentoId = 5 },
            new Funcionario { FuncionarioId = 15, Nome = "Lucas", Cargo = "Assistente de Suporte", Salario = 2500, DataAdmissao = new DateTime(2020, 10, 1), DepartamentoId = 5 },

            // Mais funcionários distribuídos ao longo dos meses
            // Vamos adicionar alguns exemplos adicionais para cobrir um período maior de tempo
            new Funcionario { FuncionarioId = 16, Nome = "Eduardo", Cargo = "Analista Financeiro", Salario = 6000, DataAdmissao = new DateTime(2018, 1, 10), DepartamentoId = 1 },
            new Funcionario { FuncionarioId = 17, Nome = "Amanda", Cargo = "Desenvolvedora Júnior", Salario = 2800, DataAdmissao = new DateTime(2018, 2, 20), DepartamentoId = 2 },
            new Funcionario { FuncionarioId = 18, Nome = "Carolina", Cargo = "Analista de Marketing", Salario = 5000, DataAdmissao = new DateTime(2019, 7, 5), DepartamentoId = 3 },
            new Funcionario { FuncionarioId = 19, Nome = "Roberto", Cargo = "Assistente Administrativo", Salario = 2300, DataAdmissao = new DateTime(2020, 3, 15), DepartamentoId = 4 },
            new Funcionario { FuncionarioId = 20, Nome = "Rodrigo", Cargo = "Suporte Técnico", Salario = 3100, DataAdmissao = new DateTime(2021, 5, 25), DepartamentoId = 5 },
            new Funcionario { FuncionarioId = 21, Nome = "Isabela", Cargo = "Analista de Vendas", Salario = 4800, DataAdmissao = new DateTime(2022, 9, 12), DepartamentoId = 1 }
        );


        modelBuilder.Entity<DespesaMensal>().HasData(
            // Departamento 1 - Gestão
            new DespesaMensal { Id = 1, DepartamentoId = 1, Valor = 150000, MesReferencia = 1 },
            new DespesaMensal { Id = 2, DepartamentoId = 1, Valor = 145000, MesReferencia = 2 },
            new DespesaMensal { Id = 3, DepartamentoId = 1, Valor = 155000, MesReferencia = 3 },
            new DespesaMensal { Id = 4, DepartamentoId = 1, Valor = 160000, MesReferencia = 4 },
            new DespesaMensal { Id = 5, DepartamentoId = 1, Valor = 165000, MesReferencia = 5 },
            new DespesaMensal { Id = 6, DepartamentoId = 1, Valor = 170000, MesReferencia = 6 },
            new DespesaMensal { Id = 7, DepartamentoId = 1, Valor = 175000, MesReferencia = 7 },
            new DespesaMensal { Id = 8, DepartamentoId = 1, Valor = 180000, MesReferencia = 8 },
            new DespesaMensal { Id = 9, DepartamentoId = 1, Valor = 185000, MesReferencia = 9 },
            new DespesaMensal { Id = 10, DepartamentoId = 1, Valor = 190000, MesReferencia = 10 },
            new DespesaMensal { Id = 11, DepartamentoId = 1, Valor = 195000, MesReferencia = 11 },
            new DespesaMensal { Id = 12, DepartamentoId = 1, Valor = 200000, MesReferencia = 12 },

            // Departamento 2 - Desenvolvimento
            new DespesaMensal { Id = 13, DepartamentoId = 2, Valor = 120000, MesReferencia = 1 },
            new DespesaMensal { Id = 14, DepartamentoId = 2, Valor = 118000, MesReferencia = 2 },
            new DespesaMensal { Id = 15, DepartamentoId = 2, Valor = 122000, MesReferencia = 3 },
            new DespesaMensal { Id = 16, DepartamentoId = 2, Valor = 125000, MesReferencia = 4 },
            new DespesaMensal { Id = 17, DepartamentoId = 2, Valor = 128000, MesReferencia = 5 },
            new DespesaMensal { Id = 18, DepartamentoId = 2, Valor = 130000, MesReferencia = 6 },
            new DespesaMensal { Id = 19, DepartamentoId = 2, Valor = 132000, MesReferencia = 7 },
            new DespesaMensal { Id = 20, DepartamentoId = 2, Valor = 135000, MesReferencia = 8 },
            new DespesaMensal { Id = 21, DepartamentoId = 2, Valor = 138000, MesReferencia = 9 },
            new DespesaMensal { Id = 22, DepartamentoId = 2, Valor = 140000, MesReferencia = 10 },
            new DespesaMensal { Id = 23, DepartamentoId = 2, Valor = 142000, MesReferencia = 11 },
            new DespesaMensal { Id = 24, DepartamentoId = 2, Valor = 145000, MesReferencia = 12 },

            // Departamento 3 - Infraestrutura
            new DespesaMensal { Id = 25, DepartamentoId = 3, Valor = 90000, MesReferencia = 1 },
            new DespesaMensal { Id = 26, DepartamentoId = 3, Valor = 88000, MesReferencia = 2 },
            new DespesaMensal { Id = 27, DepartamentoId = 3, Valor = 91000, MesReferencia = 3 },
            new DespesaMensal { Id = 28, DepartamentoId = 3, Valor = 93000, MesReferencia = 4 },
            new DespesaMensal { Id = 29, DepartamentoId = 3, Valor = 95000, MesReferencia = 5 },
            new DespesaMensal { Id = 30, DepartamentoId = 3, Valor = 97000, MesReferencia = 6 },
            new DespesaMensal { Id = 31, DepartamentoId = 3, Valor = 99000, MesReferencia = 7 },
            new DespesaMensal { Id = 32, DepartamentoId = 3, Valor = 100000, MesReferencia = 8 },
            new DespesaMensal { Id = 33, DepartamentoId = 3, Valor = 102000, MesReferencia = 9 },
            new DespesaMensal { Id = 34, DepartamentoId = 3, Valor = 104000, MesReferencia = 10 },
            new DespesaMensal { Id = 35, DepartamentoId = 3, Valor = 106000, MesReferencia = 11 },
            new DespesaMensal { Id = 36, DepartamentoId = 3, Valor = 108000, MesReferencia = 12 },

            // Departamento 4 - Qualidade
            new DespesaMensal { Id = 37, DepartamentoId = 4, Valor = 60000, MesReferencia = 1 },
            new DespesaMensal { Id = 38, DepartamentoId = 4, Valor = 59000, MesReferencia = 2 },
            new DespesaMensal { Id = 39, DepartamentoId = 4, Valor = 61000, MesReferencia = 3 },
            new DespesaMensal { Id = 40, DepartamentoId = 4, Valor = 62000, MesReferencia = 4 },
            new DespesaMensal { Id = 41, DepartamentoId = 4, Valor = 63000, MesReferencia = 5 },
            new DespesaMensal { Id = 42, DepartamentoId = 4, Valor = 64000, MesReferencia = 6 },
            new DespesaMensal { Id = 43, DepartamentoId = 4, Valor = 65000, MesReferencia = 7 },
            new DespesaMensal { Id = 44, DepartamentoId = 4, Valor = 66000, MesReferencia = 8 },
            new DespesaMensal { Id = 45, DepartamentoId = 4, Valor = 67000, MesReferencia = 9 },
            new DespesaMensal { Id = 46, DepartamentoId = 4, Valor = 68000, MesReferencia = 10 },
            new DespesaMensal { Id = 47, DepartamentoId = 4, Valor = 69000, MesReferencia = 11 },
            new DespesaMensal { Id = 48, DepartamentoId = 4, Valor = 70000, MesReferencia = 12 },

            // Departamento 5 - Suporte
            new DespesaMensal { Id = 49, DepartamentoId = 5, Valor = 75000, MesReferencia = 1 },
            new DespesaMensal { Id = 50, DepartamentoId = 5, Valor = 74000, MesReferencia = 2 },
            new DespesaMensal { Id = 51, DepartamentoId = 5, Valor = 76000, MesReferencia = 3 },
            new DespesaMensal { Id = 52, DepartamentoId = 5, Valor = 77000, MesReferencia = 4 },
            new DespesaMensal { Id = 53, DepartamentoId = 5, Valor = 78000, MesReferencia = 5 },
            new DespesaMensal { Id = 54, DepartamentoId = 5, Valor = 79000, MesReferencia = 6 },
            new DespesaMensal { Id = 55, DepartamentoId = 5, Valor = 80000, MesReferencia = 7 },
            new DespesaMensal { Id = 56, DepartamentoId = 5, Valor = 81000, MesReferencia = 8 },
            new DespesaMensal { Id = 57, DepartamentoId = 5, Valor = 82000, MesReferencia = 9 },
            new DespesaMensal { Id = 58, DepartamentoId = 5, Valor = 83000, MesReferencia = 10 },
            new DespesaMensal { Id = 59, DepartamentoId = 5, Valor = 84000, MesReferencia = 11 },
            new DespesaMensal { Id = 60, DepartamentoId = 5, Valor = 85000, MesReferencia = 12 }
         );
    }
}
