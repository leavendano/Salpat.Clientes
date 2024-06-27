using Ardalis.Result;
using Ardalis.SharedKernel;
using Salpat.Clientes.Core.ClienteAggregate;
using Salpat.Clientes.Core.ClienteAggregate.Specifications;

namespace Salpat.Clientes.UseCases.Clientes.Get;

/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetClienteByEmailHandler(IReadRepository<Cliente> _repository)
  : IQueryHandler<GetClienteByEmailQuery, Result<ClienteDTO>>
{
  public async Task<Result<ClienteDTO>> Handle(GetClienteByEmailQuery request, CancellationToken cancellationToken)
  {
    var spec = new ClienteByEmailSpec(request.Email);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new ClienteDTO(entity.Id, entity.Nombre, entity.Telefono, entity.Email, entity.SaldoPuntos);
  }
}
