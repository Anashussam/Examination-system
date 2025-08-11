using OnlineExamSystem.Models.Exams;

namespace OnlineExamSystem.Data
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly ExamDbContext _context;

       public AnswerRepository(ExamDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Answer> GetAllAnswers()
        {
            return _context.Answers.ToList();
        }
        //public Answer GetAnswerById(int answerId)
        //{
        //    return _context.Answers.FirstOrDefault(a => a.AnswerID == answerId);
        //}

        public void AddAnswer(Answer answer)
        {
            _context.Answers.Add(answer);
        }
        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

    }
}
