using AutoMapper;
using MediatR;
using Projeto.Application.Shared.Exceptions;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.UseCases.LivroValor.UpdateLivroValor;

public class UpdateLivroValorHandler(IUnitOfWork unitOfWork, ILivroValorRepository LivroValorRepository, IMapper mapper) : IRequestHandler<UpdateLivroValorRequest, LivroValorResponse?>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILivroValorRepository _LivroValorRepository = LivroValorRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<LivroValorResponse?> Handle(UpdateLivroValorRequest request, CancellationToken cancellationToken)
    {

        var entity = await _LivroValorRepository.GetByIdAsynct(request.LivroCodl, request.TipoVendaCodTv, cancellationToken);
        if (entity != null && entity.TipoVendaCodTv != request.TipoVendaCodTv)
        {
            {
                throw new DomainException("LivroValor já cadastrada.");
            }
        }

        if (entity is null) return default;

        entity.TipoVendaCodTv = request.TipoVendaCodTv;
        entity.Valor = request.Valor;

        _LivroValorRepository.Update(entity);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<LivroValorResponse>(entity);
    }

}

