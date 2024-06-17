using Ardalis.SharedKernel;

namespace Salpat.Clientes.Core.RecompensaAgreggate.Events;

/// <summary>
/// A domain event that is dispatched whenever a contributor is deleted.
/// The DeleteContributorService is used to dispatch this event.
/// </summary>
internal sealed class RecompensaDisabledEvent(int recompensaId) : DomainEventBase
{
  public int RecompensaId { get; init; } = recompensaId;
}
