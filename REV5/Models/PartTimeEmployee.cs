using System.Numerics;
using System.Xml.Linq;
using REV5.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace REV5.Models
{
    public class PartTimeEmployee : Employee
    {
        private string? dept;
        private double rate;
        private int hours;

        public PartTimeEmployee(int id, string? name, string? email, string? phone, string? dept, double rate, int hours) : base()
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            this.dept = dept;
            this.rate = rate;
            this.hours = hours;
        }

        public double HourRate { get; set; }
        public int HoursWorked { get; set; }


        public override double CalculateSalary()
        {
            return HourRate*HoursWorked;
        }

        S
    }
}

//object using emp = new PartTimeEmployee(id, name, email, phone, dept, rate, hours);
//Employee employee = new PartTimeEmployee(id, name, email, phone, dept, rate, hours);
