using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using OnlineExamSystem.Business_Logic;
using OnlineExamSystem.Models.DTOs;
using OnlineExamSystem.Models.Questions;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace OnlineExamSystem.Controllers
{
    [Route("api/options")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly IOptionService _optionService;
        public OptionController(IOptionService optionService)
        {
            _optionService = optionService;
        }
        [HttpGet("question/{questionId}")]
        public IActionResult GetOptionsByQuestionId(int questionId)
        {
            var options = _optionService.GetOptionsByQuestionId(questionId);
            
            return Ok(options);
        }
        [HttpGet("{optionId}")]
        public IActionResult GetOption(int optionId)
        {
            var option = _optionService.GetOptionById(optionId);
            if (option == null)
                return NotFound();
            return Ok(option);
        }
        [HttpPost]
        public IActionResult AddOption([FromBody] OptionDto dto)
        {
            if (dto == null)
                return BadRequest("Option cannot be null");
            var option = new Option
            {
                QuestionID = dto.QuestionID,
                OptionText = dto.OptionText,
                IsCorrect = dto.IsCorrect
            };
            var result=_optionService.AddOption(option);
            if (!result == null)
                return StatusCode(500,"Failed to add option");
            return Ok(option);
        }

        [HttpPut("{optionId}")]
        public IActionResult UpdateOption(int optionId, [FromBody] OptionDto dto)
        {
           var existing = _optionService.GetOptionById(optionId);
            if (existing == null)
                return NotFound("Option not found");
            if (dto == null)
                return BadRequest("Option cannot be null");
            existing.OptionText = dto.OptionText;
            existing.IsCorrect = dto.IsCorrect;
          
            var result = _optionService.UpdateOption(existing);
            if (!result)
                return StatusCode(500, "Failed to update option");
            return Ok(existing);
        }
        [HttpDelete("{optionId}")]
        public IActionResult DeleteOption(int optionId)
        {
            var existing = _optionService.GetOptionById(optionId);
            if (existing == null)
                return NotFound("Option not found");
            var result = _optionService.DeleteOption(optionId);
            if (!result)
                return StatusCode(500, "Failed to delete option");
            return Ok(new { message = "Option deleted successfully." });
        }

    }
}
