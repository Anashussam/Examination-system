namespace OnlineExamSystem.Models.Exams
{
    public class Result
    {
       public int ResultID { get; set; }
        //public int SessionID { get; set; } // Foreign key to the ExamSession
        public int TotalScore { get; set; } // Total marks scored in the exam
        public int CorrectAnswers { get; set; } // Number of correct answers    
        public int WrongAnswers { get; set; } // Number of wrong answers

        public decimal Percentage { get; set; } // Percentage of correct answers
        public bool passed { get; set; } // Indicates if the user passed the exam
        //public ExamSession Session { get; set; } // Navigation property to the ExamSession
    }
}
