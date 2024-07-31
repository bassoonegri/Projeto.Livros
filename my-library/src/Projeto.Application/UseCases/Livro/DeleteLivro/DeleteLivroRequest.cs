using MediatR;

namespace Projeto.Application.UseCases.Livros.DeleteLivro;

public sealed record class DeleteLivroRequest(int Codigo) : IRequest<LivroResponse>;