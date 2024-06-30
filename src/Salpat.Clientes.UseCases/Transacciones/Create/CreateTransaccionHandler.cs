using Ardalis.Result;
using Ardalis.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Salpat.Clientes.Core.ClienteAggregate;
using Salpat.Clientes.Core.TransaccionAggregate;

namespace Salpat.Clientes.UseCases.Transacciones.Create;

public class CreateTransaccionHandler(IRepository<Transaccion> _repository, IRepository<Cliente> _repoClientes)
  : ICommandHandler<CreateTransaccionCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateTransaccionCommand request,
    CancellationToken cancellationToken)
  {
    var newTransaccion = new Transaccion(request.HoseDeliveryId,request.ClienteId,request.EstacionId,request.Fecha,request.Importe,(int)request.Importe);
    try{
      var existingCliente = await _repoClientes.GetByIdAsync(request.ClienteId, cancellationToken);
      if (existingCliente != null)
      {
        var createdItem = await _repository.AddAsync(newTransaccion, cancellationToken);
        existingCliente.AgregarImporte(request.Importe);
        existingCliente.AgregarPuntos((int)request.Importe);
        await _repoClientes.UpdateAsync(existingCliente,cancellationToken);
        return createdItem.Id;
      }
     
      return 0;
    }
    catch(DbUpdateException ex)
    {
      return Result<int>.Conflict(ex.InnerException?.Message);
    }
    

    
  }
}
