namespace OnlineExamSystem.Models.DTOs.Exams
{
    public class ExamCreateDto
    {
        public int SubjectID { get; set; }
        public int CreatedBy { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Diffficulty { get; set; }
    }
}
