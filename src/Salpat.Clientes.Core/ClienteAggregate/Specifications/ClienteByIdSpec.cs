using Ardalis.Specification;



namespace Salpat.Clientes.Core.ClienteAggregate.Specifications;

public class ClienteByIdSpec : Specification<Cliente>
{
  public ClienteByIdSpec(int clienteId)
  {
    Query
        .Where(cliente => cliente.Id == clienteId);
  }
}
