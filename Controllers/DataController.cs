using Microsoft.AspNetCore.Mvc;
using VerificaDespesas.Services;

namespace VerificaDespesas.Controllers;

[ApiController]
[Route("api/data")]
public class DataController : ControllerBase
{
    private readonly IDataService _dataService;

    public DataController(IDataService dataService)
    {
        _dataService = dataService;
    }

    /// <summary>
    /// Carrega os dados a partir de um arquivo CSV enviado.
    /// </summary>
    /// <remarks>
    /// O arquivo enviado deve ser um CSV válido e estar na URL `http://www.camara.leg.br/cotas/Ano-{ano}.csv`.
    /// </remarks>
    /// <param name="file">Arquivo CSV a ser carregado.</param>
    /// <returns>Resultado da operação de carregamento de dados.</returns>
    [HttpPost("carregar")]
    public async Task<IActionResult> CarregarDadosAsync([FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
        return BadRequest();
        }

        string tempPath = Path.Combine(Path.GetTempPath(), file.FileName);
        using (var stream = new FileStream(tempPath, FileMode.Create))
        {
        await file.CopyToAsync(stream);
        }

        await _dataService.CarregarDadosAsync(tempPath);

        return Ok();
    }
}
