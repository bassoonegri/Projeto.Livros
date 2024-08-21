using AutoMapper;
using MediatR;
using Projeto.Application.Shared.Exceptions;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.UseCases.TipoVenda.UpdateTipoVenda;

public class UpdateTipoVendaHandler(IUnitOfWork unitOfWork, ITipoVendaRepository TipoVendaRepository, IMapper mapper) : IRequestHandler<UpdateTipoVendaRequest, TipoVendaResponse?>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ITipoVendaRepository _TipoVendaRepository = TipoVendaRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<TipoVendaResponse?> Handle(UpdateTipoVendaRequest request, CancellationToken cancellationToken)
    {

        var entity = await _TipoVendaRepository.GetByIdAsynct(request.CodTv, cancellationToken);
        if (entity != null && entity.CodTv != request.CodTv)
        {
            {
                throw new DomainException("TipoVenda já cadastrada.");
            }
        }

        if (entity is null) return default;

        entity.Descricao = request.Descricao;

        _TipoVendaRepository.Update(entity);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<TipoVendaResponse>(entity);
    }

}

