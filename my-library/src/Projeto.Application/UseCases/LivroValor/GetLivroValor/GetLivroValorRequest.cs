using MediatR;

namespace Projeto.Application.UseCases.LivroValor.GetLivroValor;

public sealed record class GetLivroValorRequest(int Codigo, int tipo) : IRequest<LivroValorResponse>;
