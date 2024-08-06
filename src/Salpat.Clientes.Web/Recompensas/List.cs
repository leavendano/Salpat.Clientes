using FastEndpoints;
using MediatR;
using Salpat.Clientes.Core.Base;
using Salpat.Clientes.UseCases.Recompensas.List;


namespace Salpat.Clientes.Web.Recompensas;

public class List(IMediator _mediator) : EndpointWithoutRequest<ApiResponse<RecompensaRecord>>
{
  public override void Configure()
  {
    Get("/Api/Recompensas");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new ListRecompensasQuery(null, null));

    if (result.IsSuccess)
    {
      Response = new ApiResponse<RecompensaRecord>
      {
        Success = true,
        Error = "",
        Data = result.Value.Select(c => new RecompensaRecord(c.Descripcion, c.PuntosRequeridos)).ToList()
      };
    }
  }
}
