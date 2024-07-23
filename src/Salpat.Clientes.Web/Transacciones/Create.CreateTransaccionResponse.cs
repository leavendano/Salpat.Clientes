namespace Salpat.Clientes.Web.Transacciones;

public class CreateTransaccionResponse(int hoseDeliveryId, int clienteId, DateTime fecha, decimal importe, int puntos)
{
  public int HoseDeliveryId { get; set; } = hoseDeliveryId;
  public int ClienteId { get; set; } = clienteId;
  public DateTime Fecha { get; set;} = fecha;
  public decimal Importe { get; set;} = importe;
  public int Puntos { get; set; } = puntos;
}
