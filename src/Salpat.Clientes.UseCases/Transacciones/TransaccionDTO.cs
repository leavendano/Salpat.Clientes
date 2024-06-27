namespace Salpat.Clientes.UseCases.Transacciones;

public record TransaccionDTO(int HoseDeliveryId, int ClienteId, DateTime Fecha, decimal Importe);