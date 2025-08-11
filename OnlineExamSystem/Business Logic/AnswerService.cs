using OnlineExamSystem.Data;
using OnlineExamSystem.Models.DTOs;
using OnlineExamSystem.Models.Exams;

namespace OnlineExamSystem.Business_Logic
{
    public class AnswerService
    {
        private readonly IAnswerRepository _answerRepository;

        private readonly ExamDbContext _context;
        public AnswerService(IAnswerRepository answerRepository, ExamDbContext context)
        {
            _answerRepository = answerRepository;
            _context = context;
        }
        public IEnumerable<Answer> GetAllAnswers()
        {
            return _answerRepository.GetAllAnswers();
        }
        public bool AddAnswer(Answer answer)
        {
            var option = _context.Options.FirstOrDefault(o => o.OptionID == answer.OptionID);
            if (option != null)
            {
                answer.IsCorrect = option.IsCorrect;
            }

            _answerRepository.AddAnswer(answer);
            return _answerRepository.SaveChanges();
        }
        public bool SaveChanges()
        {
            return _answerRepository.SaveChanges();
        }

    }
}
