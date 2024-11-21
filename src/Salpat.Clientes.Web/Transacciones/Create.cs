using Salpat.Clientes.UseCases.Transacciones.Create;
using FastEndpoints;
using MediatR;
using Salpat.Clientes.Core.Base;
using Salpat.Clientes.UseCases.Transacciones.List;
using Salpat.Clientes.UseCases.Estaciones.Get;

namespace Salpat.Clientes.Web.Transacciones;

/// <summary>
/// Create a new Transaccion
/// </summary>
/// <remarks>
/// Creates a new Transacion.
/// </remarks>
public class Create(IMediator _mediator, IConfiguration _configuration) : Endpoint<CreateTransaccionRequest, ApiResponse<CreateTransaccionResponse>>
{
  public override void Configure()
  {
    Post(CreateTransaccionRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.ExampleRequest = new CreateTransaccionRequest{ HoseDeliveryId = 0, ClienteId = 0, Fecha = DateTime.Now, Importe = 0};
    });
  }
   
  public override async Task HandleAsync(CreateTransaccionRequest request,CancellationToken cancellationToken)
  {
    int limiteHoras  = _configuration.GetValue<int>("BsRules:MinHoursNewRecord");
    var resultPrevio = await _mediator.Send( new ListTransaccionesQuery(request.EstacionId,request.Fecha.AddHours(-1 * limiteHoras),
        request.Fecha,request.ClienteId, null, null));

    if(resultPrevio.Value.Count() == 0)
    {
      var resultEstacion = await _mediator.Send(new GetEstacionQuery(request.EstacionId));
      if(!resultEstacion.IsSuccess)
      {
        
        ThrowError("No se encuentra ese número de estación");
      }
      var result = await _mediator.Send(new CreateTransaccionCommand(request.HoseDeliveryId,
        request.ClienteId,request.EstacionId,resultEstacion.Value.Nombre,request.Posicion,request.Fecha,request.Importe
        ,request.Volumen,request.ProductoId,(int)request.Importe), cancellationToken);
    
      if (result.IsSuccess)
      {
        Response = new ApiResponse<CreateTransaccionResponse>
        {
          Success = true,
          Error = "",
          Data = new List<CreateTransaccionResponse>()
          {
            new CreateTransaccionResponse( result.Value.HoseDeliveryId,
            result.Value.ClienteId,result.Value.Fecha,result.Value.ProductoId,result.Value.Importe,result.Value.Volumen,
            result.Value.Puntos,resultEstacion.Value.Nombre)
          }
        };
        return;
      }
      else
      {
        Response = new ApiResponse<CreateTransaccionResponse>
        {
          Success = false,
          Error = result.Errors.FirstOrDefault() == null ? "" : result.Errors.FirstOrDefault()!
        };
      }
    }
    else
    {
      Response = new ApiResponse<CreateTransaccionResponse>
      {
        Success = false,
        Error = $"Existe un movimiento antes de las {limiteHoras}hrs del mismo cliente"
      };
    }
    
    // TODO: Handle other cases as necessary
  }
}
