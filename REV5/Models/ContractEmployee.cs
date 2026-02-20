namespace REV5.Models
{
    public class ContractEmployee : Employee
    {
        public double ContractAmount { get; set; }

        public override double CalculateSalary()
        {
            return ContractAmount;
        }
    }
}