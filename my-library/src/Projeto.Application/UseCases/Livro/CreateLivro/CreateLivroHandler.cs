using AutoMapper;
using MediatR;
using Projeto.Application.Shared.Exceptions;
using Projeto.Domain.Entities;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.UseCases.Livros.CreateLivro;

public class CreateLivroHandler(IUnitOfWork unitOfWork, ILivroRepository LivroRepository, IMapper mapper) : IRequestHandler<CreateLivroRequest, LivroResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILivroRepository _LivroRepository = LivroRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<LivroResponse> Handle(CreateLivroRequest request, CancellationToken cancellationToken)
    {
        await TaskAlreadyRegistered(request, cancellationToken);

        var entity = _mapper.Map<Livro>(request);

        _LivroRepository.Create(entity);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<LivroResponse>(entity);
    }

    private async Task TaskAlreadyRegistered(CreateLivroRequest request, CancellationToken cancellationToken)
    {
        var entity = await _LivroRepository.GetByNome(request.Titulo, cancellationToken);
        if (entity != null)
        {
            throw new DomainException("Livro já cadastrada.");
        }
    }
}
