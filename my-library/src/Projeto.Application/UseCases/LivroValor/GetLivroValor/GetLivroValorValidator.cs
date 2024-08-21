using FluentValidation;

namespace Projeto.Application.UseCases.LivroValor.GetLivroValor;

public class GetLivroValorValidator : AbstractValidator<GetLivroValorRequest>
{
    public GetLivroValorValidator()
    {
        RuleFor(n => n.Codigo).NotEmpty();
    }
}
