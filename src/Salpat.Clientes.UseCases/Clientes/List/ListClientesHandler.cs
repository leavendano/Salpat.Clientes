using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Salpat.Clientes.UseCases.Clientes.List;

public class ListClientesHandler(IListClientesQueryService _query)
  : IQueryHandler<ListClientesQuery, Result<IEnumerable<ClienteDTO>>>
{
  public async Task<Result<IEnumerable<ClienteDTO>>> Handle(ListClientesQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    return Result.Success(result);
  }
}
