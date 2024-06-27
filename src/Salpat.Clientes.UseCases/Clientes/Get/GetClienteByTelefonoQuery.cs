using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Salpat.Clientes.UseCases.Clientes.Get;

public record GetClienteByTelefonoQuery(string Telefono) : IQuery<Result<ClienteDTO>>;
