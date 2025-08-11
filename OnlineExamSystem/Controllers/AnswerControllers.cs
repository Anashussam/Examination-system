using Microsoft.AspNetCore.Mvc;
using OnlineExamSystem.Business_Logic;
using OnlineExamSystem.Data;
using OnlineExamSystem.Models.DTOs;
using OnlineExamSystem.Models.Exams;

namespace OnlineExamSystem.Controllers
{
    [Route("api/Answer")]
    [ApiController]
    public class AnswerControllers : ControllerBase
    {
        private readonly AnswerService _answerService;

        public AnswerControllers(AnswerService answerService)
        {
             _answerService= answerService;
        }

        [HttpPost]
        public IActionResult AddAnswer([FromBody] AnswerCreateDto answerDto)
        {
            if (answerDto == null)
            {
                return BadRequest("Invalid answer data.");
            }
            var answer = new Answer
            {
                //ExamID = answerDto.ExamId,
                QuestionID = answerDto.QuestionId,
                //UserID = answerDto.UserId,
                OptionID = answerDto.OptionId
                
                //Exam = new Exam { ExamID = answerDto.ExamId }
            };
           var result = _answerService.AddAnswer(answer);
            if (!result)
            {
                return StatusCode(500, "An error occurred while saving the answer.");
            }

            return Ok(new { message = "Answer added successfully.",answer });

        }

        [HttpGet]
        public IActionResult GetAnswers()
        {
            var answers = _answerService.GetAllAnswers();
            if (answers == null || !answers.Any())
            {
                return NotFound("No answers found.");
            }
            return Ok(answers);
        }

    }
}
