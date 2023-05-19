using MediatR;
using Microsoft.AspNetCore.Mvc;
using ViSoft.Playground.Application.Data;
using ViSoft.Playground.Application.Users.Get;
using ViSoft.Playground.Application.Users.Register;
using ViSoft.Playground.Domain.Users;

namespace ViSoft.Playground.WebAPI.Features.Users
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISender _sender;

        public UserController(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            ISender sender)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _sender = sender;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(User user)
        {
            var registerUserCommand = new RegisterUserCommand 
            (
                user.EmailAddress,
                user.FirstName,
                user.LastName
            );

            var response = await _sender.Send(registerUserCommand);
            
            return new OkObjectResult(response);
        }

        [HttpGet("GetByEmailAddress")]
        public async Task<IActionResult> GetByEmailAddress(string emailAddress)
        {
            var getUserByEmailAddressQuery = new GetUserByEmailAddressQuery(emailAddress);

            var userResponse = await _sender.Send(getUserByEmailAddressQuery);
            if (userResponse.Status == GetUserByEmailAddressStatus.NotFound)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(userResponse.User);
        }
    }
}
