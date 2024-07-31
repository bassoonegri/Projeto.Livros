using AutoMapper;
using Projeto.Application.UseCases.Autor.CreateAutor;
using Projeto.Application.UseCases.Autor.UpdateAutor;

namespace Projeto.Application.UseCases.Autor;

public class AutorMapper : Profile
{
    public AutorMapper()
    {
        CreateMap<Domain.Entities.Autor, AutorResponse>()
            .ForMember(dest => dest.CodAu, opt => opt.MapFrom(src => src.CodAu))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

        CreateMap<CreateAutorRequest, Domain.Entities.Autor>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));

        CreateMap<UpdateAutorRequest, Domain.Entities.Autor>()
            .ForMember(dest => dest.CodAu, opt => opt.MapFrom(src => src.CodAu))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome));
    }
}
