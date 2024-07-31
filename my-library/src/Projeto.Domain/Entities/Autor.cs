namespace Projeto.Domain.Entities;

public sealed class Autor
{
    public int CodAu { get; set; }
    public string Nome { get; set; }

    // Navegação
    public ICollection<LivroAutor> LivroAutores { get; set; }
}
