namespace VerificaDespesas.Models;

public class Deputado
{
    public int DeputadoId { get; set; }
    public string? Nome { get; set; }
    public string? Partido { get; set; }
    public string? Uf { get; set; }
    public string? Cpf { get; set; }
    public string? UrlFoto { get; set; }
    public ICollection<Despesa>? Despesas { get; set; }

    public Deputado(string nome, string partido, string uf, string cpf, string urlFoto)
    {
        Nome = nome;
        Partido = partido;
        Uf = uf;
        Cpf = cpf;
        UrlFoto = urlFoto;
    }
    
    public Deputado()
    {
        
    }
}