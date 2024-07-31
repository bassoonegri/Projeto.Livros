using AutoMapper;
using MediatR;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.UseCases.Livros.GetLivro;

public sealed class GetLivroHandler : IRequestHandler<GetLivroRequest, LivroResponse>
{
    private readonly ILivroRepository _LivroRepository;
    private readonly IMapper _mapper;

    public GetLivroHandler(ILivroRepository LivroRepository, IMapper mapper)
    {
        _LivroRepository = LivroRepository;
        _mapper = mapper;
    }

    public async Task<LivroResponse> Handle(GetLivroRequest request, CancellationToken cancellationToken)
    {
        var entity = await _LivroRepository.Get(request.Codigo, cancellationToken);
        return _mapper.Map<LivroResponse>(entity);
    }
}
