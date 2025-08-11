namespace OnlineExamSystem.Models.DTOs
{
    public class QuestionCreateDto
    {
        public int ExamID { get; set; } // Foreign key to the Exam
        public string QuestionText { get; set; } // The text of the question
        public int Marks { get; set; } 
        //public List<OptionDto> Options { get; set; } 
    }
   
}
