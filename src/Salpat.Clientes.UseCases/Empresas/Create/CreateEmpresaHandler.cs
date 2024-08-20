

using Ardalis.Result;
using Ardalis.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Salpat.Clientes.Core.EmpresaAggregate;

namespace Salpat.Clientes.UseCases.Empresas.Create;

public class CreateEmpresaHandler(IRepository<Empresa> _repository) : ICommandHandler<CreateEmpresaCommand, Result<int>>
{

public async Task<Result<int>> Handle(CreateEmpresaCommand request, CancellationToken cancellationToken)
  {
    var newItem = new Empresa(request.Nombre);
    try
    {
      var createdItem = await _repository.AddAsync(newItem, cancellationToken);
      return createdItem.Id;
    }
    catch (DbUpdateException ex)
    {
      return Result<int>.Conflict(ex.InnerException?.Message);
    }
  }
}