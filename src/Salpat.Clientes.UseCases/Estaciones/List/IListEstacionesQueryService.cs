using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salpat.Clientes.UseCases.Clientes;

namespace Salpat.Clientes.UseCases.Estaciones.List;
public interface IListEstacionesQueryService
{
  Task<IEnumerable<EstacionDTO>> ListAsync();
}
