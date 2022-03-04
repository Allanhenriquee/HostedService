using HostedService.Domain.Entities;
using HostedService.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HostedService.API.Controllers;

[ApiController]
[Route("v1/boletos")]
public class BoletoController : ControllerBase
{
    private readonly IBoletoRepository _boletoRepository;

    public BoletoController(IBoletoRepository boletoRepository)
    {
        _boletoRepository = boletoRepository;
    }

    [HttpGet]
    [Route("todos")]
    public IEnumerable<Boleto> PegarTodosBoletosEmMemoria()
    {
        var boletos = _boletoRepository.PegarTodosBoletosEmMemoria();

        return boletos;
    }
    [HttpGet]
    [Route("registrados")]
    public IEnumerable<Boleto> PegarTodosBoletosRegistradosEmMemoria()
    {
        var boletos = _boletoRepository.PegarTodosBoletosRegistradosEmMemoria();

        return boletos;
    }
    [HttpGet]
    [Route("nao-registrados")]
    public IEnumerable<Boleto> PegarTodosBoletosNaoRegistradosEmMemoria()
    {
        var boletos = _boletoRepository.PegarTodosBoletosNaoRegistradosEmMemoria();

        return boletos;
    }

    [HttpPost]
    public Boleto Cadastrar(string nome)
    {
        Random numRandom = new Random();

        var boleto = new Boleto(numRandom.Next(),numRandom.Next().ToString(), nome,100.0m,
                        new Endereco("Milto Gavetti", "Londrina", "PR", "Rua 17", "987", "89165236"));
        
        _boletoRepository.Cadastrar(boleto);

        return boleto;
    }
}