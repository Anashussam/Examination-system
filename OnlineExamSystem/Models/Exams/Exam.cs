//using OnlineExamSystem.Models.Exams;
//using OnlineExamSystem.Models.Subjects;

//namespace OnlineExamSystem.Models.Exams
//{
//    public class Exam
//    {
//        public int ExamID { get; set; }
//        public int SubjectID { get; set; }
//        public int CreatedBy { get; set; }
//        public string Title { get; set; }
//        public string Description { get; set; }

//        public int Duration { get; set; } // in minutes
//        public string Diffficulty { get; set; } // Easy, Medium, Hard
//        public DateTime CreatedAt { get; set; }
//        public Subject Subject { get; set; }
//        public User CreatedByUser { get; set; }
//    }
//}
namespace OnlineExamSystem.Models.Exams
{
    public class Exam
    {
        public int ExamID { get; set; }

        // Foreign Keys
        public int SubjectID { get; set; }
        public int CreatedBy { get; set; }

        // Properties
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; } // in minutes
        public string Diffficulty { get; set; } // Easy, Medium, Hard
        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public OnlineExamSystem.Models.Subjects.Subject Subject { get; set; }
        public User CreatedByUser { get; set; }
    }
}
