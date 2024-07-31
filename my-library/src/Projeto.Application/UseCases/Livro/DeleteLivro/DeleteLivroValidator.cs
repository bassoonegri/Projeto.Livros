using FluentValidation;

namespace Projeto.Application.UseCases.Livros.DeleteLivro;

public class DeleteLivroValidator : AbstractValidator<DeleteLivroRequest>
{
    public DeleteLivroValidator()
    {
        RuleFor(n => n.Codigo).NotEmpty();
    }
}
