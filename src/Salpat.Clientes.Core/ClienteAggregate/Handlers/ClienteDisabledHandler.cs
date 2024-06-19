using Salpat.Clientes.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Salpat.Clientes.Core.ClienteAggregate.Events;

namespace Salpat.Clientes.Core.ClienteAggregate.Handlers;

/// <summary>
/// NOTE: Internal because ContributorDeleted is also marked as internal.
/// </summary>
internal class ClienteDisabledHandler(ILogger<ClienteDisabledHandler> logger,
  IEmailSender emailSender) : INotificationHandler<ClienteDisabledEvent>
{
  public async Task Handle(ClienteDisabledEvent domainEvent, CancellationToken cancellationToken)
  {
    logger.LogInformation("Handling Contributed Deleted event for {contributorId}", domainEvent.ClienteId);

    await emailSender.SendEmailAsync("to@test.com",
                                     "from@test.com",
                                     "Contributor Deleted",
                                     $"Contributor with id {domainEvent.ClienteId} was deleted.");
  }
}
