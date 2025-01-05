using AutoMapper;
using VerificaDespesas.DTOs;
using VerificaDespesas.Helpers;
using VerificaDespesas.Pagination;
using VerificaDespesas.Repositories;

namespace VerificaDespesas.Services;

public class DeputadoService : IDeputadoService
{
    private readonly IDeputadoRepository _deputadoRepository;
    private readonly IDespesaRepository _despesaRepository;
    private readonly IMapper _mapper;

    public DeputadoService(IDeputadoRepository deputadoRepository, IDespesaRepository despesaRepository, IMapper mapper)
    {
        _deputadoRepository = deputadoRepository;
        _despesaRepository = despesaRepository;
        _mapper = mapper;
    }

    public async Task<DeputadoDto> ObterDeputadoPorIdAsync(int id)
    {
        var deputado = await _deputadoRepository.ObterDeputadoPorIdAsync(id);
        DeputadoDto deputadoDto = _mapper.Map<DeputadoDto>(deputado);
        return deputadoDto;
    }

    public async Task<PagedList<DeputadoDto>> ObterDeputadosAsync(DeputadoParameters deputadoParameters)
    {
        var deputadosPaginados = await _deputadoRepository.ObterDeputadosAsync(deputadoParameters);
        var deputadosDto = _mapper.Map<List<DeputadoDto>>(deputadosPaginados);
        return new PagedList<DeputadoDto>(deputadosDto, deputadosPaginados.TotalCount, deputadosPaginados.CurrentPage, deputadosPaginados.PageSize);
    }

    public async Task<PagedList<DespesaDto>> ObterDespesasPorDeputadoAsync(int id, DespesasParameters despesasParameters)
    {
        var despesasPaginadas = await _despesaRepository.ObterDespesasPorDeputadoAsync(id, despesasParameters);
        var despesasDto = _mapper.Map<List<DespesaDto>>(despesasPaginadas);
        return new PagedList<DespesaDto>(despesasDto, despesasPaginadas.TotalCount, despesasPaginadas.CurrentPage, despesasPaginadas.PageSize);
    }
}