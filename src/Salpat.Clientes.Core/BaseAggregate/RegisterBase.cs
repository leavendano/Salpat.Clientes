using Ardalis.SharedKernel;

namespace Salpat.Clientes.Core.Base;
public abstract class RegisterBase : EntityBase
{
  public string? Usuario { get; set; } = null;
  public RegisterStatus Estatus { get; set; } = RegisterStatus.Activo;
        
  public DateTime CreatedAt { get; set; }
        
  public DateTime UpdatedAt { get; set; }
}