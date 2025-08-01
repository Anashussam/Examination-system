using System.ComponentModel.DataAnnotations;

namespace OnlineExamSystem.Models.DTOs.Subjects
{
    public class SubjectCreateDto
    {
        [Required]
        [StringLength(100)]
        public string SubjectName { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        public bool Status { get; set; } = true;

        [Required]
        public int CreatedBy { get; set; }
    }
}
