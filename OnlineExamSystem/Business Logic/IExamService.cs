using OnlineExamSystem.Models.DTOs.Exams;

namespace OnlineExamSystem.Business_Logic
{
    public interface IExamService
    {
        IEnumerable<ExamResponseDto> GetAllExams();
        ExamResponseDto GetExamById(int examId);
        bool AddExam(ExamCreateDto examCreateDto);
        bool Delete(int id);
    }
}
