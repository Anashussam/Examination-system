using OnlineExamSystem.Models.Exams;

namespace OnlineExamSystem.Business_Logic
{
    public interface IExamSessionService
    {
        IEnumerable<ExamSession> GetAllSessions();
        ExamSession GetSessionById(int sessionId);
        bool AddSession(ExamSession session);
        bool UpdateSession(ExamSession session);
        bool DeleteSession(int sessionId);
    
    }
}
