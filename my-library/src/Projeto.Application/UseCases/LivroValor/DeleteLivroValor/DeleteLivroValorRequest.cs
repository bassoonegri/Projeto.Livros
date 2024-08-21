using MediatR;

namespace Projeto.Application.UseCases.LivroValor.DeleteLivroValor;

public sealed record class DeleteLivroValorRequest(int Codigo, int Tipo) : IRequest<LivroValorResponse>;