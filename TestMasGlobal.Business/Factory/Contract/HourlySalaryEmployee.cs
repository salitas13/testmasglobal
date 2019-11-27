using TestMasGlobal.Model;

namespace TestMasGlobal.Business.Factory.Contract
{
    public class HourlySalaryEmployee : Interfaces.Employee
    {
        private const int HOURS = 120;
        private const int MONTHS = 12;

        public override void CalculateSalary()
        {
            this.AnnualSalary = HOURS * this.HourlySalary * MONTHS;
        }
    }
}
