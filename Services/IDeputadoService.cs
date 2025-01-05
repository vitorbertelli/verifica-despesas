using VerificaDespesas.DTOs;
using VerificaDespesas.Helpers;
using VerificaDespesas.Pagination;

namespace VerificaDespesas.Services;

public interface IDeputadoService
{
    public Task<DeputadoDto> ObterDeputadoPorIdAsync(int id);
    public Task<PagedList<DeputadoDto>> ObterDeputadosAsync(DeputadoParameters deputadoParameters);
    public Task<PagedList<DespesaDto>> ObterDespesasPorDeputadoAsync(int id, DespesasParameters despesasParameters);
}