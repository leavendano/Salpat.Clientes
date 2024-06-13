using Ardalis.Result;

namespace Salpat.Clientes.Core.Interfaces;

public interface IDeleteClienteService
{
  // This service and method exist to provide a place in which to fire domain events
  // when deleting this aggregate root entity
  public Task<Result> DeleteCliente(int clienteId);
}
