using Microsoft.EntityFrameworkCore;
using Projeto.Data.Context;
using Projeto.Domain.Entities;
using Projeto.Domain.Interfaces;

namespace Projeto.Data.Repositories;

public class AssuntoRepository : IAssuntoRepository
{
    private readonly ContextoBd _context;

    public AssuntoRepository(ContextoBd context)
    {
        _context = context;
    }

    public async Task<Assunto?> Get(int id, CancellationToken cancellationToken)
    {
        return await _context.Assuntos.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<IEnumerable<Assunto>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Assuntos.ToListAsync(cancellationToken);
    }

    public async Task<Assunto> Create(Assunto assunto)
    {
        _context.Assuntos.Add(assunto);
        await _context.SaveChangesAsync();
        return assunto;
    }

    public void Update(Assunto assunto)
    {
        _context.Assuntos.Update(assunto);
    }

    public async Task Delete(int id, CancellationToken cancellationToken)
    {
        var assunto = await _context.Assuntos.FindAsync(new object[] { id }, cancellationToken);
        if (assunto != null)
        {
            _context.Assuntos.Remove(assunto);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}