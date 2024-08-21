using AutoMapper;
using MediatR;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.UseCases.TipoVenda.GetAllTipoVenda;

public sealed class GetAllTipoVendaHandler : IRequestHandler<GetAllTipoVendaRequest, List<TipoVendaResponse>>
{
    private readonly ITipoVendaRepository _TipoVendaRepository;
    private readonly IMapper _mapper;

    public GetAllTipoVendaHandler(ITipoVendaRepository TipoVendaRepository, IMapper mapper)
    {
        _TipoVendaRepository = TipoVendaRepository;
        _mapper = mapper;
    }

    public async Task<List<TipoVendaResponse>> Handle(GetAllTipoVendaRequest request, CancellationToken cancellationToken)
    {
        var entities = await _TipoVendaRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<TipoVendaResponse>>(entities);
    }
}
