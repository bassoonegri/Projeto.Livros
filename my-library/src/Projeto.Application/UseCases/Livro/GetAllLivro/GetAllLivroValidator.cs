using FluentValidation;

namespace Projeto.Application.UseCases.Livros.GetAllLivro;

public class GetAllLivroValidator : AbstractValidator<GetAllLivrosRequest>
{
    public GetAllLivroValidator()
    {
        //sem validação
    }
}
