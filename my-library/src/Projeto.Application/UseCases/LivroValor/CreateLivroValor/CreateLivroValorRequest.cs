using MediatR;

namespace Projeto.Application.UseCases.LivroValor.CreateLivroValor;

public sealed record class CreateLivroValorRequest(
    string TipoVendaCodTv,
    string LivroCodl,
    decimal Valor
    ) : IRequest<LivroValorResponse>;

