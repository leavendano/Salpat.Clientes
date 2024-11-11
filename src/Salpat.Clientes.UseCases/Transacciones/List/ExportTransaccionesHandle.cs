using Ardalis.Result;
using Ardalis.SharedKernel;
using Salpat.Clientes.Core.Base;


namespace Salpat.Clientes.UseCases.Transacciones.List;
public class ExportTransaccionesHandle(IListTransaccionesQueryService _query) : IQueryHandler<ExportTransaccionesQuery, Result<ExportResponseDTO>>
{
  public async Task<Result<ExportResponseDTO>> Handle(ExportTransaccionesQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ExportAsync(request.Tipo,request.EstacionId,request.FechaInicial,request.FechaFinal);

    return result;
  }
}
