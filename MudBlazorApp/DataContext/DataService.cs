using Microsoft.EntityFrameworkCore;
using MudBlazorApp.Entities;

namespace MudBlazorApp.DataContext;

public class DataService
{
    private readonly AppDbContext _context;

    public DataService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Funcionario>> GetFuncionariosAsync()
    {
        return await _context.Funcionarios.Include(f => f.Departamento).ToListAsync();
    }
    public async Task<List<Departamento>> GetDepartamentoAsync()
    {
        return await _context.Departamentos.ToListAsync();
    }

    public async Task<Dictionary<string, decimal>> GetSalariosPorDepartamentoAsync()
    {
        return await _context.Funcionarios
            .Include(f => f.Departamento!)
            .GroupBy(f => f.Departamento!.Nome!)
            .Select(g => new { Departamento = g.Key, TotalSalarios = g.Sum(f => f.Salario) })
            .ToDictionaryAsync(x => x.Departamento, x => x.TotalSalarios);
    }

    public async Task<Dictionary<string, int>> GetFuncionariosPorDepartamentoAsync()
    {
        return await _context.Funcionarios
            .Include(f => f.Departamento!)
            .GroupBy(f => f.Departamento!.Nome!)
            .Select(g => new { Departamento = g.Key, NumeroFuncionarios = g.Count() })
            .ToDictionaryAsync(x => x.Departamento, x => x.NumeroFuncionarios);
    }

    public async Task<Dictionary<string, double[]>> GetDespesaMensalPorDepartamentoAsync()
    {
        var departamentos = await _context.Departamentos.ToListAsync();
        var meses = Enumerable.Range(1, 12).ToArray(); // Meses de janeiro a dezembro

        var despesaMensal = new Dictionary<string, double[]>();

        foreach (var departamento in departamentos)
        {
            var despesas = new double[12]; // Array para armazenar as despesas mensais

            for (int i = 0; i < 12; i++)
            {
                var valorDespesa = await _context.DespesaMensais
                    .Where(d => d.DepartamentoId == departamento.DepartamentoId && d.MesReferencia == meses[i])
                    .Select(d => d.Valor)
                    .FirstOrDefaultAsync();

                despesas[i] = (double)valorDespesa;
            }

            despesaMensal[departamento.Nome!] = despesas;
        }

        return despesaMensal;
    }

    public async Task<Dictionary<string, double[]>> GetDespesaMensalPorDepartamento2Async()
    {
        var departamentos = await _context.Departamentos
            .Where(d => d.DepartamentoId == 1 || d.DepartamentoId == 2 || d.DepartamentoId == 3) // Filtra apenas os departamentos desejados (1, 2, 3)
            .ToListAsync();

        var meses = Enumerable.Range(1, 12).ToArray(); // Meses de janeiro a dezembro

        var despesaMensal = new Dictionary<string, double[]>();

        foreach (var departamento in departamentos)
        {
            var despesas = new double[12]; // Array para armazenar as despesas mensais

            for (int i = 0; i < 12; i++)
            {
                var valorDespesa = await _context.DespesaMensais
                    .Where(d => d.DepartamentoId == departamento.DepartamentoId && d.MesReferencia == meses[i])
                    .Select(d => d.Valor)
                    .FirstOrDefaultAsync();

                // Converter decimal para double
                despesas[i] = (double)valorDespesa;
            }

            despesaMensal[departamento.Nome!] = despesas;
        }

        return despesaMensal;
    }
}
