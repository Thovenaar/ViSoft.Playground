using MediatR;
using ViSoft.Playground.Domain.Users;

namespace ViSoft.Playground.Application.Users.Get
{
    public record GetUserByEmailAddressQuery(string EmailAddress) : IRequest<GetUserByEmailAddressQueryResponse>;
}
