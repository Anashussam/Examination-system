using OnlineExamSystem.Controllers;
using OnlineExamSystem.Models;
using OnlineExamSystem.Models.Exams;
using OnlineExamSystem.Models.Login;

namespace OnlineExamSystem.Business_Logic
{
    public interface IUserService
    {
        OperationResult Register(RegisterModel model);
        User Login(LoginModel model);
        User GetUserById(int userId);
        IEnumerable<User> GetAllUsers();

        bool DeleteUser(int userId);
    }
}
