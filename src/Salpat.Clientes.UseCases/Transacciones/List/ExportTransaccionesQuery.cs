using Ardalis.Result;
using Ardalis.SharedKernel;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;


namespace Salpat.Clientes.UseCases.Transacciones.List; 
public record ExportTransaccionesQuery(string Tipo , int? EstacionId,DateTime FechaInicial,DateTime FechaFinal,int? Skip, int? Take) : 
 IQuery<Result<ExportResponseDTO>>;