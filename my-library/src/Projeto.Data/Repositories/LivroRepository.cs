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
        return await _context.Livros
                .Include(c => c.LivroAssuntos)
                    .ThenInclude(c => c.Assunto)
                .Include(c => c.LivroAutores)
                    .ThenInclude(c => c.Autor)
            .ToListAsync(cancellationToken);
    }

    public async Task<Livro?> GetByNome(string titulo, CancellationToken cancellationToken)
    {
        return await _context.Livros.AsNoTracking().FirstOrDefaultAsync(n => n.Titulo == titulo, cancellationToken);
    }

    public async Task<Livro?> Get(int id, CancellationToken cancellationToken)
    {
        return await _context.Livros
                .Include(c => c.LivroAssuntos)
                    .ThenInclude(c => c.Assunto)
                .Include(c => c.LivroAutores)
                    .ThenInclude(c => c.Autor)
                .Where(c => c.Codl == id).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Livro> CreateAsync(Livro livro)
    {
        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();
        return livro;
    }

    public async Task<Livro> CreateWithRelationsAsync(Livro livro, CancellationToken cancellationToken)
    {
        // Adiciona o livro
        _context.Set<Livro>().Add(livro);

        // Adiciona as relações Livro_Autor
        foreach (var autor in livro.LivroAutores)
        {
            _context.Set<LivroAutor>().Add(autor);
        }

        // Adiciona as relações Livro_Assunto
        foreach (var assunto in livro.LivroAssuntos)
        {
            _context.Set<LivroAssunto>().Add(assunto);
        }

        await _context.SaveChangesAsync(cancellationToken);
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
