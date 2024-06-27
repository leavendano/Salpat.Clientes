using Ardalis.Result;
using Ardalis.SharedKernel;
using Salpat.Clientes.Core.ClienteAggregate;
using Salpat.Clientes.Core.ClienteAggregate.Specifications;

namespace Salpat.Clientes.UseCases.Clientes.Get;

/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetClienteHandler(IReadRepository<Cliente> _repository)
  : IQueryHandler<GetClienteQuery, Result<ClienteDTO>>
{
  public async Task<Result<ClienteDTO>> Handle(GetClienteQuery request, CancellationToken cancellationToken)
  {
    var spec = new ClienteByIdSpec(request.ClienteId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new ClienteDTO(entity.Id, entity.Nombre, entity.Telefono, entity.Email, entity.SaldoPuntos);
  }
}
