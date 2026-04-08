using BusinessLayer.Interfaces;
using DataBaseLayer.Interfaces;
using ModelLayer.DTOs;
using ModelLayer.Entities;

namespace BusinessLayer.Services
{
    public class StudentBL : IStudentBL
    {
        private readonly IStudentDL studentDL;

        public StudentBL(IStudentDL studentDL)
        {
            this.studentDL = studentDL;
        }

        public bool AddStudent(AddStudentDTO dto)
        {
            
            Student student = new Student
            {
                Name = dto.Name,
                Email = dto.Email
            };

            return studentDL.AddStudent(student);
        }
    }
}
