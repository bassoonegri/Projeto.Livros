using AutoMapper;
using Projeto.Application.UseCases.Livros.CreateLivro;
using Projeto.Application.UseCases.Livros.UpdateLivro;
using Projeto.Domain.Entities;

namespace Projeto.Application.UseCases.Livros;

public class LivroMapper : Profile
{
    public LivroMapper()
    {
        // Mapeia de CreateLivroRequest para Livro
        CreateMap<CreateLivroRequest, Livro>()
            .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
            .ForMember(dest => dest.Editora, opt => opt.MapFrom(src => src.Editora))
            .ForMember(dest => dest.Edicao, opt => opt.MapFrom(src => src.Edicao))
            .ForMember(dest => dest.AnoPublicacao, opt => opt.MapFrom(src => src.AnoPublicacao));

        // Mapeia de UpdateLivroRequest para Livro
        CreateMap<UpdateLivroRequest, Livro>()
            .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
            .ForMember(dest => dest.Editora, opt => opt.MapFrom(src => src.Editora))
            .ForMember(dest => dest.Edicao, opt => opt.MapFrom(src => src.Edicao))
            .ForMember(dest => dest.AnoPublicacao, opt => opt.MapFrom(src => src.AnoPublicacao));

        // Mapeia de Livro para LivroResponse
        CreateMap<Livro, LivroResponse>()
            .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Codl))
            .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Titulo))
            .ForMember(dest => dest.Editora, opt => opt.MapFrom(src => src.Editora))
            .ForMember(dest => dest.Edicao, opt => opt.MapFrom(src => src.Edicao))
            .ForMember(dest => dest.AnoPublicacao, opt => opt.MapFrom(src => src.AnoPublicacao));
    }
}