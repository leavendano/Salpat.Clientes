using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Salpat.Clientes.UseCases.Clientes.Update;

public record UpdateClienteCommand(int ClinteId, string NuevoNombre,string NuevoTelefono,string NuevoEmail) : ICommand<Result<ClienteDTO>>;
