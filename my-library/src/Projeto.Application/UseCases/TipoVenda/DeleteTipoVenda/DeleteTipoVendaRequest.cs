using MediatR;

namespace Projeto.Application.UseCases.TipoVenda.DeleteTipoVenda;

public sealed record class DeleteTipoVendaRequest(int Codigo) : IRequest<TipoVendaResponse>;