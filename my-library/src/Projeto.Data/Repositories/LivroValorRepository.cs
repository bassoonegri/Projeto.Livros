using Microsoft.EntityFrameworkCore;
using Projeto.Data.Context;
using Projeto.Domain.Entities;
using Projeto.Domain.Interfaces;

namespace Projeto.Data.Repositories;

public class LivroValorRepository : ILivroValorRepository
{
    private readonly ContextoBd _context;

    public LivroValorRepository(ContextoBd context)
    {
        _context = context;
    }

    public async Task<IEnumerable<LivroValor>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _context.LivroValor
              .Include(lv => lv.Livro) // Carregar o Livro relacionado
              .Include(lv => lv.TipoVenda) // Carregar o TipoVenda relacionado
                        .AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<LivroValor?> GetByIdAsynct(int id, int tipo, CancellationToken cancellationToken)
    {
        return await _context.LivroValor
              .Include(lv => lv.Livro) // Carregar o Livro relacionado
              .Include(lv => lv.TipoVenda) // Carregar o TipoVenda relacionado
            .Where(c => c.LivroCodl == id && c.TipoVendaCodTv == tipo).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<LivroValor> Create(LivroValor valor)
    {
        _context.LivroValor.Add(valor);
        await _context.SaveChangesAsync();
        return valor;
    }
    public void Update(LivroValor tipo)
    {
        _context.LivroValor.Update(tipo);
    }

    public async Task Delete(LivroValor item, CancellationToken cancellationToken)
    {
        _context.LivroValor.Remove(item);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}

