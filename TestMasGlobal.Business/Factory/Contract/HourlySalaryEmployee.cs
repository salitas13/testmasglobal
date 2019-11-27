using TestMasGlobal.Model;

namespace TestMasGlobal.Business.Factory.Contract
{
    public class HourlySalaryEmployee : Interfaces.Employee
    {
        private const int HOURS = 120;
        private const int MONTHS = 12;

        public override double CalculateSalary()
        {
            return HOURS * this.HourlySalary * MONTHS;
        }
    }
}
