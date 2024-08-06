using Ardalis.SmartEnum;

namespace Salpat.Clientes.Core.Base;

public class RegisterStatus : SmartEnum<RegisterStatus>
{
  public static readonly RegisterStatus Activo = new(nameof(Activo), 1);
  public static readonly RegisterStatus Inactivo = new(nameof(Inactivo), 2);
  protected RegisterStatus(string name, int value) : base(name, value) { }
}

