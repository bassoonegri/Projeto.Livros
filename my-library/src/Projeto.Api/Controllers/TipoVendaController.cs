using MediatR;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.UseCases.Livros;
using Projeto.Application.UseCases.TipoVenda.CreateTipoVenda;
using Projeto.Application.UseCases.TipoVenda.DeleteTipoVenda;
using Projeto.Application.UseCases.TipoVenda.GetAllTipoVenda;
using Projeto.Application.UseCases.TipoVenda.GetTipoVenda;
using Projeto.Application.UseCases.TipoVenda.UpdateTipoVenda;

namespace Projeto.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TipoVendaController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<List<LivroResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllTipoVendaRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpGet("{codigo}")]
    public async Task<ActionResult<LivroResponse>> Get(int codigo, CancellationToken cancellationToken)
    {
        if (codigo == 0)
            return BadRequest();

        var response = await _mediator.Send(new GetTipoVendaRequest(codigo), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<LivroResponse>> Create(CreateTipoVendaRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<LivroResponse>> Update(UpdateTipoVendaRequest request, CancellationToken cancellationToken)
    {
        if (request.CodTv == 0)
            return BadRequest();

        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{codigo}")]
    public async Task<ActionResult> Delete(int codigo, CancellationToken cancellationToken)
    {
        if (codigo == 0)
            return BadRequest();

        var response = await _mediator.Send(new DeleteTipoVendaRequest(codigo), cancellationToken);
        return Ok(response);
    }
}
