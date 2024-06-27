using Ardalis.Specification;



namespace Salpat.Clientes.Core.ClienteAggregate.Specifications;

public class ClienteByEmailSpec : Specification<Cliente>
{
  public ClienteByEmailSpec(string email)
  {
    Query
        .Where(cliente => cliente.Email == email);
  }
}
