using Ardalis.Result;
using Ardalis.SharedKernel;


namespace Salpat.Clientes.UseCases.Empresas.List;

public record ListEmpresasQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<EmpresaDTO>>>;