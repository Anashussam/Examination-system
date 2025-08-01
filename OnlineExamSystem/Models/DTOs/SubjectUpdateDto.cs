namespace OnlineExamSystem.Models.DTOs.Subjects
{
    public class SubjectUpdateDto
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; }
        public int CreatedBy { get; set; }
    }
}
