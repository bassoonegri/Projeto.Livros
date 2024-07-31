namespace Projeto.Domain.Entities;

public sealed class Livro 
{
    public Livro()
    {

        LivroAutores = new List<LivroAutor>();
        LivroAssuntos = new List<LivroAssunto>();
    }

    public Livro(int codl, string titulo, string editora, int edicao, string anoPublicacao, ICollection<LivroAutor> livroAutores, ICollection<LivroAssunto> livroAssuntos)
    {
        Codl = codl;
        Titulo = titulo;
        Editora = editora;
        Edicao = edicao;
        AnoPublicacao = anoPublicacao;
        LivroAutores = livroAutores;
        LivroAssuntos = livroAssuntos;
    }

    public int Codl { get; set; }
    public string Titulo { get; set; }
    public string Editora { get; set; }
    public int Edicao { get; set; }
    public string AnoPublicacao { get; set; }

    // Navegação
    public ICollection<LivroAutor> LivroAutores { get; set; }
    public ICollection<LivroAssunto> LivroAssuntos { get; set; }
}
