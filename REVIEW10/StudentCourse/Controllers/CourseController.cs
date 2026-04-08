using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Interfaces;
using ModelLayer.DTOs;

namespace StudentCourse.Controllers
{
    [ApiController]
    [Route("course")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseBL courseBL;

        public CourseController(ICourseBL courseBL)
        {
            this.courseBL = courseBL;
        }


        //to add a new course
        [HttpPost]
        public IActionResult AddCourse(AddCourseDTO dto)
        {
            bool result = courseBL.AddCourse(dto);

            if (result)
                return Ok("Course added successfully");

            return BadRequest("Failed to add course");
        }
    }
}
