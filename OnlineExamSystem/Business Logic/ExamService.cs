using OnlineExamSystem.Data;
using OnlineExamSystem.Business_Logic;
using OnlineExamSystem.Models.DTOs.Exams;
using OnlineExamSystem.Models.Exams;


namespace OnlineExamSystem.Business_Logic
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISubjectRepository _subjectRepository;
        public ExamService(IExamRepository examRepository, IUserRepository userRepository, ISubjectRepository subjectRepository)
        {
            _examRepository = examRepository;
            _userRepository = userRepository;
            _subjectRepository = subjectRepository;
        }

        public bool AddExam(ExamCreateDto dto)
        {
           if(!_userRepository.Exists(dto.CreatedBy) || !_subjectRepository.Exists(dto.SubjectID))
                return false;

           var exam = new Exam
           {
               SubjectID = dto.SubjectID,
               CreatedBy = dto.CreatedBy,
               Title = dto.Title,
               Description = dto.Description,
               Duration = dto.Duration,
               Diffficulty = dto.Diffficulty,
               CreatedAt = DateTime.Now,
               Subject = dto.SubjectName != null ? _subjectRepository.GetById(dto.SubjectID) : null



           };
            _examRepository.Add(exam);
            return _examRepository.Save();
        }

        public bool Delete(int id)
        {
            var exam = _examRepository.GetById(id);
            if (!_examRepository.Exists(id))
                return false;
          
            _examRepository.Delete(exam);
            return _examRepository.Save();
        }

        public IEnumerable<ExamResponseDto> GetAllExams()
        {
            var exams = _examRepository.GetAll();
            return exams.Select(e => new ExamResponseDto
            {
                ExamID = e.ExamID,
                Title = e.Title,
                Description = e.Description,
                Duration = e.Duration,
                Diffficulty = e.Diffficulty,
                SubjectName = e.Subject?.SubjectName,
                CreatedByName = e.CreatedByUser?.Name
            });
        }
        public ExamResponseDto GetExamById(int id)
        {
            var exam = _examRepository.GetById(id);
            if (exam == null)
                return null;
            return new ExamResponseDto
            {
                ExamID = exam.ExamID,
                Title = exam.Title,
                Description = exam.Description,
                Duration = exam.Duration,
                Diffficulty = exam.Diffficulty,
                SubjectName = exam.Subject?.SubjectName,
                CreatedByName = exam.CreatedByUser?.Name
            };
        }
    }
}
