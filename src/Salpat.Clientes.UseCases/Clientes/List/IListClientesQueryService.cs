namespace Salpat.Clientes.UseCases.Clientes.List;

/// <summary>
/// Represents a service that will actually fetch the necessary data
/// Typically implemented in Infrastructure
/// </summary>
public interface IListClientesQueryService
{
  Task<IEnumerable<ClienteDTO>> ListAsync();
}
