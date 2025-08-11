namespace OnlineExamSystem.Models.DTOs
{
    public class ExamSessionDto
    {
        public int SessionID { get; set; }
        public int ExamID { get; set; }
        public int UserID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Status { get; set; }
    }
    public class ExamSessionCreateDto
    {
        public int ExamID { get; set; }
        public int UserID { get; set; }
        public DateTime StartTime { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "In Progress"; // Default status
    }
}
