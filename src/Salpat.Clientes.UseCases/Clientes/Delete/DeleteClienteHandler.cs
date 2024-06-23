using Ardalis.Result;
using Ardalis.SharedKernel;
using Salpat.Clientes.Core.Interfaces;

namespace Salpat.Clientes.UseCases.Clientes.Delete;

public class DeleteClienteHandler(IClienteService _ClienteService)
  : ICommandHandler<DeleteClienteCommand, Result>
{
  public async Task<Result> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
  {
    // This Approach: Keep Domain Events in the Domain Model / Core project; this becomes a pass-through
    // This is @ardalis's preferred approach
    return await _ClienteService.DeleteCliente(request.ClinteId);

    // Another Approach: Do the real work here including dispatching domain events - change the event from internal to public
    // @ardalis prefers using the service above so that **domain** event behavior remains in the **domain model** (core project)
    // var aggregateToDelete = await _repository.GetByIdAsync(request.ContributorId);
    // if (aggregateToDelete == null) return Result.NotFound();

    // await _repository.DeleteAsync(aggregateToDelete);
    // var domainEvent = new ContributorDeletedEvent(request.ContributorId);
    // await _mediator.Publish(domainEvent);
    // return Result.Success();
  }
}
