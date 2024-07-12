using Ardalis.Result;
using FastEndpoints;
using MediatR;
using Salpat.Clientes.UseCases.Clientes.Get;

namespace Salpat.Clientes.Web.Clientes;

public class GetByPhone(IMediator _mediator)
  : Endpoint<GetClientByPhoneRequest, ClienteRecord>
{
  public override void Configure()
  {
    Get(GetClientByPhoneRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetClientByPhoneRequest request,
    CancellationToken cancellationToken)
  {
    var command = new GetClienteByTelefonoQuery(request.Telefono);

    var result = await _mediator.Send(command, cancellationToken);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new ClienteRecord(result.Value.Id, result.Value.Nombre, result.Value.SaldoPuntos);
    }
  }
}