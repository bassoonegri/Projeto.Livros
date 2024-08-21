using FluentValidation;

namespace Projeto.Application.UseCases.LivroValor.UpdateLivroValor;

public class UpdateLivroValorValidator : AbstractValidator<UpdateLivroValorRequest>
{
    public UpdateLivroValorValidator()
    {
        RuleFor(n => n.TipoVendaCodTv);
        RuleFor(n => n.LivroCodl);
        RuleFor(n => n.Valor);
    }
}
