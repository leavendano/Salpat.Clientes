using Ardalis.Result;
using Ardalis.SharedKernel;


namespace Salpat.Clientes.UseCases.Clientes.List;

public record ListClientesQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<ClienteDTO>>>;
