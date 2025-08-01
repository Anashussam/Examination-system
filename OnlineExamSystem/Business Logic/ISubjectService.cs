using OnlineExamSystem.Models.Subjects;
using OnlineExamSystem.Models.Exams;

namespace OnlineExamSystem.Business_Logic.Interfaces
{
    public interface ISubjectService
    {
        IEnumerable<Subject> GetAll();
        Subject GetById(int id);

        bool Add(Subject subject);
        bool Update(Subject subject);
        bool Delete(int id);
    }
}
