////Employee Management &Payroll System — Main Question

////You are developing a backend employee management and payroll system for Carl Zeiss to manage employees, validate data, store records in files, and calculate salaries based on employee type.

////Build the system by implementing the following use cases.

////Use Cases

////Use Case 1 — Abstract Class & Properties

////Create an abstract employee structure with private fields, validated properties using Regex, and a method to calculate salary.

////Use Case 2 — Multiple Employee Types

////Implement multiple employee types:

////Full Time(Monthly salary)

////Part Time(Rate per hour)

////Contract employee

////Use Case 3 — Employee Data Validation

////Validate employee details including name, phone number, and email using Regex.

////Use Case 4 — Employee Storage (Collections / DSA)

////Store and manage employee records using appropriate data structures.

////Use Case 5 — Department Grouping

////Group employees by department (e.g., IT, HR).

////Use Case 6 — Salary Processing & Analysis

////Calculate total salary expenses, find the highest paid employee, and compute the average salary.

////Use Case 7 — Custom Exception Handling

////Create and use custom exceptions for validation and system errors.

////Use Case 8 — File Storage using Stream

////Save and retrieve employee records using file streams.

////Use Case 9 — Searching using Algorithm

////Implement employee searching functionality.

////Use Case 10 — Find First Duplicate Email

////Detect the first duplicate employee email.

using System;
using REV5.Models;
using REV5.Services;
using REV5.Exceptions;

namespace REV5
{
    class EmployeeMain
    {
        static void Main(string[] args)
        {
            EmployeeManager manager = new EmployeeManager();
            FileService fileService = new FileService();

            bool running = true;

            while (running)
            {
                Console.WriteLine("\nEmployee Management & Payroll System  ");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Search Employee by ID");
                Console.WriteLine("4. Salary Analysis");
                Console.WriteLine("5. Group By Dept");
                Console.WriteLine("6. Find First Duplicate Email");
                Console.WriteLine("7. Save to File");
                Console.WriteLine("8. Exit");
                Console.Write("Choose Option: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            AddEmployee(manager);
                            break;

                        case 2:
                            ViewEmployees(manager);
                            break;

                        case 3:
                            Console.Write("Enter ID to search: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            var emp = manager.SearchById(id);

                            if (emp != null)
                                Console.WriteLine($"Found: {emp.Name} - {emp.CalculateSalary()}");
                            else
                                Console.WriteLine("Employee not found.");
                            break;

                        case 4:
                            Console.WriteLine("Total Salary: " + manager.TotalSalaryExpense());
                            Console.WriteLine("Average Salary: " + manager.AverageSalary());

                            var highest = manager.HighestPaidEmployee();
                            if (highest != null)
                                Console.WriteLine("Highest Paid: " + highest.Name);
                            break;

                        case 5:
                            foreach (var group in manager.GroupByDepartment())
                            {
                                Console.WriteLine("\nDepartment: " + group.Key);
                                foreach (var e in group)
                                {
                                    Console.WriteLine(e.Name);
                                }
                            }
                            break;

                        case 6:
                            string duplicate = manager.FindFirstDuplicateEmail();
                            Console.WriteLine("First Duplicate Email: " + duplicate);
                            break;

                        case 7:
                            fileService.SaveToFile("employees.txt", manager.GetAllEmployees());
                            Console.WriteLine("Saved Successfully!");
                            break;

                        case 8:
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Invalid Option.");
                            break;
                    }
                }
                catch (Validation ex)
                {
                    Console.WriteLine("Validation Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("System Error: " + ex.Message);
                }
            }
        }


        //Add Employee 
        static void AddEmployee(EmployeeManager manager)
        {
            Console.WriteLine("\nSelect Employee Type:");
            Console.WriteLine("1.Full Time");
            Console.WriteLine("2.Part Time");
            Console.WriteLine("3.Contract");

            int type = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();

            Console.Write("Enter Department: ");
            string dept = Console.ReadLine();

            Employee emp = null;

            if (type == 1)
            {
                Console.Write("Enter Monthly Salary: ");
                double salary = Convert.ToDouble(Console.ReadLine());

                emp = new FullTimeEmployee
                {
                    Id = id,
                    Name = name,
                    Email = email,
                    Phone = phone,
                    Department = dept,
                    MonthlySalary = salary
                };
            }
            else if (type == 2)
            {
                Console.Write("Enter Hour Rate: ");
                double rate = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Hours Worked: ");
                int hours = Convert.ToInt32(Console.ReadLine());

                //emp = new PartTimeEmployee
                //{
                //    Id = id,
                //    Name = name,
                //    Email = email,
                //    Phone = phone,
                //    Department = dept,
                //    HourRate = rate,
                //    HoursWorked = hours
                //};

                //parametrized const
                emp = new PartTimeEmployee(id, name, email, phone, dept, rate, hours);

            }
            else if (type == 3)
            {
                Console.Write("Enter Contract Amount: ");
                double amount = Convert.ToDouble(Console.ReadLine());

                emp = new ContractEmployee
                {
                    Id = id,
                    Name = name,
                    Email = email,
                    Phone = phone,
                    Department = dept,
                    ContractAmount = amount
                };
            }

            manager.AddEmployee(emp);
            Console.WriteLine("Employee Added Successfully!");
        }

        static void ViewEmployees(EmployeeManager manager)
        {
            var list = manager.GetAllEmployees();

            foreach (var e in list)
            {
                Console.WriteLine($"{e.Id} - {e.Name} - {e.Department} - {e.CalculateSalary()}");
            }
        }

        //Employee employee1 = new PartTimeEmployee
        //{
        //    id = 1,
        //    Name = "Tom",
        //    Email = "Tom@gmail.com",
        //    phone = "9876543210",   
        //    Dept = "eng",
        //    Rate = 300,
        //    hours = 9;
        //    }

        };

}