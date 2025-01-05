namespace VerificaDespesas.Helpers;

public class DespesasParameters : QueryStringParameters
{
    private string _order = "ASC";
    /// <summary>
    /// Define a ordenação dos resultados.
    /// Use `ASC` para ordem crescente (padrão) ou `DESC` para ordem decrescente.
    /// </summary>
    public string? Order 
    {
        get => _order;
        set => _order = (value != null && value.Equals("DESC", StringComparison.CurrentCultureIgnoreCase)) ? value : _order;
    }
}
