using Microsoft.AspNetCore.Mvc;
using OnlineExamSystem.Business_Logic;
using OnlineExamSystem.Models.DTOs;
using OnlineExamSystem.Models.Questions;
namespace OnlineExamSystem.Controllers
{
 

    [ApiController]
    [Route("api/questions")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _service;

        public QuestionsController(IQuestionService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddQuestion([FromBody] QuestionCreateDto dto)
        {
            if (dto == null)
                return BadRequest("Question data is missing.");

            if (!_service.Exists(dto.ExamID))
                return NotFound("Exam not found.");

            var question = new Question
            {
                ExamID = dto.ExamID,
                QuestionText = dto.QuestionText,
                Marks = dto.Marks
            };

            var success = _service.AddQuestion(question);

            if (!success)
                return StatusCode(500, "Failed to add question.");

            return CreatedAtAction(nameof(GetQuestionById), new { id = question.QuestionID }, question);
        }

        [HttpGet("{id}")]
        public IActionResult GetQuestionById(int id)
        {
            var question = _service.GetQuestionById(id);
            if (question == null)
                return NotFound("Question not found.");

            return Ok(question);
        }

        [HttpGet]
        public IActionResult GetAllQuestions()
        {
            var questions = _service.GetAllQuestions();
            return Ok(questions);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion(int id)
        {
            var existingQuestion = _service.GetQuestionById(id);

            if (existingQuestion == null)
                return NotFound($"Question with ID {id} not found.");

            var result = _service.DeleteQuestion(id);

            if (!result)
                return StatusCode(500, "Failed to delete the question.");

            return Ok(new { message = "Question deleted successfully." });
        }
        [HttpPut("{id}")]
        public IActionResult UpdateQuestion(int id, [FromBody] QuestionCreateDto dto)
        {
            if (dto == null)
                return BadRequest("Question data is missing.");

            if (!_service.Exists(dto.ExamID))
                return NotFound("Exam not found.");

            var existingQuestion = _service.GetQuestionById(id);
            if (existingQuestion == null)
                return NotFound($"Question with ID {id} not found.");

            existingQuestion.QuestionText = dto.QuestionText;
            existingQuestion.Marks = dto.Marks;
            existingQuestion.ExamID = dto.ExamID;

            var result = _service.UpdateQuestion(existingQuestion);

            if (!result)
                return StatusCode(500, "Failed to update the question.");

            return Ok(new { message = "Question updated successfully." });
        }


    }

}
