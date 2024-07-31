using MediatR;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.UseCases.Livros;
using Projeto.Application.UseCases.Livros.CreateLivro;
using Projeto.Application.UseCases.Livros.DeleteLivro;
using Projeto.Application.UseCases.Livros.GetAllLivro;
using Projeto.Application.UseCases.Livros.GetLivro;
using Projeto.Application.UseCases.Livros.UpdateLivro;

namespace Projeto.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LivroController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<List<LivroResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllLivrosRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpGet("{codigo}")]
    public async Task<ActionResult<LivroResponse>> Get(int codigo, CancellationToken cancellationToken)
    {
        if (codigo == 0)
            return BadRequest();

        var response = await _mediator.Send(new GetLivroRequest(codigo), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<LivroResponse>> Create(CreateLivroRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<LivroResponse>> Update(UpdateLivroRequest request, CancellationToken cancellationToken)
    {
        if (request.Codigo == 0)
            return BadRequest();

        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{codigo}")]
    public async Task<ActionResult> Delete(int codigo, CancellationToken cancellationToken)
    {
        if (codigo == 0)
            return BadRequest();

        var response = await _mediator.Send(new DeleteLivroRequest(codigo), cancellationToken);
        return Ok(response);
    }
}
