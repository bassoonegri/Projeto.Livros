using MediatR;

namespace Projeto.Application.UseCases.TipoVenda.CreateTipoVenda;

public sealed record class CreateTipoVendaRequest(
    int CodTv,
    string Descricao
    ) : IRequest<TipoVendaResponse>;

