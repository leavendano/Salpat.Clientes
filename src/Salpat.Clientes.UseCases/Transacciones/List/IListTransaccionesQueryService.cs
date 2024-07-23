using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salpat.Clientes.UseCases.Clientes;

namespace Salpat.Clientes.UseCases.Transacciones.List;
public interface IListTransaccionesQueryService
{
  Task<IEnumerable<TransaccionDTO>> ListAsync();
}
