using MediatR;
using ViSoft.Playground.Domain.Users;

namespace ViSoft.Playground.Application.Users.Get
{
    internal sealed class GetUserByEmailAddressQueryHandler : IRequestHandler<GetUserByEmailAddressQuery, GetUserByEmailAddressQueryResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailAddressQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserByEmailAddressQueryResponse> Handle(GetUserByEmailAddressQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmail(request.EmailAddress);

            return new GetUserByEmailAddressQueryResponse(user,
                user == null
                    ? GetUserByEmailAddressStatus.NotFound
                    : GetUserByEmailAddressStatus.Found);
        }
    }
}
