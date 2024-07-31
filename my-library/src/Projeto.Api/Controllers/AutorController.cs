using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.UseCases.Autor;
using Projeto.Application.UseCases.Autor.CreateAutor;
using Projeto.Application.UseCases.Autor.UpdateAutor;
using Projeto.Domain.Entities;
using Projeto.Domain.Interfaces;

namespace Projeto.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AutorController : ControllerBase
{
    private readonly IAutorRepository _autorRepository;
    private readonly IMapper _mapper;

    public AutorController(IAutorRepository autorRepository, IMapper mapper)
    {
        _autorRepository = autorRepository;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAutorRequest request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var autor = _mapper.Map<Autor>(request);
        var createdAutor = await _autorRepository.Create(autor);

        var response = _mapper.Map<AutorResponse>(createdAutor);
        return CreatedAtAction(nameof(GetById), new { id = response.CodAu }, response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAutorRequest request, CancellationToken cancellationToken)
    {
        if (id != request.CodAu)
        {
            return BadRequest("ID mismatch.");
        }

        var existingAutor = await _autorRepository.Get(id, cancellationToken);
        if (existingAutor == null)
        {
            return NotFound();
        }

        var autor = _mapper.Map(request, existingAutor);
        _autorRepository.Update(autor);
        await _autorRepository.SaveChangesAsync(cancellationToken);

        var response = _mapper.Map<AutorResponse>(autor);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var existingAutor = await _autorRepository.Get(id, cancellationToken);
        if (existingAutor == null)
        {
            return NotFound();
        }

        await _autorRepository.Delete(id, cancellationToken);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var autor = await _autorRepository.Get(id, cancellationToken);
        if (autor == null)
        {
            return NotFound();
        }

        var response = _mapper.Map<AutorResponse>(autor);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var autores = await _autorRepository.GetAll(cancellationToken);
        var response = _mapper.Map<List<AutorResponse>>(autores);
        return Ok(response);
    }
}