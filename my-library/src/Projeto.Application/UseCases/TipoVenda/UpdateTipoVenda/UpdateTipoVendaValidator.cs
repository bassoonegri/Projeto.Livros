using FluentValidation;

namespace Projeto.Application.UseCases.TipoVenda.UpdateTipoVenda;

public class UpdateTipoVendaValidator : AbstractValidator<UpdateTipoVendaRequest>
{
    public UpdateTipoVendaValidator()
    {
        RuleFor(n => n.CodTv);
        RuleFor(n => n.Descricao);
    }
}
