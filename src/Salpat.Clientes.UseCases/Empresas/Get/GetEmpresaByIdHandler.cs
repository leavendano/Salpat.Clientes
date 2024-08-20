using Ardalis.Result;
using Ardalis.SharedKernel;
using Salpat.Clientes.UseCases.Empresas;
using Salpat.Clientes.Core.EmpresaAggregate.Specifications;
using Salpat.Clientes.Core.EmpresaAggregate;
using Salpat.Clientes.UseCases.Empresas.Get;

namespace Salpat.Clientes.UseCases.Recompensas.Get;
public class GetEmpresaByIdHandler(IReadRepository<Empresa> _repository) : IQueryHandler<GetEmpresaByIdQuery, Result<EmpresaDTO>>
{
  public async Task<Result<EmpresaDTO>> Handle(GetEmpresaByIdQuery request, CancellationToken cancellationToken)
  {
    var spec = new EmpresaByIdSpec(request.Id);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new EmpresaDTO(entity.Id, entity.Nombre);
  }
}
