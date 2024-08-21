using Projeto.Domain.Entities;


namespace Projeto.Domain.Interfaces;

public interface ILivroValorRepository
{
    Task<IEnumerable<LivroValor>> GetAllAsync(CancellationToken cancellationToken);
    Task<LivroValor?> GetByIdAsynct(int id, int tipo, CancellationToken cancellationToken);
    Task<LivroValor> Create(LivroValor tipo);
    void Update(LivroValor tipo);
    Task Delete(LivroValor item, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
