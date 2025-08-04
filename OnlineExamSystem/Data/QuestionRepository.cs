using Microsoft.EntityFrameworkCore;
using OnlineExamSystem.Models.Questions;

namespace OnlineExamSystem.Data
{
  


    public class QuestionRepository : IQuestionRepository
    {
        private readonly ExamDbContext _context;

        public QuestionRepository(ExamDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            return _context.Questions.ToList();
        }

        public Question GetQuestionById(int questionId)
        {
            return _context.Questions.FirstOrDefault(q => q.QuestionID == questionId);
        }

        public void AddQuestion(Question question)
        {
            _context.Questions.Add(question);
        }

        public void UpdateQuestion(Question question)
        {
            _context.Questions.Update(question);
        }

        public void DeleteQuestion(int questionId)
        {
            var question = _context.Questions.Find(questionId);
            if (question != null)
            {
                _context.Questions.Remove(question);
            }
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }

}
