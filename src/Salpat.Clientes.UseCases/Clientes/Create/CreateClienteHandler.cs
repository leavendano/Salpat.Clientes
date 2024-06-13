using Ardalis.Result;
using Ardalis.SharedKernel;
using Salpat.Clientes.Core.ClienteAggregate;

namespace Salpat.Clientes.UseCases.Clientes.Create;

public class CreateClienteHandler(IRepository<Cliente> _repository)
  : ICommandHandler<CreateClienteCommand, Result<int>>
{
  public async Task<Result<int>> Handle(CreateClienteCommand request,
    CancellationToken cancellationToken)
  {
    var newCliente = new Cliente(request.Nombre, request.Telefono, request.Email);
   
    var createdItem = await _repository.AddAsync(newCliente, cancellationToken);

    return createdItem.Id;
  }
}
