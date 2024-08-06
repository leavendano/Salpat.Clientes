using Microsoft.EntityFrameworkCore;
using Salpat.Clientes.UseCases.Transacciones;
using Salpat.Clientes.UseCases.Transacciones.List;

namespace Salpat.Clientes.Infrastructure.Data.Queries;
public class ListTransaccionesQueryService(AppDbContext _db) : IListTransaccionesQueryService
{
  public async Task<IEnumerable<TransaccionDTO>> ListAsync()
  {
    var result = await _db.Database.SqlQuery<TransaccionDTO>(
      $"SELECT id,estacion_id, hose_delivery_id, fecha,posicion,producto_id, importe, volumen, cliente_id, puntos  FROM transacciones") // don't fetch other big columns
      .ToListAsync();

    return result;
  }
}
