using AutoMapper;
using MediatR;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.UseCases.Livros.GetAllLivro;

public sealed class GetAllLivroHandler : IRequestHandler<GetAllLivrosRequest, List<LivroResponse>>
{
    private readonly ILivroRepository _LivroRepository;
    private readonly IMapper _mapper;

    public GetAllLivroHandler(ILivroRepository LivroRepository, IMapper mapper)
    {
        _LivroRepository = LivroRepository;
        _mapper = mapper;
    }

    public async Task<List<LivroResponse>> Handle(GetAllLivrosRequest request, CancellationToken cancellationToken)
    {
        var entities = await _LivroRepository.GetAll(cancellationToken);
        return _mapper.Map<List<LivroResponse>>(entities);
    }
}
