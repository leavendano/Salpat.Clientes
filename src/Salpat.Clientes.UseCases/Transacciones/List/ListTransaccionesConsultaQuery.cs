using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Salpat.Clientes.UseCases.Transacciones.List; 
public record ListTransaccionesConsultaQuery(int? EstacionId,DateTime FechaInicial,DateTime FechaFinal,int? Skip, int? Take) : 
        IQuery<Result<IEnumerable<TransaccionConsultaDTO>>>;
