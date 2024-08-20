using Ardalis.Result;
using Ardalis.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Salpat.Clientes.Core.RecompensaAgreggate;

namespace Salpat.Clientes.UseCases.Recompensas.Create;
public class CreateRecompensaHandler(IRepository<Recompensa> _repository) : ICommandHandler<CreateRecompensaCommand, Result<int>>
{

public async Task<Result<int>> Handle(CreateRecompensaCommand request, CancellationToken cancellationToken)
  {
    var newRecompensa = new Recompensa(request.Descripcion, request.PuntosRequeridos);
    try
    {
      var createdItem = await _repository.AddAsync(newRecompensa, cancellationToken);
      return createdItem.Id;
    }
    catch (DbUpdateException ex)
    {
      return Result<int>.Conflict(ex.InnerException?.Message);
    }
  }
}
