using Ardalis.Result;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Salpat.Clientes.Core.Base;
using Salpat.Clientes.UseCases.Transacciones;
using Salpat.Clientes.UseCases.Transacciones.List;

namespace Salpat.Clientes.Web.Transacciones;

public class List(IMediator _mediator,ILogger<List> _logger) : Endpoint<ListTransaccionRequest>
{
    public override void Configure()
    {
        Get(ListTransaccionRequest.Route);
        AllowAnonymous();
        Summary(s =>
        {
          s.ExampleRequest = new ListTransaccionRequest{ EstacionId = 0, FechaInicial = DateTime.Now, FechaFinal = DateTime.Now};
        });
    }
    
    public override async Task HandleAsync( ListTransaccionRequest request, CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new ExportTransaccionesQuery(request.EstacionId,request.FechaInicial.ToUniversalTime(),
    request.FechaFinal.ToUniversalTime(),null, null), cancellationToken);
    _logger.LogInformation($"Fecha Inicial {request.FechaInicial.ToUniversalTime()},Fecha final  {request.FechaFinal.ToLocalTime()}");
    await SendBytesAsync(result.Value.StreamContent, result.Value.FileName, "application/octet-stream", cancellation: cancellationToken);
    
  }
}