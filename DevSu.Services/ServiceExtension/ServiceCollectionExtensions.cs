using DevSu.Services.Interfaces;
using DevSu.Services.ServiceEntities;
using DevSu.Services.ServiceHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace DevSu.Services.ServiceExtension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ICuentaService, CuentaService>();
            services.AddScoped<IMovimientosService, MovimientoService>();
            services.AddScoped<IReportService, ReportService>();

            services.AddScoped<ICalculoMovimientosService, CalculoMovimientosService>();

            services.AddScoped<IValidacionClienteService, ValidacionClienteService>();

            services.AddScoped<IValidacionCuentaService, ValidacionCuentaService>();

            return services;
        }
    }
}
