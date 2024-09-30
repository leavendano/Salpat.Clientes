using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Salpat.Clientes.Core.Base;
using Salpat.Clientes.UseCases.Transacciones;
using Salpat.Clientes.UseCases.Transacciones.List;

namespace Salpat.Clientes.Web.Transacciones;

public class List(IMediator _mediator) : Endpoint<ListTransaccionRequest, ApiResponse<TransaccionDTO>>
{
    public override void Configure()
    {
        Get(ListTransaccionRequest.Route);
        AllowAnonymous();
        Summary(s =>
        {
          s.ExampleRequest = new CreateTransaccionRequest{ HoseDeliveryId = 0, ClienteId = 0, Fecha = DateTime.Now, Importe = 0};
        });
    }
    
    public override async Task HandleAsync( ListTransaccionRequest request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new ListTransaccionesQuery(request.FechaInicial,request.FechaFinal,null, null), cancellationToken);
  
    if (result.IsSuccess)
    {
      Response = new ApiResponse<TransaccionDTO>
      {
        Success = true,
        Error = "",
        Data = result.Value
      };
      return;
    }
    else
    {
      Response = new ApiResponse<TransaccionDTO>
      {
        Success = false,
        Error = result.Errors.FirstOrDefault() == null ? "" : result.Errors.FirstOrDefault()!
      };
    }
    // TODO: Handle other cases as necessary
  }
}