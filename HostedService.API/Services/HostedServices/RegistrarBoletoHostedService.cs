using HostedService.Domain.Repositories.Interfaces;

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
        //CONSOLE COM COR
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Serviço de registro de boleto iniciado");
        Console.ForegroundColor = ConsoleColor.White;

        //LOGGER
        _logger.LogInformation("Serviço de registro iniciado");

        _timer = new Timer(Registrar, null, 0, 100000);

        return Task.CompletedTask;
    }

    private void Registrar(object state)
    {
        using (var scope = ServiceProvider.CreateScope())
        {
            var boletoRepository = scope.ServiceProvider.GetRequiredService<IBoletoRepository>();

            //MEMORY
            var boletosInMemory = boletoRepository.PegarTodosBoletosNaoRegistradosEmMemoria();

            if (boletosInMemory != null)
            {
                foreach (var boleto in boletosInMemory)
                {
                    //CONSOLE COM COR
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Iniciando registro do boleto : {boleto.NumeroBoleto} em nome de {boleto.Nome}");
                    Console.ForegroundColor = ConsoleColor.White;

                    //LOGGER
                    _logger.LogInformation($"Iniciando registro do boleto : {boleto.NumeroBoleto} em nome de {boleto.Nome}" );

                    boleto.MarcarComoRegistrado();

                    boletoRepository.Registrar(boleto);

                    //CONSOLE COM COR
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Finalizando registro do boleto: {boleto.NumeroBoleto} em nome de {boleto.Nome}");
                    Console.ForegroundColor = ConsoleColor.White;

                    //LOGGER
                    _logger.LogInformation($"Finalizando registro do boleto: {boleto.NumeroBoleto} em nome de {boleto.Nome}");
                }
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