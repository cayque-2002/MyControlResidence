using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyControlResidence.Api.Domain.Enums;
using MyControlResidence.Api.Infrastructure.Context;

namespace MyControlResidence.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RelatorioController : ControllerBase
{
    private readonly RelatorioService _service;

    public RelatorioController(RelatorioService relatorioService)
    {
        _service = relatorioService;
    }

    [HttpGet(nameof(GetRelatorioPorPessoa))]
    public async Task<IActionResult> GetRelatorioPorPessoa()
    {
        return Ok(await _service.GetRelatorioPorPessoa());
    }

    [HttpGet(nameof(GetRelatorioPorCategoria))]
    public async Task<IActionResult> GetRelatorioPorCategoria()
    {
        return Ok(await _service.GetRelatorioPorCategoria());
    }
}