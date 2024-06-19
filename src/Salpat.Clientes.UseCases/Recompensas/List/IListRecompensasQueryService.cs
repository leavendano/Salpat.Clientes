namespace Salpat.Clientes.UseCases.Recompensas.List;

/// <summary>
/// Represents a service that will actually fetch the necessary data
/// Typically implemented in Infrastructure
/// </summary>
public interface IListRecompensaQueryService
{
  Task<IEnumerable<RecompensaDTO>> ListAsync();
}
