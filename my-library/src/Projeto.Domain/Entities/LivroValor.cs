using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto.Domain.Entities;
public class LivroValor
{
    [Column("TipoVenda_CodTv", TypeName = "int")]
    public int TipoVendaCodTv { get; set; }
   
    [Column("Livro_Codl", TypeName = "int")]
    public int LivroCodl { get; set; }

    public decimal Valor { get; set; }


    // Propriedades de navegação
    public TipoVenda TipoVenda { get; set; } // Relacionamento com TipoVenda
    public Livro Livro { get; set; } // Relacionamento com Livro
}
