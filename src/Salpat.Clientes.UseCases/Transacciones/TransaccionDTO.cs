namespace Salpat.Clientes.UseCases.Transacciones;

public record TransaccionDTO(int HoseDeliveryId, int ClienteId, DateTime Fecha
  , int ProductoId, decimal Importe,decimal Volumen,int Puntos = 0);
