namespace VerificaDespesas.Models;

public class Despesa
{
    public int DespesaId { get; set; }
    public decimal ValorLiquido { get; set; }
    public DateTime DataEmissao { get; set; }
    public string? Fornecedor { get; set; }
    public string? Descricao { get; set; }
    public string? UrlDocumento { get; set; }
    public int DeputadoId { get; set; }
    public Deputado? Deputado { get; set; }

    public Despesa(decimal valorLiquido, DateTime dataEmissao, string fornecedor, string descricao, string urlDocumento, int deputadoId)
    {
        ValorLiquido = valorLiquido;
        DataEmissao = dataEmissao;
        Fornecedor = fornecedor;
        Descricao = descricao;
        UrlDocumento = urlDocumento;
        DeputadoId = deputadoId;
    }

    public Despesa()
    {
        
    }
}