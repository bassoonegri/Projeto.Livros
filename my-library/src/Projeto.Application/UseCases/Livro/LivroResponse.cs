using Projeto.Domain.Entities;

namespace Projeto.Application.UseCases.Livros;

public sealed record class LivroResponse
{
    public int Codigo { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Editora { get; set; } = string.Empty;
    public int Edicao { get; set; }
    public string AnoPublicacao { get; set; } = string.Empty;


    public ICollection<LivroAutorResponse> LivroAutores { get; set; }
    public ICollection<LivroAssuntoResponse> LivroAssuntos { get; set; }
}

