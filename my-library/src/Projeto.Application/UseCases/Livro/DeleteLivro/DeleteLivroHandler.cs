using AutoMapper;
using MediatR;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.UseCases.Livros.DeleteLivro;

public sealed class DeleteLivroHandler : IRequestHandler<DeleteLivroRequest, LivroResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILivroRepository _LivroRepository;
    private readonly IMapper _mapper;

    public DeleteLivroHandler(IUnitOfWork unitOfWork, ILivroRepository LivroRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _LivroRepository = LivroRepository;
        _mapper = mapper;
    }

    public async Task<LivroResponse?> Handle(DeleteLivroRequest request, CancellationToken cancellationToken)
    {
        var entity = await _LivroRepository.Get(request.Codigo, cancellationToken);

        if (entity == null) return default;

        _LivroRepository.Delete(request.Codigo, cancellationToken);
        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<LivroResponse>(entity);
    }
}
