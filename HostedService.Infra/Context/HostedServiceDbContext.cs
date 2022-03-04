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
        //modelBuilder.Entity<Endereco>().HasNoKey();

        //modelBuilder.Entity<Boleto>()
        //    .HasOne(b => b.Endereco)
        //    .WithOne(e => e.Boleto).HasForeignKey<Endereco>(b => b.numeroBoleto);


        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HostedServiceDbContext).Assembly);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
        
        base.OnModelCreating(modelBuilder);

    }
}