using OnlineExamSystem.Models.Exams;

namespace OnlineExamSystem.Data
{
    public interface IResultRepository
    {
        IEnumerable<Result> GetAllResults();
        Result GetResultById(int resultId);

        void AddResult(Result result);
        void UpdateResult(Result result);
        void DeleteResult(int resultId);
        void SaveChanges();

    }
}
