using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Salpat.Clientes.UseCases.Clientes.List;
using Salpat.Clientes.UseCases.Clientes;

namespace Salpat.Clientes.UseCases.Transacciones.List;
public class ListTransaccionesHandler(IListTransaccionesQueryService _query) : IQueryHandler<ListTransaccionesQuery, Result<IEnumerable<TransaccionDTO>>>
{
  public async Task<Result<IEnumerable<TransaccionDTO>>> Handle(ListTransaccionesQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    return Result.Success(result);
  }
}
