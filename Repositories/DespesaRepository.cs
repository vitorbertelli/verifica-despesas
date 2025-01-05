using Microsoft.EntityFrameworkCore;
using VerificaDespesas.Context;
using VerificaDespesas.Helpers;
using VerificaDespesas.Models;
using VerificaDespesas.Pagination;

namespace VerificaDespesas.Repositories;

public class DespesaRepository : IDespesaRepository
{
    private readonly ApplicationDbContext _context;

    public DespesaRepository(ApplicationDbContext context)
    {
        _context = context;    
    }

    public async Task CarregarDespesasAsync(List<Despesa> despesas)
    {
        await _context.Despesas.AddRangeAsync(despesas);
        await _context.SaveChangesAsync();
    }

    public async Task<PagedList<Despesa>> ObterDespesasPorDeputadoAsync(int id, DespesasParameters despesasParameters)
    {
        var query = _context.Despesas.AsNoTracking().Where(d => d.DeputadoId == id);

        if (despesasParameters.Order == "DESC")
        {
        query = query.OrderByDescending(d => d.ValorLiquido);
        }
        else
        {
        query = query.OrderBy(d => d.ValorLiquido);
        }

        int count = await query.CountAsync();

        var despesas = await query
        .Skip((despesasParameters.PageNumber - 1) * despesasParameters.PageSize)
        .Take(despesasParameters.PageSize)
        .ToListAsync();

        return new PagedList<Despesa>(despesas, count, despesasParameters.PageNumber, despesasParameters.PageSize);
    }
}