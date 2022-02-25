using HostedService.Domain.Entities;

namespace HostedService.Domain.Repositories.Interfaces;

public interface IBoletoRepository
{
    List<Boleto> ObterBoletosNaoRegistrados();
    void Salvar();
}