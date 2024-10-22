namespace Salpat.Clientes.UseCases.Transacciones;


public record ExportServiceRequest(string name, string type, string rdlc,IEnumerable<ParamDTO>? parameters,IEnumerable<ExportData>? dataSource);