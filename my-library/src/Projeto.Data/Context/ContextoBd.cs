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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração da entidade LivroAutor
        modelBuilder.Entity<LivroAutor>()
            .HasKey(la => new { la.LivroCodl, la.AutorCodAu });

        modelBuilder.Entity<LivroAutor>()
            .HasOne(la => la.Livro)
            .WithMany(l => l.LivroAutores)
            .HasForeignKey(la => la.LivroCodl);

        modelBuilder.Entity<LivroAutor>()
            .HasOne(la => la.Autor)
            .WithMany(a => a.LivroAutores)
            .HasForeignKey(la => la.AutorCodAu);

        // Configuração da entidade LivroAssunto
        modelBuilder.Entity<LivroAssunto>()
            .HasKey(la => new { la.LivroCodl, la.AssuntoCodAs });

        modelBuilder.Entity<LivroAssunto>()
            .HasOne(la => la.Livro)
            .WithMany(l => l.LivroAssuntos)
            .HasForeignKey(la => la.LivroCodl);

        modelBuilder.Entity<LivroAssunto>()
            .HasOne(la => la.Assunto)
            .WithMany(a => a.LivroAssuntos)
            .HasForeignKey(la => la.AssuntoCodAs);

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
            entity.ToTable("Livro", "dbo"); // Mapeia para a tabela dbo.Livro
            entity.HasKey(e => e.Codl);

            entity.Property(e => e.Codl)
                .HasColumnName("Codl");

            entity.Property(e => e.Titulo)
                .HasColumnName("Titulo");

            entity.Property(e => e.Editora)
                .HasColumnName("Editora");

            entity.Property(e => e.Edicao)
                .HasColumnName("Edicao");

            entity.Property(e => e.AnoPublicacao)
                .HasColumnName("AnoPublicacao");
        });
    }


}
