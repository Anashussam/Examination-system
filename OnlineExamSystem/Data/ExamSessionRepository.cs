using Microsoft.EntityFrameworkCore;
using OnlineExamSystem.Models.Exams;

namespace OnlineExamSystem.Data
{
    public class ExamSessionRepository : IExamSessionRepository
    {
        private readonly ExamDbContext _context;
        public ExamSessionRepository(ExamDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ExamSession> GetAllSessions()
        {
            return _context.ExamSessions.ToList();
        }
        public ExamSession GetSessionById(int sessionId)
        {
            return _context.ExamSessions.FirstOrDefault(es => es.SessionID == sessionId);
        }
        public void AddSession(ExamSession session)
        {
            _context.ExamSessions.Add(session);
        }
        public void UpdateSession(ExamSession session)
        {
            _context.ExamSessions.Update(session);
        }
        public void DeleteSession(int sessionId)
        {
            var session = _context.ExamSessions.Find(sessionId);
            if (session != null)
            {
                _context.ExamSessions.Remove(session);
            }
        }
        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
