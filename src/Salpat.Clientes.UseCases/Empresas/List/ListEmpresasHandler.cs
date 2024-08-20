using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Salpat.Clientes.UseCases.Empresas.List;
public class ListEmpresasHandler(IListEmpresasQueryService _query) : IQueryHandler<ListEmpresasQuery, Result<IEnumerable<EmpresaDTO>>>
{
  public async Task<Result<IEnumerable<EmpresaDTO>>> Handle(ListEmpresasQuery request, CancellationToken cancellationToken)
  {
    var result = await _query.ListAsync();

    return Result.Success(result);

  }
}