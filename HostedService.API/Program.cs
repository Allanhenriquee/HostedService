using HostedService.API.Configuration;
using HostedService.Domain.Entities;
using HostedService.Infra.Context;
using HostedService.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<HostedServiceDbContext>(options => 
    options.UseInMemoryDatabase("Database"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegistrarInjecaoDependencia();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetService<HostedServiceDbContext>();
IncluirDadosDeTeste(context);

app.Run();


//DADOS DE TESTE CARREGADOS IN MEMORY
void IncluirDadosDeTeste(HostedServiceDbContext context)
{
    List<Boleto> boleto = new List<Boleto>();

    context.Boletos.AddRange(
        new Boleto(1, "48723", "Allan", 150.00M, new Endereco()),
                     new Boleto(2, "549879", "Teste", 250.00M, new Endereco()),
                     new Boleto(3, "798132", "Teste Boleto", 350.00M, new Endereco())
    );

    context.SaveChanges();
}