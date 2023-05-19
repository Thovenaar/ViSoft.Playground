using MediatR;

namespace ViSoft.Playground.Application.Users.Register
{
    public record UserRegisteredEvent (Guid UserId) : INotification;
}
