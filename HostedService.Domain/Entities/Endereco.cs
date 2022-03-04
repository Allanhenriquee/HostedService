using System.ComponentModel.DataAnnotations.Schema;
using HostedService.Domain.Entities.Base;

namespace HostedService.Domain.Entities;

public class Endereco : Entity
{
    protected Endereco(){}
    public Endereco(string bairro, string cidade, string estado, string logradouro, string numero, string cep)
    {
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
        Logradouro = logradouro;
        Numero = numero;
        Cep = cep;
    }

    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Cep { get; set; }
    public Guid BoletoId { get; set; }
    public Boleto Boleto { get; set; }
}