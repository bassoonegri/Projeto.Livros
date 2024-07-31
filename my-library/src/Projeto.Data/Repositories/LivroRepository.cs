using Microsoft.EntityFrameworkCore;
using Projeto.Data.Context;
using Projeto.Domain.Entities;
using Projeto.Domain.Interfaces;

namespace Projeto.Data.Repositories;

public class LivroRepository : ILivroRepository
{

    private readonly ContextoBd _context;

    public LivroRepository(ContextoBd context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Livro>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Livros.ToListAsync(cancellationToken);
    }

    public async Task<Livro?> GetByNome(string titulo, CancellationToken cancellationToken)
    {
        return await _context.Livros.AsNoTracking().FirstOrDefaultAsync(n => n.Titulo == titulo, cancellationToken);
    }

    public async Task<Livro?> Get(int id, CancellationToken cancellationToken)
    {
        return await _context.Livros.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<Livro> CreateAsync(Livro livro)
    {
        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();
        return livro;
    }

    public void Update(Livro livro)
    {
        _context.Livros.Update(livro);
    }

    public async Task Delete(int codigo, CancellationToken cancellationToken)
    {
        var livro = await _context.Livros.FindAsync(new object[] { codigo }, cancellationToken);
        if (livro != null)
        {
            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

}
