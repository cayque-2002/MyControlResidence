using Microsoft.EntityFrameworkCore;
using MyControlResidence.Api.Domain.Interfaces;
using MyControlResidence.Api.Infrastructure.Context;
using MyControlResidence.Api.Infrastructure.Repositorios;
using MyControlResidence.Api.Middleware;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=mycontrolresidence.db"));

// Registrando os serviços de aplicação
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<PessoaService>();
builder.Services.AddScoped<TransacaoService>();
builder.Services.AddScoped<RelatorioService>();

//registrando os repositórios
builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

//bloqueio CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        p => p.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorMiddleware>();

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();