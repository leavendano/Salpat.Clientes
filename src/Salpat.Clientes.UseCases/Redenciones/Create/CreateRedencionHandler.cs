using Ardalis.Result;
using Ardalis.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Salpat.Clientes.Core.ClienteAggregate;
using Salpat.Clientes.Core.Interfaces;
using Salpat.Clientes.Core.RecompensaAgreggate;
using Salpat.Clientes.Core.RedencionAggregate;


namespace Salpat.Clientes.UseCases.Redenciones.Create;
public class CreateRedencionHandler(IRepository<Redencion> _repository, IRepository<Cliente> _repoClientes,
  IRepository<Recompensa> _repoRecompensa, IEmailSender emailSender) : 
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

        var recompensa = await _repoRecompensa.GetByIdAsync(request.RecompensaId);
        string nombreRecompensa = recompensa?.Descripcion ?? "";
        string rootpath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot");
        string htmlmessage = File.ReadAllText(rootpath + "/email_redencion.html");

        var createdItem = await _repository.AddAsync(newItem, cancellationToken);
        existingCliente.RedimirPuntos(request.PuntosRedimidos);
        await _repoClientes.UpdateAsync(existingCliente, cancellationToken);

        var mensaje = $"Canjeaste {request.PuntosRedimidos} puntos por {nombreRecompensa}";
        htmlmessage = htmlmessage.Replace("{{nombre_cliente}}",existingCliente.Nombre);
        htmlmessage = htmlmessage.Replace("{{saldo_puntos}}", existingCliente.SaldoPuntos.ToString());
        htmlmessage = htmlmessage.Replace("{{mensaje}}", mensaje);


        await emailSender.SendEmailAsync(existingCliente.Email,
                                   "lealtad.salpat@gmail.com",
                                   "Canjeaste puntos en Salpat!",
                                   $"Hola {existingCliente.Nombre}" + Environment.NewLine +
                                   $"Consumiste  {request.PuntosRedimidos} puntos, tu saldo ahora es {existingCliente.SaldoPuntos} puntos." +
                                   $"Recuerda que con Salpat siempre ganas!", htmlmessage);
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
