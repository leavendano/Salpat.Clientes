using Microsoft.EntityFrameworkCore;
using Salpat.Clientes.UseCases.Estaciones;
using Salpat.Clientes.UseCases.Estaciones.List;
using Salpat.Clientes.UseCases.Recompensas;

namespace Salpat.Clientes.Infrastructure.Data.Queries;
public class ListEstacionesQueryService(AppDbContext _db) : IListEstacionesQueryService
{
  public async Task<IEnumerable<EstacionDTO>> ListAsync()
  {
    var result = await _db.Database.SqlQuery<EstacionDTO>(
       $"SELECT id, nombre, factor_puntos FROM estaciones") // don't fetch other big columns
       .ToListAsync();

    return result;
  }
}
