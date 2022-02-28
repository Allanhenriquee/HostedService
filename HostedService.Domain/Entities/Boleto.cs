using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HostedService.Domain.Entities;

public class Boleto
{
    protected Boleto(){}
    public Boleto(int numeroBoleto, string codigoBarras, string nome, decimal valor, Endereco endereco)
    {
        NumeroBoleto = numeroBoleto;
        CodigoBarras = codigoBarras;
        Nome = nome;
        Valor = valor;
        Endereco = endereco;
        DataValidade = DateTime.Now.AddDays(5);
        DataCriacao = DateTime.Now;
        Registrado = false;
    }

    [Key]
    public int NumeroBoleto { get; private set; }
    public string CodigoBarras { get; private set; }
    public string Nome { get; set; }
    public decimal Valor { get; private set; }
    [NotMapped]
    public Endereco Endereco { get; private set; }
    public DateTime DataValidade { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public bool Registrado { get; private set; }

    public void MarcarComoRegistrado()
    {
        Registrado = true; 
    }
}