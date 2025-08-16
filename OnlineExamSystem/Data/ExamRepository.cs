using Microsoft.EntityFrameworkCore;
using OnlineExamSystem.Models.Exams;

namespace OnlineExamSystem.Data
{
    public class ExamRepository : IExamRepository
    {
        private readonly ExamDbContext _context;
        public ExamRepository(ExamDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Exam> GetAll()
        {
            //return _context.Exams.ToList();\
            return _context.Exams
                .Include(e => e.Subject)
                .Include(e => e.CreatedByUser)
                .ToList();
        }
        public Exam GetById(int id)
        {
            //return _context.Exams.FirstOrDefault(e => e.ExamID == id);
            return _context.Exams
               .Include(e => e.Subject)
               .Include(e => e.CreatedByUser)
               .FirstOrDefault(e => e.ExamID == id);
          
        }
        public void Add(Exam exam)
        {
            _context.Exams.Add(exam);
        }
        public void Update(Exam exam)
        {
            _context.Exams.Update(exam);
        }
        public void Delete(Exam exam)
        {
            _context.Exams.Remove(exam);
        }
        public bool Exists(int id)
        {
            return _context.Exams.Any(e => e.ExamID == id);
        }
        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

    }
}
