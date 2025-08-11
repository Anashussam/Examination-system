using OnlineExamSystem.Models.Exams;

namespace OnlineExamSystem.Data
{
    public class ResultRepository : IResultRepository
    {
       private readonly ExamDbContext _context;
        public ResultRepository(ExamDbContext context) {
            _context = context;
        }
        public IEnumerable<Result> GetAllResults()
        {
            return _context.Result.ToList();
        }
        public Result GetResultById(int resultId)
        {
            return _context.Result.FirstOrDefault(r => r.ResultID == resultId);
        }
        public void AddResult(Result result)
        {
            _context.Result.Add(result);
           
        }
        public void UpdateResult(Result result)
        {
            _context.Result.Update(result);
        }
        public void DeleteResult(int resultId)
        {
            var result = GetResultById(resultId);
            if (result != null)
            {
                _context.Result.Remove(result);
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
