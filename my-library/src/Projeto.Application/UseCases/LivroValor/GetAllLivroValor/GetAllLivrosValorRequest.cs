using MediatR;

namespace Projeto.Application.UseCases.LivroValor.GetAllLivroValor;

public sealed record class GetAllLivroValorRequest : IRequest<List<LivroValorResponse>>;
