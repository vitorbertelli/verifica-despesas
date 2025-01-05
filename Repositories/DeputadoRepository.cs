using Microsoft.EntityFrameworkCore;
using VerificaDespesas.Context;
using VerificaDespesas.Helpers;
using VerificaDespesas.Enums;
using VerificaDespesas.Models;
using VerificaDespesas.Pagination;

namespace VerificaDespesas.Repositories;

public class DeputadoRepository : IDeputadoRepository
{
    private readonly ApplicationDbContext _context;

    public DeputadoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CarregarDeputadosAsync(List<Deputado> deputados)
    {
        await _context.Deputados.AddRangeAsync(deputados);
        await _context.SaveChangesAsync();
    }

    public async Task<PagedList<Deputado>> ObterDeputadosAsync(DeputadoParameters deputadoParameters)
    {
        var query = _context.Deputados.AsNoTracking();

        if (!string.IsNullOrEmpty(deputadoParameters.Nome))
        {
        query = query.Where(d => d.Nome != null && d.Nome.Contains(deputadoParameters.Nome));
        }

        if (!string.IsNullOrEmpty(deputadoParameters.Partido))
        {
        query = query.Where(d => d.Partido != null && d.Partido.ToLower().Equals(deputadoParameters.Partido.ToLower()));
        }

        if (!string.IsNullOrEmpty(deputadoParameters.Uf))
        {
        query = query.Where(d => d.Uf != null && d.Uf.ToUpper().Equals(deputadoParameters.Uf.ToUpper()));
        }

        if (!string.IsNullOrEmpty(deputadoParameters.OrderBy))
        {
        var orderBy = (DeputadoOrderBy)Enum.Parse(typeof(DeputadoOrderBy), deputadoParameters.OrderBy, true);

        query = orderBy switch
        {
            DeputadoOrderBy.Nome => query.OrderBy(d => d.Nome),
            DeputadoOrderBy.Uf => query.OrderBy(d => d.Uf),
            DeputadoOrderBy.Partido => query.OrderBy(d => d.Partido),
            _ => query
        };
        }

        int count = await query.CountAsync();

        var deputados = await query
        .Skip((deputadoParameters.PageNumber - 1) * deputadoParameters.PageSize)
        .Take(deputadoParameters.PageSize)
        .ToListAsync();

        return new PagedList<Deputado>(deputados, count, deputadoParameters.PageNumber, deputadoParameters.PageSize);
    }

    public async Task<Deputado?> ObterDeputadoPorIdAsync(int id)
    {
        return await _context.Deputados.AsNoTracking().FirstOrDefaultAsync(d => d.DeputadoId == id);
    }
}