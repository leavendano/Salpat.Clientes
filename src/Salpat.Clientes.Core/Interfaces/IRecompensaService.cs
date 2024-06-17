using Ardalis.Result;

namespace Salpat.Clientes.Core.Interfaces;

public interface IRecompensaService
{
  // This service and method exist to provide a place in which to fire domain events
  // when deleting this aggregate root entity
  public Task<Result> DeleteRecompensa(int recompensaId);
  public Task<Result> DisableRecompensa(int recompensaId);
}
