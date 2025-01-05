namespace VerificaDespesas.Helpers;

public abstract class QueryStringParameters
{
    const int MaxPageSize = 50;
    /// <summary>
    /// Número da página a ser exibida (padrão: 1).
    /// </summary>
    public int PageNumber { get; set; } = 1;
    private int _pageSize = 10;
    /// <summary>
    /// Quantidade de registros por página (máximo: 50, padrão: 10).
    /// </summary>
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
}
