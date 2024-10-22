using Ardalis.Result;
using Ardalis.SharedKernel;


namespace Salpat.Clientes.UseCases.Transacciones.List;
public class ListTransaccionesConsultaHandler(IListTransaccionesQueryService _query) : 
             IQueryHandler<ListTransaccionesConsultaQuery, Result<IEnumerable<TransaccionConsultaDTO>>>
{
  public async Task<Result<IEnumerable<TransaccionConsultaDTO>>> Handle(ListTransaccionesConsultaQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListConsultaAsync(request.EstacionId,request.FechaInicial,request.FechaFinal);

    return Result.Success(result);
  }
}
