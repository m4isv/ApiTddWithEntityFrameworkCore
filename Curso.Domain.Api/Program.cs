using Microsoft.OpenApi.Models;
using Curso.Domain.Infra.Extensions;
using Curso.Domain.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext com InMemory
builder.Services.AddDbContext<CursoDbContext>(options =>
    options.UseInMemoryDatabase("CursoInMemoryDb"));



// Adiciona serviços do domínio
builder.Services.AddInfrastructure();

// Adiciona serviços de controllers
builder.Services.AddControllers();

// Configuração do Swagger com mais detalhes
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Curso API",
        Version = "v1",
        Description = "API para gerenciamento de cursos",
        Contact = new OpenApiContact
        {
            Name = "Suporte",
            Email = "suporte@curso.com"
        }
    });
});

var app = builder.Build();

// Middleware do Swagger (sempre habilitado)
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Curso API v1");
    options.RoutePrefix = string.Empty; // Faz o Swagger ser a página inicial
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
