using Dapper;
using ModelLayer.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using DataBaseLayer.Interfaces;

namespace DataBaseLayer.Repositories
{
    public class CourseDL : ICourseDL
    {
        private readonly string connectionString;

        public CourseDL(IConfiguration config)
        {
            connectionString = config.GetConnectionString("DefaultConnection");
        }

        public bool AddCourse(Course course)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO dbo.Courses (CourseName, Duration) VALUES (@CourseName, @Duration)";
                int result = connection.Execute(query, course);
                return result > 0;
            }
        }
    }
}
