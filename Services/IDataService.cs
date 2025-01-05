namespace VerificaDespesas.Services;

public interface IDataService
{
    public Task CarregarDadosAsync(string path);
}