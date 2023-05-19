using MediatR;
using ViSoft.Playground.Application.Data;
using ViSoft.Playground.Domain.Users;

namespace ViSoft.Playground.Application.Users.Register
{
    internal sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublisher _publisher;

        public RegisterUserCommandHandler(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork, 
            IPublisher publisher)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _publisher = publisher;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.Create(request.EmailAddress, request.FirstName, request.LastName);
            
            _userRepository.Add(user);
            
            var response = await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (response <= 0)
            {
                return false;
            }

            await _publisher.Publish(new UserRegisteredEvent(user.Id), cancellationToken);
            return true;

        }
    }
}
