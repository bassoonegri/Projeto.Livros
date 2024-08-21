using AutoMapper;
using MediatR;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.UseCases.LivroValor.CreateLivroValor;

public class CreateLivroValorHandler(IUnitOfWork unitOfWork, ILivroValorRepository LivroValorRepository, IMapper mapper) : IRequestHandler<CreateLivroValorRequest, LivroValorResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILivroValorRepository _LivroValorRepository = LivroValorRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<LivroValorResponse> Handle(CreateLivroValorRequest request, CancellationToken cancellationToken)
    {
        try
        {

            var entity = _mapper.Map<Domain.Entities.LivroValor>(request);

            var createdEntity = await _LivroValorRepository.Create(entity);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<LivroValorResponse>(createdEntity);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
