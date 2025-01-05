using CsvHelper;
using CsvHelper.Configuration;
using VerificaDespesas.Repositories;
using System.Globalization;
using VerificaDespesas.Models;

namespace VerificaDespesas.Services;

public class DataService : IDataService
{
    private readonly IDeputadoRepository _deputadoRepository;
    private readonly IDespesaRepository _despesaRepository;

    public DataService(IDeputadoRepository deputadoRepository, IDespesaRepository despesaRepository)
    {
        _deputadoRepository = deputadoRepository;
        _despesaRepository = despesaRepository;
    }

    public async Task CarregarDadosAsync(string path)
    {
        var config = new CsvConfiguration()
        {
        CultureInfo = CultureInfo.InvariantCulture,
        Delimiter = ";",
        HasHeaderRecord = true
        };
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, config);

        List<Despesa> despesas = new List<Despesa>();
        Dictionary<int, Deputado> deputados = new Dictionary<int, Deputado>();

        while (csv.Read())
        {
        if (string.IsNullOrWhiteSpace(csv.GetField("ideCadastro")))
        {
            continue;
        }

        int deputadoId = csv.GetField<int>("ideCadastro");

        if (!deputados.ContainsKey(deputadoId))
        {
            Deputado deputado = new Deputado
            (
            csv.GetField("txNomeParlamentar"),
            csv.GetField("sgPartido"),
            csv.GetField("sgUF"),
            csv.GetField("cpf"),
            $"http://www.camara.leg.br/internet/deputado/bandep/{deputadoId}.jpg"
            );
            deputado.DeputadoId = deputadoId;
            deputados[deputadoId] = deputado;
        }

        Despesa despesa = new Despesa
        (
            csv.GetField<decimal>("vlrLiquido"),
            csv.GetField<DateTime>("datEmissao"),
            csv.GetField<string>("txtFornecedor"),
            csv.GetField<string>("txtDescricao"),
            csv.GetField<string>("urlDocumento"),
            deputadoId
        );
        despesas.Add(despesa);
        }

        await _deputadoRepository.CarregarDeputadosAsync(deputados.Values.ToList());
        await _despesaRepository.CarregarDespesasAsync(despesas);
    }
}