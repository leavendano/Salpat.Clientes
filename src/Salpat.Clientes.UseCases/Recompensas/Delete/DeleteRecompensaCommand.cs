using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Salpat.Clientes.UseCases.Recompensas.Delete;
public record DeleteRecompensaCommand(int Id) : ICommand<Result>;

