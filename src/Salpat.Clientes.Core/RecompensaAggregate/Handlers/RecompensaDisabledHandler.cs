using Salpat.Clientes.Core.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Salpat.Clientes.Core.RecompensaAgreggate.Events;

namespace Salpat.Clientes.Core.RecompensaAgreggate.Handlers;

/// <summary>
/// NOTE: Internal because ContributorDeleted is also marked as internal.
/// </summary>
internal class RecompensaDisabledHandler(ILogger<RecompensaDisabledHandler> logger,
  IEmailSender emailSender) : INotificationHandler<RecompensaDisabledEvent>
{
  public async Task Handle(RecompensaDisabledEvent domainEvent, CancellationToken cancellationToken)
  {
    logger.LogInformation("Handling Contributed Deleted event for {contributorId}", domainEvent.RecompensaId);

    await emailSender.SendEmailAsync("to@test.com",
                                     "from@test.com",
                                     "Recompensa Desactivada",
                                     $"Contributor with id {domainEvent.RecompensaId} was deleted.");
  }
}
