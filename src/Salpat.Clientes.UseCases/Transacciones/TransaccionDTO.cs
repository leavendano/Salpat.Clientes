using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Salpat.Clientes.UseCases.Transacciones;

public record TransaccionDTO(int HoseDeliveryId, int ClienteId,int EstacionId,int Posicion, DateTime Fecha
  , int ProductoId, decimal Importe,decimal Volumen,int Puntos);
