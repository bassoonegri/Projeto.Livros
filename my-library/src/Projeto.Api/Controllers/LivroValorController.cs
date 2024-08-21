using MediatR;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.UseCases.LivroValor;
using Projeto.Application.UseCases.LivroValor.CreateLivroValor;
using Projeto.Application.UseCases.LivroValor.DeleteLivroValor;
using Projeto.Application.UseCases.LivroValor.GetAllLivroValor;
using Projeto.Application.UseCases.LivroValor.GetLivroValor;
using Projeto.Application.UseCases.LivroValor.UpdateLivroValor;


namespace Projeto.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LivroValorController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<List<LivroValorResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllLivroValorRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpGet("{codigo}/{tipo}")]
    public async Task<ActionResult<LivroValorResponse>> Get(int codigo,int tipo, CancellationToken cancellationToken)
    {
        if (codigo == 0)
            return BadRequest();

        var response = await _mediator.Send(new GetLivroValorRequest(codigo, tipo), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<LivroValorResponse>> Create(CreateLivroValorRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<LivroValorResponse>> Update(UpdateLivroValorRequest request, CancellationToken cancellationToken)
    {
        if (request.LivroCodl == 0)
            return BadRequest();

        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{codigo}/{tipo}")]
    public async Task<ActionResult> Delete(int codigo, int tipo, CancellationToken cancellationToken)
    {
        if (codigo == 0)
            return BadRequest();

        var response = await _mediator.Send(new DeleteLivroValorRequest(codigo, tipo), cancellationToken);
        return Ok(response);
    }
}
