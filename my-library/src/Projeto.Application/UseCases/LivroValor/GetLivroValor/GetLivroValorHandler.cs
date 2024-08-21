using AutoMapper;
using MediatR;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.UseCases.LivroValor.GetLivroValor;

public sealed class GetLivroValorHandler : IRequestHandler<GetLivroValorRequest, LivroValorResponse>
{
    private readonly ILivroValorRepository _LivroValorRepository;
    private readonly IMapper _mapper;

    public GetLivroValorHandler(ILivroValorRepository LivroValorRepository, IMapper mapper)
    {
        _LivroValorRepository = LivroValorRepository;
        _mapper = mapper;
    }

    public async Task<LivroValorResponse> Handle(GetLivroValorRequest request, CancellationToken cancellationToken)
    {
        var entity = await _LivroValorRepository.GetByIdAsynct(request.Codigo, request.tipo, cancellationToken);
        return _mapper.Map<LivroValorResponse>(new LivroValorResponse
                                                {
                                                    TipoVendaCodTv = entity.TipoVendaCodTv,
                                                    TipoVendaDescricao = entity.TipoVenda.Descricao,
                                                    LivroCodl = entity.LivroCodl,
                                                    LivroTitulo = entity.Livro.Titulo,
                                                    Valor = entity.Valor
                                                });
    }
}
