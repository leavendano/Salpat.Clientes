using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Salpat.Clientes.UseCases.Recompensas.Update;
public record UpdateRecompensaCommand(int Id, string Descripcion, int PuntosRequeridos) : ICommand<Result<RecompensaDTO>>;
