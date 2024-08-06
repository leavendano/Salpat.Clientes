using System;
using System.Collections.Generic;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Salpat.Clientes.Core.RecompensaAgreggate;


namespace Salpat.Clientes.UseCases.Recompensas.Update;
public class UpdateRecompensaHandler(IRepository<Recompensa> _repository) : ICommandHandler<UpdateRecompensaCommand, Result<RecompensaDTO>>
{
  public async Task<Result<RecompensaDTO>> Handle(UpdateRecompensaCommand request, CancellationToken cancellationToken)
  {
    var item = await _repository.GetByIdAsync(request.Id, cancellationToken);
    if (item == null)
    {
      return Result.NotFound();
    }

    item.UpdateDescripcion (request.Descripcion!);

    item.UpdatePuntos(request.PuntosRequeridos);

    

    await _repository.UpdateAsync(item, cancellationToken);

    return Result.Success(new RecompensaDTO(item.Id, item.Descripcion, item.PuntosRequeridos));
  }
}
