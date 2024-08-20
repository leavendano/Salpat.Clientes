using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Salpat.Clientes.UseCases.Empresas.Get;
public record GetEmpresaByIdQuery(int Id) : IQuery<Result<EmpresaDTO>>;

