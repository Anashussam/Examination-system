using OnlineExamSystem.Models.Questions;
using OnlineExamSystem.Models.Exams;

namespace OnlineExamSystem.Models.Exams
{
    public class Answer
    {
        public int AnswerID { get; set; } 
        public int QuestionID { get; set; } 
        public int OptionID { get; internal set; }
        public bool IsCorrect { get; set; } 
        public Question Question { get; set; }
        public Option Option { get; set; } 
    }
}
