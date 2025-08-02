namespace OnlineExamSystem.Models.DTOs.Exams
{
    public class ExamResponseDto
    {
        public int ExamID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Diffficulty { get; set; }
        public string SubjectName { get; set; }
        public string CreatedByName { get; set; }
    }
}
