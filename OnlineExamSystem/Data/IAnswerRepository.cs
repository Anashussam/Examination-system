using OnlineExamSystem.Models.Exams;

namespace OnlineExamSystem.Data
{
    public interface IAnswerRepository
    {
        IEnumerable<Answer> GetAllAnswers();

        void AddAnswer(Answer answer);

       // void GetAnswerById(int answerId);
        bool SaveChanges();

    }
}
