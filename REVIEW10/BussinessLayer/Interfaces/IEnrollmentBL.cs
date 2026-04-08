using System;
using ModelLayer.DTOs;
using ModelLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IEnrollmentBL
    {
        bool Enroll(EnrollDTO dto);
        List<Course> GetCourses(int studentId);
        List<Student> GetStudents(int courseId);
    }
}
