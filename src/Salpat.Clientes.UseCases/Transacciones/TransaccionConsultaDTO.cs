namespace Salpat.Clientes.UseCases.Transacciones;

public record TransaccionConsultaDTO(int HoseDeliveryId, int ClienteId,string NombreCliente,
    int? EmpresaId, string? NombreEmpresa, int EstacionId, string NombreEstacion,int Posicion, DateTime Fecha
  , int ProductoId,string NombreProducto, decimal Importe,decimal Volumen,int Puntos);
