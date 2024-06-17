using Ardalis.Specification;



namespace Salpat.Clientes.Core.RecompensaAgreggate.Specifications;

public class RecompensaByIdSpec : Specification<Recompensa>
{
  public RecompensaByIdSpec(int recompensaId)
  {
    Query
        .Where(item => item.Id == recompensaId);
  }
}
