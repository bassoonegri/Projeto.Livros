using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.UseCases.Assunto;
using Projeto.Application.UseCases.Assunto.CreateAutor;
using Projeto.Application.UseCases.Assunto.UpdateAutor;
using Projeto.Domain.Entities;
using Projeto.Domain.Interfaces;

namespace Projeto.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AssuntoController : ControllerBase
{
    private readonly IAssuntoRepository _assuntoRepository;
    private readonly IMapper _mapper;

    public AssuntoController(IAssuntoRepository assuntoRepository, IMapper mapper)
    {
        _assuntoRepository = assuntoRepository;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAssuntoRequest request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var assunto = _mapper.Map<Assunto>(request);
        var createdAssunto = await _assuntoRepository.Create(assunto);

        var response = _mapper.Map<AssuntoResponse>(createdAssunto);
        return CreatedAtAction(nameof(GetById), new { id = response.CodAs }, response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAssuntoRequest request, CancellationToken cancellationToken)
    {
        if (id != request.CodAs)
        {
            return BadRequest("ID mismatch.");
        }

        var existingAssunto = await _assuntoRepository.Get(id, cancellationToken);
        if (existingAssunto == null)
        {
            return NotFound();
        }

        var assunto = _mapper.Map(request, existingAssunto);
        _assuntoRepository.Update(assunto);
        await _assuntoRepository.SaveChangesAsync(cancellationToken);

        var response = _mapper.Map<AssuntoResponse>(assunto);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var existingAssunto = await _assuntoRepository.Get(id, cancellationToken);
        if (existingAssunto == null)
        {
            return NotFound();
        }

        await _assuntoRepository.Delete(id, cancellationToken);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var assunto = await _assuntoRepository.Get(id, cancellationToken);
        if (assunto == null)
        {
            return NotFound();
        }

        var response = _mapper.Map<AssuntoResponse>(assunto);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var assuntos = await _assuntoRepository.GetAll(cancellationToken);
        var response = _mapper.Map<List<AssuntoResponse>>(assuntos);
        return Ok(response);
    }
}