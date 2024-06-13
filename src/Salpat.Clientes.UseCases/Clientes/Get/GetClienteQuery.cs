using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Salpat.Clientes.UseCases.Clientes.Get;

public record GetClienteQuery(int ClienteId) : IQuery<Result<ClienteDTO>>;
