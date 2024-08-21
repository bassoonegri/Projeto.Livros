using MediatR;

namespace Projeto.Application.UseCases.LivroValor.UpdateLivroValor;

public sealed record class UpdateLivroValorRequest(
    int TipoVendaCodTv,
    int LivroCodl,
    decimal Valor) : IRequest<LivroValorResponse>;
