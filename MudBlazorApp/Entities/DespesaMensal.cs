namespace MudBlazorApp.Entities;

public class DespesaMensal
{
    public int Id { get; set; }
    public int DepartamentoId { get; set; }
    public decimal Valor { get; set; }
    public int MesReferencia { get; set; } // 1 para Janeiro, 2 para Fevereiro, ..., 12 para Dezembro

    public virtual Departamento? Departamento { get; set; }
}
