using Microsoft.AspNetCore.Mvc;
using OnlineExamSystem.Business_Logic;
using OnlineExamSystem.Models.DTOs;

namespace OnlineExamSystem.Controllers
{
    [Route("api/Result")]
    [ApiController]
    public class ResultController:ControllerBase
    {
        private readonly IResultService _service;
        public ResultController(IResultService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAllResults()
        {
            var results = _service.GetAll();
            if (results == null || !results.Any())
            {
                return NotFound("No results found.");
            }
            return Ok(results);
        }
        [HttpGet("{id}")]
        public IActionResult GetResultById(int id)
        {
            var result = _service.GetById(id);
            if (result == null)
            {
                return NotFound($"Result with ID {id} not found.");
            }
            return Ok(result);
        }
        [HttpPost]
       public IActionResult Create(ResultDto dto)
        {
            var created = _service.Create(dto);
            if (created == null)
            {
                return BadRequest("Failed to create result.");
            }
            return CreatedAtAction(nameof(GetResultById), new { id = created.ResultID }, created);


        }
        [HttpPut("{id}")]
      public IActionResult UpdateResult(int id, ResultUpdateDto dto)
        {
         var updated = _service.Update(id, dto);
            if (!updated)
            {
                return NotFound($"Result with ID {id} not found.");
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteResult(int id)
        {
            var deleted = _service.Delete(id);
            if (!deleted)
            {
                return NotFound($"Result with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
