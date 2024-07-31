using MediatR;

namespace Projeto.Application.UseCases.Livros.GetAllLivro;

public sealed record class GetAllLivrosRequest : IRequest<List<LivroResponse>>;
