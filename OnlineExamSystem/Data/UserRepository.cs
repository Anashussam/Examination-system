using OnlineExamSystem.Models;

namespace OnlineExamSystem.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ExamDbContext _Context;

        public UserRepository(ExamDbContext context)
        {
            _Context = context;
        }

        public void AddUser(User user)
        {
            _Context.Users.Add(user);
            _Context.SaveChanges();
        }

        public User GetByEmail(string email)
        {
            return _Context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetEmailAndPassword(string email, string password)
        {
            return _Context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
