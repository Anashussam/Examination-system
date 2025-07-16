using OnlineExamSystem.Models;

namespace OnlineExamSystem.Business_Logic
{
    public interface IUserService
    {
        bool Register(RegisterModel model);
        User Login(LoginModel model);
    }
}
