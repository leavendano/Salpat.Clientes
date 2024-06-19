using Ardalis.Result;
using Ardalis.SharedKernel;
using Salpat.Clientes.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Salpat.Clientes.Core.ClienteAggregate;
using Salpat.Clientes.Core.ClienteAggregate.Events;
using Salpat.Clientes.Core.Base;

namespace Salpat.Clientes.Core.Services;

/// <summary>
/// This is here mainly so there's an example of a domain service
/// and also to demonstrate how to fire domain events from a service.
/// </summary>
/// <param name="_repository"></param>
/// <param name="_mediator"></param>
/// <param name="_logger"></param>
public class ClienteService(IRepository<Cliente> _repository,
  IMediator _mediator,
  ILogger<ClienteService> _logger) : IClienteService
{
  public async Task<Result> DeleteCliente(int clienteId)
  {
    _logger.LogInformation("Eliminando Ciente {clienteId}", clienteId);
    Cliente? aggregateToDelete = await _repository.GetByIdAsync(clienteId);
    if (aggregateToDelete == null) return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new ClienteDeletedEvent(clienteId);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }

  public async Task<Result> DisableCliente(int clienteId)
  {
    _logger.LogInformation("Desactivando Ciente {clienteId}", clienteId);
    Cliente? aggregateToDelete = await _repository.GetByIdAsync(clienteId);
    if (aggregateToDelete == null) return Result.NotFound();

    aggregateToDelete.Estatus = RegisterStatus.Inactivo;
    await _repository.UpdateAsync(aggregateToDelete);
    var domainEvent = new ClienteDisabledEvent(clienteId);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}
