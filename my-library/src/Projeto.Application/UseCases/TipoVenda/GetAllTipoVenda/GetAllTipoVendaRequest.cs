using MediatR;

namespace Projeto.Application.UseCases.TipoVenda.GetAllTipoVenda;

public sealed record class GetAllTipoVendaRequest : IRequest<List<TipoVendaResponse>>;
