using FluentValidation;

namespace Projeto.Application.UseCases.Livros.UpdateLivro;

public class UpdateLivroValidator : AbstractValidator<UpdateLivroRequest>
{
    public UpdateLivroValidator()
    {
        RuleFor(n => n.Titulo).NotEmpty().MaximumLength(40);
        RuleFor(n => n.Editora).MaximumLength(40);
        RuleFor(n => n.AnoPublicacao).MaximumLength(4);
    }
}
