using Microsoft.EntityFrameworkCore;

using Salpat.Clientes.UseCases.Empresas;
using Salpat.Clientes.UseCases.Empresas.List;


namespace Salpat.Clientes.Infrastructure.Data.Queries;
public class ListEmpresasQueryService(AppDbContext _db) : IListEmpresasQueryService
{
  public async Task<IEnumerable<EmpresaDTO>> ListAsync()
  {
    var result = await _db.Database.SqlQuery<EmpresaDTO>(
       $"SELECT id, nombre FROM empresas") // don't fetch other big columns
       .ToListAsync();

    return result;
  }
}
