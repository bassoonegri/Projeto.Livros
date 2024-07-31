using AutoMapper;
using Projeto.Application.UseCases.Assunto.CreateAutor;
using Projeto.Application.UseCases.Assunto.UpdateAutor;

namespace Projeto.Application.UseCases.Assunto;

public class AssuntoMapper : Profile
{
    public AssuntoMapper()
    {
        CreateMap<Domain.Entities.Assunto, AssuntoResponse>()
            .ForMember(dest => dest.CodAs, opt => opt.MapFrom(src => src.CodAs))
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao));

        CreateMap<CreateAssuntoRequest, Domain.Entities.Assunto>()
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao));

        CreateMap<UpdateAssuntoRequest, Domain.Entities.Assunto>()
            .ForMember(dest => dest.CodAs, opt => opt.MapFrom(src => src.CodAs))
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao));
    }
}
