using MediatR;

namespace Projeto.Application.UseCases.Livros.CreateLivro;

public sealed record class CreateLivroRequest(string Titulo, string Editora, int Edicao, string AnoPublicacao) : IRequest<LivroResponse>;

