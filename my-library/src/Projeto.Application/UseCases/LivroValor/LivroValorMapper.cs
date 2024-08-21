using AutoMapper;
using Projeto.Application.UseCases.LivroValor;
using Projeto.Application.UseCases.LivroValor.CreateLivroValor;
using Projeto.Application.UseCases.LivroValor.UpdateLivroValor;

namespace Projeto.Application.UseCases.LivrosValor;

public class TipoVendaMapper : Profile
{
    public TipoVendaMapper()
    {
        // Mapeia de CreateLivroValorRequest para Livro
        CreateMap<CreateLivroValorRequest, Domain.Entities.LivroValor>()
            .ForMember(dest => dest.LivroCodl, opt => opt.MapFrom(src => src.LivroCodl))
            .ForMember(dest => dest.TipoVendaCodTv, opt => opt.MapFrom(src => src.TipoVendaCodTv))
            .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor));

        // Mapeia de UpdateLivroValorRequest para Livro
        CreateMap<UpdateLivroValorRequest, Domain.Entities.LivroValor>()
            .ForMember(dest => dest.LivroCodl, opt => opt.MapFrom(src => src.LivroCodl))
            .ForMember(dest => dest.TipoVendaCodTv, opt => opt.MapFrom(src => src.TipoVendaCodTv))
            .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor));



        CreateMap<LivroValorResponse, Domain.Entities.LivroValor>()
            .ForMember(dest => dest.LivroCodl, opt => opt.MapFrom(src => src.LivroCodl))
            .ForMember(dest => dest.TipoVendaCodTv, opt => opt.MapFrom(src => src.TipoVendaCodTv))
            .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor))
        .ReverseMap();

    }
}
