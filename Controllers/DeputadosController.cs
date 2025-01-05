using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using VerificaDespesas.DTOs;
using VerificaDespesas.Helpers;
using VerificaDespesas.Services;

namespace VerificaDespesas.Controllers;

[Route("api/deputados")]
[ApiController]
public class DeputadosController : ControllerBase
{
    private readonly IDeputadoService _deputadoService;

    public DeputadosController(IDeputadoService deputadoService)
    {
        _deputadoService = deputadoService;
    }

    /// <summary>
    /// Listagem e busca de deputados segundo critérios de pesquisa
    /// </summary>
    /// <remarks>
    /// Este método permite a busca de deputados com base nos critérios informados.
    /// Os resultados podem ser ordenados e filtrados.
    /// </remarks>
    /// <param name="deputadoParameters"></param>
    /// <returns>
    /// Lista de deputados que atendem aos critérios especificados.
    /// </returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DeputadoDto>>> ObterDeputados([FromQuery] DeputadoParameters deputadoParameters){
        var deputados = await _deputadoService.ObterDeputadosAsync(deputadoParameters);

        var metadata = new
        {
        deputados.TotalCount,
        deputados.PageSize,
        deputados.CurrentPage,
        deputados.TotalPages,
        deputados.HasNext,
        deputados.HasPrevious
        };

        Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));

        return Ok(deputados);
    }

    /// <summary>
    /// Obtém os detalhes de um deputado específico pelo ID.
    /// </summary>
    /// <param name="id">O ID do deputado.</param>
    /// <returns>Os detalhes do deputado.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<DeputadoDto>> ObterDeputadoPorId(int id)
    {
        var deputado = await _deputadoService.ObterDeputadoPorIdAsync(id);

        return Ok(deputado);
    }

    /// <summary>
    /// Obtém uma lista paginada de despesas de um deputado pelo ID.
    /// </summary>
    /// <param name="id">O ID do deputado.</param>
    /// <param name="despesasParameters">Parâmetros de paginação e filtros para as despesas.</param>
    /// <returns>Uma lista paginada de despesas do deputado ou uma lista vazia.</returns>
    [HttpGet("{id}/despesas")]
    public async Task<ActionResult<IEnumerable<DespesaDto>>> ObterDespesasPorDeputado(int id, [FromQuery] DespesasParameters despesasParameters)
    {
        var despesas = await _deputadoService.ObterDespesasPorDeputadoAsync(id, despesasParameters);

        var metadata = new
        {
        despesas.TotalCount,
        despesas.PageSize,
        despesas.CurrentPage,
        despesas.TotalPages,
        despesas.HasNext,
        despesas.HasPrevious
        };

        Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metadata));

        return Ok(despesas);
    }
}