using MediatR;

namespace Projeto.Application.UseCases.TipoVenda.GetTipoVenda;

public sealed record class GetTipoVendaRequest(int Codigo) : IRequest<TipoVendaResponse>;
