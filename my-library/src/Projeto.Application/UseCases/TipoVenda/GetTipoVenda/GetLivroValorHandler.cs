using AutoMapper;
using MediatR;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.UseCases.TipoVenda.GetTipoVenda;

public sealed class GetTipoVendaHandler : IRequestHandler<GetTipoVendaRequest, TipoVendaResponse>
{
    private readonly ITipoVendaRepository _TipoVendaRepository;
    private readonly IMapper _mapper;

    public GetTipoVendaHandler(ITipoVendaRepository TipoVendaRepository, IMapper mapper)
    {
        _TipoVendaRepository = TipoVendaRepository;
        _mapper = mapper;
    }

    public async Task<TipoVendaResponse> Handle(GetTipoVendaRequest request, CancellationToken cancellationToken)
    {
        var entity = await _TipoVendaRepository.GetByIdAsynct(request.Codigo, cancellationToken);
        return _mapper.Map<TipoVendaResponse>(entity);
    }
}
