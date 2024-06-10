using Ardalis.SharedKernel;

namespace Salpat.Clientes.Core.ContributorAggregate.Events;

/// <summary>
/// A domain event that is dispatched whenever a contributor is deleted.
/// The DeleteContributorService is used to dispatch this event.
/// </summary>
internal sealed class ClienteDeletedEvent(int clienteId) : DomainEventBase
{
  public int ClienteId { get; init; } = clienteId;
}
