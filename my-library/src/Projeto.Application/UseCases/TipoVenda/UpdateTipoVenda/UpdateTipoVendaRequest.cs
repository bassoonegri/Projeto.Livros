using MediatR;

namespace Projeto.Application.UseCases.TipoVenda.UpdateTipoVenda;

public sealed record class UpdateTipoVendaRequest(
    int CodTv,
    string Descricao,
    decimal Valor) : IRequest<TipoVendaResponse>;
