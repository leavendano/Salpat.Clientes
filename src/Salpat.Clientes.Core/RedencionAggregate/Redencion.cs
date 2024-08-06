using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Salpat.Clientes.Core.Base;


namespace Salpat.Clientes.Core.RedencionAggregate;
public sealed class Redencion(int clienteId, DateTime fecha,int recompensaId, int puntosRedimidos) : RegisterBase, IAggregateRoot
{
  public int ClienteId { get; private set; } = Guard.Against.NegativeOrZero(clienteId, nameof(clienteId));
  public DateTime Fecha { get; private set; } = Guard.Against.NullOrOutOfSQLDateRange(fecha, nameof(fecha));
  public int RecompensaId { get; private set; } = Guard.Against.NegativeOrZero(recompensaId, nameof(recompensaId));
  public int PuntosRedimidos { get; private set; } = Guard.Against.NegativeOrZero(puntosRedimidos, nameof(puntosRedimidos));
   
}
