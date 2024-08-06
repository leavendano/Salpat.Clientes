using Ardalis.Result;
using Ardalis.SharedKernel;
using Salpat.Clientes.Core.RecompensaAgreggate;
using Salpat.Clientes.UseCases.Clientes;
using Salpat.Clientes.Core.RecompensaAgreggate.Specifications;

namespace Salpat.Clientes.UseCases.Recompensas.Get;
public class GetRecompensaByIdHandler(IReadRepository<Recompensa> _repository) : IQueryHandler<GetRecompensaByIdQuery, Result<RecompensaDTO>>
{
  public async Task<Result<RecompensaDTO>> Handle(GetRecompensaByIdQuery request, CancellationToken cancellationToken)
  {
    var spec = new RecompensaByIdSpec(request.Id);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new RecompensaDTO(entity.Id, entity.Descripcion, entity.PuntosRequeridos);
  }
}
