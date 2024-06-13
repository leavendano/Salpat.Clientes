using Salpat.Clientes.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Salpat.Clientes.Core.ClienteAggregate.Events;

namespace Salpat.Clientes.Core.ContributorAggregate.Handlers;

/// <summary>
/// NOTE: Internal because ContributorDeleted is also marked as internal.
/// </summary>
internal class ClienteDeletedHandler(ILogger<ClienteDeletedHandler> logger,
  IEmailSender emailSender) : INotificationHandler<ClienteDeletedEvent>
{
  public async Task Handle(ClienteDeletedEvent domainEvent, CancellationToken cancellationToken)
  {
    logger.LogInformation("Handling Contributed Deleted event for {contributorId}", domainEvent.ClienteId);

    await emailSender.SendEmailAsync("to@test.com",
                                     "from@test.com",
                                     "Contributor Deleted",
                                     $"Contributor with id {domainEvent.ClienteId} was deleted.");
  }
}
