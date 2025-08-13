using Microsoft.AspNetCore.Mvc;
using OnlineExamSystem.Business_Logic;
using OnlineExamSystem.Models;
using OnlineExamSystem.Models.Login;
using OnlineExamSystem.Models.Subjects;

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
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);

            }
        }
        [HttpGet("users/{userId}")]
        public IActionResult GetUserById(int userId)
        {
            try
            {
                var user = _userService.GetUserById(userId);
                if (user == null)
                    return NotFound("User not found");
                return Ok(new
                {
                    user.UserID,
                    user.Name,
                    user.Email,
                    Role = user.Role?.RoleName
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpGet("users")]
        public IActionResult GetUsers()
        {

            try
            {
                var users = _userService.GetAllUsers();
                return Ok(users.Select(u => new
                {
                    u.UserID,
                    u.Name,
                    u.Email,
                    Role = u.Role?.RoleName
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpDelete("users/{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            try
            {
                var result = _userService.DeleteUser(userId);
                if (!result)
                    return NotFound("User not found");
                return Ok("User deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

    }
}
