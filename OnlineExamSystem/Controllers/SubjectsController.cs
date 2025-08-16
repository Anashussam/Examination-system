using Microsoft.AspNetCore.Mvc;
using OnlineExamSystem.Business_Logic.Interfaces;
using OnlineExamSystem.Models.Subjects;
using OnlineExamSystem.Models.DTOs.Subjects;
using System.Security.Claims;
using OnlineExamSystem.Data;
using Microsoft.EntityFrameworkCore;
using OnlineExamSystem.Models.Exams;


namespace OnlineExamSystem.Controllers
{
    
        [Route("api/Subjects")]
        [ApiController]
        public class SubjectsController : ControllerBase
        {
            private readonly ISubjectService _subjectService;
        private readonly ISubjectRepository _subjectRepository;
        /// <summary>
        /// Constructor for SubjectsController.
        /// </summary>
        /// <param name="subjectService">Service for managing subjects.</param>
        /// 
        public SubjectsController(ISubjectService subjectService, ISubjectRepository subjectRepository)
        {
            _subjectService = subjectService;
            _subjectRepository = subjectRepository;
        }
        


            /// <summary>
            /// Get all subjects from the database.
            /// </summary>       
        [HttpGet("GetAllSubjects")]
        public IActionResult GetAllSubjects()
        {
            try
            {
                var subjects = _subjectService.GetAll();
                if (!subjects.Any())
                    return NoContent();

                
                var response = subjects.Select(s => new SubjectResponseDto
                {
                    SubjectID = s.SubjectID,
                    SubjectName = s.SubjectName,
                    Code = s.Code,
                    Status = s.Status,
                    CreatedBy=s.CreatedBy 
                    //GreatedByName = s.createdByUser?.Name ?? "Unknown"
                });
                    
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500, title: "Error Retrieving Subjects");
            }
        }

        /// <summary>
        /// Get a subject by its ID.
        /// </summary>
        [HttpGet("GetSubjectById/{id}")]
            public IActionResult GetById(int id)
            {
                try
                {
                    var subjectId = _subjectService.GetById(id);
                    if (subjectId == null)
                        return NotFound($"Subject with ID {id} not found.");
                   
                    var response = new SubjectResponseDto
                    {
                        SubjectID = subjectId.SubjectID,
                        SubjectName = subjectId.SubjectName,
                        Code = subjectId.Code,
                        Status = subjectId.Status,
                        CreatedBy=subjectId.CreatedBy
                    };
                return Ok(response);
            }
                catch (Exception ex)
                {
                    return Problem(detail: ex.Message, statusCode: 500, title: "Error Retrieving Subject");
                }
            }
            /// <summary>
            /// Get Add Subject.
            /// <summary>
            [HttpPost("AddSubject")]
        public IActionResult Add([FromBody] SubjectCreateDto dto)
        {
            
            if (dto == null)
                return BadRequest("Input cannot be null.");

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                // التحقق من أن CreatedBy موجود وله قيمة صالحة
                if (dto.CreatedBy <= 0)
                    return BadRequest("Invalid CreatedBy value");

                //var subject = new Subject
                //{
                //    SubjectName = dto.SubjectName,
                //    Code = dto.Code,
                //    Status = dto.Status,
                //    CreatedBy = dto.CreatedBy
                //};
                var subject = new Subject
                {
                    SubjectName = dto.SubjectName,
                    Code = dto.Code,
                    Status = dto.Status,
                    CreatedBy = dto.CreatedBy,
                };

                _subjectRepository.Add(subject);

                // حفظ التغييرات مباشرة مع التحقق من النجاح
                if (!_subjectRepository.Save())
                {
                    return StatusCode(500, "Failed to save subject to database");
                }

                var response = new SubjectResponseDto
                {
                    SubjectID = subject.SubjectID, // يجب أن يكون SubjectID موجودًا في الكائن subject بعد الحفظ
                    SubjectName = subject.SubjectName,
                    Code = subject.Code,
                    Status = subject.Status,
                    CreatedBy = subject.CreatedBy
                };
                //return CreatedAtAction(nameof(GetById), new { id = subject.SubjectID }, response);
               return CreatedAtAction(nameof(GetById), new { id = response.SubjectID }, response);
            }
            catch (DbUpdateException dbEx)
            {
                // معالجة أخطاء قاعدة البيانات بشكل خاص
                return Problem(
                    detail: "Database error: " + dbEx.InnerException?.Message,
                    statusCode: 500,
                    title: "Database Error");
            }
            catch (Exception ex)
            {
                return Problem(
                    detail: ex.Message,
                    statusCode: 500,
                    title: "Error Adding Subject");
            }

        }

        /// <summary>
        /// Update a subject.
        /// </summary>
      
        [HttpPut("UpdateSubject/{id}")]
        public IActionResult Update(int id, [FromBody] SubjectUpdateDto dto)
        {
            if (dto == null || dto.SubjectID != id)
                return BadRequest("Invalid data or ID mismatch.");

            try
            {
                var subject = new Subject
                {
                    SubjectID = dto.SubjectID,
                    SubjectName = dto.SubjectName,
                    Code = dto.Code,
                    Status = dto.Status,
                    CreatedBy = dto.CreatedBy
                };

                var updated = _subjectService.Update(subject);
                if (!updated)
                    return NotFound($"Subject with ID {id} not found.");

                return Ok(new { message = "Subject updated successfully" });
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500, title: "Error Updating Subject");
            }
        }

        /// <summary>
        /// Delete a subject by its ID.
        /// </summary>
        [HttpDelete("DeleteSubject/{id}")]
            public IActionResult Delete(int id)
            {
                try
                {
                    var deleted = _subjectService.Delete(id);
                    if (!deleted)
                        return NotFound($"Subject with ID {id} not found.");

                return NoContent();
            }
            catch (Exception ex)
                {
                    return Problem(detail: ex.Message, statusCode: 500, title: "Error Deleting Subject");
                }
            }

        }
}

