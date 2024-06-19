using System.ComponentModel.DataAnnotations;

namespace MudBlazorApp.Entities;

public class Departamento
{
    public int DepartamentoId { get; set; }
    [MaxLength(100)]
    public string? Nome { get; set; }
    public ICollection<Funcionario> Funcionarios { get; set; }=new List<Funcionario>();

    // Propriedade calculada para a despesa mensal
    public decimal DespesaMensal => Funcionarios.Sum(f => f.Salario);

}

