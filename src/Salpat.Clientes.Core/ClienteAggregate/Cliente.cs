using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Salpat.Clientes.Core.Base;

namespace Salpat.Clientes.Core.ContributorAggregate;

public class Cliente(string nombre, string telefono, string email) : RegisterBase, IAggregateRoot
{
  // Example of validating primary constructor inputs
  // See: https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/primary-constructors#initialize-base-class
  public string Nombre { get; private set; } = Guard.Against.NullOrEmpty(nombre, nameof(nombre));
  public string Telefono { get; private set; } = Guard.Against.NullOrEmpty(telefono, nameof(telefono));
  public string EMail { get; private set; } = Guard.Against.NullOrEmpty(email, nameof(email));
 
  public void UpdateName(string newName)
  {
    Nombre = Guard.Against.NullOrEmpty(newName, nameof(newName));
  }

  public void UpdateTelefono(string newPhone)
  {
    Telefono = Guard.Against.NullOrEmpty(newPhone, nameof(newPhone));
  }

  public void UpdateEmail(string newEmail)
  {
    EMail = Guard.Against.NullOrEmpty(newEmail, nameof(newEmail));
  }
}


