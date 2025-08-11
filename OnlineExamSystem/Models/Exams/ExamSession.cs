using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineExamSystem.Models.Exams
{
    public class ExamSession
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SessionID { get; set; }
        [Required]
        public int ExamID { get; set; }
        [Required]
        public int UserID { get; set; }
        public DateTime StartTime { get; set; } = DateTime.UtcNow;
        public DateTime? EndTime { get; set; }
        public string Status { get; set; } // e.g., "In Progress", "Completed", "Expired"

        public Exam Exams { get; set; } // Navigation property to the Exam
        public User User { get; set; } // Navigation property to the User   
        

    }
}
