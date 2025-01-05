namespace VerificaDespesas.DTOs;

public class DespesaDto
{
    public int DespesaId { get; set; }
    public decimal ValorLiquido { get; set; }
    public DateTime DataEmissao { get; set; }
    public string? Fornecedor { get; set; }
    public string? Descricao { get; set; }
    public string? UrlDocumento { get; set; }
}