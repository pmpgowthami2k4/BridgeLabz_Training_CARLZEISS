using BusinessLayer.Interfaces;
using DataBaseLayer.Interfaces;
using ModelLayer.DTOs;
using ModelLayer.Entities;

namespace BusinessLayer.Services
{
    public class EnrollmentBL : IEnrollmentBL
    {
        private readonly IEnrollmentDL enrollmentDL;

        public EnrollmentBL(IEnrollmentDL enrollmentDL)
        {
            this.enrollmentDL = enrollmentDL;
        }

        public bool Enroll(EnrollDTO dto)
        {
            
            return enrollmentDL.EnrollStudent(dto.StudentId, dto.CourseId);
        }

        public List<Course> GetCourses(int studentId)
        {
            return enrollmentDL.GetCoursesByStudent(studentId);
        }

        public List<Student> GetStudents(int courseId)
        {
            return enrollmentDL.GetStudentsByCourse(courseId);
        }
    }
}
