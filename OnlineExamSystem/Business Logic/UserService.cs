using OnlineExamSystem.Controllers;
using OnlineExamSystem.Data;
using OnlineExamSystem.Models;
using System.Security.Cryptography;
using System.Text;

namespace OnlineExamSystem.Business_Logic
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

       private string HashPassword(string password)
        {
            using(var sha256 =SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }




        public User Login(LoginModel model)
        {
            return _repo.GetEmailAndPassword(model.Email, model.Password);
        }

        public OperationResult Register(RegisterModel model)
        {

            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                return new OperationResult
                {
                    Success = false,
                    StatusCode = 400,
                    Message = "Email and password are required"

                };

            }
            var existing = _repo.GetByEmail(model.Email);
            if (existing != null)
            {
                return new OperationResult
                {
                    Success = false,
                    StatusCode= 409,
                    Message = "Email already exists"

                };
            }
            var hashedPassword = HashPassword(model.Password);

            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                Phone = model.Phone,
                Age = model.Age,
                RoleID = model.RoleID,
                Status = true
            };
            _repo.AddUser(user);
            return new OperationResult
            {
                Success = true,
                StatusCode = 200,
                Message = "User registered successfully."
            };
        }
    }
}
