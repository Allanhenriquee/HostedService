using HostedService.Domain.Entities;
using HostedService.Domain.Repositories.Interfaces;
using HostedService.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace HostedService.Infra.Repositories;

public class BoletoRepository : IBoletoRepository
{
    private readonly HostedServiceDbContext _context;

    public BoletoRepository(HostedServiceDbContext context)
    {
        _context = context;
    }
    public IEnumerable<Boleto> PegarTodosBoletosEmMemoria()
    {
        return _context.Boletos
            .AsNoTracking()
            .Include(e => e.Endereco)
            .ToList();
    }

    public IEnumerable<Boleto> PegarTodosBoletosRegistradosEmMemoria()
    {
        return _context.Boletos
            .Include(e => e.Endereco)
            .Where(b => b.Registrado)
            .OrderBy(b => b.DataCriacao);
    }

    public IEnumerable<Boleto> PegarTodosBoletosNaoRegistradosEmMemoria()
    {
        return _context.Boletos
            .Include(e => e.Endereco)
            .Where(b => !b.Registrado)
            .OrderBy(b => b.DataCriacao);
    }

    public void Registrar(Boleto boleto)
    {
        _context.Entry(boleto).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Cadastrar(Boleto boleto)
    {
        _context.Boletos.Add(boleto);
        _context.SaveChanges();
    }
}