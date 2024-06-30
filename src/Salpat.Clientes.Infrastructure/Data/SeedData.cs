using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Salpat.Clientes.Core.EstacionAggregate;

namespace Salpat.Clientes.Infrastructure.Data;

public static class SeedData
{
  public static readonly Estacion Estacion1 = new("Periferico");
  public static readonly Estacion Estacion2 = new("Zaragoza");
  public static readonly Estacion Estacion3 = new("Murayama");
  public static readonly Estacion Estacion4 = new("Oriente");

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      if (dbContext.Estaciones.Any()) return;   // DB has been seeded

      PopulateTestData(dbContext);
    }
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {
    foreach (var estacion in dbContext.Estaciones)
    {
      dbContext.Remove(estacion);
    }
    dbContext.SaveChanges();

    dbContext.Estaciones.Add(Estacion1);
    dbContext.Estaciones.Add(Estacion2);
    dbContext.Estaciones.Add(Estacion3);
    dbContext.Estaciones.Add(Estacion4);

    dbContext.SaveChanges();
  }
}
