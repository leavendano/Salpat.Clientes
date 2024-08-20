using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Salpat.Clientes.UseCases.Empresas.Delete;
public record DeleteEmpresaCommand(int Id) : ICommand<Result>;