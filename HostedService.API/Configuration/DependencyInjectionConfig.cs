using HostedService.API.Services.HostedServices;
using HostedService.Domain.Repositories.Interfaces;
using HostedService.Infra.Repositories;

namespace HostedService.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection RegistrarInjecaoDependencia(this IServiceCollection services)
    {
        //BOLETO
        services.AddHostedService<RegistrarBoletoHostedService>();
        services.AddScoped<IBoletoRepository, BoletoRepository>();

        return services;
    }
}