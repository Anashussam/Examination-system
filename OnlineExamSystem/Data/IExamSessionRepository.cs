using OnlineExamSystem.Models.Exams;

namespace OnlineExamSystem.Data
{
    public interface IExamSessionRepository
    {
        IEnumerable<ExamSession> GetAllSessions();

        ExamSession GetSessionById(int sessionId);
        void AddSession(ExamSession session);
        void UpdateSession(ExamSession session);
        void DeleteSession(int sessionId);
        bool SaveChanges();



    }
}
