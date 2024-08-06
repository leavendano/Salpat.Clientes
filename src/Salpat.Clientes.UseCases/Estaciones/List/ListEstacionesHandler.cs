using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Salpat.Clientes.UseCases.Estaciones.List;
public class ListEstacionesHandler(IListEstacionesQueryService _query) : IQueryHandler<ListEstacionesQuery, Result<IEnumerable<EstacionDTO>>>
{
  public async Task<Result<IEnumerable<EstacionDTO>>> Handle(ListEstacionesQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    return Result.Success(result);
  }
}
