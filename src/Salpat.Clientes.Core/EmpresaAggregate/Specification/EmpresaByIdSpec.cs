using Ardalis.Specification;



namespace Salpat.Clientes.Core.EmpresaAggregate.Specifications;

public class EmpresaByIdSpec : Specification<Empresa>
{
  public EmpresaByIdSpec(int empresaId)
  {
    Query
        .Where(item => item.Id == empresaId);
  }
}
