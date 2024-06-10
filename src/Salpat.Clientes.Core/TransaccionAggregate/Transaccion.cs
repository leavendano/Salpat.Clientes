using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Salpat.Clientes.Core.Base;

namespace Salpat.Clientes.Core.ContributorAggregate;

public class Transaccion(int clienteId,DateTime fecha, decimal cantidad,decimal importe) : RegisterBase, IAggregateRoot
{
  // Example of validating primary constructor inputs
  // See: https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/primary-constructors#initialize-base-class
  public int ClienteId { get; private set; } = Guard.Against.NegativeOrZero(clienteId, nameof(clienteId));
  public DateTime Fecha { get; private set; } = Guard.Against.NullOrOutOfSQLDateRange(fecha, nameof(fecha));
  public decimal Cantidad { get; private set; } = Guard.Against.NegativeOrZero(cantidad, nameof(cantidad));
  public decimal Importe { get; private set; } = Guard.Against.NegativeOrZero(importe, nameof(importe));
 
  public void UpdateCliente(int newClienteId)
  {
    ClienteId = Guard.Against.NegativeOrZero(newClienteId, nameof(newClienteId));
  }

}


