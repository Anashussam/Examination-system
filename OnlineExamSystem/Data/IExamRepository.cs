using OnlineExamSystem.Models.Exams;
namespace OnlineExamSystem.Data
{
    public interface IExamRepository
    {
        IEnumerable<Exam> GetAll();
        Exam GetById(int id);
        void Add(Exam exam);
        void Update(Exam exam);
        void Delete(Exam exam);
        bool Exists(int id);
        bool Save();
    }
}
