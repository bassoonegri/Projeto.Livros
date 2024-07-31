using Microsoft.EntityFrameworkCore;
using Projeto.Data.Context;
using Projeto.Domain.Entities;
using Projeto.Domain.Interfaces;

namespace Projeto.Data.Repositories;

public class AutorRepository : IAutorRepository
{
    private readonly ContextoBd _context;

    public AutorRepository(ContextoBd context)
    {
        _context = context;
    }

    public async Task<Autor?> Get(int id, CancellationToken cancellationToken)
    {
        return await _context.Autores.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<IEnumerable<Autor>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Autores.ToListAsync(cancellationToken);
    }

    public async Task<Autor> Create(Autor autor)
    {
        _context.Autores.Add(autor);
        await _context.SaveChangesAsync();
        return autor;
    }

    public void Update(Autor autor)
    {
        _context.Autores.Update(autor);
    }

    public async Task Delete(int id, CancellationToken cancellationToken)
    {
        var autor = await _context.Autores.FindAsync(new object[] { id }, cancellationToken);
        if (autor != null)
        {
            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}