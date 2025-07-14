namespace OnlineExamSystem.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        public int ExamID { get; set; }
        public string QuestionText { get; set; }
      
        public int Marks { get; set; }
   
        public Exams Exam { get; set; } // Navigation property to the Exam
        public ICollection<Option> Options { get; set; } // Collection of options for the question
    }
}
