namespace REV5.Models
{
    public class FullTimeEmployee : Employee
    {


        public double MonthlySalary { get; set; }

        public override double CalculateSalary()
        {
            return MonthlySalary;
        }
    }
}