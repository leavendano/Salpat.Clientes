
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Salpat.Clientes.Core.Base;

namespace Salpat.Clientes.Core.EmpresaAggregate;

public class Empresa(string nombre) : RegisterBase, IAggregateRoot
{

    public string Nombre { get; set; } = Guard.Against.NullOrEmpty(nombre,nameof(nombre));
}