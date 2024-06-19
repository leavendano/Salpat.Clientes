using Salpat.Clientes.UseCases.Contributors;
using Salpat.Clientes.UseCases.Clientes.List;
using Microsoft.EntityFrameworkCore;
using Salpat.Clientes.UseCases.Clientes;

namespace Salpat.Clientes.Infrastructure.Data.Queries;

public class ListClintesQueryService(AppDbContext _db) : IListClientesQueryService
{
  // You can use EF, Dapper, SqlClient, etc. for queries -
  // this is just an example

  public async Task<IEnumerable<ClienteDTO>> ListAsync()
  {
    // NOTE: This will fail if testing with EF InMemory provider!
    var result = await _db.Database.SqlQuery<ClienteDTO>(
      $"SELECT Id, nombre, telefono, email  FROM Clientes") // don't fetch other big columns
      .ToListAsync();

    return result;
  }
}
