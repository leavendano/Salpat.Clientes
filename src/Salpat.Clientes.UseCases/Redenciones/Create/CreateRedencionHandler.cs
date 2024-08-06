using Ardalis.Result;
using Ardalis.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Salpat.Clientes.Core.ClienteAggregate;
using Salpat.Clientes.Core.Interfaces;
using Salpat.Clientes.Core.RedencionAggregate;


namespace Salpat.Clientes.UseCases.Redenciones.Create;
public class CreateRedencionHandler(IRepository<Redencion> _repository, IRepository<Cliente> _repoClientes, IEmailSender emailSender) : 
    ICommandHandler<CreateRedencionCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateRedencionCommand request, CancellationToken cancellationToken)
  {
    var newItem = new Redencion(request.ClienteId, request.Fecha,request.RecompensaId,request.PuntosRedimidos);
    try
    {
      var existingCliente = await _repoClientes.GetByIdAsync(request.ClienteId, cancellationToken);
      if (existingCliente != null)
      {

        if(existingCliente.SaldoPuntos < request.PuntosRedimidos)
        {
          return Result<int>.Conflict("El cliente no cuenta con los puntos requeridos");
        }
        var createdItem = await _repository.AddAsync(newItem, cancellationToken);
        existingCliente.RedimirPuntos(request.PuntosRedimidos);
        await _repoClientes.UpdateAsync(existingCliente, cancellationToken);
        await emailSender.SendEmailAsync(existingCliente.Email,
                                   "cfdi@infinitummail.com",
                                   "Canjeaste puntos en Salpat!",
                                   $"Hola {existingCliente.Nombre}" + Environment.NewLine +
                                   $"Redimiste  {request.PuntosRedimidos} puntos, tu saldo ahora es {existingCliente.SaldoPuntos} puntos." +
                                   $"Recuerda que con Salpat siempre ganas!");
        return createdItem.Id;
      }
      else
      {
        return Result<int>.NotFound("No se encontró el cliente seleccionado");
      }
     
     
    }
    catch (DbUpdateException ex)
    {
      return Result<int>.Conflict(ex.InnerException?.Message);
    }


  }
}
