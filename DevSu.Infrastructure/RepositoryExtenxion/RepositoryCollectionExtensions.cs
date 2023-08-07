using DevSu.Core.Interfaces;
using DevSu.Core.Models;
using DevSu.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DevSu.Infrastructure.RepositoryExtenxion
{
    public static class RepositoryCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICuentaRepository, CuentaRepository>();

            services.AddScoped<IMovimientosRepository, MovimientosRepository>();

            services.AddScoped<IValidacionCuentaRepository, ValidacionCuentaRepository>();

            services.AddScoped<IValidacionClienteRepository, ValidacionClienteRepository>();


            return services;
        }
    }
}
