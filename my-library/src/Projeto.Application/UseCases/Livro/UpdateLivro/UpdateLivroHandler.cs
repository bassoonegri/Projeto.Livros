using AutoMapper;
using MediatR;
using Projeto.Application.Shared.Exceptions;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.UseCases.Livros.UpdateLivro;

public class UpdateLivroHandler(IUnitOfWork unitOfWork, ILivroRepository LivroRepository, IMapper mapper) : IRequestHandler<UpdateLivroRequest, LivroResponse?>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILivroRepository _LivroRepository = LivroRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<LivroResponse?> Handle(UpdateLivroRequest request, CancellationToken cancellationToken)
    {
        await TaskAlreadyRegistered(request, cancellationToken);

        var entity = await _LivroRepository.Get(request.Codigo, cancellationToken);

        if (entity is null) return default;

        entity.Titulo = request.Titulo;
        entity.Editora = request.Editora;
        entity.AnoPublicacao = request.AnoPublicacao;

        _LivroRepository.Update(entity);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<LivroResponse>(entity);
    }

    private async Task TaskAlreadyRegistered(UpdateLivroRequest request, CancellationToken cancellationToken)
    {
        var entity = await _LivroRepository.GetByNome(request.Titulo, cancellationToken);
        if (entity != null && entity.Codl != request.Codigo)
        {
            {
                throw new DomainException("Livro já cadastrada.");
            }
        }
    }
}

