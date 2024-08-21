using FluentValidation;

namespace Projeto.Application.UseCases.LivroValor.CreateLivroValor;

public sealed class CreateLivroValorValidator : AbstractValidator<CreateLivroValorRequest>
{
    public CreateLivroValorValidator()
    {
        RuleFor(n => n.LivroCodl);
        RuleFor(n => n.TipoVendaCodTv);
        RuleFor(n => n.Valor);
    }
}
