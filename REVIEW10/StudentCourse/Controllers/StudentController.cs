using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Interfaces;
using ModelLayer.DTOs;

namespace StudentCourse.Controllers
{
    [ApiController]
    [Route("student")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentBL studentBL;

        public StudentController(IStudentBL studentBL)
        {
            this.studentBL = studentBL;
        }


        //register a new student
        [HttpPost]
        public IActionResult AddStudent(AddStudentDTO dto)
        {
            bool result = studentBL.AddStudent(dto);

            if (result)
                return Ok("Student Added Successfully");

            return BadRequest("Failed to add student");
        }
    }
}
