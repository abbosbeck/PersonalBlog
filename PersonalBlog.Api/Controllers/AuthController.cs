using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Core.Services.UserServices;
using PersonalBlog.Core.ViewModels.UserViewModels;

namespace PersonalBlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginViewModel model)
        {
            var token = await _userService.AuthenticateAsync(model);

            return Ok(new { Token = token });
        }

    }
}
