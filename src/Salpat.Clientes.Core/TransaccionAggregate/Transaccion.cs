using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Salpat.Clientes.Core.Base;

namespace Salpat.Clientes.Core.TransaccionAggregate;

public sealed class Transaccion(int hoseDeliveryId,int clienteId,int estacionId,DateTime fecha,decimal importe, int puntos) : RegisterBase, IAggregateRoot
{
  // Example of validating primary constructor inputs
  // See: https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/primary-constructors#initialize-base-class
  public int HoseDeliveryId { get; private set; } = Guard.Against.NegativeOrZero(hoseDeliveryId,nameof(hoseDeliveryId));
 
  public DateTime Fecha { get; private set; } = Guard.Against.NullOrOutOfSQLDateRange(fecha, nameof(fecha));
  
  public decimal Importe { get; private set; } = Guard.Against.NegativeOrZero(importe, nameof(importe));
  public int Puntos { get; private set; } = Guard.Against.NegativeOrZero(puntos, nameof(puntos));
  public int ClienteId { get; private set; } = Guard.Against.NegativeOrZero(clienteId, nameof(clienteId));
  public int EstacionId { get; private set; } = Guard.Against.NegativeOrZero(estacionId, nameof(estacionId));

}


