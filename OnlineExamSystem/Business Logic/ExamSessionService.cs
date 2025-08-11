using OnlineExamSystem.Data;
using OnlineExamSystem.Models.Exams;

namespace OnlineExamSystem.Business_Logic
{
    public class ExamSessionService : IExamSessionService
    {
        private readonly IExamSessionRepository _sessionRepository;
        public ExamSessionService(IExamSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public IEnumerable<ExamSession> GetAllSessions() => _sessionRepository.GetAllSessions();

        public ExamSession GetSessionById(int sessionId) => _sessionRepository.GetSessionById(sessionId);

        public bool AddSession(ExamSession session)
        {
            _sessionRepository.AddSession(session);
            return _sessionRepository.SaveChanges();
        }
        public bool UpdateSession(ExamSession session)
        {
            _sessionRepository.UpdateSession(session);
            return _sessionRepository.SaveChanges();
        }
        public bool DeleteSession(int sessionId)
        {
            _sessionRepository.DeleteSession(sessionId);
            return _sessionRepository.SaveChanges();
        }
    }
}
