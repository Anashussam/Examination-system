using OnlineExamSystem.Models.Questions;

namespace OnlineExamSystem.Business_Logic
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetAllQuestions();
        Question GetQuestionById(int id);
        bool AddQuestion(Question question);
        bool UpdateQuestion(Question question);
        bool DeleteQuestion(int id);
        bool Exists(int examId);
        


    }
}
