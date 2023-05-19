using MediatR;

namespace ViSoft.Playground.Application.Users.Register
{
    public record RegisterUserCommand(string EmailAddress, string FirstName, string LastName) : IRequest<bool>;
}
