using AutoMapper;
using Projeto.Application.UseCases.TipoVenda.CreateTipoVenda;
using Projeto.Application.UseCases.TipoVenda.UpdateTipoVenda;

namespace Projeto.Application.UseCases.TipoVenda;

public class TipoVendaMapper : Profile
{
    public TipoVendaMapper()
    {


        CreateMap<TipoVendaResponse, Domain.Entities.TipoVenda>()
            .ForMember(dest => dest.CodTv, opt => opt.MapFrom(src => src.CodTv))
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
        .ReverseMap();

        // Mapeia de CreateLivroValorRequest para TipoVenda
        CreateMap<CreateTipoVendaRequest, Domain.Entities.TipoVenda>()
            .ForMember(dest => dest.CodTv, opt => opt.MapFrom(src => src.CodTv))
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao));

        // Mapeia de UpdateLivroValorRequest para TipoVenda
        CreateMap<UpdateTipoVendaRequest, Domain.Entities.TipoVenda>()
            .ForMember(dest => dest.CodTv, opt => opt.MapFrom(src => src.CodTv))
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao));
    }
}
