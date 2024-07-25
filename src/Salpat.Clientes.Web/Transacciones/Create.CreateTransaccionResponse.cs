namespace Salpat.Clientes.Web.Transacciones;

public class CreateTransaccionResponse(int hoseDeliveryId, int clienteId, DateTime fecha,
  int productoId, decimal importe, decimal volumen, int puntos)
{
  public int HoseDeliveryId { get; set; } = hoseDeliveryId;
  public int ClienteId { get; set; } = clienteId;
  public DateTime Fecha { get; set;} = fecha;
  public int ProductoId { get; set; } = productoId;
  public decimal Importe { get; set;} = importe;
  public decimal Volumen { get; set; } = volumen;
  public int Puntos { get; set; } = puntos;
}
