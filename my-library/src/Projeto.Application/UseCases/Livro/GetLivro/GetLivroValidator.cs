using FluentValidation;

namespace Projeto.Application.UseCases.Livros.GetLivro;

public class GetLivroValidator : AbstractValidator<GetLivroRequest>
{
    public GetLivroValidator()
    {
        RuleFor(n => n.Codigo).NotEmpty();
    }
}
