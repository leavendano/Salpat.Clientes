using Ardalis.Result;

namespace Salpat.Clientes.UseCases.Transacciones.Create;

/// <summary>
/// Create a new Contributor.
/// </summary>
/// <param name="Name"></param>
public record CreateTransaccionCommand(int HoseDeliveryId,int ClienteId,int EstacionId, DateTime Fecha,
  decimal Importe,decimal Volumen,int ProductoId,int Puntos) : Ardalis.SharedKernel.ICommand<Result<TransaccionDTO>>;
