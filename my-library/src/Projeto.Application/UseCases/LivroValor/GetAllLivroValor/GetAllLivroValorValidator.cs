using FluentValidation;

namespace Projeto.Application.UseCases.LivroValor.GetAllLivroValor;

public class GetAllLivroValorValidator : AbstractValidator<GetAllLivroValorRequest>
{
    public GetAllLivroValorValidator()
    {
        //sem validação
    }
}
