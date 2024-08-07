﻿using Salpat.Clientes.UseCases.Transacciones.Create;
using FastEndpoints;
using MediatR;
using Salpat.Clientes.Core.Base;

namespace Salpat.Clientes.Web.Transacciones;

/// <summary>
/// Create a new Transaccion
/// </summary>
/// <remarks>
/// Creates a new Transacion.
/// </remarks>
public class Create(IMediator _mediator)
  : Endpoint<CreateTransaccionRequest, ApiResponse<CreateTransaccionResponse>>
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
   
  public override async Task HandleAsync(
    CreateTransaccionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateTransaccionCommand(request.HoseDeliveryId,
      request.ClienteId,request.EstacionId,request.Posicion,request.Fecha,request.Importe
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
          result.Value.ClienteId,result.Value.Fecha,result.Value.ProductoId,result.Value.Importe,result.Value.Volumen,result.Value.Puntos)
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
    // TODO: Handle other cases as necessary
  }
}
