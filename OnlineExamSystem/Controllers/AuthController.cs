using Microsoft.AspNetCore.Mvc;
using OnlineExamSystem.Business_Logic;
using OnlineExamSystem.Models;

namespace OnlineExamSystem.Controllers
{
  //  [Route("api/[controller]")]
    [Route("api/ExamSystem")]

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
            try
            {
                var result = _userService.Register(model);
                return StatusCode(result.StatusCode, result.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {


            try
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
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);

            }




        }
    }
}
