using OnlineExamSystem.Data;
using OnlineExamSystem.Models;

namespace OnlineExamSystem.Business_Logic
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        

        public User Login(LoginModel model)
        {
            return _repo.GetEmailAndPassword(model.Email, model.Password);
        }

        public bool Register(RegisterModel model)
        {
            var existing = _repo.GetByEmail(model.Email);
            if (existing != null)
                return false;

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
            return true;
        }
    }
}
