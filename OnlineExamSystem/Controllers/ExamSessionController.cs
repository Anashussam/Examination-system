//using Microsoft.AspNetCore.Mvc;
//using OnlineExamSystem.Business_Logic;
//using OnlineExamSystem.Models.DTOs;
//using OnlineExamSystem.Models.Exams;

//namespace OnlineExamSystem.Controllers
//{
//    [Route("api/ExamSessions")]
//    [ApiController]
//    public class ExamSessionController : ControllerBase
//    {
//        private readonly IExamSessionService _examSessionService;
//        public ExamSessionController(IExamSessionService examSessionService)
//        {
//            _examSessionService = examSessionService;
//        }
//        [HttpGet]
//        public IActionResult GetAllExamSessions()
//        {
//            var examSessions = _examSessionService.GetAllSessions();
//            return Ok(examSessions);
//        }
//        [HttpGet("{id}")]
//        public IActionResult GetExamSessionById(int id)
//        {
//            var examSession = _examSessionService.GetSessionById(id);
//            if (examSession == null)
//            {
//                return NotFound();
//            }
//            return Ok(examSession);
//        }
//        [HttpPost]
//        public IActionResult CreateExamSession([FromBody] ExamSessionDto dto)
//        {
//            try
//            {
//                var examSession = new ExamSession
//                {
//                    ExamID = dto.ExamID,
//                    UserID = dto.UserID,
//                    StartTime = dto.StartTime,
//                    Status = dto.Status
//                };
//                if (_examSessionService.AddSession(examSession))
//                    return CreatedAtAction(nameof(GetExamSessionById), new { id = examSession.SessionID }, examSession);

//                return Ok(new { message = "Exam session created successfully", sessionId = examSession.SessionID });
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal server error: {ex.Message}");
//            }

//        }

//        [HttpPut("{id}")]
//        public IActionResult UpdateExamSession(int id, [FromBody] ExamSessionDto dto)
//        {
//            var existing = _examSessionService.GetSessionById(id);
//            if (existing == null)
//            {
//                return NotFound();
//            }
//            existing.ExamID = dto.ExamID;
//            existing.UserID = dto.UserID;
//            existing.StartTime = dto.StartTime;
//            existing.EndTime = dto.EndTime;
//            existing.Status = dto.Status;

//            if (_examSessionService.UpdateSession(existing))
//            {
//                return StatusCode(500, "Error updating ExamSession");
//            }
//            return Ok(existing);
//        }
//        [HttpDelete("{id}")]
//        public IActionResult DeleteExamSession(int id)
//        {
//            var existing = _examSessionService.GetSessionById(id);
//            if (existing == null)
//            {
//                return NotFound();
//            }
//            if (_examSessionService.DeleteSession(id))
//            {
//                return NoContent();
//            }
//            return StatusCode(500, "Error deleting ExamSession");
//        }

//    }
//}
