using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyControlResidence.Api.Domain.Entidades;
using MyControlResidence.Api.Domain.Enums;
using MyControlResidence.Api.Infrastructure.Context;

namespace MyControlResidence.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransacaoController : ControllerBase
{
    private readonly TransacaoService _service;

    public TransacaoController(TransacaoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<Transacao>>> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateTransacaoDto dto)
    {
        var transacao = await _service.Create(dto);
        return Ok(transacao);
    }
}