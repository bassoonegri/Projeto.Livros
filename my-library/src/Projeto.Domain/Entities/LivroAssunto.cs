using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Domain.Entities;

public class LivroAssunto
{
    [Column("Livro_Codl", TypeName = "int")]
    public int LivroCodl { get; set; }

    [Column("Assunto_codAs", TypeName = "int")]
    public int AssuntoCodAs { get; set; }

    public Livro Livro { get; set; }
    public Assunto Assunto { get; set; }
}
