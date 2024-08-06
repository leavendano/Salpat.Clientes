using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Salpat.Clientes.UseCases.Clientes;
using Salpat.Clientes.UseCases.Recompensas;
using Salpat.Clientes.UseCases.Recompensas.List;

namespace Salpat.Clientes.Infrastructure.Data.Queries;
public class ListRecompensasQueryService(AppDbContext _db) : IListRecompensasQueryService
{
  public async Task<IEnumerable<RecompensaDTO>> ListAsync()
  {
    var result = await _db.Database.SqlQuery<RecompensaDTO>(
       $"SELECT id, descripcion, puntos_requeridos  FROM recompensas") // don't fetch other big columns
       .ToListAsync();

    return result;
  }
}
