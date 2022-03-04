using HostedService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostedService.Infra.Mappings
{
    public class BoletoMapping : IEntityTypeConfiguration<Boleto>
    {
        public void Configure(EntityTypeBuilder<Boleto> builder)
        {
            builder.HasKey(b => b.Id);

            builder
                .HasOne(b => b.Endereco)
                .WithOne(e => e.Boleto)
                .HasForeignKey<Endereco>(e => e.BoletoId);
        }
    }
}
