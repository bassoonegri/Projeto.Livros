using AutoMapper;
using MediatR;
using Projeto.Domain.Interfaces;

namespace Projeto.Application.UseCases.LivroValor.GetAllLivroValor;

public sealed class GetAllLivroValorHandler : IRequestHandler<GetAllLivroValorRequest, List<LivroValorResponse>>
{
    private readonly ILivroValorRepository _LivroValorRepository;
    private readonly IMapper _mapper;

    public GetAllLivroValorHandler(ILivroValorRepository LivroValorRepository, IMapper mapper)
    {
        _LivroValorRepository = LivroValorRepository;
        _mapper = mapper;
    }

    public async Task<List<LivroValorResponse>> Handle(GetAllLivroValorRequest request, CancellationToken cancellationToken)
    {
        var entities = await _LivroValorRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<LivroValorResponse>>(entities.Select(lv => new LivroValorResponse
                                                        {
                                                            TipoVendaCodTv = lv.TipoVendaCodTv,
                                                            TipoVendaDescricao = lv.TipoVenda.Descricao,  
                                                            LivroCodl = lv.LivroCodl,
                                                            LivroTitulo = lv.Livro.Titulo,  
                                                            Valor = lv.Valor
                                                        })
        );
    }
}
