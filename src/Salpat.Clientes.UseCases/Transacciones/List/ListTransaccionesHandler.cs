using Ardalis.Result;
using Ardalis.SharedKernel;


namespace Salpat.Clientes.UseCases.Transacciones.List;
public class ListTransaccionesHandler(IListTransaccionesQueryService _query) : IQueryHandler<ListTransaccionesQuery, Result<IEnumerable<TransaccionDTO>>>
{
  public async Task<Result<IEnumerable<TransaccionDTO>>> Handle(ListTransaccionesQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync(request.EstacionId,request.FechaInicial,request.FechaFinal,request.ClienteId);

    return Result.Success(result);
  }
}
