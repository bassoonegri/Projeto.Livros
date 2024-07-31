using MediatR;

namespace Projeto.Application.UseCases.Livros.GetLivro;

public sealed record class GetLivroRequest(int Codigo) : IRequest<LivroResponse>;
