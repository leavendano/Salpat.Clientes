using Ardalis.Result;
using Ardalis.SharedKernel;
using Salpat.Clientes.Core.EstacionAggregate;
using Salpat.Clientes.Core.EstacionAggregate.Specifications;


namespace Salpat.Clientes.UseCases.Estaciones.Get;
public class GetEstacionHandler(IReadRepository<Estacion> _repository) : IQueryHandler<GetEstacionQuery, Result<EstacionDTO>>
{
  public async Task<Result<EstacionDTO>> Handle(GetEstacionQuery request, CancellationToken cancellationToken)
  {
    var spec = new EstacionByIdSpec(request.Id);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new EstacionDTO(entity.Id, entity.Nombre, entity.FactorPuntos);
  }
}
