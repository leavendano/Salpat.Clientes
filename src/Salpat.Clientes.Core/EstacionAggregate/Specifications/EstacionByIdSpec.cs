using Ardalis.Specification;
using Salpat.Clientes.Core.ClienteAggregate;


namespace Salpat.Clientes.Core.EstacionAggregate.Specifications;
public class EstacionByIdSpec : Specification<Estacion>
{
  public EstacionByIdSpec(int Id)
  {
    Query
       .Where(estacion => estacion.Id == Id);
  }
}
