using Salpat.Clientes.UseCases.Transacciones.Create;
using FastEndpoints;
using MediatR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Salpat.Clientes.UseCases.Responses;

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
      s.ExampleRequest = new CreateTransaccionRequest { HoseDeliveryId = 0, ClienteId = 0, Fecha = DateTime.Now, Importe = 0};
    });
  }
   
  public override async Task HandleAsync(
    CreateTransaccionRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreateTransaccionCommand(request.HoseDeliveryId,
      request.ClienteId,request.EstacionId,request.Fecha,request.Importe,(int)request.Importe), cancellationToken);
  
    if (result.IsSuccess)
    {
      Response = new ApiResponse<CreateTransaccionResponse>
      {
        Success = true,
        Error = "",
        Data = new List<CreateTransaccionResponse>()
        {
          new CreateTransaccionResponse(result.Value, request.HoseDeliveryId,
          request.ClienteId,request.Fecha,request.Importe,(int)request.Importe)
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
