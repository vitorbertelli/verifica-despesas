using VerificaDespesas.Helpers;
using VerificaDespesas.Models;
using VerificaDespesas.Pagination;

namespace VerificaDespesas.Repositories;

public interface IDespesaRepository
{
    public Task CarregarDespesasAsync(List<Despesa> despesas);
    public Task<PagedList<Despesa>> ObterDespesasPorDeputadoAsync(int id, DespesasParameters despesasParameters);
}