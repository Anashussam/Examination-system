namespace OnlineExamSystem.Models
{
    public class ExamSession
    {
        public int SessionID { get; set; }
        public int ExamID { get; set; }
        public int UserID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; } // e.g., "In Progress", "Completed", "Expired"

        public Exams Exams { get; set; } // Navigation property to the Exam
        public User User { get; set; } // Navigation property to the User   
        public ICollection<Answer> Answers { get; set; } // Collection of answers for the session
        public Result Result { get; set; } // Collection of results for the session
    }
}
