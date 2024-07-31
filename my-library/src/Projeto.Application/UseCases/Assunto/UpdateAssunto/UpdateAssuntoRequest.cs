namespace Projeto.Application.UseCases.Assunto.UpdateAutor;

public sealed record class UpdateAssuntoRequest
{
    public int CodAs { get; set; }
    public string Descricao { get; set; }
}
