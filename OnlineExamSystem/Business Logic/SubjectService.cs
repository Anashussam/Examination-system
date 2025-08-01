using OnlineExamSystem.Data;
using OnlineExamSystem.Models.Subjects;

using OnlineExamSystem.Business_Logic.Interfaces;

namespace OnlineExamSystem.Business_Logic
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public IEnumerable<Subject> GetAll()
        {
            return _subjectRepository.GetAll();
        }

        public Subject GetById(int id)
        {
            return _subjectRepository.GetById(id);
        }

        public bool Add(Subject subject)
        {
            if (_subjectRepository.Exists(subject.SubjectID))
                return false;

            _subjectRepository.Add(subject);
            return _subjectRepository.Save();

        }
        public bool Update(Subject subject)
        {
            if (!_subjectRepository.Exists(subject.SubjectID))
                return false;
            _subjectRepository.Update(subject);
            return _subjectRepository.Save();
        }

        public bool Delete(int id)
        {
            if (!_subjectRepository.Exists(id))
                return false;
            _subjectRepository.Delete(id);
            return _subjectRepository.Save();
        }

    }

}
