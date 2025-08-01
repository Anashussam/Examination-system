
using OnlineExamSystem.Models.Subjects;


namespace OnlineExamSystem.Data
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAll();
        Subject GetById(int id);
        void Add(Subject subject);
       
        void Update(Subject subject);
        void Delete(int id);
        bool Exists(int id);
        bool Save();
      
    }
}
