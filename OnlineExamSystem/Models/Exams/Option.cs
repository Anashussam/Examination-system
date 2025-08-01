namespace OnlineExamSystem.Models.Exams
{
    public class Option
    {
       public int OptionID { get; set; }

        public int QuestionID { get; set; }
        public string OptionText { get; set; }
        public bool IsCorrect { get; set; } // Indicates if this option is the correct answer

        public Question Question { get; set; } // Navigation property to the Question
    }
}
