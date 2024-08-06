using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salpat.Clientes.UseCases.Redenciones;
public record RedencionDTO(int ClienteId, DateTime Fecha, int RecompensaId, int PuntosRedimidos);
