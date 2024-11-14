using System.ComponentModel.DataAnnotations;

namespace Salpat.Clientes.Web.Transacciones;

public class ListTransaccionRequest
{
  public string Tipo { get; set; } = "PDF";
  public int? EstacionId { get; set; }
  public const string Route = "/Api/Transacciones";
  [Required]
  public DateTime FechaInicial { get; set; } = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
  [Required]
  public DateTime FechaFinal { get; set; } = DateTime.Now;

}
