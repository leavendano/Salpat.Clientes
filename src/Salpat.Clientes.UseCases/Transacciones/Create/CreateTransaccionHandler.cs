using System.IO;
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
      ,request.Importe,request.Volumen,request.ProductoId,request.Puntos,request.Posicion);
    try{
      var existingCliente = await _repoClientes.GetByIdAsync(request.ClienteId, cancellationToken);
      if (existingCliente != null)
      {
        var createdItem = await _repository.AddAsync(newTransaccion, cancellationToken);
        existingCliente.AgregarImporte(request.Importe);
        existingCliente.AgregarPuntos(request.Puntos);
        string rootpath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot");
        string htmlmessage = File.ReadAllText(rootpath + "/email_ticket.html");
        switch(request.ProductoId)
        {
          case 1:
            htmlmessage =htmlmessage.Replace("{{producto_venta}}", "Magna");
            break;
          case 2:
            htmlmessage =htmlmessage.Replace("{{producto_venta}}", "Premium");
            break;
          default:
            htmlmessage=htmlmessage.Replace("{{producto_venta}}", "Diesel");
            break;
        }
        htmlmessage = htmlmessage.Replace("{{nombre_cliente}}",existingCliente.Nombre);
        htmlmessage = htmlmessage.Replace("{{nombre_estacion}}", "Periferico");
        htmlmessage = htmlmessage.Replace("{{posicion_venta}}",request.Posicion.ToString());
        htmlmessage = htmlmessage.Replace("{{fecha_venta}}",request.Fecha.ToString());
        htmlmessage = htmlmessage.Replace("{{folio_venta}}",request.HoseDeliveryId.ToString());
        htmlmessage = htmlmessage.Replace("{{puntos_venta}}",request.Puntos.ToString());
        htmlmessage = htmlmessage.Replace("{{cantidad_venta}}",request.Volumen.ToString());
        htmlmessage = htmlmessage.Replace("{{saldo_puntos}}", existingCliente.SaldoPuntos.ToString());
        htmlmessage = htmlmessage.Replace("{{importe_venta}}", request.Importe.ToString());

        await _repoClientes.UpdateAsync(existingCliente,cancellationToken);
        await emailSender.SendEmailAsync(existingCliente.Email,
                                   "cfdi@infinitummail.com",
                                   "Acumulaste puntos con Salpat!",
                                   "",
                                   htmlmessage);
        return new TransaccionDTO(createdItem.HoseDeliveryId,createdItem.ClienteId,createdItem.EstacionId,createdItem.Posicion,createdItem.Fecha
          ,createdItem.ProductoId ,createdItem.Importe,createdItem.Volumen,createdItem.Puntos);
      }
     
      return new TransaccionDTO(request.HoseDeliveryId,request.ClienteId,request.EstacionId,request.Posicion, request.Fecha
        ,request.ProductoId, request.Importe,request.Volumen, 0);
    }
    catch(DbUpdateException)
    {
      return Result<TransaccionDTO>.Conflict("La venta  ya fue registrada anteriormente");
    }
    catch(Exception ex)
    {
      return Result<TransaccionDTO>.CriticalError(ex.InnerException?.Message);
    }
    

    
  }
}
