using BusinessLayer.Interfaces;
using DataBaseLayer.Interfaces;
using ModelLayer.DTOs;
using ModelLayer.Entities;

namespace BusinessLayer.Services
{
    public class CourseBL : ICourseBL
    {
        private readonly ICourseDL courseDL;

        public CourseBL(ICourseDL courseDL)
        {
            this.courseDL = courseDL;
        }

        public bool AddCourse(AddCourseDTO dto)
        {
            Course course = new Course
            {
                CourseName = dto.CourseName,
                Duration = dto.Duration
            };

            return courseDL.AddCourse(course);
        }
    }
}
