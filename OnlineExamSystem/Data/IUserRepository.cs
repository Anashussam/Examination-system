using OnlineExamSystem.Models.Exams;

namespace OnlineExamSystem.Data
{
    public interface IUserRepository
    {
        User Get(int id);
        IEnumerable<User> GetAllUsers();
        User GetByEmail(string email);
        void AddUser(User user);
        bool Exists(int id);

        User GetEmailAndPassword(string email, string password);

        bool Delete(int id);
    }
}
