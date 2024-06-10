using Salpat.Clientes.UseCases.Contributors;
using Salpat.Clientes.UseCases.Contributors.List;
using Microsoft.EntityFrameworkCore;

namespace Salpat.Clientes.Infrastructure.Data.Queries;

public class ListContributorsQueryService(AppDbContext _db) : IListContributorsQueryService
{
  // You can use EF, Dapper, SqlClient, etc. for queries -
  // this is just an example

  public async Task<IEnumerable<ContributorDTO>> ListAsync()
  {
    // NOTE: This will fail if testing with EF InMemory provider!
    var result = await _db.Database.SqlQuery<ContributorDTO>(
      $"SELECT Id, name, phone_number_number AS phone_number FROM Contributors") // don't fetch other big columns
      .ToListAsync();

    return result;
  }
}
