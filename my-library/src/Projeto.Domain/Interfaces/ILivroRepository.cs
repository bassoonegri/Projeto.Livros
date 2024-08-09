using Projeto.Domain.Entities;

namespace Projeto.Domain.Interfaces;

public interface ILivroRepository
{
    Task<IEnumerable<Livro>> GetAll(CancellationToken cancellationToken);

    Task<Livro> CreateAsync(Livro livro);

    Task<Livro> CreateWithRelationsAsync(Livro livro, CancellationToken cancellationToken);

    Task<Livro?> Get(int codigo, CancellationToken cancellationToken);

    void Update(Livro livro);

    Task<Livro?> GetByNome(string titulo, CancellationToken cancellationToken);

    Task Delete(int codigo, CancellationToken cancellationToken);

}