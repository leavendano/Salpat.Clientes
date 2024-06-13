using Ardalis.Result;

namespace Salpat.Clientes.UseCases.Clientes.Create;

/// <summary>
/// Create a new Contributor.
/// </summary>
/// <param name="Name"></param>
public record CreateClienteCommand(string Nombre, string Telefono, string Email) : Ardalis.SharedKernel.ICommand<Result<int>>;
