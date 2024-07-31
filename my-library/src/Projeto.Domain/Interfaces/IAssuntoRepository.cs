using Projeto.Domain.Entities;

namespace Projeto.Domain.Interfaces;


public interface IAssuntoRepository
{
    Task<Assunto?> Get(int id, CancellationToken cancellationToken);
    Task<IEnumerable<Assunto>> GetAll(CancellationToken cancellationToken);
    Task<Assunto> Create(Assunto assunto);
    void Update(Assunto assunto);
    Task Delete(int id, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}