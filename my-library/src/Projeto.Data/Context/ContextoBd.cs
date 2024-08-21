using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Entities;

namespace Projeto.Data.Context;

public class ContextoBd : DbContext
{
    public ContextoBd(DbContextOptions<ContextoBd> options) : base(options) { }

    public DbSet<Livro> Livros { get; set; }
    public DbSet<Autor> Autores { get; set; }
    public DbSet<Assunto> Assuntos { get; set; }
    public DbSet<LivroAutor> LivroAutores { get; set; }
    public DbSet<LivroAssunto> LivroAssuntos { get; set; }
    public DbSet<LivroValor> LivroValor { get; set; }
    public DbSet<TipoVenda> TipoVenda { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração da entidade LivroAutor
        modelBuilder.Entity<LivroAutor>(entity =>
        {
            entity.ToTable("Livro_Autor", "dbo"); // Mapeia para a tabela dbo.Autor
            entity.HasKey(la => new { la.LivroCodl, la.AutorCodAu });

            entity.HasOne(la => la.Livro)
            .WithMany(l => l.LivroAutores)
            .HasForeignKey(la => la.LivroCodl);

            entity.HasOne(la => la.Autor)
            .WithMany(a => a.LivroAutores)
            .HasForeignKey(la => la.AutorCodAu);
        });


        // Configuração da entidade LivroAssunto
        modelBuilder.Entity<LivroAssunto>(entity =>
        {
            entity.ToTable("Livro_Assunto", "dbo"); // Mapeia para a tabela dbo.Autor
            entity.HasKey(la => new { la.LivroCodl, la.AssuntoCodAs });

            entity.HasOne(la => la.Livro)
            .WithMany(l => l.LivroAssuntos)
            .HasForeignKey(la => la.LivroCodl);

            entity.HasOne(la => la.Assunto)
            .WithMany(a => a.LivroAssuntos)
            .HasForeignKey(la => la.AssuntoCodAs);
        });


        // Configuração da entidade Assunto
        modelBuilder.Entity<Assunto>(entity =>
        {
            entity.ToTable("Assunto", "dbo"); // Mapeia para a tabela dbo.Assunto
            entity.HasKey(e => e.CodAs);
        });

        // Configuração da entidade Autor
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.ToTable("Autor", "dbo"); // Mapeia para a tabela dbo.Autor
            entity.HasKey(e => e.CodAu);
        });

        // Configuração da entidade Livro
        modelBuilder.Entity<Livro>(entity =>
        {
            entity.ToTable("Livro", "dbo");

            entity.HasKey(e => e.Codl);

            entity.Property(e => e.Codl)
                .HasColumnName("Codl")
                .ValueGeneratedOnAdd(); // Indica que o valor será gerado pelo banco de dados (auto-incremento)

            entity.Property(e => e.Titulo)
                .HasColumnName("Titulo")
                .HasMaxLength(40) // Define o comprimento máximo da coluna
                .IsRequired(); // Define que a coluna é obrigatória

            entity.Property(e => e.Editora)
                .HasColumnName("Editora")
                .HasMaxLength(40) // Define o comprimento máximo da coluna
                .IsRequired(); // Define que a coluna é obrigatória

            entity.Property(e => e.Edicao)
                .HasColumnName("Edicao")
                .IsRequired(); // Define que a coluna é obrigatória

            entity.Property(e => e.AnoPublicacao)
                .HasColumnName("AnoPublicacao")
                .HasMaxLength(4) // Define o comprimento máximo da coluna
                .IsRequired(); // Define que a coluna é obrigatória
        });


        // Configuração da entidade TipoVenda
        modelBuilder.Entity<TipoVenda>(entity =>
        {
            entity.ToTable("Tipo_Venda", "dbo"); // Mapeia para a tabela dbo.TipoVenda
            entity.HasKey(e => e.CodTv); // Define CodTv como a chave primária
            entity.Property(e => e.Descricao);
        });

        // Configuração da entidade LivroValor
        modelBuilder.Entity<LivroValor>(entity =>
        {
            entity.ToTable("Livro_Valor", "dbo"); // Mapeia para a tabela dbo.Livro_Valor

            // Configura a chave primária composta
            entity.HasKey(e => new { e.TipoVendaCodTv, e.LivroCodl });

            // Configura a relação com TipoVenda
            entity.HasOne(e => e.TipoVenda)
                .WithMany()  
                .HasForeignKey(e => e.TipoVendaCodTv)
                .OnDelete(DeleteBehavior.Restrict);  

            // Configura a relação com Livro
            entity.HasOne(e => e.Livro)
                .WithMany() 
                .HasForeignKey(e => e.LivroCodl)
                .OnDelete(DeleteBehavior.Restrict);  
        });

    }


}
