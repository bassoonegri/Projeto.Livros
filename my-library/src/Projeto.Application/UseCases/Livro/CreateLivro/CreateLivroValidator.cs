using FluentValidation;

namespace Projeto.Application.UseCases.Livros.CreateLivro;

public sealed class CreateLivroValidator : AbstractValidator<CreateLivroRequest>
{
    public CreateLivroValidator()
    {
        RuleFor(n => n.Titulo).NotEmpty().MaximumLength(40);
        RuleFor(n => n.Editora).MaximumLength(40);
    }
}
