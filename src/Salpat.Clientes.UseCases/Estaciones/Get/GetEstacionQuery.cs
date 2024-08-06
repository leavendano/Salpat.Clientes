using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Salpat.Clientes.UseCases.Estaciones.Get;
public record GetEstacionQuery(int Id) : IQuery<Result<EstacionDTO>>;
