using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Salpat.Clientes.UseCases.Redenciones.Create;
public record CreateRedencionCommand(int ClienteId, DateTime Fecha, int RecompensaId, int PuntosRedimidos) : ICommand<Result<int>>;

