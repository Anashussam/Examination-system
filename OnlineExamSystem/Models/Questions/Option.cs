using OnlineExamSystem.Models.Questions;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineExamSystem.Models.Questions
{
    public class Option
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OptionID { get; set; }


        public int QuestionID { get; set; }

        [Required]
        public string OptionText { get; set; }
        public bool IsCorrect { get; set; }

        public Question Question { get; set; }
    }

}

