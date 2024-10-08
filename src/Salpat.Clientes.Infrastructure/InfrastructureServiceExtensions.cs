﻿using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Salpat.Clientes.Core.Interfaces;
using Salpat.Clientes.Core.Services;
using Salpat.Clientes.Infrastructure.Data;
using Salpat.Clientes.Infrastructure.Data.Queries;
using Salpat.Clientes.Infrastructure.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Salpat.Clientes.UseCases.Clientes.List;
using Salpat.Clientes.UseCases.Transacciones.List;
using Salpat.Clientes.UseCases.Recompensas.List;
using Salpat.Clientes.UseCases.Estaciones.List;
using Salpat.Clientes.UseCases.Empresas.List;

namespace Salpat.Clientes.Infrastructure;
public static class InfrastructureServiceExtensions
{
  public static IServiceCollection AddInfrastructureServices(
    this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger)
  {
    string? connectionString = config.GetConnectionString("DefaultConnection");
    Guard.Against.Null(connectionString);
    services.AddDbContext<AppDbContext>(options =>
     options.UseNpgsql(connectionString));

    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
    services.AddScoped<IListClientesQueryService, ListClintesQueryService>();
    services.AddScoped<IListTransaccionesQueryService, ListTransaccionesQueryService>();
    services.AddScoped<IListRecompensasQueryService, ListRecompensasQueryService>();
    services.AddScoped<IListEstacionesQueryService, ListEstacionesQueryService>();
    services.AddScoped<IListEmpresasQueryService, ListEmpresasQueryService>();
    services.AddScoped<IClienteService, ClienteService>();

    services.Configure<MailserverConfiguration>(config.GetSection("Mailserver"));

    logger.LogInformation("{Project} services registered", "Infrastructure");

    return services;
  }
}
