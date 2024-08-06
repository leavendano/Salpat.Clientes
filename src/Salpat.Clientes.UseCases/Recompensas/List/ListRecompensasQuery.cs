using Ardalis.Result;
using Ardalis.SharedKernel;


namespace Salpat.Clientes.UseCases.Recompensas.List;

public record ListRecompensasQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<RecompensaDTO>>>;

