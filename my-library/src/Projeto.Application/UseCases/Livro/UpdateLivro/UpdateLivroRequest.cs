using MediatR;

namespace Projeto.Application.UseCases.Livros.UpdateLivro;

public sealed record class UpdateLivroRequest(int Codigo, string Titulo, string Editora, int Edicao, string AnoPublicacao) : IRequest<LivroResponse>;
