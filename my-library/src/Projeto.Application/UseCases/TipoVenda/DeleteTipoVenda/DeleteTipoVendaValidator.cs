using FluentValidation;
using Projeto.Application.UseCases.Livros.DeleteLivro;

namespace Projeto.Application.UseCases.TipoVenda.DeleteTipoVenda;

public class DeleteTipoVendaValidator : AbstractValidator<DeleteTipoVendaRequest>
{
    public DeleteTipoVendaValidator()
    {
        RuleFor(n => n.Codigo).NotEmpty();
    }
}
