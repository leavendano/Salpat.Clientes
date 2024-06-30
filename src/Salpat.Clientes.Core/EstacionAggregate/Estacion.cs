using Ardalis.GuardClauses;
using Ardalis.SharedKernel;

namespace Salpat.Clientes.Core.EstacionAggregate;


public sealed class Estacion(string nombre) : Base.RegisterBase, IAggregateRoot
{
    public string Nombre { get; private set; } = Guard.Against.NullOrEmpty(nombre, nameof(nombre));
}