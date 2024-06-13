using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Salpat.Clientes.UseCases.Clientes.Delete;

public record DeleteClienteCommand(int ClinteId) : ICommand<Result>;
