namespace OnlineExamSystem.Models.DTOs
{
    public class ResultReadDto
    {
        public int ResultID { get; set; }

        public int TotalScore { get; set; }
        public int CorrectAnswers { get; set; }
        public int WrongAnswers { get; set; }
        public decimal Percentage { get; set; }
        public bool Passed { get; set; }
    }
}
