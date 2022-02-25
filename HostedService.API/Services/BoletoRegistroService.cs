using HostedService.Domain.Entities;
using HostedService.Domain.Services;

namespace HostedService.API.Services;

public class BoletoRegistroService : IBoletoRegistroService
{
    public bool Registrar(Boleto boleto)
    {
        return true;
    }
}