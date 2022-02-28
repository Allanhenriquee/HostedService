using System.Reflection;
using HostedService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HostedService.Infra.Context;

public class HostedServiceDbContext : DbContext
{
    public HostedServiceDbContext(){}
    public HostedServiceDbContext(DbContextOptions<HostedServiceDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Boleto> Boletos { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Endereco>().HasNoKey();

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
    }
}