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
            .ForMember(dest => dest.AnoPublicacao, opt => opt.MapFrom(src => src.AnoPublicacao))
            .ForMember(dest => dest.LivroAutores, opt => opt.MapFrom(src => src.Autores.Select(a => new LivroAutor { AutorCodAu = a.AutorCodAu, LivroCodl = a.LivroCodl })))
            .ForMember(dest => dest.LivroAssuntos, opt => opt.MapFrom(src => src.Assuntos.Select(a => new LivroAssunto { AssuntoCodAs = a.AssuntoCodAs, LivroCodl = a.LivroCodl })));

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
            .ForMember(dest => dest.AnoPublicacao, opt => opt.MapFrom(src => src.AnoPublicacao))
            .ForMember(dest => dest.LivroAutores, opt => opt.MapFrom(src => src.LivroAutores))
            .ForMember(dest => dest.LivroAssuntos, opt => opt.MapFrom(src => src.LivroAssuntos));

        CreateMap<LivroAssunto, LivroAssuntoResponse>()
            .ForMember(dest => dest.LivroCodl, opt => opt.MapFrom(src => src.LivroCodl))
            .ForMember(dest => dest.AssuntoCodAs, opt => opt.MapFrom(src => src.AssuntoCodAs))
        .ReverseMap();

        CreateMap<LivroAutor, LivroAutorResponse>()
          .ForMember(dest => dest.LivroCodl, opt => opt.MapFrom(src => src.LivroCodl))
          .ForMember(dest => dest.AutorCodAu, opt => opt.MapFrom(src => src.AutorCodAu))
      .ReverseMap();
    }
}
