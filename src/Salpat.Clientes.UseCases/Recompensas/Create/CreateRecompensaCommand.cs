using Ardalis.Result;

namespace Salpat.Clientes.UseCases.Recompensas.Create;
public record CreateRecompensaCommand(string Descripcion, int PuntosRequeridos) : Ardalis.SharedKernel.ICommand<Result<int>>;

