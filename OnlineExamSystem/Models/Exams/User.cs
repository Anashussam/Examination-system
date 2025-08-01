using OnlineExamSystem.Models.Login;
using OnlineExamSystem.Models.Subjects; 
namespace OnlineExamSystem.Models.Exams
{
    public class User
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }

        public Roles Role { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public ICollection<LoginHistory> LoginHistories { get; set; }
    }
}
