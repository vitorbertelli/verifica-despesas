namespace VerificaDespesas.Helpers;

public class DeputadoParameters : QueryStringParameters
{
    /// <summary>
    /// Parte do nome do parlamentar (opcional).
    /// </summary>
    public string? Nome { get; set; }

    /// <summary>
    /// Unidade Federativa (estado) do parlamentar (opcional).
    /// </summary>
    public string? Uf { get; set; }

    /// <summary>
    /// Partido do parlamentar (opcional).
    /// </summary>
    public string? Partido { get; set; }

    /// <summary>
    /// Campo utilizado para ordenar os resultados (opcional). Valores aceitos: `Nome`, `Uf`, `Partido`.
    /// </summary>
    public string? OrderBy { get; set; }
}
