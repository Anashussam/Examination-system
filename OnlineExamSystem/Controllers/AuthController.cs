using Microsoft.AspNetCore.Mvc;
using OnlineExamSystem.Business_Logic;
using OnlineExamSystem.Models;

namespace OnlineExamSystem.Controllers
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

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            var result = _userService.Register(model);
            if (!result)
                return BadRequest("Email alredy exists");

            return Ok("User registerd susscessfuly");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user = _userService.Login(model);
            if (user == null)
                return Unauthorized("Invalid email or password ");

            return Ok(new
            {
                user.UserID,
                user.Name,
                user.Email,
                Role = user.Role?.RoleName

            });
        }
    }
}
