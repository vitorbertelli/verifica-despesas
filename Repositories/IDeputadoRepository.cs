using VerificaDespesas.Helpers;
using VerificaDespesas.Models;
using VerificaDespesas.Pagination;

namespace VerificaDespesas.Repositories;

public interface IDeputadoRepository
{
    public Task CarregarDeputadosAsync(List<Deputado> deputados);
    public Task<PagedList<Deputado>> ObterDeputadosAsync(DeputadoParameters deputadoParameters);
    public Task<Deputado?> ObterDeputadoPorIdAsync(int id);
}