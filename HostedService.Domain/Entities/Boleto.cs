namespace HostedService.Domain.Entities;

public class Boleto
{
    public Boleto(int numeroBoleto, string codigoBarras, decimal valor, Endereco endereco)
    {
        NumeroBoleto = numeroBoleto;
        CodigoBarras = codigoBarras;
        Valor = valor;
        Endereco = endereco;
        DataValidade = DateTime.Now.AddDays(5);
        DataCriacao = DateTime.Now;
        Registrado = false;
    }

    public int NumeroBoleto { get; private set; }
    public string CodigoBarras { get; private set; }
    public decimal Valor { get; private set; }
    public Endereco Endereco { get; private set; }
    public DateTime DataValidade { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public bool Registrado { get; private set; }

    public void MarcarComoRegistrado()
    {
        Registrado = true; 
    }
}