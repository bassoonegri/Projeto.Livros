using AutoMapper;
using Moq;
using Projeto.Application.Shared.Exceptions;
using Projeto.Application.UseCases.Livros.CreateLivro;
using Projeto.Domain.Entities;
using Projeto.Domain.Interfaces;

namespace Projeto.Tests;

public class LivroTest
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly Mock<ILivroRepository> _LivroRepository;
    private readonly Mock<IMapper> _mapper;

    public LivroTest()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _LivroRepository = new Mock<ILivroRepository>();
        _mapper = new Mock<IMapper>();
    }

    [Fact(DisplayName = "Nova Livro válida")]
    [Trait("Categoria", "Livro")]
    public void Livro_Valida()
    {
        // Arrange
        var request = new CreateLivroRequest("Livro01", "Descrição da Livro 01", 1, "2000");
        var LivroHandler = new CreateLivroHandler(_unitOfWork.Object, _LivroRepository.Object, _mapper.Object);

        // Act
        var result = LivroHandler.Handle(request, new CancellationToken());

        // Assert
        _LivroRepository.Verify(n => n.Create(It.IsAny<Livro>()), Times.Once);
        _unitOfWork.Verify(n => n.Commit(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact(DisplayName = "Livro já cadastrada.")]
    [Trait("Categoria", "Livro")]
    public async void Livro_Ja_Cadastrada()
    {
        // Arrange
        var request = new CreateLivroRequest("", "", 0, "");
        var LivroHandler = new CreateLivroHandler(_unitOfWork.Object, _LivroRepository.Object, _mapper.Object);

        _LivroRepository.Setup(n => n.GetByNome(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Livro());

        // Act
        var exception = await Assert.ThrowsAsync<DomainException>(() => LivroHandler.Handle(request, new CancellationToken()));

        // Assert
        Assert.Equal("Livro já cadastrada.", exception.Message);
    }
}
