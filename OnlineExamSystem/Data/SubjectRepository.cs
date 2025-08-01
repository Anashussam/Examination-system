using Microsoft.EntityFrameworkCore;


using OnlineExamSystem.Models.Subjects;





namespace OnlineExamSystem.Data
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ExamDbContext _context;
        public SubjectRepository(ExamDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Subject> GetAll()
        {
            return _context.Subjects
                .Include(s => s.Exams)
                .Include(s => s.createdByUser) 
                .ToList();
        }

        public Subject GetById(int id)
        {
            return _context.Subjects
                .Include(s => s.Exams)
                .Include(s => s.createdByUser) 
                .FirstOrDefault(s => s.SubjectID == id);
        }

        public void Add(Subject subject)
        {
            _context.Subjects.Add(subject);
        }
        public void Update(Subject subject)
        {
            _context.Subjects.Update(subject);
        }
        public void Delete(int id)
        {
            var subject = GetById(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
            }
        }

        public bool Exists(int id)
        {
            return _context.Subjects.Any(s => s.SubjectID == id);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
