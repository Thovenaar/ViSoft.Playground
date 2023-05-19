using MediatR;
using Microsoft.Extensions.Logging;

namespace ViSoft.Playground.Application.Users.Register
{
    internal sealed class SendEmailVerificationEventHandler : INotificationHandler<UserRegisteredEvent>
    {
        private readonly ILogger<SendEmailVerificationEventHandler> _logger;

        public SendEmailVerificationEventHandler(ILogger<SendEmailVerificationEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Sending email verification to user {UserId}..", notification.UserId);

            return Task.CompletedTask;
        }
    }
}
