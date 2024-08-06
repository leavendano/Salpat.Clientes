using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Salpat.Clientes.UseCases.Clientes.Create;

/// <summary>
/// Create a new Contributor.
/// </summary>
/// <param name="Name"></param>
public record CreateClienteCommand(string Nombre, string Telefono, string Email) : ICommand<Result<int>>;
