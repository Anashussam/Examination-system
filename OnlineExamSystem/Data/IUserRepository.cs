using OnlineExamSystem.Models.Exams;

namespace OnlineExamSystem.Data
{
    public interface IUserRepository
    {
        User GetByEmail(string email);
        void AddUser(User user);

        User GetEmailAndPassword(string email, string password);
    }
}
