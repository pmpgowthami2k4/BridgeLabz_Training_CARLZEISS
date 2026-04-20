//Employee
//id 
//Name 
//salary
//deptid
//Date of Joining ( using Joining Get Experience ) 

//Department Table 
//Dept ID
//Dept Name

//Endpoints 
//Get all Employees (id , name salary , deptid, exp ) 
//Get emp by id 
//Post Emp details 
//Put Emp Details 
//Date change 
//Delete 

//Filtering By Name 
//Dept name , salary, experience,  (fresher, intermediate, expert )

using System.Globalization;

namespace REVIEW11.Model


{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int DeptId { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int Experience 
        { 
            get 
            {
                var age = DateTime.Today.Year - DateOfJoining.Year;
                if (DateOfJoining.Date > DateTime.Today.AddYears(-age)) age--;
                return age;
            }
        }
        public Employee(int id, string name, int salary, int deptId, DateTime dateOfJoining)
        {
            Id = id;
            Name = name;
            Salary = salary;
            DeptId = deptId;
            DateOfJoining = dateOfJoining;

            
        }

    }
}
