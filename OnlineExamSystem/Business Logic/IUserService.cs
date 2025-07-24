using OnlineExamSystem.Controllers;
using OnlineExamSystem.Models;

namespace OnlineExamSystem.Business_Logic
{
    public interface IUserService
    {
        OperationResult Register(RegisterModel model);
        User Login(LoginModel model);
    }
}
