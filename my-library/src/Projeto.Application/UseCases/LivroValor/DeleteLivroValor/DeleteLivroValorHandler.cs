using AutoMapper;
using MediatR;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.UseCases.LivroValor.DeleteLivroValor;

public sealed class DeleteLivroValorHandler : IRequestHandler<DeleteLivroValorRequest, LivroValorResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILivroValorRepository _LivroValorRepository;
    private readonly IMapper _mapper;

    public DeleteLivroValorHandler(IUnitOfWork unitOfWork, ILivroValorRepository LivroValorRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _LivroValorRepository = LivroValorRepository;
        _mapper = mapper;
    }

    public async Task<LivroValorResponse?> Handle(DeleteLivroValorRequest request, CancellationToken cancellationToken)
    {
        var entity = await _LivroValorRepository.GetByIdAsynct(request.Codigo, request.Tipo, cancellationToken);

        if (entity == null) return default;

        _LivroValorRepository.Delete(entity, cancellationToken);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<LivroValorResponse>(entity);
    }
}
