using Ardalis.Result;
using Ardalis.SharedKernel;
using Salpat.Clientes.Core.ClienteAggregate;


namespace Salpat.Clientes.UseCases.Clientes.Update;

public class UpdateClienteHandler(IRepository<Cliente> _repository)
  : ICommandHandler<UpdateClienteCommand, Result<ClienteDTO>>
{
  public async Task<Result<ClienteDTO>> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
  {
    var existingCliente = await _repository.GetByIdAsync(request.ClinteId, cancellationToken);
    if (existingCliente == null)
    {
      return Result.NotFound();
    }

    existingCliente.UpdateName(request.NuevoNombre!);

    existingCliente.UpdateTelefono(request.NuevoTelefono!);

    existingCliente.UpdateEmail(request.NuevoEmail);

    await _repository.UpdateAsync(existingCliente, cancellationToken);

    return Result.Success(new ClienteDTO(existingCliente.Id,
      existingCliente.Nombre, existingCliente.Telefono, existingCliente.Email, existingCliente.SaldoPuntos
      
      ));
  }
}
