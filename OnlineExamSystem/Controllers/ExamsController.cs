using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using OnlineExamSystem.Business_Logic;
using OnlineExamSystem.Models.DTOs.Exams;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace OnlineExamSystem.Controllers
{
    [Route("api/Exams")]
    [ApiController]
    public class ExamsController : ControllerBase
    {

        private readonly IExamService _examService;
        public ExamsController(IExamService examService)
        {
            _examService = examService;
        }

        /// <summary>
        /// Get All Exams
        /// </summary>
        [HttpGet("GetAllExams")]
        public IActionResult GetAllExams()
        {
            try
            {
                var exams = _examService.GetAllExams();
                if (exams == null || !exams.Any())
                    return NoContent();
                return Ok(exams);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500, title: "Error Retrieving Exams");
            }
        }

        /// <summary>
        /// Get Exam By Id
        /// </summary>
        [HttpGet("GetExamById/{examId}")]
        public IActionResult GetExamById(int examId)
        {
            try
            {
                var exam = _examService.GetExamById(examId);
                if (exam == null)
                    return NotFound();
                return Ok(exam);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500, title: "Error Retrieving Exam");
            }
        }
        /// <summary>
        /// Add Exam
        /// </summary>
        [HttpPost("AddExam")]
        public IActionResult AddExam([FromBody] ExamCreateDto examCreateDto)
        {
            if (examCreateDto == null)
                return BadRequest("Exam data is null");
            try
            {
                var result = _examService.AddExam(examCreateDto);
                if (!result)
                    return BadRequest("Failed to add exam. Please check the provided data.");
                return Ok(new { message = "Exam added successfully" });
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500, title: "Error Adding Exam");
            }
        }
        /// <summary>
        /// Delete Exam
        /// </summary>
        [HttpDelete("DeleteExam/{id}")]
        public IActionResult DeleteExam(int id)
        {
            try
            {
                var result = _examService.Delete(id);
                if (!result)
                    return NotFound($"Exam with ID {id} not found.");
                return Ok(new { message = "Exam deleted successfully" });
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500, title: "Error Deleting Exam");
            }
        }
    }
}
