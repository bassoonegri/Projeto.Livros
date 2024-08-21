using AutoMapper;
using MediatR;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.UseCases.TipoVenda.CreateTipoVenda;

public class CreateTipoVendaHandler(IUnitOfWork unitOfWork, ITipoVendaRepository TipoVendaRepository, IMapper mapper) : IRequestHandler<CreateTipoVendaRequest, TipoVendaResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ITipoVendaRepository _TipoVendaRepository = TipoVendaRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<TipoVendaResponse> Handle(CreateTipoVendaRequest request, CancellationToken cancellationToken)
    {
        try
        {

            var entity = _mapper.Map<Domain.Entities.TipoVenda>(request);

            var createdEntity = await _TipoVendaRepository.Create(entity);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<TipoVendaResponse>(createdEntity);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
