using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Interfaces;
using ModelLayer.DTOs;

namespace StudentCourse.Controllers
{

    
    [ApiController]
    [Route("enroll")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentBL enrollmentBL;

        public EnrollmentController(IEnrollmentBL enrollmentBL)
        {
            this.enrollmentBL = enrollmentBL;
        }

        // Enroll student in course
        [HttpPost]
        public IActionResult Enroll(EnrollDTO dto)
        {
            bool result = enrollmentBL.Enroll(dto);

            if (result)
                return Ok("Student enrolled successfully");

            return BadRequest("Enrollment failed");
        }

        // Get all courses of a student
        [HttpGet("students/{id}/courses")]
        public IActionResult GetCourses(int id)
        {
            var courses = enrollmentBL.GetCourses(id);
            return Ok(courses);
        }

        // Get all students of a course
        [HttpGet("courses/{id}/students")]
        public IActionResult GetStudents(int id)
        {
            var students = enrollmentBL.GetStudents(id);
            return Ok(students);
        }
    }
}
