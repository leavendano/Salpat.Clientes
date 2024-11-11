using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Salpat.Clientes.UseCases.Clientes;

namespace Salpat.Clientes.UseCases.Transacciones.List; 
public record ListTransaccionesQuery(int? EstacionId,DateTime FechaInicial,DateTime FechaFinal,int? ClienteId,int? Skip, int? Take) : IQuery<Result<IEnumerable<TransaccionDTO>>>;
