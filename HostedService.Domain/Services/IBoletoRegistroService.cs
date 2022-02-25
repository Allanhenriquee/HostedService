using HostedService.Domain.Entities;

namespace HostedService.Domain.Services;

public interface IBoletoRegistroService
{
    bool Registrar(Boleto boleto);
}