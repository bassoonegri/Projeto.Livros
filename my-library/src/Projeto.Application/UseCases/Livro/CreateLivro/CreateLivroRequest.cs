using MediatR;
using Projeto.Domain.Entities;

namespace Projeto.Application.UseCases.Livros.CreateLivro;

public sealed record class CreateLivroRequest(
    string Titulo, 
    string Editora, 
    int Edicao, 
    string AnoPublicacao,
    ICollection<LivroAutor> Autores,
    ICollection<LivroAssunto> Assuntos
    ) : IRequest<LivroResponse>;

