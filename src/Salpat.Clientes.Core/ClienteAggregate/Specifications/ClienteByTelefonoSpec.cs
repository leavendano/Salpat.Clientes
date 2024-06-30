using Ardalis.Specification;



namespace Salpat.Clientes.Core.ClienteAggregate.Specifications;

public class ClienteByTelefonoSpec : Specification<Cliente>
{
  public ClienteByTelefonoSpec(string telefono)
  {
    Query
        .Where(cliente => cliente.Telefono == telefono);
  }
}
