using System.Collections.Generic;
using System.Linq;
using REV5.Models;

namespace REV5.Services
{
    public class EmployeeManager
    {
        private List<Employee> employees= new List<Employee>();

        public void AddEmployee(Employee emp)
        {
            employees.Add(emp);
        }

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }


        public Employee SearchById(int id)
        {
            foreach (Employee employee in employees)
            {
                if (employee.Id == id)
                {
                    return employee;
                }
            }
            return null;
        }


        //Search Employee by Id
        //public int SearchById(int id)
        //{
        //    return employees.FirstOrDefault(e => e.Id == id);
        //}



        //salary Expense
        public double TotalSalaryExpense()
        {
            return employees.Sum(e => e.CalculateSalary());
        }

        //average Salary
        public double AverageSalary()
        {
            if (employees.Count == 0)
                return 0;

            return employees.Average(e => e.CalculateSalary());
        }

        //Highest Paid Employee
  
        public Employee HighestPaidEmployee()
        {
            if (employees.Count == 0)
                return null;

            Employee highestPaid=employees[0];

            foreach (Employee employee in employees)
            {
                if (employee.CalculateSalary()> highestPaid.CalculateSalary())
                {
                    highestPaid = employee;
                }
            }

            return highestPaid;

        }

        //Group By Dept
        public IEnumerable<IGrouping<string, Employee>> GroupByDepartment()
        {
            return employees.GroupBy(e => e.Department);
        }
        
        // First Duplicate Email
        public string FindFirstDuplicateEmail()
        {
            HashSet<string> seen = new HashSet<string>();

            foreach (var emp in employees)
            {
                if (!seen.Add(emp.Email))
                    return emp.Email;
            }

            return null;
        }
    }
}