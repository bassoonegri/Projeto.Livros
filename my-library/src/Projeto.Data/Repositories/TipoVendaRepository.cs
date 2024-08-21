using Microsoft.EntityFrameworkCore;
using Projeto.Data.Context;
using Projeto.Domain.Entities;
using Projeto.Domain.Interfaces;
using System.Threading;

namespace Projeto.Data.Repositories;

public class TipoVendaRepository : ITipoVendaRepository
{
    private readonly ContextoBd _context;

    public TipoVendaRepository(ContextoBd context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TipoVenda>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.TipoVenda.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<TipoVenda?> GetByIdAsynct(int id, CancellationToken cancellationToken)
    {
        return await _context.TipoVenda.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<TipoVenda> Create(TipoVenda tipo)
    {
        _context.TipoVenda.Add(tipo);
        await _context.SaveChangesAsync();
        return tipo;
    }
    public void Update(TipoVenda tipo)
    {
        _context.TipoVenda.Update(tipo);
    }

    public async Task Delete(int id, CancellationToken cancellationToken)
    {
        var tipo = await _context.TipoVenda.FindAsync(new object[] { id }, cancellationToken);
        if (tipo != null)
        {
            _context.TipoVenda.Remove(tipo);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}

