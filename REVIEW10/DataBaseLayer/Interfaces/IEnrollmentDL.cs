using ModelLayer.Entities;

namespace DataBaseLayer.Interfaces
{
    public interface IEnrollmentDL
    {
        bool EnrollStudent(int studentId, int courseId);
        List<Course> GetCoursesByStudent(int studentId);
        List<Student> GetStudentsByCourse(int courseId);
    }
}
