using Microsoft.EntityFrameworkCore;
using Salpat.Clientes.UseCases.Transacciones;
using Salpat.Clientes.UseCases.Transacciones.List;

namespace Salpat.Clientes.Infrastructure.Data.Queries;
public class ListTransaccionesQueryService(AppDbContext _db) : IListTransaccionesQueryService
{
  public async Task<IEnumerable<TransaccionDTO>> ListAsync(DateTime FechaInicial, DateTime Fechafinal)
  {
    var result = await _db.Database.SqlQuery<TransaccionDTO>(
      $@"SELECT id,estacion_id, hose_delivery_id, fecha,posicion,producto_id, importe, volumen, cliente_id, puntos 
          FROM transacciones WHERE fecha > '{FechaInicial}' and fecha < '{Fechafinal}' ")
      .ToListAsync();

    return result;
  }
}
