using OnlineExamSystem.Models.Exams;

namespace OnlineExamSystem.Models.Questions
{
    public class Question
    {
        public int QuestionID { get; set; }
        public int ExamID { get; set; }
        public string QuestionText { get; set; }
        public int Marks { get; set; }

        public Exam Exams { get; set; }
       // public ICollection<Option> Options { get; set; }
    }

}
