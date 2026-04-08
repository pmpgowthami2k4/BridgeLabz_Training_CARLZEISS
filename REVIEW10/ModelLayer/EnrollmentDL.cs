using Dapper;
using ModelLayer.Entities;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using DataBaseLayer.Interfaces;

namespace DataBaseLayer.Repositories
{
    public class EnrollmentDL : IEnrollmentDL
    {
        private readonly string connectionString;

        public EnrollmentDL(IConfiguration config)
        {
            connectionString = config.GetConnectionString("DefaultConnection");
        }

        public bool EnrollStudent(int studentId, int courseId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO dbo.Enrollments (StudentId, CourseId) VALUES (@StudentId, @CourseId)";
                int result = connection.Execute(query, new { studentId, courseId });
                return result > 0;
            }
        }

        public List<Course> GetCoursesByStudent(int studentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT c.* 
                    FROM Courses c
                    JOIN Enrollments e ON c.CourseId = e.CourseId
                    WHERE e.StudentId = @StudentId";

                return connection.Query<Course>(query, new { studentId }).ToList();
            }
        }

        public List<Student> GetStudentsByCourse(int courseId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT s.* 
                    FROM Students s
                    JOIN Enrollments e ON s.StudentId = e.StudentId
                    WHERE e.CourseId = @CourseId";

                return connection.Query<Student>(query, new { courseId }).ToList();
            }
        }
    }
}