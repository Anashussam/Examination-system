namespace OnlineExamSystem.Models.DTOs
{
    public class OptionDto
    {
        public int QuestionID { get; set; }
        public string OptionText { get; set; }
        public bool IsCorrect { get; set; }
    }

}
