using FluentValidation;

namespace Projeto.Application.UseCases.TipoVenda.GetAllTipoVenda;

public class GetAllTipoVendaValidator : AbstractValidator<GetAllTipoVendaRequest>
{
    public GetAllTipoVendaValidator()
    {
        //sem validação
    }
}
