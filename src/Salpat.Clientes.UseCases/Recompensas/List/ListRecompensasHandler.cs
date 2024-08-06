using Ardalis.Result;
using Ardalis.SharedKernel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Salpat.Clientes.UseCases.Recompensas.List;
public class ListRecompensasHandler(IListRecompensasQueryService _query) : IQueryHandler<ListRecompensasQuery, Result<IEnumerable<RecompensaDTO>>>
{
  public async Task<Result<IEnumerable<RecompensaDTO>>> Handle(ListRecompensasQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    return Result.Success(result);

  }
}
