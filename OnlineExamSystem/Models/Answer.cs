namespace OnlineExamSystem.Models
{
    public class Answer
    {
        public int AnswerID { get; set; } // Unique identifier for the answer
        public int QuestionID { get; set; } // Foreign key to the Question
        public int SessionID { get; set; } // Foreign key to the ExamSession
        public int optionID { get; set; } // Foreign key to the Option (if applicable)
        public bool IsCorrect { get; set; } // Indicates if the answer is correct
        public Question Question { get; set; } // Navigation property to the Question
        public ExamSession ExamSession { get; set; } // Navigation property to the ExamSession
        public Option Option { get; set; } // Navigation property to the Option (if applicable)
    }
}
