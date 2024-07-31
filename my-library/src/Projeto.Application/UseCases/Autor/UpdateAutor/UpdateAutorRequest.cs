namespace Projeto.Application.UseCases.Autor.UpdateAutor;

public sealed record class UpdateAutorRequest
{
    public int CodAu { get; set; }
    public string Nome { get; set; }
}
