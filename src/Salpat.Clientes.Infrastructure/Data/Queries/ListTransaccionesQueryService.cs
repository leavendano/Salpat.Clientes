using Microsoft.EntityFrameworkCore;
using Salpat.Clientes.UseCases.Transacciones;
using Salpat.Clientes.UseCases.Transacciones.List;

namespace Salpat.Clientes.Infrastructure.Data.Queries;
public class ListTransaccionesQueryService(AppDbContext _db) : IListTransaccionesQueryService
{
  public async Task<IEnumerable<TransaccionDTO>> ListAsync()
  {
    var result = await _db.Database.SqlQuery<TransaccionDTO>(
      $"SELECT Id, nombre, telefono, email, (puntos_ganados - puntos_redimidos) as saldo_puntos  FROM Transacciones") // don't fetch other big columns
      .ToListAsync();

    return result;
  }
}
