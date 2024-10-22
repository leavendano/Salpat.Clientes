using Ardalis.Result;
using Ardalis.SharedKernel;


namespace Salpat.Clientes.UseCases.Transacciones.List; 
public record ExportTransaccionesQuery(int? EstacionId,DateTime FechaInicial,DateTime FechaFinal,int? Skip, int? Take) : 
 IQuery<Result<ExportResponseDTO>>;
