using Microsoft.AspNetCore.Mvc;
using ViSoft.Playground.Domain.Repositories;

namespace ViSoft.Playground.WebAPI.Features.User
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var user = await _userRepository.GetUser();

            return new OkObjectResult(user);
        }
    }
}
