namespace OnlineExamSystem.Models
{
    public class Exams
    {
        public int ExamID { get; set; }
        public int SubjectID { get; set; }
        public int CreatedBy { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public int Duration { get; set; } // in minutes
        public string Diffficulty { get; set; } // Easy, Medium, Hard
        public DateTime CreatedAt { get; set; }
        public Subject Subject { get; set; }
        public User CreatedByUser { get; set; }
    }
}
