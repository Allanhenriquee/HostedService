using HostedService.Domain.Entities;
using HostedService.Domain.Repositories.Interfaces;

namespace HostedService.Infra.Repositories;

public class BoletoRepository : IBoletoRepository
{
    private List<Boleto> _boletos;

    public BoletoRepository()
    {
        _boletos = new List<Boleto>
        {
            new Boleto(1, "12345", 100.0m, new Endereco()),
            new Boleto(2, "12345", 200.0m, new Endereco()),
            new Boleto(3, "12345", 300.0m, new Endereco()),
            new Boleto(4, "12345", 400.0m, new Endereco()),
            new Boleto(5, "12345", 500.0m, new Endereco())
        };
    }

    public List<Boleto> ObterBoletosNaoRegistrados()
    {
        return _boletos.Where(b => !b.Registrado).ToList();
    }

    public void Salvar()
    {
        return;
    }
}