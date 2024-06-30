using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Salpat.Clientes.UseCases.Clientes.Get;

public record GetClienteByEmailQuery(string Email) : IQuery<Result<ClienteDTO>>;
