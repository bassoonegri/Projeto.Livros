using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Domain.Entities;

public class LivroAutor
{
    [Column("Livro_Codl", TypeName = "int")]
    public int LivroCodl { get; set; }
    
    [Column("Autor_CodAu", TypeName = "int")]
    public int AutorCodAu { get; set; }

    public Livro Livro { get; set; }
    public Autor Autor { get; set; }
}
