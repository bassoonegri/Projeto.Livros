using Projeto.Domain.Entities;

namespace Projeto.Domain.Interfaces;

public interface ITipoVendaRepository
{
    Task<IEnumerable<TipoVenda>> GetAllAsync(CancellationToken cancellationToken); 
    Task<TipoVenda?> GetByIdAsynct(int id, CancellationToken cancellationToken);
    Task<TipoVenda> Create(TipoVenda tipo);
    void Update(TipoVenda tipo);
    Task Delete(int id, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
