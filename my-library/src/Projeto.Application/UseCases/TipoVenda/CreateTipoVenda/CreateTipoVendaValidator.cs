using FluentValidation;

namespace Projeto.Application.UseCases.TipoVenda.CreateTipoVenda;

public sealed class CreateTipoVendaValidator : AbstractValidator<CreateTipoVendaRequest>
{
    public CreateTipoVendaValidator()
    {
        RuleFor(n => n.CodTv);
        RuleFor(n => n.Descricao);
    }
}
