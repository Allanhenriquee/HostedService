using HostedService.Domain.Entities;

namespace HostedService.Domain.Repositories.Interfaces;

public interface IBoletoRepository
{
    IEnumerable<Boleto> PegarTodosBoletosEmMemoria();
    IEnumerable<Boleto> PegarTodosBoletosRegistradosEmMemoria();
    IEnumerable<Boleto> PegarTodosBoletosNaoRegistradosEmMemoria();
    void Registrar(Boleto boleto);
    void Cadastrar(Boleto boleto);
}