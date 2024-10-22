using System.Collections;

namespace Salpat.Clientes.UseCases.Transacciones;

public record ExportData(string Name, IEnumerable DataCollection);