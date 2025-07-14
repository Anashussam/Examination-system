namespace OnlineExamSystem.Models
{
    public class Roles
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        
        public ICollection<User> Users { get; set; }
    }
}
