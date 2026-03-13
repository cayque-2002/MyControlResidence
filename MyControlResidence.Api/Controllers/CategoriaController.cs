using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyControlResidence.Api.Domain.Entidades;
using MyControlResidence.Api.Infrastructure.Context;

namespace MyControlResidence.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly CategoriaService _service;

    public CategoriaController(CategoriaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<CreateCategoriaDto>>> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    [HttpPost]
    public async Task<ActionResult<Categoria>> Create(CreateCategoriaDto dto)
    {
        var categoria = await _service.Create(dto);
        
        return Ok(categoria);

    }
}