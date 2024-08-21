using FluentValidation;
using Projeto.Application.UseCases.Livros.DeleteLivro;

namespace Projeto.Application.UseCases.LivroValor.DeleteLivroValor;

public class DeleteLivroValorValidator : AbstractValidator<DeleteLivroValorRequest>
{
    public DeleteLivroValorValidator()
    {
        RuleFor(n => n.Codigo).NotEmpty();
    }
}
