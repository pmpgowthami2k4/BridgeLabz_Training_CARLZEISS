using System.Text.RegularExpressions;
using REV5.Exceptions;

namespace REV5.Models
{
    public abstract class Employee
    {
        private string name;
        private string email;
        private string phone;


        public int Id {get;set; }
        public string Department {get;set; }

        public string Name
        {
            get { return name;}

            //string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        set
            {
                if (!Regex.IsMatch(value, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                    throw new Validation("Invalid Name!");
                name = value;
            }
        }

        public string Email
        {
            get { return email;}
            set
            {
                if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    throw new Validation("Invalid Email!");
                email = value;
            }
        }

        public string Phone
        {
            get { return phone;}
            set
            {
                if (!Regex.IsMatch(value, @"^[6-9]\d{9}$"))
                    throw new Validation("Invalid Phone Number!");
                phone = value;
            }
        }

        public abstract double CalculateSalary();
    }
}