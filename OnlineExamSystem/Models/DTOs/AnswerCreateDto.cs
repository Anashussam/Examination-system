namespace OnlineExamSystem.Models.DTOs
{
    public class AnswerCreateDto
    {
       

        public int QuestionId { get; set; }

      

        public int OptionId { get; set; }
    }

    public class AnswerReadDto
    {
        public int AnswerId { get; set; }

        public int QuestionId { get; set; }
      
        public int OptionId { get; set; }
        
        public bool IsCorrect { get; set; }
    }
}
