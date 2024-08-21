namespace Projeto.Application.UseCases.LivroValor;

public class LivroValorResponse
{
    public int TipoVendaCodTv { get; set; }
    public string TipoVendaDescricao { get; set; } // Incluindo a descrição do TipoVenda
    public int LivroCodl { get; set; }
    public string LivroTitulo { get; set; } // Incluindo o título do Livro
    public decimal Valor { get; set; }
}
