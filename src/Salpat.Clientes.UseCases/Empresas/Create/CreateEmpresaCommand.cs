
using Ardalis.Result;

namespace Salpat.Clientes.UseCases.Empresas;
public record CreateEmpresaCommand(string Nombre) : Ardalis.SharedKernel.ICommand<Result<int>>;