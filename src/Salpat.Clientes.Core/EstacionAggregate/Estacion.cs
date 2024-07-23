using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace Salpat.Clientes.Core.EstacionAggregate;


public sealed class Estacion(string nombre, decimal factorPuntos = 1) : Base.RegisterBase, IAggregateRoot
{
    public string Nombre { get; private set; } = Guard.Against.NullOrEmpty(nombre, nameof(nombre));
    public decimal FactorPuntos {  get; private set; } = Guard.Against.NegativeOrZero(factorPuntos, nameof(factorPuntos)); 
}
