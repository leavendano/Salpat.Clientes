using Ardalis.Result;


namespace Salpat.Clientes.UseCases.Transacciones.List;
public interface IListTransaccionesQueryService : IDisposable
{
  Task<IEnumerable<TransaccionDTO>> ListAsync(int? EstacionId,DateTime? FechaInicial, DateTime? FechaFinal,int? ClienteId);

  Task<IEnumerable<TransaccionConsultaDTO>> ListConsultaAsync(int? EstacionId,DateTime? FechaInicial, DateTime? FechaFinal);

  Task<Result<ExportResponseDTO>> ExportAsync(string Tipo,int? EstacionId,DateTime? FechaInicial, DateTime? FechaFinal);
}
