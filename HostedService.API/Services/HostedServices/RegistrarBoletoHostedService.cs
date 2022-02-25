using HostedService.Domain.Repositories.Interfaces;
using HostedService.Domain.Services;

namespace HostedService.API.Services.HostedServices;

public class RegistrarBoletoHostedService : IHostedService, IDisposable
{
    private Timer _timer;
    private readonly IServiceProvider ServiceProvider;
    private readonly ILogger<RegistrarBoletoHostedService> _logger;

    public RegistrarBoletoHostedService(IServiceProvider serviceProvider, ILogger<RegistrarBoletoHostedService> logger)
    {
        ServiceProvider = serviceProvider;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Serviço de registro iniciado");
        
        _timer = new Timer(Registrar, null, 0, 100000);

        return Task.CompletedTask;
    }

    private void Registrar(object state)
    {
        using (var scope = ServiceProvider.CreateScope())
        {
            var boletoRepository = scope.ServiceProvider.GetRequiredService<IBoletoRepository>();
            var boletoRegistroService = scope.ServiceProvider.GetRequiredService<IBoletoRegistroService>();

            var boletos = boletoRepository.ObterBoletosNaoRegistrados();

            foreach (var boleto in boletos)
            {
                _logger.LogInformation($"Iniciando registro do boleto: {boleto.NumeroBoleto}");
                boletoRegistroService.Registrar(boleto);

                boleto.MarcarComoRegistrado();

                boletoRepository.Salvar();
                _logger.LogInformation($"Finalizando registro do boleto: {boleto.NumeroBoleto}");
            }
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Serviço de registro de boleto finalizado");
        
        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}