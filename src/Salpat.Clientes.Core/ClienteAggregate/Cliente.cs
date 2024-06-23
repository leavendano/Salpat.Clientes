using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Salpat.Clientes.Core.Base;


namespace Salpat.Clientes.Core.ClienteAggregate;

public class Cliente(string nombre, string telefono, string email) : RegisterBase, IAggregateRoot
{
  // Example of validating primary constructor inputs
  // See: https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/primary-constructors#initialize-base-class
  public string Nombre { get; private set; } = Guard.Against.NullOrEmpty(nombre, nameof(nombre));
  public string Telefono { get; private set; } = Guard.Against.NullOrEmpty(telefono, nameof(telefono));
  public string Email { get; private set; } = Guard.Against.NullOrEmpty(email, nameof(email));
  public decimal SumaImporte { get; private set;} = 0m;
  public int PuntosGanados { get; private set; } = 0;
  public int PuntosRedimidos { get; private set;} = 0;

 
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
    Email = Guard.Against.NullOrEmpty(newEmail, nameof(newEmail));
  }

  public void AgregarImporte(decimal importe)
  {
    SumaImporte += Guard.Against.NegativeOrZero(importe,nameof(importe));
  }
  public void AgregarPuntos(int puntos)
  {
    PuntosGanados += Guard.Against.NegativeOrZero(puntos, nameof(puntos));
  }

  public void RedimirPuntos(int puntos)
  {
    PuntosRedimidos += Guard.Against.NegativeOrZero(puntos, nameof(puntos));
  }

  public int SaldoPuntos() 
  {
    return PuntosGanados - PuntosRedimidos;
  }
}


