using ViSoft.Playground.Domain.Users;

namespace ViSoft.Playground.Application.Users.Get
{
    public record GetUserByEmailAddressQueryResponse(User? User, GetUserByEmailAddressStatus Status);
}
