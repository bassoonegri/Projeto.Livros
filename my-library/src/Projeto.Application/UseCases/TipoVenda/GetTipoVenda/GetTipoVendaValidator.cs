using FluentValidation;

namespace Projeto.Application.UseCases.TipoVenda.GetTipoVenda;

public class GetTipoVendaValidator : AbstractValidator<GetTipoVendaRequest>
{
    public GetTipoVendaValidator()
    {
        RuleFor(n => n.Codigo).NotEmpty();
    }
}
