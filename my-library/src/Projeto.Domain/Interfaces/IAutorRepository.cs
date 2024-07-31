using Projeto.Domain.Entities;

namespace Projeto.Domain.Interfaces
{

    public interface IAutorRepository
    {
        Task<Autor?> Get(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Autor>> GetAll(CancellationToken cancellationToken);
        Task<Autor> Create(Autor autor);
        void Update(Autor autor);
        Task Delete(int id, CancellationToken cancellationToken);
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}