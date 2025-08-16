using OnlineExamSystem.Models.Exams;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineExamSystem.Models.Subjects
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectID { get; set; }
        public int CreatedBy { get; set; }

        public string SubjectName { get; set; }
        public string Code { get; set; }

        public bool Status { get; set; }

        public User createdByUser { get; set; }
        public ICollection<Exam> Exams { get; set; } 
    }
}
