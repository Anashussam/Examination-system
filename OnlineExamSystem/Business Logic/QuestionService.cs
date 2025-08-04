using OnlineExamSystem.Data;
using OnlineExamSystem.Models.Questions;

namespace OnlineExamSystem.Business_Logic
{
   
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repo;

        public QuestionService(IQuestionRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Question> GetAllQuestions() => _repo.GetAllQuestions();
        public Question GetQuestionById(int id) => _repo.GetQuestionById(id);

        public bool AddQuestion(Question question)
        {
            _repo.AddQuestion(question);
            return _repo.SaveChanges();
        }

        public bool UpdateQuestion(Question question)
        {
            _repo.UpdateQuestion(question);
            return _repo.SaveChanges();
        }

        public bool DeleteQuestion(int id)
        {
            _repo.DeleteQuestion(id);
            return _repo.SaveChanges();
        }

        public bool Exists(int examId)
        {
            return _repo.GetAllQuestions().Any(q => q.ExamID == examId);
        }
    }

}
