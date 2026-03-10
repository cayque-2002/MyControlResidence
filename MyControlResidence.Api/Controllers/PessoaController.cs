using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyControlResidence.Api.Infrastructure.Context;
using MyControlResidence.Api.Domain.Entidades;

namespace MyControlResidence.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PessoaController : ControllerBase
{
    private readonly PessoaService _service;

    public PessoaController(PessoaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Pessoa>>> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePessoaDto dto)
    {
        var pessoa = await _service.Create(dto);
        return Ok(pessoa);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, UpdatePessoaDto dto)
    {
        await _service.Update(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}