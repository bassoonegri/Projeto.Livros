namespace Projeto.Domain.Entities;

public class Assunto
{
    public int CodAs { get; set; }
    public string Descricao { get; set; }

    // Navegação
    public ICollection<LivroAssunto> LivroAssuntos { get; set; }
}
