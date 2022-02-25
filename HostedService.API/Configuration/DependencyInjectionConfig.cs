using HostedService.API.Services;
using HostedService.API.Services.HostedServices;
using HostedService.Domain.Repositories.Interfaces;
using HostedService.Domain.Services;
using HostedService.Infra.Repositories;

namespace HostedService.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection RegistrarInjecaoDependencia(this IServiceCollection services)
    {
        services.AddHostedService<RegistrarBoletoHostedService>();

        services.AddScoped<IBoletoRepository, BoletoRepository>();

        services.AddScoped<IBoletoRegistroService, BoletoRegistroService>();

        return services;
    }
}