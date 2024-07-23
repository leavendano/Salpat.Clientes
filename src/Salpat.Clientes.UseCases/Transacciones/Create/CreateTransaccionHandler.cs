using Ardalis.Result;
using Ardalis.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Salpat.Clientes.Core.ClienteAggregate;
using Salpat.Clientes.Core.Interfaces;
using Salpat.Clientes.Core.TransaccionAggregate;

namespace Salpat.Clientes.UseCases.Transacciones.Create;

public class CreateTransaccionHandler(IRepository<Transaccion> _repository, IRepository<Cliente> _repoClientes,IEmailSender emailSender)
  : ICommandHandler<CreateTransaccionCommand, Result<TransaccionDTO>>
{
  public async Task<Result<TransaccionDTO>> Handle(CreateTransaccionCommand request,
    CancellationToken cancellationToken)
  {
    var newTransaccion = new Transaccion(request.HoseDeliveryId,request.ClienteId,request.EstacionId,request.Fecha
      ,request.Importe,request.Volumen,request.ProductoId,request.Puntos);
    try{
      var existingCliente = await _repoClientes.GetByIdAsync(request.ClienteId, cancellationToken);
      if (existingCliente != null)
      {
        var createdItem = await _repository.AddAsync(newTransaccion, cancellationToken);
        existingCliente.AgregarImporte(request.Importe);
        existingCliente.AgregarPuntos(request.Puntos);
        await _repoClientes.UpdateAsync(existingCliente,cancellationToken);
        await emailSender.SendEmailAsync(existingCliente.Email,
                                   "cfdi@infinitummail.com",
                                   "Acumulaste puntos con Salpat!",
                                   $"Hola {existingCliente.Nombre}" + Environment.NewLine +
                                   $"Acumulaste  {request.Puntos} puntos, tu saldo ahora es {existingCliente.PuntosGanados} puntos." +
                                   $"Recuerda que con Salpat siempre ganas!");
        return new TransaccionDTO(createdItem.HoseDeliveryId,createdItem.ClienteId,createdItem.Fecha
          ,createdItem.ProductoId ,createdItem.Importe,createdItem.Volumen,createdItem.Puntos);
      }
     
      return new TransaccionDTO(request.HoseDeliveryId,request.ClienteId , request.Fecha
        ,request.ProductoId, request.Importe,request.Volumen, 0);
    }
    catch(DbUpdateException ex)
    {
      return Result<TransaccionDTO>.Conflict(ex.InnerException?.Message);
    }
    

    
  }
}
