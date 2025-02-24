using Curso.Domain.Infra.Services;
using Microsoft.Extensions.DependencyInjection;


namespace Curso.Domain.Infra.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Injeção de Dependência
            services.AddScoped<ICursoService, CursoService>();
            return services;
        }

    }
}