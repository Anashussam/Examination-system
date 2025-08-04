using OnlineExamSystem.Models.Questions;

namespace OnlineExamSystem.Data
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetAllQuestions();

        Question GetQuestionById(int questionId);
        void AddQuestion(Question question);
        void UpdateQuestion(Question question);
        void DeleteQuestion(int questionId);
        bool SaveChanges();
    }
}
