using Microsoft.EntityFrameworkCore;
using OnlineExamSystem.Models.Exams;



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
        public User Get(int id)
        {
            return _Context.Users.Include(u => u.Role).FirstOrDefault(u => u.UserID == id);
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _Context.Users.Include(u => u.Role).ToList();
        }

        public User GetByEmail(string email)
        {
            return _Context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetEmailAndPassword(string email, string password)
        {
            return _Context.Users
                .Include(u => u.Role) 
                .FirstOrDefault(u => u.Email == email && u.Password == password);
        }


        public bool Exists(int id)
        {
            return _Context.Users.Any(u => u.UserID == id);
        }
        public bool Delete(int id)
        {
            var user = Get(id);
            if (user == null) return false;
            _Context.Users.Remove(user);
            _Context.SaveChanges();
            return true;
        }
    }
}
