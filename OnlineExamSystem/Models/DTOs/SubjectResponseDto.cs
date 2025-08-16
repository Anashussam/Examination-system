using OnlineExamSystem.Models.Exams;

namespace OnlineExamSystem.Models.DTOs.Subjects
{
    public class SubjectResponseDto
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; }
        public int CreatedBy { get; set; }

        //public string GreatedByName { get; set; }



    }
}
