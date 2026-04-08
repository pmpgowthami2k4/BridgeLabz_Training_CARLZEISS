using Dapper;
using ModelLayer.Entities;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using DataBaseLayer.Interfaces;

namespace DataBaseLayer.Repositories
{
    public class StudentDL : IStudentDL
    {
        private readonly string connectionString;

        public StudentDL(IConfiguration config)
        {
            connectionString = config.GetConnectionString("DefaultConnection");
        }

        public bool AddStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Students (Name, Email) VALUES (@Name, @Email)";
                int result = connection.Execute(query, student);
                return result > 0;
            }
        }
    }
}
